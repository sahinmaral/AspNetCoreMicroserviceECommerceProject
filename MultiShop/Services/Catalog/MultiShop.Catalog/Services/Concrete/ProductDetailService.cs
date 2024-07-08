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
            var productDetail = _mapper.Map<ProductDetail>(dto);
            await _collection.InsertOneAsync(productDetail);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(productDetail => productDetail.Id == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllAsync()
        {
            var productDetails = await _collection.Find(productDetail => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<GetByProductDetailIdDto> GetByIdAsync(string id)
        {
            var productDetail = await _collection.Find(productDetail => productDetail.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByProductDetailIdDto>(productDetail);
        }

        public async Task UpdateAsync(UpdateProductDetailDto dto)
        {
            var productDetail = _mapper.Map<ProductDetail>(dto);
            var filter = Builders<ProductDetail>.Filter.Eq(productDetail => productDetail.Id, productDetail.Id);
            await _collection.FindOneAndReplaceAsync(filter, productDetail);
        }
    }
}
