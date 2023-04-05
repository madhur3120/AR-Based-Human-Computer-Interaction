/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Requests {

    using System;
    using Types;
    
    /// <summary>
    /// Create a prediction session.
    /// </summary>
    [Serializable]
    public sealed class CreatePredictionSessionRequest : GraphRequest {

        #region --Types--
        /// <summary>
        /// Prediction session creation variables.
        /// </summary>
        [Serializable]
        public sealed class Variables {
            /// <summary>
            /// Prediction session creation input.
            /// </summary>
            public Input input;
        }

        /// <summary>
        /// Prediction session creation input.
        /// </summary>
        [Serializable]
        public sealed class Input {
            /// <summary>
            /// Predictor tag.
            /// </summary>
            public string tag;
            /// <summary>
            /// Input features.
            /// </summary>
            public FeatureInput[] inputs;
        }
        #endregion


        #region --Client API--
        /// <summary>
        /// Request variables.
        /// </summary>
        public Variables variables;

        /// <summary>
        /// Create a prediction session.
        /// </summary>
        /// <param name="input">Request input.</param>
        public CreatePredictionSessionRequest (Input input) : base(@"
            mutation ($input: CreatePredictionSessionInput!) {
                createPredictionSession (input: $input) {
                    id
                    created
                    results {
                        data
                        type
                        shape
                    }
                    latency
                    error
                }
            }
        ") => this.variables = new Variables { input = input };
        #endregion
    }

    [Serializable]
    public sealed class CreatePredictionSessionResponse : GraphResponse {

        public ResponseData data;

        [Serializable]
        public sealed class ResponseData {
            public PredictionSession createPredictionSession;
        }
    }
}