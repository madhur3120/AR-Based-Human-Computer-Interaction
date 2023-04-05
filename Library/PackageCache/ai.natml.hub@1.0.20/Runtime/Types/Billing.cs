/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using System;

    /// <summary>
    /// User billing info.
    /// </summary>
    [Serializable, Obsolete]
    public sealed class Billing {

        /// <summary>
        /// Billing plan.
        /// </summary>
        [Obsolete]
        public string plan;
    }
}