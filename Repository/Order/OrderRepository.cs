using EcommerceWebApi.Data;
using EcommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceWebApi.Repository
{
    public class OrderRepository: IOrderRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public OrderRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _dbContext.Orders.FindAsync(orderId);
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _dbContext.Entry(order).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _dbContext.Orders.FindAsync(orderId);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool?> OrderExistsAsync(int orderId){
            return await _dbContext.Orders?.AnyAsync(e => e.Id == orderId);
        }
    }

    public class OrderItemRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public OrderItemRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _dbContext.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _dbContext.OrderItems.FindAsync(orderItemId);
        }

        public async Task<OrderItem> CreateOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync();
            return orderItem;
        }

        public async Task UpdateOrderItemAsync(OrderItem orderItem)
        {
            _dbContext.Entry(orderItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOrderItemAsync(int orderItemId)
        {
            var orderItem = await _dbContext.OrderItems.FindAsync(orderItemId);
            _dbContext.OrderItems.Remove(orderItem);
            await _dbContext.SaveChangesAsync();
        }
    }
}