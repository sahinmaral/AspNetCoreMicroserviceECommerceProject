using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class ProductDetailService : GenericService<ProductDetail>, IProductDetailService
    {
        public ProductDetailService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
        }

        public async Task CreateAsync(CreateProductDetailDto dto)
        {
            var category = _mapper.Map<ProductDetail>(dto);
            await _collection.InsertOneAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(category => category.Id == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllAsync()
        {
            var categories = await _collection.Find(category => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(categories);
        }

        public async Task<GetByProductDetailIdDto> GetByIdAsync(string id)
        {
            var category = await _collection.Find(category => category.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductDetailIdDto>(category);
        }

        public async Task UpdateAsync(UpdateProductDetailDto dto)
        {
            var category = _mapper.Map<ProductDetail>(dto);
            await _collection.FindOneAndReplaceAsync(category => category.Id == category.Id, category);
        }
    }
}
