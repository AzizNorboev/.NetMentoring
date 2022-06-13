using EF_API.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace EF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productRepository.GetById(id);
            return Ok(product);
        }
        [HttpGet("productName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var products = await _productRepository.GetProductsByName(name);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            await _productRepository.Create(product);
            return Created("", product);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            await _productRepository.Update(product);
            return Ok(product);
        }
    }
}
