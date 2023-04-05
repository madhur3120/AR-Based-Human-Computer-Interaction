/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Requests {

    using System;

    [Serializable]
    public sealed class GetPredictorRequest : GraphRequest {

        public Variables variables;

        public GetPredictorRequest (Input input) : base(@"
            query ($input: PredictorInput!) {
                predictor (input: $input) {
                    tag
                    name
                    description
                    status
                    access
                    graphs {
                        id
                        format
                        status
                        variant
                        encrypted
                    }
                    endpoints {
                        id
                        url
                        acceleration
                        status
                        variant
                        signature {
                            inputs {
                                name
                                type
                                description
                                optional
                                range
                                stringDefault
                                floatDefault
                                intDefault
                                boolDefault
                            }
                            outputs {
                                name
                                type
                                description
                                optional
                                range
                                stringDefault
                                floatDefault
                                intDefault
                                boolDefault
                            }
                        }
                    }
                }
            }
        ") => this.variables = new Variables { input = input };

        [Serializable]
        public sealed class Variables {
            public Input input;
        }

        [Serializable]
        public sealed class Input {
            public string tag;
        }
    }

    [Serializable]
    public sealed class GetPredictorResponse : GraphResponse {

        public ResponseData data;

        [Serializable]
        public sealed class ResponseData {
            public Predictor predictor;
        }
    }
}