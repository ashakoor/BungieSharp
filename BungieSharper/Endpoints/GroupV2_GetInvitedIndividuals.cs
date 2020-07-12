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
        /// Get the list of users who have been invited into the group.
        /// </summary>
        public async Task<Schema.SearchResultOfGroupMemberApplication> GroupV2_GetInvitedIndividuals(int currentpage, long groupId)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.SearchResultOfGroupMemberApplication>(
                new Uri($"GroupV2/{groupId}/Members/InvitedIndividuals/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}