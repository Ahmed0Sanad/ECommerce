using ECommerce.Core;
using ECommerce.Core.Entity;
using ECommerce.Core.Services.Contract;
using ECommerce.Core.Specifications;
using ECommerce.Core.Specifications.ProductSpecifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        

        public async Task<IEnumerable<ProductBrand>> GetBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand>(). GetAllAsync();
            return brands;
        }

        public async Task<IEnumerable<ProductCategory>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.GetRepository<ProductCategory>().GetAllAsync();
            return categories;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var spec = new ProductWithBrandAndCategory(id);
            var product = await _unitOfWork.GetRepository<Product>() .GetByIdSpecAsync(spec);
            return product;
        }

        public async Task<(IEnumerable<Product> Products, int Count)> GetProductsAsync(ProductSpecificationPram pram)
        {
            var spec = new ProductWithBrandAndCategory(pram);
            var products = await _unitOfWork.GetRepository<Product>().GetAllSpecAsync(spec);
            var countSpec = new Specification<Product>(spec.criteria);
            var count = await _unitOfWork.GetRepository<Product>().CountSpecAsync(countSpec);

            return (products, count);
        }

    }
}
