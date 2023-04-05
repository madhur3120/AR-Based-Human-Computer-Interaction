/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using System;
    using Types;

    [Serializable, Obsolete(@"Deprecated in Hub 1.0.13. Use `PredictorSession` instead.")]
    public sealed class Session : PredictorSession { }

    [Obsolete]
    public static class Framework {
        public static string Unity = @"UNITY";
    }
}