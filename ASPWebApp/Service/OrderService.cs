using ASPWebApp.Entities;
using ASPWebApp.Model;
using ASPWebApp.Repository;

namespace ASPWebApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountRepository _accountRepository;

        public OrderService(IOrderRepository orderRepository, IBookRepository bookRepository, IAuthenticationService authenticationService, IAccountRepository accountRepository )
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _authenticationService = authenticationService;
            _accountRepository = accountRepository;
        }

        public async Task<bool> CheckOrderInStock(long bookId, int quantity)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }
            if (book.Quantity < quantity)
            {
                return false;
            }
            return true;
        }

        public async Task<Order> CreateOrder(OrderCreateRequest orderCreateRequest)
        {
            var userDTO = await _authenticationService.GetCurrentUser();
            var user = await _accountRepository.GetByIdAsync(Guid.Parse(userDTO.Id));
            var isInStock = await CheckOrderInStock(orderCreateRequest.BookId, orderCreateRequest.Quantity);
            if (!isInStock) { 
                throw new ArgumentException("Book is not in stock");          
            }
            var book = await _bookRepository.GetBookByIdAsync(orderCreateRequest.BookId);
            Order createOrder = new Order
            {
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.Now.AddDays(3),
                Address = "Test Address",
                TotalPrice = book.Price * orderCreateRequest.Quantity,
                AccountId = Guid.Parse(userDTO.Id),
                Account = user,
            };
            await _orderRepository.AddOrderAsync(createOrder);
            return createOrder;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}
