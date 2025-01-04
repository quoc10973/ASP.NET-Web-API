using ASPWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookStoreContext _context;

        public OrderRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(Order order)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders;
        }

        public async Task UpdateOrderAsync(Order order)
        {
            var orderToUpdate = _context.Orders.SingleOrDefault(o => o.Id == order.Id);
            if (orderToUpdate == null)
            {
                throw new ArgumentException("Order not found");
            }
            orderToUpdate.OrderDate = order.OrderDate;
            orderToUpdate.TotalPrice = order.TotalPrice;
            orderToUpdate.AccountId = order.AccountId;
            orderToUpdate.Address = order.Address;
            orderToUpdate.DeliveryDate = order.DeliveryDate;
            _context.SaveChangesAsync();
        }
    }
}
