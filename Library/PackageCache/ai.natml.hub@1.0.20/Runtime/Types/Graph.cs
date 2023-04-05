/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// Predictor graph.
    /// </summary>
    [Serializable]
    public sealed class Graph {

        /// <summary>
        /// Graph ID.
        /// </summary>
        public string id;

        /// <summary>
        /// Graph format.
        /// </summary>
        public string format;

        /// <summary>
        /// Graph status.
        /// </summary>
        public string status;

        /// <summary>
        /// Graph variant.
        /// </summary>
        public string variant;

        /// <summary>
        /// Whether the graph is encrypted.
        /// </summary>
        public bool encrypted;
    }

    /// <summary>
    /// Graph status.
    /// </summary>
    public static class GraphStatus {

        /// <summary>
        /// Graph is being provisioned.
        /// </summary>
        public const string Provisioning = @"PROVISIONING";

        /// <summary>
        /// Graph is active.
        /// </summary>
        public const string Active = @"ACTIVE";

        /// <summary>
        /// Graph is invalid.
        /// </summary>
        public const string Invalid = @"INVALID";
    }
}