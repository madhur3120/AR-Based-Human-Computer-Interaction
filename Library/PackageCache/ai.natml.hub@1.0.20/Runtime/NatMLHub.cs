/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

//#define NATML_HUB_STAGING

namespace NatML.Hub {

    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using UnityEngine;
    using UnityEngine.Networking;
    using Requests;
    using Types;

    /// <summary>
    /// NatML API.
    /// </summary>
    public static class NatMLHub {

        #region --Constants--
        /// <summary>
        /// NatML API URL.
        /// </summary>
        public const string URL =
        #if NATML_HUB_STAGING
        @"https://staging.api.natml.ai/graph";
        #else
        @"https://api.natml.ai/graph";
        #endif
        #endregion


        #region --Bundle--
        /// <summary>
        /// Current platform identifier.
        /// </summary>
        public static string CurrentPlatform => Application.platform.ToNatML();

        /// <summary>
        /// Get the current application bundle identifier.
        /// </summary>
        /// <param name="platform">NatML platform identifier.</param>
        /// <returns>Application bundle identifier.</returns>
        public static string GetAppBundle (string platform = null) => (platform ?? CurrentPlatform) switch {
            Platform.Web        => Regex.Replace($"com.{Application.companyName}.{Application.productName}", "[^A-Z,a-z,0-9,-,.]", "-"),
            Platform.Windows    => @"com.defaultcompany.winapp",
            _                   => Application.identifier,
        };

        /// <summary>
        /// Get the current editor bundle identifier.
        /// </summary>
        /// <param name="platform">NatML platform identifier.</param>
        /// <returns>Editor bundle identifier.</returns>
        public static string GetEditorBundle (string platform = null) => (platform ?? CurrentPlatform) switch {
            Platform.macOS      => @"com.unity3d.UnityEditor5.x",
            Platform.Windows    => @"com.defaultcompany.winapp",
            _                   => default,
        };
        #endregion


        #region --Mutations--
        /// <summary>
        /// Get a NatML user.
        /// </summary>
        /// <param name="accessKey">NatML access key.</param>
        /// <returns>NatML user.</returns>
        public static async Task<User> GetUser (string accessKey) {
            var request = new GetUserRequest();
            var response = await Request<GetUserRequest, GetUserResponse>(request, accessKey);
            var result = response.data.user;
            return !string.IsNullOrEmpty(result.email) ? result : null;
        }

        /// <summary>
        /// Get a predictor.
        /// </summary>
        /// <param name="tag">Predictor tag.</param>
        /// <param name="accessKey">NatML access key.</param>
        /// <returns>Predictor.</returns>
        public static async Task<Predictor> GetPredictor (string tag, string accessKey) {
            var input = new GetPredictorRequest.Input { tag = tag };
            var request = new GetPredictorRequest(input);
            var response = await Request<GetPredictorRequest, GetPredictorResponse>(request, accessKey);
            var result = response.data.predictor;
            return !string.IsNullOrEmpty(result.tag) ? result : null;
        }

        /// <summary>
        /// Create a predictor session.
        /// </summary>
        /// <param name="input">Predictor session input.</param>
        /// <param name="accessKey">NatML access key.</param>
        /// <returns>Predictor session.</returns>
        public static async Task<PredictorSession> CreatePredictorSession (CreatePredictorSessionRequest.Input input, string accessKey) {
            var request = new CreatePredictorSessionRequest(input);
            var response = await Request<CreatePredictorSessionRequest, CreatePredictorSessionResponse>(request, accessKey);
            var result = response.data.createPredictorSession;
            return !string.IsNullOrEmpty(result.id) ? result : null;
        }

        /// <summary>
        /// Create a media session.
        /// </summary>
        /// <param name="input">Media session input.</param>
        /// <param name="accessKey">NatML access key.</param>
        /// <returns>Media session.</returns>
        public static async Task<MediaSession> CreateMediaSession (CreateMediaSessionRequest.Input input, string accessKey) {
            input.product = string.IsNullOrEmpty(input.product) ? input.api : input.product;
            var request = new CreateMediaSessionRequest(input);
            var response = await Request<CreateMediaSessionRequest, CreateMediaSessionResponse>(request, accessKey);
            var result = response.data.createMediaSession;
            return !string.IsNullOrEmpty(result.id) ? result : null;
        }

        /// <summary>
        /// Create a prediction session.
        /// </summary>
        /// <param name="input">Prediction session input.</param>
        /// <param name="accessKey">NatML access key.</param>
        /// <returns>Prediction session.</returns>
        public static async Task<PredictionSession> CreatePredictionSession (CreatePredictionSessionRequest.Input input, string accessKey) {
            var request = new CreatePredictionSessionRequest(input);
            var response = await Request<CreatePredictionSessionRequest, CreatePredictionSessionResponse>(request, accessKey);
            var result = response.data.createPredictionSession;
            return !string.IsNullOrEmpty(result.id) ? result : null;
        }

        /// <summary>
        /// Request an upload URL.
        /// </summary>
        /// <param name="name">File name.</param>
        /// <param name="type">Upload type.</param>
        /// <returns>Pre-signed upload URL.</returns>
        public static async Task<string> GetUploadURL (string name, string type) {
            var input = new GetUploadURLRequest.Input { type = type, name = name };
            var request = new GetUploadURLRequest(input);
            var response = await Request<GetUploadURLRequest, GetUploadURLResponse>(request);
            return response.data.uploadURL;
        }
        #endregion


