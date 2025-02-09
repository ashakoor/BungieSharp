﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BungieSharper.Entities.Destiny.Components.Profiles;

/// <summary>
/// The set of progression-related information that applies at a Profile-wide level for your Destiny experience. This differs from the Jimi Hendrix Experience because there's less guitars on fire. Yet. #spoileralert?
/// This will include information such as Checklist info.
/// </summary>
public class DestinyProfileProgressionComponent
{
    /// <summary>
    /// The set of checklists that can be examined on a profile-wide basis, keyed by the hash identifier of the Checklist (DestinyChecklistDefinition)
    /// For each checklist returned, its value is itself a Dictionary keyed by the checklist's hash identifier with the value being a boolean indicating if it's been discovered yet.
    /// </summary>
    [JsonPropertyName("checklists")]
    public Dictionary<uint, Dictionary<uint, bool>> Checklists { get; set; }

    /// <summary>Data related to your progress on the current season's artifact that is the same across characters.</summary>
    [JsonPropertyName("seasonalArtifact")]
    public Destiny.Artifacts.DestinyArtifactProfileScoped SeasonalArtifact { get; set; }
}

/// <summary>
/// This is an experimental set of data that Bungie considers to be "transitory" - information that may be useful for API users, but that is coming from a non-authoritative data source about information that could potentially change at a more frequent pace than Bungie.net will receive updates about it.
/// This information is provided exclusively for convenience should any of it be useful to users: we provide no guarantees to the accuracy or timeliness of data that comes from this source. Know that this data can potentially be out-of-date or even wrong entirely if the user disconnected from the game or suddenly changed their status before we can receive refreshed data.
/// </summary>
public class DestinyProfileTransitoryComponent
{
    /// <summary>If you have any members currently in your party, this is some (very) bare-bones information about those members.</summary>
    [JsonPropertyName("partyMembers")]
    public IEnumerable<Destiny.Components.Profiles.DestinyProfileTransitoryPartyMember> PartyMembers { get; set; }

