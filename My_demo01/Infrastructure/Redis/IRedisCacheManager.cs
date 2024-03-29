﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Redis
{
    public interface IRedisCacheManager
    {
        void Clear();
        bool Get(string key);
        string GetValue(string key);
        TEntity Get<TEntity>(string key);
        void Remove(string key);
        void Set(string key, object value, TimeSpan cacheTime);
        void SetAsync(string key, object value, TimeSpan cacheTime);
        bool SetValue(string key, byte[] value);
        Task<bool> SetValueAsync(string key, byte[] value);
    }
}
