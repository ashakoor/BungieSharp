﻿using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Requests
{
    public class DestinyItemTransferRequest
    {
        [JsonPropertyName("itemReferenceHash")]
        public uint ItemReferenceHash { get; set; }

        [JsonPropertyName("stackSize")]
        public int StackSize { get; set; }

        [JsonPropertyName("transferToVault")]
        public bool TransferToVault { get; set; }

        /// <summary>The instance ID of the item for this action request.</summary>
        [JsonPropertyName("itemId")]
        public long ItemId { get; set; }

        [JsonPropertyName("characterId")]
        public long CharacterId { get; set; }

        [JsonPropertyName("membershipType")]
        public BungieMembershipType MembershipType { get; set; }
    }

    [JsonSerializable(typeof(DestinyItemTransferRequest))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DestinyItemTransferRequestJsonContext : JsonSerializerContext { }
}