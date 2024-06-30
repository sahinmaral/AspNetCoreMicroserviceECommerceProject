using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Order.Application.Features.Addresses.Commands.Delete;
using MultiShop.Order.Application.Features.Addresses.Commands.Update;
using MultiShop.Order.Application.Features.Addresses.Queries.GetAll;
using MultiShop.Order.Application.Features.Addresses.Queries.GetById;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressesController(IMediator mediator)
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
        public async Task<IActionResult> Create(MultiShop.Order.Application.Features.Addresses.Commands.Create.CreateCommand request)
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
