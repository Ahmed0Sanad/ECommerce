using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Core.Entity;

namespace ECommerce.Core.Specifications
{
    public class Specification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> criteria { get; set; }
        public List<Expression<Func<T, BaseEntity>>> includes { get; set; } = new List<Expression<Func<T, BaseEntity>>>();

        public Specification()
        {
            
        }
        public Specification(Expression<Func<T,bool>> cretira)
        {
            criteria = cretira;
            
        }
    }
}
