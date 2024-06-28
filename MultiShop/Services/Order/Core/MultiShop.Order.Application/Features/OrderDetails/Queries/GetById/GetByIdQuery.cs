using MediatR;

using MultiShop.Order.Application.Features.OrderDetails.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.OrderDetails.Queries.GetById
{
    public class GetByIdQuery: IRequest<GetOrderDetailByIdQueryResult>
    {
        public string Id { get; set; }

        public class GetByIdQueryHandler: IRequestHandler<GetByIdQuery, GetOrderDetailByIdQueryResult>
        {
            private readonly IRepository<OrderDetail> _repository;

            public GetByIdQueryHandler(IRepository<OrderDetail> repository)
            {
                _repository = repository;
            }

            public async Task<GetOrderDetailByIdQueryResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var foundOrderDetail = await _repository.GetByIdAsync(request.Id);
                if (foundOrderDetail is null)
                    throw new ArgumentNullException();

                return new GetOrderDetailByIdQueryResult
                {
                    Id = foundOrderDetail.Id,
                    ProductId = foundOrderDetail.ProductId,
                    ProductName = foundOrderDetail.ProductName,
                    ProductPrice = foundOrderDetail.ProductPrice,
                    ProductAmont = foundOrderDetail.ProductAmont,
                    ProductTotalPrice = foundOrderDetail.ProductTotalPrice,
                    OrderingId = foundOrderDetail.OrderingId
                };
            }
        }
    }
}