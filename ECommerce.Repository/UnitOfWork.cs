using ECommerce.Core;
using ECommerce.Core.Entity;
using ECommerce.Core.Repository.Contract;
using ECommerce.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            _repositories = new Dictionary<string, GenericRepository<BaseEntity>>();
        }
        public Dictionary<string,GenericRepository<BaseEntity>> _repositories { get; set; }

        public async Task CompleteAsync()
        {
           await appDbContext.SaveChangesAsync();
        }

       

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var Key = typeof(T).Name;
            if (!_repositories.ContainsKey(Key))
            {
                _repositories[Key] = new GenericRepository<T>(appDbContext) as GenericRepository<BaseEntity>;
            }
            return _repositories[Key] as GenericRepository<T>;
        }
    }
}
