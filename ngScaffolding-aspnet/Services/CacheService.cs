using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace ngScaffolding.Services
{
    public class CacheService: ICacheService
    {
        private IMemoryCache _cache;

        public CacheService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public object Get(string key)
        {
            object returnValue = null;
            _cache.TryGetValue(key, out returnValue);
            return returnValue;
        }

        public void Set(string key, object data, int? cacheTime)
        {
            // Default to 5 minutes
            if (!cacheTime.HasValue)
            {
                cacheTime = 300;
            }
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheTime.Value));

            // Save data in cache.
            _cache.Set(key, data, cacheEntryOptions);
        }

        public bool IsSet(string key)
        {
            object returnValue = null;
            _cache.TryGetValue(key, out returnValue);

            return returnValue != null;
        }

        public void Invalidate(string key)
        {
            _cache.Remove(key);
        }
    }
}
