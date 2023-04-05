/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// Predictor endpoint.
    /// </summary>
    [Serializable]
    public sealed class Endpoint {

        /// <summary>
        /// Endpoint ID.
        /// </summary>
        public string id;

        /// <summary>
        /// Endpoint URL.
        /// </summary>
        public string url;

        /// <summary>
        /// Endpoint acceleration.
        /// </summary>
        public string acceleration;

        /// <summary>
        /// Endpoint status.
        /// </summary>
        public string status;

        /// <summary>
        /// Endpoint variant.
        /// </summary>
        public string variant;

        /// <summary>
        /// Endpoint signature.
        /// </summary>
        public EndpointSignature signature;
    }

    /// <summary>
    /// Endpoint status.
    /// </summary>
    public static class EndpointStatus {

        /// <summary>
        /// Endpoint is being provisioned.
        /// </summary>
        public const string Provisioning = @"PROVISIONING";

        /// <summary>
        /// Endpoint is active.
        /// </summary>
        public const string Active = @"ACTIVE";

        /// <summary>
        /// Endpoint is faulted.
        /// </summary>
        public const string Faulted = @"FAULTED";
    }

    /// <summary>
    /// Endpoint acceleration.
    /// </summary>
    public static class EndpointAcceleration {

        /// <summary>
        /// Endpoint is run on serverless infrastructure.
        /// </summary>
        public const string Serverless = @"SERVERLESS";
    }

    /// <summary>
    /// Endpoint signature.
    /// </summary>
    [Serializable]
    public sealed class EndpointSignature {
        
        /// <summary>
        /// Input parameters.
        /// </summary>
        public EndpointParameter[] inputs;

        /// <summary>
        /// Output parameters.
        /// </summary>
        public EndpointParameter[] outputs;
    }

    /// <summary>
    /// Endpoint parameter.
    /// </summary>
    [Serializable]
    public sealed class EndpointParameter {

        /// <summary>
        /// Parameter name.
        /// </summary>
        public string name;

        /// <summary>
        /// Parameter type.
        /// This is `null` if the type is unknown or unsupported by NatML.
        /// </summary>
        public string type;

        /// <summary>
        /// Parameter description.
        /// </summary>
        public string description;

        /// <summary>
        /// Parameter is optional.
        /// </summary>
        public bool optional;
        
        /// <summary>
        /// Parameter value range for numeric parameters.
        /// </summary>
        public float[] range;

        /// <summary>
        /// Parameter default string value.
        /// </summary>
        public string stringDefault;

        /// <summary>
        /// Parameter default float value.
        /// </summary>
        public float floatDefault;

        /// <summary>
        /// Parameter default integer value.
        /// </summary>
        public int intDefault;

        /// <summary>
        /// Parameter default boolean value.
        /// </summary>
        public bool boolDefault;
    }
}