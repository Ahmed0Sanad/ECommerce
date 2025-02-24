using ECommerce.Core.Entity.rides;
using ECommerce.Core.Repository.Contract;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer connectionMultiplexer)
        {
            _database = connectionMultiplexer.GetDatabase();

        }
        public async Task DeleteCustomerBasket(string id)
        {
            await _database.KeyDeleteAsync(id);
        }

        public async Task<CustomerBasket?> GetCustomerBasket(string id)
        {
            var result = await _database.StringGetAsync(id);

            return result.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(result) ; 
        }

        public async Task<CustomerBasket?> SetCustomerBasket( CustomerBasket cart)
        {
            var result = await _database.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));
            if (!result)
                return null;
            return await GetCustomerBasket(cart.Id);
        }
    }
}
