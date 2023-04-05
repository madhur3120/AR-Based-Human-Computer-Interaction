/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Requests {

    using System;
    using Types;

    /// <summary>
    /// Create predictor session request.
    /// </summary>
    [Serializable]
    public sealed class CreatePredictorSessionRequest : GraphRequest {

        #region --Types--
        /// <summary>
        /// Predictor session creation variables.
        /// </summary>
        [Serializable]
        public sealed class Variables {
            /// <summary>
            /// Predictor session creation input.
            /// </summary>
            public Input input;
        }

        /// <summary>
        /// Predictor session creation input.
        /// </summary>
        [Serializable]
        public sealed class Input {
            /// <summary>
            /// Predictor tag.
            /// </summary>
            public string tag;
            /// <summary>
            /// Device platform.
            /// </summary>
            public string platform;
            /// <summary>
            /// Application bundle identifier.
            /// </summary>
            public string bundle;
            /// <summary>
            /// Preferred graph format for session predictor.
            /// </summary>
            public string format;
            /// <summary>
            /// Device model.
            /// </summary>
            public string device;
            /// <summary>
            /// Graph secret.
            /// This is required for encrypted graphs.
            /// </summary>
            public string secret;
        }
        #endregion
        

        #region --Client API--
        /// <summary>
        /// Request variables.
        /// </summary>
        public Variables variables;

        /// <summary>
        /// Create a predictor session.
        /// </summary>
        /// <param name="input">Request input.</param>
        public CreatePredictorSessionRequest (Input input) : base(@"
            mutation ($input: CreatePredictorSessionInput!) {
                createPredictorSession (input: $input) {
                    id
                    predictor {
                        tag
                        name
                        status
                        labels
                        normalization {
                            mean
                            std
                        }
                        aspectMode
                        audioFormat {
                            sampleRate
                            channelCount
                        }
                    }
                    platform
                    graph
                    format
                    flags
                    secret
                }
            }
        ") => this.variables = new Variables { input = input };
        #endregion
    }

    /// <summary>
    /// Create prediction session response.
    /// </summary>
    [Serializable]
    public sealed class CreatePredictorSessionResponse : GraphResponse {

        #region --Types--
        /// <summary>
        /// Response data.
        /// </summary>
        [Serializable]
        public sealed class ResponseData {

            /// <summary>
            /// Predictor session.
            /// </summary>
            public PredictorSession createPredictorSession;
        }
        #endregion


        #region --Client API--
        /// <summary>
        /// Response data.
        /// </summary>
        public ResponseData data;
        #endregion
    }
}