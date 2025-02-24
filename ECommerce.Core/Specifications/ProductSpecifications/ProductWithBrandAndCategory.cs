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
        public ProductWithBrandAndCategory(ProductSpecificationPram pram):
            base(
                p=>(!pram.brandId.HasValue|| p.BrandId == pram.brandId)&&
                (!pram.categoryId.HasValue|| p.CategoryId == pram.categoryId)&&
                (string.IsNullOrEmpty(pram.Search)||p.Name.ToLower().Contains(pram.Search))
                )
        {
           
            includes.Add(p=>p.Brand);
            includes.Add(p=>p.Category);
           
            #region sorting
            if (!string.IsNullOrEmpty(pram.sort))
            {
                switch (pram.sort)
                {
                    case "priceAsc":
                        OrderBy = p => p.Price;
                        break;
                    case "priceDesc":
                        OrderByDesc = p => p.Price;
                        break;
                    default:
                        OrderBy = p => p.Name;
                        break;

                }
            }
            else
            {
                OrderBy = p => p.Name;
            }
            #endregion

            #region Pagination
            // 20 5 3
            ApplyPagination((pram.index-1)*pram.PageSize,pram.PageSize);
            #endregion
        }
        public ProductWithBrandAndCategory(int id) :base(p=>p.Id==id) 
        {
            includes.Add(p => p.Brand);
            includes.Add(p => p.Category);

        }

    }
}
