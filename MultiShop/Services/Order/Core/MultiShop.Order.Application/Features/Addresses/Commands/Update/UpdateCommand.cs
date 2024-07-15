using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Update
{
    public class UpdateCommand: IRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail1 { get; set; }
        public string Detail2 { get; set; }
        public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
        {
            private readonly IRepository<Address> _repository;

            public UpdateCommandHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task Handle(UpdateCommand request, CancellationToken cancellationToken)
            {
                await _repository.UpdateAsync(new Address()
                {
                    Id = request.Id,
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
