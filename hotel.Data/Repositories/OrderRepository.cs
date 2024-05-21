using Microsoft.EntityFrameworkCore;
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

        public async Task<Order> AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task DeleteOrderAsync(int id)
        {
            var temp = await GetOrderByIdAsync(id);
            _context.Orders.Remove(temp);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FirstAsync(x => x.OrderId == id);
        }

        public async Task<Order> UpdateOrderAsync(int id, Order Order)
        {
            var temp = await GetOrderByIdAsync(id);
            temp.NameClient = Order.NameClient;
            temp.OrderId = id;
            temp.Date = Order.Date;
            temp.DosesCount = Order.DosesCount;
            await _context.SaveChangesAsync();
            return temp;
        }
    }
}
