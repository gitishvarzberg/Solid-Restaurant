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
         Order AddOrder(Order Order);
         void DeleteOrder(int id);
         IEnumerable<Order> GetOrders();
         Order GetById(int id);
         Order UpdateOrder(int id, Order Order);
    }
}
