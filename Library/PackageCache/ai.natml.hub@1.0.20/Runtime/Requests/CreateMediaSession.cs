/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Requests {

    using System;
    using Types;

    /// <summary>
    /// Create media session request.
    /// </summary>
    [Serializable]
    public sealed class CreateMediaSessionRequest : GraphRequest {

        #region --Types--
        /// <summary>
        /// Media session creation variables.
        /// </summary>
        [Serializable]
        public sealed class Variables {
            /// <summary>
            /// Media session creation input.
            /// </summary>
            public Input input;
        }

        /// <summary>
        /// Media session creation input.
        /// </summary>
        [Serializable]
        public sealed class Input {
            /// <summary>
            /// NatML product identifier.
            /// </summary>
            public string product;
            /// <summary>
            /// Product version.
            /// </summary>
            public string version;
            /// <summary>
            /// Device platform.
            /// </summary>
            public string platform;
            /// <summary>
            /// Application bundle identifier.
            /// </summary>
            public string bundle;
            /// <summary>
            /// Deprecated in Hub 1.0.16. Use `product` field instead.
            /// </summary>
            [Obsolete(@"Deprecated in Hub 1.0.16. Use `product` field instead.", false)]
            public string api;
        }
        #endregion


        #region --Client API--
        /// <summary>
        /// Request variables.
        /// </summary>
        public Variables variables;
        
        /// <summary>
        /// Create a media session.
        /// </summary>
        /// <param name="input">Request input.</param>
        public CreateMediaSessionRequest (Input input) : base(@"
            mutation ($input: CreateMediaSessionInput!) {
                createMediaSession (input: $input) {
                    id
                    platform
                    token
                }
            }
        ") => this.variables = new Variables { input = input };
        #endregion
    }

    /// <summary>
    /// Create media session response.
    /// </summary>
    [Serializable]
    public sealed class CreateMediaSessionResponse : GraphResponse {

        public ResponseData data;

        [Serializable]
        public sealed class ResponseData {
            public MediaSession createMediaSession;
        }
    }
}