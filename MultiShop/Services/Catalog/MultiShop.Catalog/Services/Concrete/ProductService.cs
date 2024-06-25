

using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class ProductService : GenericService<Product>, IProductService
    {

        public ProductService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }

        public async Task CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _collection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(product => product.Id == id);
        }

        public async Task<List<ResultProductDto>> GetAllAsync()
        {
            var categories = await _collection.Find(product => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(categories);
        }

        public async Task<GetByProductIdDto> GetByIdAsync(string id)
        {
            var product = await _collection.Find(product => product.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductIdDto>(product);
        }

        public async Task UpdateAsync(UpdateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _collection.FindOneAndReplaceAsync(product => product.Id == product.Id, product);
        }
    }
}
