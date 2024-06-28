using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Orderings.Commands.Create
{
    public class CreateCommand : IRequest
    {
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateCommand>
        {
            private readonly IRepository<Ordering> _repository;

            public CreateCommandHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new Ordering()
                {
                    TotalPrice = request.TotalPrice,
                    UserId = request.UserId,
                    OrderDate = request.OrderDate
                });
            }
        }
    }
}
