using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Contract
{
    public interface ICacheService
    {
        public Task SetCachedData(string key, object data, TimeSpan expirationTime);
        public Task<string?> GetCachedData(string key);

    }
}
