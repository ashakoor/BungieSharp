﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.StringVariables
{
    public class DestinyStringVariablesComponent
    {
        [JsonPropertyName("integerValuesByHash")]
        public Dictionary<uint, int> IntegerValuesByHash { get; set; }
    }

    [JsonSerializable(typeof(DestinyStringVariablesComponent))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyStringVariablesComponentJsonContext : JsonSerializerContext { }
}