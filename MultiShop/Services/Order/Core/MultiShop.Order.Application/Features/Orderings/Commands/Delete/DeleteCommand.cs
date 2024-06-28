using MediatR;

using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Orderings.Commands.Delete
{
    public class DeleteCommand : IRequest
    {
        public string Id { get; set; }
        public class DeleteCommandHandler: IRequestHandler<DeleteCommand>
        {
            private readonly IRepository<Ordering> _repository;

            public DeleteCommandHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var foundOrdering = await _repository.GetByIdAsync(request.Id);
                if (foundOrdering is null)
                    throw new ArgumentNullException();
                await _repository.DeleteAsync(foundOrdering);
            }
        }
    }
}
