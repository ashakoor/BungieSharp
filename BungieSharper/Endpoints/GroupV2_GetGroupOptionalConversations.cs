﻿using BungieSharper.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a list of available optional conversation channels and their settings.
        /// </summary>
        public async Task<IEnumerable<Schema.GroupsV2.GroupOptionalConversation>> GroupV2_GetGroupOptionalConversations(long groupId)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.GroupsV2.GroupOptionalConversation>>(
                new Uri($"GroupV2/{groupId}/OptionalConversations/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}