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
        /// Search for Groups.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.GroupsV2.GroupSearchResponse> GroupV2_GroupSearch(Schema.GroupsV2.GroupQuery requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.GroupsV2.GroupSearchResponse>(
=======
        public async Task<Entities.GroupsV2.GroupSearchResponse> GroupV2_GroupSearch(Entities.GroupsV2.GroupQuery requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.GroupsV2.GroupSearchResponse>(
>>>>>>> rewrite
                new Uri($"GroupV2/Search/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}