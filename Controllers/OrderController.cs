using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EcommerceWebApi.Data;
using EcommerceWebApi.Model;
using EcommerceWebApi.Repository;

namespace EcommerceWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// GET: api/Order
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            List<Order> orders = await _orderRepository.GetAllOrdersAsync();
            return orders ?? (ActionResult<IEnumerable<Order>>)NotFound();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            Order order = await _orderRepository.GetOrderByIdAsync(id);
            return order ?? (ActionResult<Order>)NotFound();
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest("Order cannot be null");
            }
            await _orderRepository.UpdateOrderAsync(order);

            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (order == null)
            {
                return Problem("Entity set 'EcommerceDbContext.Orders'  is null.");
            }
            Order createdOrder = await _orderRepository.CreateOrderAsync(order);
            // _context.Orders.Add(order);
            // await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = createdOrder.Id }, createdOrder);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            await _orderRepository.DeleteOrderAsync(id);

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _orderRepository.OrderExistsAsync(id);
        }
    }
}
