using ECommerce.Core.Entity;
using ECommerce.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Repository.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T>GetSpecAsync(int id ,ISpecification<T> spec);
        Task<IEnumerable<T>> GetAllSpecAsync(ISpecification<T> spec);
        Task<int> CountSpecAsync(ISpecification<T> spec);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
