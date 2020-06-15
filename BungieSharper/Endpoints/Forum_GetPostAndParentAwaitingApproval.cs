﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<Schema.Forum.PostSearchResponse> Forum_GetPostAndParentAwaitingApproval(long childPostId, string showbanned)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Forum.PostSearchResponse>(
                $"Forum/GetPostAndParentAwaitingApproval/{childPostId}/", null, null, HttpMethod.Get
                );
        }
    }
}