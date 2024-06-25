using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class ProductImageService : GenericService<ProductImage>, IProductImageService
    {

        public ProductImageService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        }

        public async Task CreateAsync(CreateProductImageDto dto)
        {
            var category = _mapper.Map<ProductImage>(dto);
            await _collection.InsertOneAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(category => category.Id == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllAsync()
        {
            var categories = await _collection.Find(category => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(categories);
        }

        public async Task<GetByProductImageIdDto> GetByIdAsync(string id)
        {
            var category = await _collection.Find(category => category.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductImageIdDto>(category);
        }

        public async Task UpdateAsync(UpdateProductImageDto dto)
        {
            var category = _mapper.Map<ProductImage>(dto);
            await _collection.FindOneAndReplaceAsync(category => category.Id == category.Id, category);
        }
    }
}
