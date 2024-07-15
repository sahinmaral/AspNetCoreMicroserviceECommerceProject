using MediatR;

using MultiShop.Order.Application.Features.Addresses.Results;
using MultiShop.Order.Application.Services.Repositories;
using MultiShop.Order.Domain.Entities.Concrete;

namespace MultiShop.Order.Application.Features.Addresses.Queries.GetAll
{
    public class GetAllQuery: IRequest<List<GetAddressQueryResult>>
    {
        public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<GetAddressQueryResult>>
        {
            private readonly IRepository<Address> _repository;

            public GetAllQueryHandler(IRepository<Address> repository)
            {
                _repository = repository;
            }

            public async Task<List<GetAddressQueryResult>> Handle(GetAllQuery request, CancellationToken cancellationToken)
            {
                var foundAddresses = await _repository.GetAllAsync();

                return foundAddresses.Select((address) =>
                {
                    return new GetAddressQueryResult
                    {
                        Id = address.Id,
                        City = address.City,
                        Detail1 = address.Detail1,
                        Detail2 = address.Detail2,
                        District = address.District,
                        UserId = address.UserId,
                        Name = address.Name,
                        Surname = address.Surname,
                        Email = address.Email,
                        PhoneNumber = address.PhoneNumber,
                    };
                }).ToList();
            }
        }
    }
}
