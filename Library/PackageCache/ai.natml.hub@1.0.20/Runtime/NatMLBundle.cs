/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using System;

    /// <summary>
    /// Specify your app's bundle identifier that will be used to generate NatML sessions.
    /// This attribute is intended for use when the app identifier in Unity is different from the final
    /// app identifier at runtime, like when Unity is embedded within another app.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class NatMLBundleAttribute : Attribute {

        #region --Client API--
        /// <summary>
        /// App bundle identifier.
        /// </summary>
        public readonly string identifier;

        /// <summary>
        /// Specify an application bundle identifier.
        /// </summary>
        /// <param name="identifier">App bundle identifier.</param>
        public NatMLBundleAttribute (string identifier) => this.identifier = identifier;
        #endregion
    }
}