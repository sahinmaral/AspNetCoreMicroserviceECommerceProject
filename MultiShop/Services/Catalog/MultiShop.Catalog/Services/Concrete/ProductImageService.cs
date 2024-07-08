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
            var productImage = _mapper.Map<ProductImage>(dto);
            await _collection.InsertOneAsync(productImage);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(productImage => productImage.Id == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllAsync()
        {
            var productImages = await _collection.Find(productImage => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(productImages);
        }

        public async Task<GetByProductImageIdDto> GetByIdAsync(string id)
        {
            var productImage = await _collection.Find(productImage => productImage.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductImageIdDto>(productImage);
        }

        public async Task UpdateAsync(UpdateProductImageDto dto)
        {
            var productImage = _mapper.Map<ProductImage>(dto);
            var filter = Builders<ProductImage>.Filter.Eq(productImage => productImage.Id, productImage.Id);
            await _collection.FindOneAndReplaceAsync(filter, productImage);
        }
    }
}
