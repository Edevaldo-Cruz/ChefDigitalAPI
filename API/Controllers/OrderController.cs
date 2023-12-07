using ChefDigital.Entities.DTO;
using ChefDigitalAPI.Application.Order.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ChefDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] OrderCreateDTO order)
        {
            Entities.Entities.Order result = await _orderAppService.CreateAsync(order);

            if (result == null)
                return NotFound("Cliente não encontrado.");

            if (result.HasNotifications)
                return BadRequest(result.Notitycoes);

            return Ok("Pedido realizado com sucesso.");
        }

        [HttpPost("CreateOrderNewClient")]
        public async Task<IActionResult> CreateOrderNewClient([FromBody] OrderCreateNewClientDTO order)
        {
            Entities.Entities.Order result = await _orderAppService.CreateOrderNewClientAsync(order);

            if (result == null)
                return BadRequest("Erro ao realizar o pedido");

            if (result.HasNotifications)
                return BadRequest(result.Notitycoes);

            return Ok("Pedido realizado com sucesso.");
        }

        [HttpPut("CancelOrder/{id}")]
        public async Task<IActionResult> CancelOrder(Guid id)
        {
            Entities.Entities.Order result = await _orderAppService.CancelOrderAsync(id);

            if (result.HasNotifications)
                return BadRequest(result.Notitycoes);

            return Ok("Pedido cancelado.");
        }


        [HttpPut("UpdateStatusOrder/{id}")]
        public async Task<IActionResult> UpdateStatusOrder(Guid id)
        {
            Entities.Entities.Order result = await _orderAppService.UpdateStatusOrderAsync(id);

            if (result.HasNotifications)
                return BadRequest(result.Notitycoes);

            return Ok("Status do pedido atualizado.");
        }
    }
}
