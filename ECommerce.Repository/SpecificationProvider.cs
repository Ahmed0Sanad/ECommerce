using ECommerce.Core;
using ECommerce.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository
{
    public static class SpecificationProvider<T> where T :BaseEntity
    {
        public static IQueryable<T> GetQuary(IQueryable<T> intputQuary , ISpecification<T> spec)
        {
            var quary = intputQuary;
            if (spec.criteria != null) 
            {
                quary= quary.Where(spec.criteria);
            
            }
            quary = spec.includes.Aggregate(quary, (q, s) => q.Include(s));
            return quary;
        }
    }
}
