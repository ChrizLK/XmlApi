using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace XmlApi.Services.Caching
{
    public class RedisCacheService : IRedisCacheService
    {

        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache) 
        {
         
            _cache = cache;
        
        }

        public T? Get<T>(string key)
        {
           var red = _cache?.GetString(key);

            if (red == null) { 
            return default(T?);
            }

            return JsonSerializer.Deserialize<T>(red);
        }

        public void SetData<T>(string key, T data)
        {
            var options = new DistributedCacheEntryOptions()
            {

                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),

            };

            _cache?.SetString(key , JsonSerializer.Serialize(data), options);
        }
    }
}
