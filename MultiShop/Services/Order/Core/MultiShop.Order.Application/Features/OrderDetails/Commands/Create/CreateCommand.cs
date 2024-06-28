using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.OrderDetails.Commands.Create
{
    public class CreateCommand : IRequest
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductAmont { get; set; }
        public decimal ProductTotalPrice { get; set; }
        public string OrderingId { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateCommand>
        {
            private readonly IRepository<OrderDetail> _repository;

            public CreateCommandHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new OrderDetail()
                {
                    ProductId = request.ProductId,
                    ProductName = request.ProductName,
                    ProductPrice = request.ProductPrice,
                    ProductAmont = request.ProductAmont,
                    ProductTotalPrice = request.ProductTotalPrice,
                    OrderingId = request.OrderingId
                });
            }
        }
    }
}
