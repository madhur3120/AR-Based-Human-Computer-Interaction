/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// Edge predictor session.
    /// </summary>
    [Serializable]
    public class PredictorSession {

        /// <summary>
        /// Session ID.
        /// </summary>
        public string id;

        /// <summary>
        /// Predictor for which this session was created.
        /// </summary>
        public Predictor predictor;

        /// <summary>
        /// Session device platform.
        /// </summary>
        public string platform;

        /// <summary>
        /// Session graph.
        /// </summary>
        public string graph;

        /// <summary>
        /// Session graph format.
        /// </summary>
        public string format;

        /// <summary>
        /// Session flags.
        /// </summary>
        public int flags;

        /// <summary>
        /// Session graph fingerprint.
        /// </summary>
        public string fingerprint;

        /// <summary>
        /// Session secret.
        /// </summary>
        public string secret;
    }
}