/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// Media session.
    /// </summary>
    [Serializable]
    public sealed class MediaSession {

        /// <summary>
        /// Session ID.
        /// </summary>
        public string id;

        /// <summary>
        /// Session device platform.
        /// </summary>
        public string platform;

        /// <summary>
        /// Media session token.
        /// </summary>
        public string token;
    }
}