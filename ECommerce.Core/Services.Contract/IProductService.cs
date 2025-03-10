using ECommerce.Core.Entity;
using ECommerce.Core.Specifications.ProductSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Contract
{
    public interface IProductService
    {
        public Task<(IEnumerable<Product> Products, int Count)> GetProductsAsync(ProductSpecificationPram pram);
        public Task<Product> GetProductByIdAsync(int id);
       
        public Task<IEnumerable<ProductBrand>> GetBrandsAsync();
        public Task<IEnumerable<ProductCategory>> GetCategoriesAsync();

    }
}
