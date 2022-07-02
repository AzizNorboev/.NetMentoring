using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private protected IProductService _productService;
        private protected ICategoryService _categoryService;
        private protected IConfiguration _configuration;

        public ProductsController(IProductService productService, ICategoryService categoryService, IConfiguration configuration)
        {
            _productService = productService;
            _categoryService = categoryService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get(int pageIndex, int categoryId, int pageSize)
        {
            if(pageSize == 0)
            {
                pageSize = Int32.Parse(_configuration.GetSection("PageSize").Value);
            }
            
            if(categoryId > 0)
            {
                return Ok(_productService.GetAll(pageSize, pageIndex).Where(p => p.CategoryID == categoryId));
            }

            return Ok(_productService.GetAll(pageSize, pageIndex));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public void Post(Product product)
        {
                var categoty = _categoryService.GetByName(product.Category.CategoryName);
                product.CategoryID = categoty.CategoryID;
                product.Category = categoty;
                _productService.Create(product);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
