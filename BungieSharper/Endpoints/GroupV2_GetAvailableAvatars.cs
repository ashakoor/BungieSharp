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
        /// Returns a list of all available group avatars for the signed-in user.
        /// </summary>
        public async Task<Dictionary<int, string>> GroupV2_GetAvailableAvatars()
        {
            return await _apiAccessor.ApiRequestAsync<Dictionary<int, string>>(
                new Uri($"GroupV2/GetAvailableAvatars/", UriKind.Relative),
                null, null, HttpMethod.Get
                ).ConfigureAwait(false);
        }
    }
}