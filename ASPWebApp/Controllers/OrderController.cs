using ASPWebApp.Model;
using ASPWebApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllOrders()
        {
            try
            {
                return Ok(await _orderService.GetAllOrders());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateOrder(OrderCreateRequest orderCreateRequest)
        {
            try
            {
                return Ok(await _orderService.CreateOrder(orderCreateRequest));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
