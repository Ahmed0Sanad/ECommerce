using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.Entity;

namespace ECommerce.Core.Specifications
{
    public interface ISpecification<T>where T : BaseEntity
    {
        public Expression<Func<T, bool>> criteria { get; set; }
        public List<Expression<Func<T, BaseEntity>>> includes { get; set; }
    }
}
