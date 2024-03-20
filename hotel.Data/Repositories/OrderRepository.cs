using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        Order IOrderRepository.AddOrder(Order Order)
        {
            _context.Orders.Add( new Order
            {
                OrderId = Order.OrderId,
                NameClient = Order.NameClient,
                Date = Order.Date,
                DosesCount = Order.DosesCount,
               // Doses= Order.Doses,
               
            });
            _context.SaveChanges();
            return Order;

        }
        void IOrderRepository.DeleteOrder(int id)
        {
            var temp = _context.Orders.Find(id);
            _context.Orders.Remove(temp);
            _context.SaveChanges();

        }
        IEnumerable<Order> IOrderRepository.GetOrders()
        {
            return _context.Orders;
        }
        Order IOrderRepository.GetById(int id)
        {
            return _context.Orders.Find(id);
        }
        Order IOrderRepository.UpdateOrder(int id, Order Order)
        {
            var temp = _context.Orders.Find(id);
            temp.NameClient=Order.NameClient;
            temp.OrderId=id; 
            temp.Date=Order.Date;
            temp.DosesCount=Order.DosesCount;
            _context.SaveChanges();

            return temp;
        }
    }
}
