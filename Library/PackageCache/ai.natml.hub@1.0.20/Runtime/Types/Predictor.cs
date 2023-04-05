/* 
*   NatML Hub
*   Copyright © 2023 NatML Inc. All rights reserved.
*/

namespace NatML.Hub {

    using System;
    using Types;

    /// <summary>
    /// ML predictor.
    /// </summary>
    [Serializable]
    public sealed class Predictor {

        /// <summary>
        /// Predictor tag.
        /// </summary>
        public string tag;

        /// <summary>
        /// Predictor name.
        /// </summary>
        public string name;

        /// <summary>
        /// Predictor description.
        /// </summary>
        public string description;

        /// <summary>
        /// Predictor status.
        /// </summary>
        public string status;
        
        /// <summary>
        /// Predictor access.
        /// </summary>
        public string access;

        /// <summary>
        /// Predictor graphs.
        /// </summary>
        public Graph[] graphs;

        /// <summary>
        /// Predictor endpoints.
        /// </summary>
        public Endpoint[] endpoints;

        /// <summary>
        /// Predictor license.
        /// </summary>
        public string license;

        /// <summary>
        /// Predictor media.
        /// </summary>
        public string media;

        /// <summary>
        /// Classification labels.
        /// </summary>
        public string[] labels;

        /// <summary>
        /// Feature normalization.
        /// </summary>
        public Normalization normalization;

        /// <summary>
        /// Image aspect mode.
        /// </summary>
        public string aspectMode;

        /// <summary>
        /// Audio format.
        /// </summary>
        public AudioFormat audioFormat;
    }

    /// <summary>
    /// Predictor status.
    /// </summary>
    public static class PredictorStatus {

        /// <summary>
        /// Predictor is a draft.
        /// Predictor can only be viewed and used by author.
        /// </summary>
        public const string Draft = @"DRAFT";

        /// <summary>
        /// Predictor is pending review.
        /// Predictor can only be viewed and used by author.
        /// </summary>
        [Obsolete(@"Deprecated in Hub 1.0.16.", false)]
        public const string Pending = @"PENDING";

        /// <summary>
        /// Predictor is in review.
        /// Predictor can be viewed and used by owner or NatML predictor review team.
        /// </summary>
        [Obsolete(@"Deprecated in Hub 1.0.16.", false)]
        public const string Review = @"REVIEW";

        /// <summary>
        /// Predictor has been published.
        /// Predictor viewing and fetching permissions are dictated by the access mode.
        /// </summary>
        public const string Published = @"PUBLISHED";

        /// <summary>
        /// Predictor is archived.
        /// Predictor can be viewed but cannot be used by anyone including owner.
        /// </summary>
        public const string Archived = @"ARCHIVED";
    }

    /// <summary>
    /// Audio format.
    /// </summary>
    [Serializable]
    public sealed class AudioFormat {

        /// <summary>
        /// Audio sample rate.
        /// </summary>
        public int sampleRate;

        /// <summary>
        /// Audio channel count.
        /// </summary>
        public int channelCount;
    }

    /// <summary>
    /// Feature normalization.
    /// </summary>
    [Serializable]
    public sealed class Normalization {

        /// <summary>
        /// Mean.
        /// </summary>
        public float[] mean;

        /// <summary>
        /// Standard deviation.
        /// </summary>
        public float[] std;
    }
}