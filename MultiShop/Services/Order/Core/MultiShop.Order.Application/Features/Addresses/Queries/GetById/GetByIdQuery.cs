using MediatR;

using MultiShop.Order.Application.Features.Addresses.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Addresses.Queries.GetById
{
    public class GetByIdQuery: IRequest<GetAddressByIdQueryResult>
    {
        public string Id { get; set; }

        public class GetByIdQueryHandler: IRequestHandler<GetByIdQuery, GetAddressByIdQueryResult>
        {
            private readonly IRepository<Address> _repository;

            public GetByIdQueryHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task<GetAddressByIdQueryResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
            {
                var foundAddress = await _repository.GetByIdAsync(request.Id);
                if (foundAddress is null)
                    throw new ArgumentNullException();

                return new GetAddressByIdQueryResult
                {
                    Id = foundAddress.Id,
                    City = foundAddress.City,
                    Detail = foundAddress.Detail,
                    District = foundAddress.District,
                    UserId = foundAddress.UserId
                };
            }
        }
    }
}