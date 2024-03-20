using Restaurant.Core.Models;

namespace Restaurant.Core.Repositories
{
    public interface IOrderRepository
    {
        Order AddOrder(Order Order);
        void DeleteOrder(int id);
        IEnumerable<Order> GetOrders();
        Order GetById(int id);
        Order UpdateOrder(int id, Order Order);
        
    }
}
