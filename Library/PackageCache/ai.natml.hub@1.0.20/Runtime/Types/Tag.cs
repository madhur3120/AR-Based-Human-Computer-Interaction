/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub.Types {

    using System;

    /// <summary>
    /// Predictor tag.
    /// </summary>
    public sealed class Tag {

        #region --Client API--
        /// <summary>
        /// Username.
        /// </summary>
        public readonly string username;

        /// <summary>
        /// Name.
        /// </summary>
        public readonly string name;

        /// <summary>
        /// Variant.
        /// </summary>
        public readonly string variant;

        /// <summary>
        /// Default tag variant.
        /// </summary>
        public const string DefaultVariant = @"main";

        /// <summary>
        /// Create a tag.
        /// </summary>
        /// <param name="tag">Tag.</tag>
        public Tag (string tag) {
            // Check username prefix
            tag = tag.ToLowerInvariant();
            if (!tag.StartsWith("@"))
                throw new ArgumentException(@"Provided tag is not a valid NatML tag", nameof(tag));
            // Check stem
            var stem = tag.Split('/');
            var extendedName = stem[1].Split('@');
            if (stem.Length != 2)
                throw new ArgumentException(@"Provided tag is not a valid NatML tag", nameof(tag));
            // Parse
            this.username = stem[0].Substring(1);
            this.name = extendedName[0];
            this.variant = extendedName.Length > 1 ? extendedName[1] : null;
        }

        /// <summary>
        /// Serialize the tag.
        /// </summary>
        public override string ToString () => string.IsNullOrEmpty(variant) ? $"@{username}/{name}" : $"@{username}/{name}@{variant}";

        /// <summary>
        /// Try to parse a predictor tag from a string.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="tag">Output tag.</param>
        /// <returns>Whether the tag was successfully parsed.</returns>
        public static bool TryParse (string input, out Tag tag) {
            try {
                tag = new Tag(input);
                return true;
            } catch {
                tag = null;
                return false;
            }
        }

        public static implicit operator Tag (string tag) => new Tag(tag);

        public static implicit operator string (Tag tag) => tag.ToString();
        #endregion
    }
}