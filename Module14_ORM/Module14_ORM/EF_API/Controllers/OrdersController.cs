using EF_API.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.enums;

namespace EF_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderRepository.GetById(id);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            await _orderRepository.Create(order);
            return Created("", order);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Order order)
        {
            if (order == null)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            await _orderRepository.Update(order);
            return Ok(order);
        }

        [HttpGet("Status/{status}")]
        public async Task<IActionResult> GetById(Status status)
        {
            var order = await _orderRepository.GetByStatus(status);
            return Ok(order);
        }
    }
}
