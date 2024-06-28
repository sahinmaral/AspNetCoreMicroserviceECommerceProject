using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Create
{
    public class CreateCommand: IRequest
    {
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }

        public class CreateCommandHandler : IRequestHandler<CreateCommand>
        {
            private readonly IRepository<Address> _repository;

            public CreateCommandHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                await _repository.CreateAsync(new Address()
                {
                    City = request.City,
                    Detail = request.Detail,
                    District = request.District,
                    UserId = request.UserId
                });
            }
        }
    }
}
