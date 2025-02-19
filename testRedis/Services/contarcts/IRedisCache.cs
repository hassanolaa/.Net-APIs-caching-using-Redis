﻿namespace testRedis.Services.contarcts
{
    public interface IRedisCache
    {

        Task SetCacheValueAsync<T>(string key, T value, TimeSpan expiration);
        Task<T> GetCacheValueAsync<T>(string key);
    }
}
