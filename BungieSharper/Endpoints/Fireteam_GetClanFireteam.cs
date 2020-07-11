﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints
{
    public partial class Endpoints
    {
        /// <summary>
        /// Gets a specific clan fireteam.
        /// </summary>
        public async Task<Schema.Fireteam.FireteamResponse> Fireteam_GetClanFireteam(long fireteamId, long groupId)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.Fireteam.FireteamResponse>(
                $"Fireteam/Clan/{groupId}/Summary/{fireteamId}/", null, null, HttpMethod.Get
                );
        }
    }
}