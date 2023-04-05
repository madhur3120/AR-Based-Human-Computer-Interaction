/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// CloudKit prediction session.
    /// </summary>
    [Serializable]
    public sealed class PredictionSession {

        /// <summary>
        /// Session ID.
        /// </summary>
        public string id;

        /// <summary>
        /// Prediction results.
        /// </summary>
        public Feature[] results;

        /// <summary>
        /// Prediction latency in milliseconds.
        /// </summary>
        public float latency;

        /// <summary>
        /// Prediction error.
        /// </summary>
        public string error;
    }
}