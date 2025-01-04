using ASPWebApp.Entities;
using ASPWebApp.Model;

namespace ASPWebApp.Service
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderCreateRequest orderCreateRequest);
        Task<IEnumerable<Order>> GetAllOrders();

        Task<bool> CheckOrderInStock(long bookId, int quantity);
        

    }
}
