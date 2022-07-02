using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private protected ICategoryService _categoryService;
        private protected IConfiguration _configuration;

        public CategoriesController(ICategoryService categoryService, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult CategoryList(int pageIndex)
        {
            int pageSize = Int32.Parse(_configuration.GetSection("PageSize").Value);
            return Ok(_categoryService.GetAllCategory(pageSize, pageIndex));

        }
    }
}
