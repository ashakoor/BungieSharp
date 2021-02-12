﻿using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Net.Http;
=======
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
        /// Returns a list of possible users based on the search string
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.User.GeneralUser>> User_SearchUsers(string q = null, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.GeneralUser>>(
=======
        /// <param name="q">The search string.</param>
        public async Task<IEnumerable<Entities.User.GeneralUser>> User_SearchUsers(string? q = null, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.User.GeneralUser>>(
>>>>>>> rewrite
                new Uri($"User/SearchUsers/" + HttpRequestGenerator.MakeQuerystring(q != null ? $"q={Uri.EscapeDataString(q)}" : null), UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}