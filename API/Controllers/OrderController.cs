using ChefDigital.Entities.DTO;
using ChefDigitalAPI.Application.Order.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChefDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderCreateAppService _orderCreateAppService;
        private readonly IOrderCancelAppService _orderCancelOrderAppService;
        private readonly IOrderUpdateOrderAppService _orderUpdateOrderAppService;

        public OrderController(IOrderCreateAppService orderCreateAppService,
                                IOrderCancelAppService orderCancelOrderAppService,
                                IOrderUpdateOrderAppService orderUpdateOrderAppService)
        {
            _orderCreateAppService = orderCreateAppService;
            _orderCancelOrderAppService = orderCancelOrderAppService;
            _orderUpdateOrderAppService = orderUpdateOrderAppService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] OrderCreateDTO order)
        {
            var result = await _orderCreateAppService.CreateAsync(order);

            if (!result)
                return BadRequest("Erro ao realizar o pedido");

            return Ok("Pedido realizado com sucesso.");
        }

        [HttpPut("cancel-order/{id}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            Entities.Entities.Order result = await _orderCancelOrderAppService.CancelOrderAsync(id);

            if (result.HasNotifications)
                return BadRequest(result.Notitycoes);

            return Ok("Pedido cancelado.");
        }


        [HttpPut("update-status-order/{id}")]
        public async Task<IActionResult> UpdateStatusOrder(Guid id)
        {
            Entities.Entities.Order result = await _orderUpdateOrderAppService.UpdateStatusOrderAsync(id);

            if (result.HasNotifications)
                return BadRequest(result.Notitycoes);

            return Ok("Status do pedido atualizado.");
        }
    }
}
