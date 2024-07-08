using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.CustomerService;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class CustomerServiceService : GenericService<CustomerService>, ICustomerServiceService
    {
        public CustomerServiceService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<CustomerService>(_databaseSettings.CustomerServiceCollectionName);
        }

        public async Task CreateAsync(CreateCustomerServiceDto dto)
        {
            var productDetail = _mapper.Map<CustomerService>(dto);
            await _collection.InsertOneAsync(productDetail);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(productDetail => productDetail.Id == id);
        }

        public async Task<List<ResultCustomerServiceDto>> GetAllAsync()
        {
            var productDetails = await _collection.Find(productDetail => true).ToListAsync();
            return _mapper.Map<List<ResultCustomerServiceDto>>(productDetails);
        }

        public async Task<GetByCustomerServiceIdDto> GetByIdAsync(string id)
        {
            var productDetail = await _collection.Find(productDetail => productDetail.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByCustomerServiceIdDto>(productDetail);
        }

        public async Task UpdateAsync(UpdateCustomerServiceDto dto)
        {
            var customerService = _mapper.Map<CustomerService>(dto);
            var filter = Builders<CustomerService>.Filter.Eq(customerService => customerService.Id, customerService.Id);
            await _collection.FindOneAndReplaceAsync(filter, customerService);
        }
    }
}
