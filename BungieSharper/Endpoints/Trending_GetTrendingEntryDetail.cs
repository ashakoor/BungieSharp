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
        /// Returns the detailed results for a specific trending entry. Note that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranteed to be globally unique.
        /// </summary>
<<<<<<< HEAD
        public async Task<Schema.Trending.TrendingDetail> Trending_GetTrendingEntryDetail(string identifier, Schema.Trending.TrendingEntryType trendingEntryType, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Schema.Trending.TrendingDetail>(
=======
        /// <param name="identifier">The identifier for the entity to be returned.</param>
        /// <param name="trendingEntryType">The type of entity to be returned.</param>
        public async Task<Entities.Trending.TrendingDetail> Trending_GetTrendingEntryDetail(string identifier, Entities.Trending.TrendingEntryType trendingEntryType, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<Entities.Trending.TrendingDetail>(
>>>>>>> rewrite
                new Uri($"Trending/Details/{trendingEntryType}/{Uri.EscapeDataString(identifier)}/", UriKind.Relative),
                null, HttpMethod.Get, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}