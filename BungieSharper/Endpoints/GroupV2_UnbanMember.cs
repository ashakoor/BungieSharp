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
        /// Unbans the requested member, allowing them to re-apply for membership.
        /// </summary>
        public async Task<int> GroupV2_UnbanMember(long groupId, long membershipId, Schema.BungieMembershipType membershipType)
        {
            return await _apiAccessor.ApiRequestAsync<int>(
                new Uri($"GroupV2/{groupId}/Members/{membershipType}/{membershipId}/Unban/", UriKind.Relative),
                null, null, HttpMethod.Post
                ).ConfigureAwait(false);
        }
    }
}