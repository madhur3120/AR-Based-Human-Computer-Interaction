/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using UnityEngine;

    /// <summary>
    /// Device platform.
    /// </summary>
    public static class Platform {

        /// <summary>
        /// Android.
        /// </summary>
        public const string Android = @"ANDROID";

        /// <summary>
        /// iOS.
        /// </summary>
        public const string iOS = @"IOS";

        /// <summary>
        /// Linux.
        /// </summary>
        public const string Linux = @"LINUX";

        /// <summary>
        /// macOS.
        /// </summary>
        public const string macOS = @"MACOS";

        /// <summary>
        /// Browser or other Web platform.
        /// </summary>
        public const string Web = @"WEB";

        /// <summary>
        /// Windows.
        /// </summary>
        public const string Windows = @"WINDOWS";

        /// <summary>
        /// Get the NatML platform identifier for a given runtime platform.
        /// </summary>
        public static string ToNatML (this RuntimePlatform platform) => platform switch {
            RuntimePlatform.Android         => Platform.Android,
            RuntimePlatform.IPhonePlayer    => Platform.iOS,
            RuntimePlatform.LinuxEditor     => Platform.Linux,
            RuntimePlatform.LinuxPlayer     => Platform.Linux,
            RuntimePlatform.OSXEditor       => Platform.macOS,
            RuntimePlatform.OSXPlayer       => Platform.macOS,
            RuntimePlatform.WebGLPlayer     => Platform.Web,
            RuntimePlatform.WindowsEditor   => Platform.Windows,
            RuntimePlatform.WindowsPlayer   => Platform.Windows,
            _                               => null,
        };
    }
}