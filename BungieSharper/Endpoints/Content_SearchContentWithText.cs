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
        /// Gets content based on querystring information passed in. Provides basic search and text search capabilities.
        /// </summary>
        public async Task<Schema.SearchResultOfContentItemPublicContract> Content_SearchContentWithText(string locale, string ctype = null, int? currentpage = null, bool? head = null, string searchtext = null, string source = null, string tag = null)
        {
            return await this._apiAccessor.ApiRequestAsync<Schema.SearchResultOfContentItemPublicContract>(
                $"Content/Search/{Uri.EscapeDataString(locale)}/", null, null, HttpMethod.Get,
                ctype != null ? $"ctype={Uri.EscapeDataString(ctype)}" : null, currentpage != null ? $"currentpage={currentpage}" : null, head != null ? $"head={head}" : null, searchtext != null ? $"searchtext={Uri.EscapeDataString(searchtext)}" : null, source != null ? $"source={Uri.EscapeDataString(source)}" : null, tag != null ? $"tag={Uri.EscapeDataString(tag)}" : null);
        }
    }
}