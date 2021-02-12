﻿using BungieSharper.Client;
using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq;
>>>>>>> rewrite
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Equip a list of items by itemInstanceIds. You must have a valid Destiny Account, and either be in a social space, in orbit, or offline. Any items not found on your character will be ignored.
<<<<<<< HEAD
        /// </summary>
        public async Task<Schema.Destiny.DestinyEquipItemResults> Destiny2_EquipItems(Schema.Destiny.Requests.Actions.DestinyItemSetActionRequest requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Destiny.DestinyEquipItemResults>(
=======
        /// Requires OAuth2 scope(s): MoveEquipDestinyItems
        /// </summary>
        public async Task<Entities.Destiny.DestinyEquipItemResults> Destiny2_EquipItems(Entities.Destiny.Requests.Actions.DestinyItemSetActionRequest requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Destiny.DestinyEquipItemResults>(
>>>>>>> rewrite
                new Uri($"Destiny2/Actions/Items/EquipItems/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}