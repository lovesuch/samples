using System.Threading.Tasks;
using MediatR.Samples.Application.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Samples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> CreateOrder(CreateOrderCommand order)
        {
            return await _mediator.Send(order);
        }
    }
}