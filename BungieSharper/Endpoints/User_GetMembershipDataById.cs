﻿using BungieSharper.Client;
using System;
<<<<<<< HEAD
using System.Net.Http;
=======
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
>>>>>>> rewrite
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Returns a list of accounts associated with the supplied membership ID and membership type. This will include all linked accounts (even when hidden) if supplied credentials permit it.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Schema.BungieMembershipType membershipType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.UserMembershipData>(
=======
        /// <param name="membershipId">The membership ID of the target user.</param>
        /// <param name="membershipType">Type of the supplied membership ID.</param>
        public async Task<Entities.User.UserMembershipData> User_GetMembershipDataById(long membershipId, Entities.BungieMembershipType membershipType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.User.UserMembershipData>(
>>>>>>> rewrite
                new Uri($"User/GetMembershipsById/{membershipId}/{membershipType}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}