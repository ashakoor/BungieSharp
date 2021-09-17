﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Config
{
    /// <summary>
    /// DestinyManifest is the external-facing contract for just the properties needed by those calling the Destiny Platform.
    /// </summary>
    public class DestinyManifest
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("mobileAssetContentPath")]
        public string MobileAssetContentPath { get; set; }

        [JsonPropertyName("mobileGearAssetDataBases")]
        public IEnumerable<Destiny.Config.GearAssetDataBaseDefinition> MobileGearAssetDataBases { get; set; }

        [JsonPropertyName("mobileWorldContentPaths")]
        public Dictionary<string, string> MobileWorldContentPaths { get; set; }

        /// <summary>This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a path to the aggregated world definitions (warning: large file!)</summary>
        [JsonPropertyName("jsonWorldContentPaths")]
        public Dictionary<string, string> JsonWorldContentPaths { get; set; }

        /// <summary>This points to the generated JSON that contains all the Definitions. Each key is a locale. The value is a dictionary, where the key is a definition type by name, and the value is the path to the file for that definition. WARNING: This is unsafe and subject to change - do not depend on data in these files staying around long-term.</summary>
        [JsonPropertyName("jsonWorldComponentContentPaths")]
        public Dictionary<string, Dictionary<string, string>> JsonWorldComponentContentPaths { get; set; }

        [JsonPropertyName("mobileClanBannerDatabasePath")]
        public string MobileClanBannerDatabasePath { get; set; }

        [JsonPropertyName("mobileGearCDN")]
        public Dictionary<string, string> MobileGearCDN { get; set; }

        /// <summary>Information about the "Image Pyramid" for Destiny icons. Where possible, we create smaller versions of Destiny icons. These are found as subfolders under the location of the "original/full size" Destiny images, with the same file name and extension as the original image itself. (this lets us avoid sending largely redundant path info with every entity, at the expense of the smaller versions of the image being less discoverable)</summary>
        [JsonPropertyName("iconImagePyramidInfo")]
        public IEnumerable<Destiny.Config.ImagePyramidEntry> IconImagePyramidInfo { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(DestinyManifest))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyManifestJsonContext : JsonSerializerContext { }
#endif

    public class GearAssetDataBaseDefinition
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(GearAssetDataBaseDefinition))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class GearAssetDataBaseDefinitionJsonContext : JsonSerializerContext { }
#endif

    public class ImagePyramidEntry
    {
        /// <summary>The name of the subfolder where these images are located.</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>The factor by which the original image size has been reduced.</summary>
        [JsonPropertyName("factor")]
        public float Factor { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ImagePyramidEntry))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ImagePyramidEntryJsonContext : JsonSerializerContext { }
#endif
}