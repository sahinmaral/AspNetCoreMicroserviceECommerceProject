using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

using System.Net;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Create
{
    public class CreateCommand: IRequest
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }

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
                    Detail1 = request.Detail1,
                    Detail2 = request.Detail2,
                    District = request.District,
                    UserId = request.UserId,
                    Name = request.Name,
                    Surname = request.Surname,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                });
            }
        }
    }
}
