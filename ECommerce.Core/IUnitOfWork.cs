using ECommerce.Core.Entity;
using ECommerce.Core.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core
{
    public interface IUnitOfWork : IAsyncDisposable , IDisposable
    {
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<int> CompleteAsync();
    
    }
}
