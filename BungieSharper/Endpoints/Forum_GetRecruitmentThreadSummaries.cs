﻿using BungieSharper.Client;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
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
        /// Allows the caller to get a list of to 25 recruitment thread summary information objects.
        /// </summary>
<<<<<<< HEAD
        public async Task<IEnumerable<Schema.Forum.ForumRecruitmentDetail>> Forum_GetRecruitmentThreadSummaries(IEnumerable<long> requestBody, string authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Schema.Forum.ForumRecruitmentDetail>>(
=======
        public async Task<IEnumerable<Entities.Forum.ForumRecruitmentDetail>> Forum_GetRecruitmentThreadSummaries(IEnumerable<long> requestBody, string? authToken = null, CancellationToken cancelToken = default)
        {
            return await _apiAccessor.ApiRequestAsync<IEnumerable<Entities.Forum.ForumRecruitmentDetail>>(
>>>>>>> rewrite
                new Uri($"Forum/Recruit/Summaries/", UriKind.Relative),
                new StringContent(JsonSerializer.Serialize(requestBody), System.Text.Encoding.UTF8, "application/json"), HttpMethod.Post, authToken, AuthHeaderType.Bearer, cancelToken
                ).ConfigureAwait(false);
        }
    }
}