using MediatR;

using MultiShop.Order.Application.Features.Orderings.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Orderings.Queries.GetById
{
    public class GetByIdQuery: IRequest<GetOrderingByIdQueryResult>
    {
        public string Id { get; set; }

        public class GetByIdQueryHandler: IRequestHandler<GetByIdQuery, GetOrderingByIdQueryResult>
        {
            private readonly IRepository<Ordering> _repository;

            public GetByIdQueryHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task<GetOrderingByIdQueryResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var foundOrdering = await _repository.GetByIdAsync(request.Id);
                if (foundOrdering is null)
                    throw new ArgumentNullException();

                return new GetOrderingByIdQueryResult
                {
                    Id = foundOrdering.Id,
                    UserId = foundOrdering.UserId,
                    TotalPrice = foundOrdering.TotalPrice,
                    OrderDate = foundOrdering.OrderDate,
                };
            }
        }
    }
}