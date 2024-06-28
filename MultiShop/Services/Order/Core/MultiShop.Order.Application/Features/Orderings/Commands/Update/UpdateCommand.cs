using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Orderings.Commands.Update
{
    public class UpdateCommand: IRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
        {
            private readonly IRepository<Ordering> _repository;

            public UpdateCommandHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(new Ordering()
                {
                    Id = request.Id,
                    TotalPrice = request.TotalPrice,
                    UserId = request.UserId,
                    OrderDate = request.OrderDate
                });
            }
        }
    }
}
