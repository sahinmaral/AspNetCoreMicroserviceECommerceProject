using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MultiShop.Order.Application.Features.Orderings.Commands.Create;
using MultiShop.Order.Application.Features.Orderings.Commands.Delete;
using MultiShop.Order.Application.Features.Orderings.Commands.Update;
using MultiShop.Order.Application.Features.Orderings.Queries.GetAll;
using MultiShop.Order.Application.Features.Orderings.Queries.GetAllByUserId;
using MultiShop.Order.Application.Features.Orderings.Queries.GetById;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orderings = await _mediator.Send(new GetAllQuery());
            return Ok(orderings);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var orderings = await _mediator.Send(new GetAllByUserIdQuery
            {
                UserId = userId
            });
            return Ok(orderings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var order = await _mediator.Send(new GetByIdQuery()
            {
                Id = id
            });
            return Ok(order);
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
