using Restaurant.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public interface IOrderService
    {
        Task<Order> AddOrderAsync(Order Order);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<Order> UpdateOrderAsync(int id, Order Order);
    }
}
