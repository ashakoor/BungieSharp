﻿/*
   Copyright (C) 2020 ashakoor

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU Affero General Public License as
   published by the Free Software Foundation, either version 3 of the
   License or any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU Affero General Public License for more details.

   You should have received a copy of the GNU Affero General Public License
   along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;

namespace BungieSharper.Client
{
    public class BungieApiClient : IDisposable
    {
        private readonly ApiAccessor _apiAccessor;
        private const ushort MaxRequestsPerSecond = 20;

        internal void InitializeEndpoints()
        {
        }

        public BungieApiClient(string apiKey)
        {
            this._apiAccessor = new ApiAccessor();
            this._apiAccessor.SetApiKey(apiKey);
            this._apiAccessor.SetRateLimit(20);
            this.InitializeEndpoints();
        }

        public BungieApiClient(string apiKey, string userAgent)
        {
            this._apiAccessor = new ApiAccessor();
            this._apiAccessor.SetApiKey(apiKey);
            this._apiAccessor.SetUserAgent(userAgent);
            this._apiAccessor.SetRateLimit(20);
            this.InitializeEndpoints();
        }

        public BungieApiClient(string apiKey, ushort requestsPerSecond)
        {
            this._apiAccessor = new ApiAccessor();
            this._apiAccessor.SetApiKey(apiKey);
            this._apiAccessor.SetRateLimit(requestsPerSecond);
            this.InitializeEndpoints();
        }

        public BungieApiClient(string apiKey, string userAgent, ushort requestsPerSecond)
        {
            this._apiAccessor = new ApiAccessor();
            this._apiAccessor.SetApiKey(apiKey);
            this._apiAccessor.SetUserAgent(userAgent);
            this._apiAccessor.SetRateLimit(requestsPerSecond);
            this.InitializeEndpoints();
        }

        public void SetApiKey(string apiKey) => this._apiAccessor.SetApiKey(apiKey);

        public void SetUserAgent(string userAgent) => this._apiAccessor.SetUserAgent(userAgent);

        public void SetRateLimit() => this._apiAccessor.SetRateLimit(20);

        public void SetRateLimit(ushort requestsPerSecond) => this._apiAccessor.SetRateLimit(requestsPerSecond);

        public void Dispose() => this._apiAccessor.Dispose();
    }
}