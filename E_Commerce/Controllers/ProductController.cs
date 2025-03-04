using AutoMapper;
using E_Commerce.DTO;
using E_Commerce.Errors;
using E_Commerce.Helper;
using ECommerce.Core.Entity;
using ECommerce.Core.Repository.Contract;
using ECommerce.Core.Specifications;
using ECommerce.Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductBrand> brandsRepo;
        private readonly IGenericRepository<ProductCategory> categoryRepo;

        public ProductController(IGenericRepository<Product> ProductRepo,IMapper mapper, IGenericRepository<ProductBrand>brandsRepo, IGenericRepository<ProductCategory>categoryRepo)
        {
            _productRepo = ProductRepo;
            _mapper = mapper;
            this.brandsRepo = brandsRepo;
            this.categoryRepo = categoryRepo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Getall([FromQuery]ProductSpecificationPram pram) 
        {
            var spec = new ProductWithBrandAndCategory(pram);
            var result = await _productRepo.GetAllSpecAsync(spec);
            var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(result);
            var countspec = new Specification<Product>(spec.criteria);
            var count = await _productRepo.CountSpecAsync(countspec);
            return Ok(new Pagination<ProductDTO>(pram.PageSize,pram.index,count,data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndCategory(id);
            var product = await _productRepo.GetByIdSpecAsync(spec);
          
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Product,ProductDTO>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await brandsRepo.GetAllAsync();
            return Ok(brands);
        }
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            var result = await categoryRepo.GetAllAsync();
            return Ok(result);
        }

    }
}
