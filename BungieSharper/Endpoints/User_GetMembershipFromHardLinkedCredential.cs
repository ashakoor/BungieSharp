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
        /// Gets any hard linked membership given a credential. Only works for credentials that are public (just SteamID64 right now). Cross Save aware.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.User.HardLinkedUserMembership> User_GetMembershipFromHardLinkedCredential(string credential, Schema.BungieCredentialType crType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.User.HardLinkedUserMembership>(
=======
        /// <param name="credential">The credential to look up. Must be a valid SteamID64.</param>
        /// <param name="crType">The credential type. 'SteamId' is the only valid value at present.</param>
        public async Task<Entities.User.HardLinkedUserMembership> User_GetMembershipFromHardLinkedCredential(string credential, Entities.BungieCredentialType crType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.User.HardLinkedUserMembership>(
>>>>>>> rewrite
                new Uri($"User/GetMembershipFromHardLinkedCredential/{crType}/{Uri.EscapeDataString(credential)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}