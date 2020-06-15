﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        public async Task<IEnumerable<Schema.Entities.EntityActionResult>> GroupV2_ApprovePendingForList(long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.Entities.EntityActionResult>>(
                $"GroupV2/{groupId}/Members/ApproveList/", null, null, HttpMethod.Post
                );
        }
    }
}