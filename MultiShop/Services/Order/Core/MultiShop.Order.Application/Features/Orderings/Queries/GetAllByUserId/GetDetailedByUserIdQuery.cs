using MediatR;

using MultiShop.Order.Application.Features.Orderings.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Orderings.Queries.GetAllByUserId
{
    public class GetAllByUserIdQuery : IRequest<List<GetAllByUserIdQueryResult>>
    {
        public string UserId { get; set; }
        public class GetAllByUserIdQueryHandler : IRequestHandler<GetAllByUserIdQuery, List<GetAllByUserIdQueryResult>>
        {
            private readonly IRepository<Ordering> _repository;

            public GetAllByUserIdQueryHandler(IRepository<Ordering> repository)
            {
                _repository = repository;
            }
            public async Task<List<GetAllByUserIdQueryResult>> Handle(GetAllByUserIdQuery request, CancellationToken cancellationToken)
            {
                var orderings = await _repository.GetAllAsync(x => x.UserId == request.UserId);
                return orderings.Select((ordering) =>
                {
                    return new GetAllByUserIdQueryResult
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
