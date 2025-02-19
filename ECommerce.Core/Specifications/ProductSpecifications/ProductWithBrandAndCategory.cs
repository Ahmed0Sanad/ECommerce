using ECommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Specifications.ProductSpecifications
{
    public class ProductWithBrandAndCategory:Specification<Product>
    {
        public ProductWithBrandAndCategory():base()
        {
            includes.Add(p=>p.Brand);
            includes.Add(p=>p.Category);
        }
        public ProductWithBrandAndCategory(int id):base(p=>p.Id==id) 
        {
            includes.Add(p => p.Brand);
            includes.Add(p => p.Category);

        }

    }
}
