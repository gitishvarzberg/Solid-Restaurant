using Restaurant.Core.Models;

namespace Restaurant.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> AddOrderAsync(Order Order);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(int id, Order Order);
        
    }
}
