using ECommerce.Core;
using ECommerce.Core.Entity;
using ECommerce.Core.Repository.Contract;
using ECommerce.Repository.Data;
using System;
using System.Collections;
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
            _repositories = new Hashtable();
        }
        public Hashtable _repositories { get; set; }

        public async Task<int> CompleteAsync()
        {
          return  await appDbContext.SaveChangesAsync();
        }

       

        public async ValueTask DisposeAsync()
        {
            await appDbContext.DisposeAsync();
        }

        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            var Key = typeof(T).Name;
            if (!_repositories.ContainsKey(Key))
            {
                var repo = new GenericRepository<T>(appDbContext) ;
                _repositories.Add(Key, repo);
            }
            return _repositories[Key] as IGenericRepository<T>;
        }
    }
}
