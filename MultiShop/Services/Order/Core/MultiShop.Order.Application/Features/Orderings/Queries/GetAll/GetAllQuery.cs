using MediatR;

using MultiShop.Order.Application.Features.Orderings.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Orderings.Queries.GetAll
{
    public class GetAllQuery: IRequest<List<GetOrderingQueryResult>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<GetOrderingQueryResult>>
        {
            private readonly IRepository<Ordering> _repository;

            public GetAllQueryHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }

            public async Task<List<GetOrderingQueryResult>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                var foundOrderings = await _repository.GetAllAsync();

                return foundOrderings.Select((ordering) =>
                {
                    return new GetOrderingQueryResult
                    {
                        Id = ordering.Id,
                        UserId = ordering.UserId,
                        TotalPrice = ordering.TotalPrice,
                        OrderDate = ordering.OrderDate,
                    };
                }).ToList();
            }
        }
    }
}
