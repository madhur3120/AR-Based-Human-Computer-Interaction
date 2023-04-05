/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using System;

    /// <summary>
    /// NatML user.
    /// </summary>
    [Serializable]
    public sealed class User {

        /// <summary>
        /// Email address.
        /// </summary>
        public string email;

        /// <summary>
        /// Username.
        /// </summary>
        public string username;

        /// <summary>
        /// Billing info.
        /// </summary>
        [Obsolete]
        public Billing billing;
    }
}