using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Order.Application.Features.OrderDetails.Commands.Create;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Delete;
using MultiShop.Order.Application.Features.OrderDetails.Commands.Update;
using MultiShop.Order.Application.Features.OrderDetails.Queries.GetAll;
using MultiShop.Order.Application.Features.OrderDetails.Queries.GetById;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _mediator.Send(new GetAllQuery());
            return Ok(addresses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var address = await _mediator.Send(new GetByIdQuery()
            {
                Id = id
            });
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommand request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteCommand()
            {
                Id = id
            });
            return Ok();
        }
    }
}
