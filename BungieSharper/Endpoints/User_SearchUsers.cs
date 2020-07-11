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
        /// Returns a list of possible users based on the search string
        /// </summary>
        public async Task<IEnumerable<Schema.User.GeneralUser>> User_SearchUsers(string q = null)
        {
            return await this._apiAccessor.ApiRequestAsync<IEnumerable<Schema.User.GeneralUser>>(
                $"User/SearchUsers/", null, null, HttpMethod.Get,
                q != null ? $"q={Uri.EscapeDataString(q)}" : null);
        }
    }
}