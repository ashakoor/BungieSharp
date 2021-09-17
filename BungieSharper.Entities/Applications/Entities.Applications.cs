﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Applications
{
    [Flags]
    public enum ApplicationScopes : long
    {
        /// <summary>Read basic user profile information such as the user's handle, avatar icon, etc.</summary>
        ReadBasicUserProfile = 1,

        /// <summary>Read Group/Clan Forums, Wall, and Members for groups and clans that the user has joined.</summary>
        ReadGroups = 2,

        /// <summary>Write Group/Clan Forums, Wall, and Members for groups and clans that the user has joined.</summary>
        WriteGroups = 4,

        /// <summary>Administer Group/Clan Forums, Wall, and Members for groups and clans that the user is a founder or an administrator.</summary>
        AdminGroups = 8,

        /// <summary>Create new groups, clans, and forum posts, along with other actions that are reserved for Bungie.net elevated scope: not meant to be used by third party applications.</summary>
        BnetWrite = 16,

        /// <summary>Move or equip Destiny items</summary>
        MoveEquipDestinyItems = 32,

        /// <summary>Read Destiny 1 Inventory and Vault contents. For Destiny 2, this scope is needed to read anything regarded as private. This is the only scope a Destiny 2 app needs for read operations against Destiny 2 data such as inventory, vault, currency, vendors, milestones, progression, etc.</summary>
        ReadDestinyInventoryAndVault = 64,

        /// <summary>Read user data such as who they are web notifications, clan/group memberships, recent activity, muted users.</summary>
        ReadUserData = 128,

        /// <summary>Edit user data such as preferred language, status, motto, avatar selection and theme.</summary>
        EditUserData = 256,

        /// <summary>Access vendor and advisor data specific to a user. OBSOLETE. This scope is only used on the Destiny 1 API.</summary>
        ReadDestinyVendorsAndAdvisors = 512,

        /// <summary>Read offer history and claim and apply tokens for the user.</summary>
        ReadAndApplyTokens = 1024,

        /// <summary>Can perform actions that will result in a prompt to the user via the Destiny app.</summary>
        AdvancedWriteActions = 2048,

        /// <summary>Can user the partner offer api to claim rewards defined for a partner</summary>
        PartnerOfferGrant = 4096,

        /// <summary>Allows an app to query sensitive information like unlock flags and values not available through normal methods.</summary>
        DestinyUnlockValueQuery = 8192,

        /// <summary>Allows an app to query sensitive user PII, most notably email information.</summary>
        UserPiiRead = 16384
    }

    public class ApiUsage
    {
        /// <summary>Counts for on API calls made for the time range.</summary>
        [JsonPropertyName("apiCalls")]
        public IEnumerable<Applications.Series> ApiCalls { get; set; }

        /// <summary>Instances of blocked requests or requests that crossed the warn threshold during the time range.</summary>
        [JsonPropertyName("throttledRequests")]
        public IEnumerable<Applications.Series> ThrottledRequests { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ApiUsage))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ApiUsageJsonContext : JsonSerializerContext { }
#endif

    public class Series
    {
        /// <summary>Collection of samples with time and value.</summary>
        [JsonPropertyName("datapoints")]
        public IEnumerable<Applications.Datapoint> Datapoints { get; set; }

        /// <summary>Target to which to datapoints apply.</summary>
        [JsonPropertyName("target")]
        public string Target { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(Series))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class SeriesJsonContext : JsonSerializerContext { }
#endif

    public class Datapoint
    {
        /// <summary>Timestamp for the related count.</summary>
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        /// <summary>Count associated with timestamp</summary>
        [JsonPropertyName("count")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Count { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(Datapoint))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class DatapointJsonContext : JsonSerializerContext { }
#endif

    public class Application
    {
        /// <summary>Unique ID assigned to the application</summary>
        [JsonPropertyName("applicationId")]
        public int ApplicationId { get; set; }

        /// <summary>Name of the application</summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>URL used to pass the user's authorization code to the application</summary>
        [JsonPropertyName("redirectUrl")]
        public string RedirectUrl { get; set; }

        /// <summary>Link to website for the application where a user can learn more about the app.</summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>Permissions the application needs to work</summary>
        [JsonPropertyName("scope")]
        public long Scope { get; set; }

        /// <summary>Value of the Origin header sent in requests generated by this application.</summary>
        [JsonPropertyName("origin")]
        public string Origin { get; set; }

        /// <summary>Current status of the application.</summary>
        [JsonPropertyName("status")]
        public Applications.ApplicationStatus Status { get; set; }

        /// <summary>Date the application was first added to our database.</summary>
        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        /// <summary>Date the application status last changed.</summary>
        [JsonPropertyName("statusChanged")]
        public DateTime StatusChanged { get; set; }

        /// <summary>Date the first time the application status entered the 'Public' status.</summary>
        [JsonPropertyName("firstPublished")]
        public DateTime FirstPublished { get; set; }

        /// <summary>List of team members who manage this application on Bungie.net. Will always consist of at least the application owner.</summary>
        [JsonPropertyName("team")]
        public IEnumerable<Applications.ApplicationDeveloper> Team { get; set; }

        /// <summary>An optional override for the Authorize view name.</summary>
        [JsonPropertyName("overrideAuthorizeViewName")]
        public string OverrideAuthorizeViewName { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(Application))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ApplicationJsonContext : JsonSerializerContext { }
#endif

    public enum ApplicationStatus : int
    {
        /// <summary>No value assigned</summary>
        None = 0,

        /// <summary>Application exists and works but will not appear in any public catalog. New applications start in this state, test applications will remain in this state.</summary>
        Private = 1,

        /// <summary>Active applications that can appear in an catalog.</summary>
        Public = 2,

        /// <summary>Application disabled by the owner. All authorizations will be treated as terminated while in this state. Owner can move back to private or public state.</summary>
        Disabled = 3,

        /// <summary>Application has been blocked by Bungie. It cannot be transitioned out of this state by the owner. Authorizations are terminated when an application is in this state.</summary>
        Blocked = 4
    }

    public class ApplicationDeveloper
    {
        [JsonPropertyName("role")]
        public Applications.DeveloperRole Role { get; set; }

        [JsonPropertyName("apiEulaVersion")]
        public int ApiEulaVersion { get; set; }

        [JsonPropertyName("user")]
        public User.UserInfoCard User { get; set; }
    }

#if NET6_0_OR_GREATER
    [JsonSerializable(typeof(ApplicationDeveloper))]
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
    internal partial class ApplicationDeveloperJsonContext : JsonSerializerContext { }
#endif

    public enum DeveloperRole : int
    {
        None = 0,
        Owner = 1,
        TeamMember = 2
    }
}