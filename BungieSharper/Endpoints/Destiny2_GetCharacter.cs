﻿using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
<<<<<<< HEAD
=======
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns character information for the supplied character.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Destiny.Responses.DestinyCharacterResponse> Destiny2_GetCharacter(long characterId, long destinyMembershipId, Schema.BungieMembershipType membershipType, IEnumerable<Schema.Destiny.DestinyComponentType> components = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.Responses.DestinyCharacterResponse>(
=======
        /// <param name="characterId">ID of the character.</param>
        /// <param name="components">A comma separated list of components to return (as strings or numeric values). See the DestinyComponentType enum for valid components to request. You must request at least one component to receive results.</param>
        /// <param name="destinyMembershipId">Destiny membership ID.</param>
        /// <param name="membershipType">A valid non-BungieNet membership type.</param>
        public async Task<Entities.Destiny.Responses.DestinyCharacterResponse> Destiny2_GetCharacter(long characterId, long destinyMembershipId, Entities.BungieMembershipType membershipType, IEnumerable<Entities.Destiny.DestinyComponentType>? components = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.Responses.DestinyCharacterResponse>(
>>>>>>> rewrite
                new Uri($"Destiny2/{membershipType}/Profile/{destinyMembershipId}/Character/{characterId}/" + HttpRequestGenerator.MakeQuerystring(components != null ? $"components={string.Join(",", components.Select(x => x.ToString()))}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}