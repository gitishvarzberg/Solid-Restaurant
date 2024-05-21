
using AutoMapper;
using lesson3.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Core.DTOs;
using Restaurant.Core.Models;
using Restaurant.Core.Services;
using Restaurant.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper=mapper;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task< ActionResult> Get()
        {
            var orders = await _orderService.GetOrdersAsync();    
            var ordersDTOs = _mapper.Map<IEnumerable<OrderDTOs>>(orders);
            return Ok(ordersDTOs);

        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task < ActionResult> Get(int id)
        {
            var order =await _orderService.GetOrderByIdAsync(id);
            var orderDTOs=_mapper.Map<OrderDTOs>(order);    
            return Ok(orderDTOs);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task <ActionResult> Post([FromBody] Order order)
        {
            var orderToAdd = await _orderService.AddOrderAsync(_mapper.Map<Order>(order));
            return Ok(_mapper.Map<OrderDTOs>(orderToAdd));

        }


        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task <ActionResult> Put(int id, [FromBody] Order order)
        {
            var orderToPut = await _orderService.GetOrderByIdAsync(id);
            if (orderToPut is null)
            {
                return NotFound();
            }
            _mapper.Map(order, orderToPut);
            await _orderService.UpdateOrderAsync(id, _mapper.Map<Order>(order));
            orderToPut = await _orderService.GetOrderByIdAsync(id);
            return Ok(_mapper.Map<OrderDTOs>(orderToPut));
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order is null)
            {
                return NotFound();
            }

            await _orderService.DeleteOrderAsync(id);
            return NoContent();
        }
    }
}
