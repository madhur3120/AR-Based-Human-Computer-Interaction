/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Requests {

    using System;

    [Serializable, Obsolete(@"Deprecated in Hub 1.0.13. Use `CreateMediaSessionRequest` instead.", false)]
    public sealed class CreateAppTokenRequest : GraphRequest {

        public Variables variables;

        public CreateAppTokenRequest (Input input) : base(@"
            mutation ($input: CreateAppTokenInput!) {
                createAppToken (input: $input)
            }
        ") => this.variables = new Variables { input = input };

        [Serializable]
        public sealed class Variables {
            public Input input;
        }

        [Serializable]
        public sealed class Input {
            public string api;
            public string version;
            public string platform;
            public string bundle;
        }
    }

    [Serializable, Obsolete(@"Deprecated in Hub 1.0.13. Use `CreateMediaSessionResponse` instead.", false)]
    public sealed class CreateAppTokenResponse : GraphResponse {

        public ResponseData data;

        [Serializable]
        public sealed class ResponseData {
            public string createAppToken;
        }
    }
}