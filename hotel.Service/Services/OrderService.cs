using Restaurant.Core.Models;
using Restaurant.Core.Repositories;
using Restaurant.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Service.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        Order IOrderService.AddOrder(Order order)
        {
            return _orderRepository.AddOrder(order);
        }
        public void DeleteOrder(int id)
        {
            _orderRepository.DeleteOrder(id);
        }
        IEnumerable<Order> IOrderService.GetOrders()
        {
            return _orderRepository.GetOrders();
        }
        Order IOrderService.GetById(int id)
        {
            return _orderRepository.GetById(id);
        }
        Order IOrderService.UpdateOrder(int id, Order order)
        {
            return _orderRepository.UpdateOrder(id, order);
        }
    }
}