        #region --Requests---
        /// <summary>
        /// Send a request to the NatML Graph API.
        /// </summary>
        /// <typeparam name="TRequest">NatML API request.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="accessKey">Access key for requests that require authentication.</param>
        public static async Task Request<TRequest> (
            TRequest request,
            string accessKey = null
        ) where TRequest : GraphRequest => await Request<TRequest, GraphResponse>(request, accessKey);

        /// <summary>
        /// Send a request to the NatML Graph API.
        /// </summary>
        /// <typeparam name="TRequest">NatML API request.</typeparam>
        /// <typeparam name="TResponse">NatML API response.</typeparam>
        /// <param name="request">Request.</param>
        /// <param name="accessKey">Access key for requests that require authentication.</param>
        /// <returns>Response.</returns>
        public static Task<TResponse> Request<TRequest, TResponse> (
            TRequest request,
            string accessKey = null
        ) where TRequest : GraphRequest where TResponse : GraphResponse {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
                return RequestUnityWebRequest<TRequest, TResponse>(request, accessKey);
            else
                return RequestNet<TRequest, TResponse>(request, accessKey);
        }
        #endregion


        #region --Operations--

        private static async Task<TResponse> RequestNet<TRequest, TResponse> (
            TRequest request,
            string accessKey = null
        ) where TRequest : GraphRequest where TResponse : GraphResponse {
            var payload = JsonUtility.ToJson(request);
            using var client = new HttpClient();
            using var content = new StringContent(payload, Encoding.UTF8, @"application/json");
            // Add auth token
            var authHeader = !string.IsNullOrEmpty(accessKey) ? new AuthenticationHeaderValue(@"Bearer", accessKey) : null;
            client.DefaultRequestHeaders.Authorization = authHeader;
            // Post
            using var response = await client.PostAsync(URL, content);
            // Parse
            var responseStr = await response.Content.ReadAsStringAsync();
            var responsePayload = JsonUtility.FromJson<TResponse>(responseStr);
            // Return
            if (responsePayload.errors == null)
                return responsePayload;
            else
                throw new InvalidOperationException(responsePayload.errors[0].message);
        }

        private static async Task<TResponse> RequestUnityWebRequest<TRequest, TResponse> (
            TRequest request,
            string accessKey = null
        ) where TRequest : GraphRequest where TResponse : GraphResponse {
            var payload = JsonUtility.ToJson(request);
            using var client = new UnityWebRequest(URL, UnityWebRequest.kHttpVerbPOST) {
                uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(payload)),
                downloadHandler = new DownloadHandlerBuffer(),
                disposeDownloadHandlerOnDispose = true,
                disposeUploadHandlerOnDispose = true,
            };
            client.SetRequestHeader(@"Content-Type",  @"application/json");
            if (!string.IsNullOrEmpty(accessKey))
                client.SetRequestHeader("Authorization", $"Bearer {accessKey}");
            client.SendWebRequest();
            while (!client.isDone)
                await Task.Yield();
            var responseStr = client.downloadHandler.text;
            var response = JsonUtility.FromJson<TResponse>(responseStr);
            if (response.errors == null)
                return response;
            else
                throw new InvalidOperationException(response.errors[0].message);
        }
        #endregion


        #region --DEPRECATED--

        private static string BundleOverride => Application.platform switch {
            RuntimePlatform.WebGLPlayer     => Regex.Replace($"com.{Application.companyName}.{Application.productName}", "[^A-Z,a-z,0-9,-,.]", "-"),
            RuntimePlatform.WindowsPlayer   => @"com.defaultcompany.winapp",
            _                               => null,
        };

        [Obsolete(@"Deprecated in Hub 1.0.13. Use `GetAppBundle` instead.", false)]
        public static string Bundle => BundleOverride ?? Application.identifier;

        [Obsolete(@"Deprecated in Hub 1.0.13. Use `GetEditorBundle` instead.", false)]
        public static string EditorBundle   => Application.platform switch {
            RuntimePlatform.OSXEditor       => @"com.unity3d.UnityEditor5.x",
            RuntimePlatform.WindowsEditor   => @"com.defaultcompany.winapp",
            _                               => null
        };
        
        [Obsolete(@"Deprecated in Hub 1.0.13. Use `CreatePredictorSession` instead.", false)]
        public static async Task<Session> CreateSession (CreateSessionRequest.Input input, string accessKey) {
            var request = new CreateSessionRequest(input);
            var response = await Request<CreateSessionRequest, CreateSessionResponse>(request, accessKey);
            return response.data.createSession;
        }

        [Obsolete(@"Deprecated in Hub 1.0.13. Use `CreateMediaSession` instead.", false)]
        public static async Task<string> CreateAppToken (CreateAppTokenRequest.Input input, string accessKey) {
            var request = new CreateAppTokenRequest(input);
            var response = await Request<CreateAppTokenRequest, CreateAppTokenResponse>(request, accessKey);
            return response.data.createAppToken;
        }

        [Obsolete(@"Deprecated in Hub 1.0.13. Use `GraphFormat.FormatForPlatform` instead.", false)]
        public static string FormatForPlatform (string platform) => GraphFormat.FormatForPlatform(platform);
        #endregion
    }
}