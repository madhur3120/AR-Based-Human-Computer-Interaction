/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using System;

    /// <summary>
    /// Graph format.
    /// </summary>
    public static class GraphFormat {

        /// <summary>
        /// Apple CoreML.
        /// </summary>
        public const string CoreML = @"COREML";

        /// <summary>
        /// Open Neural Network Exchange.
        /// </summary>
        public const string ONNX = @"ONNX";

        /// <summary>
        /// TensorFlow Lite.
        /// </summary>
        public const string TensorFlowLite = @"TFLITE";

        /// <summary>
        /// Get the graph format for a given platform.
        /// </summary>
        public static string FormatForPlatform (string platform) => platform switch {
            Platform.Android    => GraphFormat.TensorFlowLite,
            Platform.iOS        => GraphFormat.CoreML,
            Platform.macOS      => GraphFormat.CoreML,
            Platform.Web        => GraphFormat.ONNX,
            Platform.Windows    => GraphFormat.ONNX,
            _                   => null,
        };
    }
}