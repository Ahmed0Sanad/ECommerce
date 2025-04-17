using ECommerce.Core.Services.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _database;
        public CacheService(IConnectionMultiplexer rids)
        {
            _database = rids.GetDatabase();
        }

        public async Task<string?> GetCachedData(string key)
        {
            var result = await _database.StringGetAsync(key);
            if (result.IsNullOrEmpty)
                return null;
            return result.ToString();
        }

        public async Task SetCachedData(string key, object data, TimeSpan expirationTime)
        {
            var serializedData = JsonSerializer.Serialize(data);
            await _database.StringSetAsync(key, serializedData, expirationTime);
           
        }
    }
}
