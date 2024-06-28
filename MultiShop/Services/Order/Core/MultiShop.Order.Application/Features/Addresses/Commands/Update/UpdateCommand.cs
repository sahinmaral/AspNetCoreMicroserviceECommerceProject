using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Update
{
    public class UpdateCommand: IRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
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
                    Detail = request.Detail,
                    District = request.District,
                    UserId = request.UserId
                });
            }
        }
    }
}