    /// <summary>If you are in an activity, this is some transitory info about the activity currently being played.</summary>
    [JsonPropertyName("currentActivity")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryCurrentActivity CurrentActivity { get; set; }

    /// <summary>Information about whether and what might prevent you from joining this person on a fireteam.</summary>
    [JsonPropertyName("joinability")]
    public Destiny.Components.Profiles.DestinyProfileTransitoryJoinability Joinability { get; set; }

    /// <summary>Information about tracked entities.</summary>
    [JsonPropertyName("tracking")]
    public IEnumerable<Destiny.Components.Profiles.DestinyProfileTransitoryTrackingEntry> Tracking { get; set; }

    /// <summary>The hash identifier for the DestinyDestinationDefinition of the last location you were orbiting when in orbit.</summary>
    [JsonPropertyName("lastOrbitedDestinationHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? LastOrbitedDestinationHash { get; set; }
}

/// <summary>
/// This is some bare minimum information about a party member in a Fireteam. Unfortunately, without great computational expense on our side we can only get at the data contained here. I'd like to give you a character ID for example, but we don't have it. But we do have these three pieces of information. May they help you on your quest to show meaningful data about current Fireteams.
/// Notably, we don't and can't feasibly return info on characters. If you can, try to use just the data below for your UI and purposes. Only hit us with further queries if you absolutely must know the character ID of the currently playing character. Pretty please with sugar on top.
/// </summary>
public class DestinyProfileTransitoryPartyMember
{
    /// <summary>The Membership ID that matches the party member.</summary>
    [JsonPropertyName("membershipId")]
    public long MembershipId { get; set; }

    /// <summary>The identifier for the DestinyInventoryItemDefinition of the player's emblem.</summary>
    [JsonPropertyName("emblemHash")]
    public uint EmblemHash { get; set; }

    /// <summary>The player's last known display name.</summary>
    [JsonPropertyName("displayName")]
    public string DisplayName { get; set; }

    /// <summary>A Flags Enumeration value indicating the states that the player is in relevant to being on a fireteam.</summary>
    [JsonPropertyName("status")]
    public Destiny.DestinyPartyMemberStates Status { get; set; }
}

/// <summary>
/// If you are playing in an activity, this is some information about it.
/// Note that we cannot guarantee any of this resembles what ends up in the PGCR in any way. They are sourced by two entirely separate systems with their own logic, and the one we source this data from should be considered non-authoritative in comparison.
/// </summary>
public class DestinyProfileTransitoryCurrentActivity
{
    /// <summary>When the activity started.</summary>
    [JsonPropertyName("startTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? StartTime { get; set; }

    /// <summary>If you're still in it but it "ended" (like when folks are dancing around the loot after they beat a boss), this is when the activity ended.</summary>
    [JsonPropertyName("endTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? EndTime { get; set; }

    /// <summary>This is what our non-authoritative source thought the score was.</summary>
    [JsonPropertyName("score")]
    public float Score { get; set; }

    /// <summary>If you have human opponents, this is the highest opposing team's score.</summary>
    [JsonPropertyName("highestOpposingFactionScore")]
    public float HighestOpposingFactionScore { get; set; }

    /// <summary>This is how many human or poorly crafted aimbot opponents you have.</summary>
    [JsonPropertyName("numberOfOpponents")]
    public int NumberOfOpponents { get; set; }

    /// <summary>This is how many human or poorly crafted aimbots are on your team.</summary>
    [JsonPropertyName("numberOfPlayers")]
    public int NumberOfPlayers { get; set; }
}

/// <summary>
/// Some basic information about whether you can be joined, how many slots are left etc. Note that this can change quickly, so it may not actually be useful. But perhaps it will be in some use cases?
/// </summary>
public class DestinyProfileTransitoryJoinability
{
    /// <summary>The number of slots still available on this person's fireteam.</summary>
    [JsonPropertyName("openSlots")]
    public int OpenSlots { get; set; }

    /// <summary>Who the person is currently allowing invites from.</summary>
    [JsonPropertyName("privacySetting")]
    public Destiny.DestinyGamePrivacySetting PrivacySetting { get; set; }

    /// <summary>Reasons why a person can't join this person's fireteam.</summary>
    [JsonPropertyName("closedReasons")]
    public Destiny.DestinyJoinClosedReasons ClosedReasons { get; set; }
}

/// <summary>
/// This represents a single "thing" being tracked by the player.
/// This can point to many types of entities, but only a subset of them will actually have a valid hash identifier for whatever it is being pointed to.
/// It's up to you to interpret what it means when various combinations of these entries have values being tracked.
/// </summary>
public class DestinyProfileTransitoryTrackingEntry
{
    /// <summary>OPTIONAL - If this is tracking a DestinyLocationDefinition, this is the identifier for that location.</summary>
    [JsonPropertyName("locationHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? LocationHash { get; set; }

    /// <summary>OPTIONAL - If this is tracking the status of a DestinyInventoryItemDefinition, this is the identifier for that item.</summary>
    [JsonPropertyName("itemHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ItemHash { get; set; }

    /// <summary>OPTIONAL - If this is tracking the status of a DestinyObjectiveDefinition, this is the identifier for that objective.</summary>
    [JsonPropertyName("objectiveHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ObjectiveHash { get; set; }

    /// <summary>OPTIONAL - If this is tracking the status of a DestinyActivityDefinition, this is the identifier for that activity.</summary>
    [JsonPropertyName("activityHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? ActivityHash { get; set; }

    /// <summary>OPTIONAL - If this is tracking the status of a quest, this is the identifier for the DestinyInventoryItemDefinition that containst that questline data.</summary>
    [JsonPropertyName("questlineItemHash")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public uint? QuestlineItemHash { get; set; }

    /// <summary>
    /// OPTIONAL - I've got to level with you, I don't really know what this is. Is it when you started tracking it? Is it only populated for tracked items that have time limits?
    /// I don't know, but we can get at it - when I get time to actually test what it is, I'll update this. In the meantime, bask in the mysterious data.
    /// </summary>
    [JsonPropertyName("trackedDate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime? TrackedDate { get; set; }
}