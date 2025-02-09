﻿using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Twitch Drops self-repair function - scans twitch for drops not marked as fulfilled and resyncs them.
    /// Requires OAuth2 scope(s): PartnerOfferGrant
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<bool> Tokens_ForceDropsRepair(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("Tokens/Partner/ForceDropsRepair/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseBoolean,
            null, HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Claim a partner offer as the authenticated user.
    /// Requires OAuth2 scope(s): PartnerOfferGrant
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<bool> Tokens_ClaimPartnerOffer(Entities.Tokens.PartnerOfferClaimRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("Tokens/Partner/ClaimOffer/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseBoolean,
            new StringContent(JsonSerializer.Serialize(requestBody, _apiAccessor.JsonContext.PartnerOfferClaimRequest), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Apply a partner offer to the targeted user. This endpoint does not claim a new offer, but any already claimed offers will be applied to the game if not already.
    /// Requires OAuth2 scope(s): PartnerOfferGrant
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<bool> Tokens_ApplyMissingPartnerOffersWithoutClaim(int partnerApplicationId, long targetBnetMembershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Tokens/Partner/ApplyMissingOffers/{partnerApplicationId}/{targetBnetMembershipId}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseBoolean,
            null, HttpMethod.Post, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the partner sku and offer history of the targeted user. Elevated permissions are required to see users that are not yourself.
    /// Requires OAuth2 scope(s): PartnerOfferGrant
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to apply missing offers to. If not self, elevated permissions are required.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<IEnumerable<Entities.Tokens.PartnerOfferSkuHistoryResponse>> Tokens_GetPartnerOfferSkuHistory(int partnerApplicationId, long targetBnetMembershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Tokens/Partner/History/{partnerApplicationId}/{targetBnetMembershipId}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseIEnumerablePartnerOfferSkuHistoryResponse,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the partner rewards history of the targeted user, both partner offers and Twitch drops.
    /// Requires OAuth2 scope(s): PartnerOfferGrant
    /// </summary>
    /// <param name="partnerApplicationId">The partner application identifier.</param>
    /// <param name="targetBnetMembershipId">The bungie.net user to return reward history for.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Tokens.PartnerRewardHistoryResponse> Tokens_GetPartnerRewardHistory(int partnerApplicationId, long targetBnetMembershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Tokens/Partner/History/{targetBnetMembershipId}/Application/{partnerApplicationId}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponsePartnerRewardHistoryResponse,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the bungie rewards for the targeted user.
    /// Requires OAuth2 scope(s): ReadAndApplyTokens
    /// </summary>
    /// <param name="membershipId">bungie.net user membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Entities.Tokens.BungieRewardDisplay>> Tokens_GetBungieRewardsForUser(long membershipId, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Tokens/Rewards/GetRewardsForUser/{membershipId}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseDictionaryStringBungieRewardDisplay,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the bungie rewards for the targeted user when a platform membership Id and Type are used.
    /// Requires OAuth2 scope(s): ReadAndApplyTokens
    /// </summary>
    /// <param name="membershipId">users platform membershipId for requested user rewards. If not self, elevated permissions are required.</param>
    /// <param name="membershipType">The target Destiny 2 membership type.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Entities.Tokens.BungieRewardDisplay>> Tokens_GetBungieRewardsForPlatformUser(long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Tokens/Rewards/GetRewardsForPlatformUser/{membershipId}/{membershipType}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseDictionaryStringBungieRewardDisplay,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns a list of the current bungie rewards
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Dictionary<string, Entities.Tokens.BungieRewardDisplay>> Tokens_GetBungieRewardsList(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("Tokens/Rewards/BungieRewards/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseDictionaryStringBungieRewardDisplay,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}