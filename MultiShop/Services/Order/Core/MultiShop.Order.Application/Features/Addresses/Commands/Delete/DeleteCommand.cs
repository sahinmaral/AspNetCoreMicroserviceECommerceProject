using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Addresses.Commands.Delete
{
    public class DeleteCommand: IRequest
    {
        public string Id { get; set; }
        public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
        {
            private readonly IRepository<Address> _repository;

            public DeleteCommandHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var foundAddress = await _repository.GetByIdAsync(request.Id);
                if (foundAddress is null)
                    throw new ArgumentNullException();
                await _repository.DeleteAsync(foundAddress);
            }
        }
    }
}
