using AutoMapper;
using E_Commerce.DTO;
using E_Commerce.Errors;
using E_Commerce.Helper;
using ECommerce.Core.Entity;
using ECommerce.Core.Repository.Contract;
using ECommerce.Core.Services.Contract;
using ECommerce.Core.Specifications;
using ECommerce.Core.Specifications.ProductSpecifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        
        private readonly IMapper _mapper;

        public readonly IProductService _ProductService;
        public  ICacheService cacheService;

        public ProductController(IMapper mapper,IProductService productService,ICacheService cacheService)
        {
            
            _mapper = mapper;
            _ProductService = productService;
            this.cacheService = cacheService;
        }

        [CacheAttribute(10)]
        [HttpGet]
       
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Getall([FromQuery] ProductSpecificationPram pram) 
        {
            var result =await _ProductService.GetProductsAsync(pram);
            var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(result.Products);
            return Ok(new Pagination<ProductDTO>(pram.PageSize,pram.index,result.Count,data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _ProductService.GetProductByIdAsync(id);
          
            if (product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok(_mapper.Map<Product,ProductDTO>(product));
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetBrands()
        {
            var brands = await _ProductService.GetBrandsAsync();
            return Ok(brands);
        }
        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetCategories()
        {
            var result =  await _ProductService.GetCategoriesAsync();
            return Ok(result);
        }

    }
}
