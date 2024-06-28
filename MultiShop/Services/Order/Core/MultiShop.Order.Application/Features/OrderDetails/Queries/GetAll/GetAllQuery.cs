using MediatR;

using MultiShop.Order.Application.Features.OrderDetails.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.OrderDetails.Queries.GetAll
{
    public class GetAllQuery: IRequest<List<GetOrderDetailQueryResult>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<GetOrderDetailQueryResult>>
        {
            private readonly IRepository<OrderDetail> _repository;

            public GetAllQueryHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task<List<GetOrderDetailQueryResult>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                var foundAddresses = await _repository.GetAllAsync();

                return foundAddresses.Select((address) =>
                {
                    return new GetOrderDetailQueryResult
                    {
                        Id = address.Id,
                        ProductId = address.ProductId,
                        ProductName = address.ProductName,
                        ProductPrice = address.ProductPrice,
                        ProductAmont = address.ProductAmont,
                        ProductTotalPrice = address.ProductTotalPrice,
                        OrderingId = address.OrderingId
                    };
                }).ToList();
            }
        }
    }
}
