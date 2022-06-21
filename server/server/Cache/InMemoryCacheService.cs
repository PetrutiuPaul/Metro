using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;

namespace server.Cache
{
    public class InMemoryCacheService : ICacheService //For Production use Reddis
    {
        private MemoryCache _memoryCache = new(new MemoryCacheOptions());

        public void Clear()
        {
            _memoryCache.Dispose();
            _memoryCache = new(new MemoryCacheOptions());
        }

        public string Get(string key)
        {
            return (string)_memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void Set(string key, object data, long cacheTime)
        {
            if (data == null)
            {
                return;
            }

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMilliseconds(cacheTime));

            var serializedResponse = JsonConvert.SerializeObject(data);

            _memoryCache.Set(key, serializedResponse, cacheEntryOptions);
        }
    }
}
