using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.OrderDetails.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public string Id { get; set; }
        public class DeleteCommandHandler: IRequestHandler<DeleteCommand>
        {
            private readonly IRepository<OrderDetail> _repository;

            public DeleteCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var foundOrderDetail = await _repository.GetByIdAsync(request.Id);
                if (foundOrderDetail is null)
                    throw new ArgumentNullException();
                await _repository.DeleteAsync(foundOrderDetail);
            }
        }
    }
}
