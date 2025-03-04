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
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public List<Expression<Func<T, object>>> includes { get; set; }
        public int skip { get; set; }
        public int take { get; set; }
        public bool IsPagination { get; set; }
    }
}
