/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// CloudKit prediction feature.
    /// </summary>
    [Serializable]
    public class Feature {

        /// <summary>
        /// Feature data URL.
        /// </summary>
        public string data;

        /// <summary>
        /// Feature data type.
        /// </summary>
        public string type;

        /// <summary>
        /// Feature shape.
        /// </summary>
        public int[] shape;
    }

    /// <summary>
    /// CloudKit prediction input feature.
    /// </summary>
    [Serializable]
    public sealed class FeatureInput : Feature {

        /// <summary>
        /// Feature name.
        /// </summary>
        public string name;
    }
}