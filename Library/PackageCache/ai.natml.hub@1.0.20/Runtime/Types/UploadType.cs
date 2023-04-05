/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    /// <summary>
    /// Upload URL type.
    /// </summary>
    public static class UploadType {

        /// <summary>
        /// Feature data.
        /// </summary>
        public const string Feature = @"FEATURE";

        /// <summary>
        /// Predictor graph.
        /// </summary>
        public const string Graph = @"GRAPH";

        /// <summary>
        /// Predictor media.
        /// </summary>
        public const string Media = @"MEDIA";

        /// <summary>
        /// Predictor notebook.
        /// </summary>
        public const string Notebook = @"NOTEBOOK";
    }
}