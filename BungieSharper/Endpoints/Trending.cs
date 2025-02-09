﻿using BungieSharper.Client;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BungieSharper.Endpoints;

public partial class Endpoints
{
    /// <summary>
    /// Returns trending items for Bungie.net, collapsed into the first page of items per category. For pagination within a category, call GetTrendingCategory.
    /// </summary>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Trending.TrendingCategories> Trending_GetTrendingCategories(string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri("Trending/Categories/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseTrendingCategories,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns paginated lists of trending items for a category.
    /// </summary>
    /// <param name="categoryId">The ID of the category for whom you want additional results.</param>
    /// <param name="pageNumber">The page # of results to return.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.SearchResultOfTrendingEntry> Trending_GetTrendingCategory(string categoryId, int pageNumber, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Trending/Categories/{Uri.EscapeDataString(categoryId)}/{pageNumber}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseSearchResultOfTrendingEntry,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }

    /// <summary>
    /// Returns the detailed results for a specific trending entry. Note that trending entries are uniquely identified by a combination of *both* the TrendingEntryType *and* the identifier: the identifier alone is not guaranteed to be globally unique.
    /// </summary>
    /// <param name="identifier">The identifier for the entity to be returned.</param>
    /// <param name="trendingEntryType">The type of entity to be returned.</param>
    /// <param name="authToken">The OAuth access token to authenticate the request with.</param>
    /// <param name="cancelToken">The <see cref="CancellationToken" /> to observe.</param>
    public Task<Entities.Trending.TrendingDetail> Trending_GetTrendingEntryDetail(string identifier, Entities.Trending.TrendingEntryType trendingEntryType, string? authToken = null, CancellationToken cancelToken = default)
    {
        return _apiAccessor.ApiRequestAsync(
            new Uri($"Trending/Details/{trendingEntryType}/{Uri.EscapeDataString(identifier)}/", UriKind.Relative), _apiAccessor.JsonContext.ApiResponseTrendingDetail,
            null, HttpMethod.Get, authToken, cancelToken
            );
    }
}