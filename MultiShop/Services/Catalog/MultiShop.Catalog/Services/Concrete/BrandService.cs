using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.Brand;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class BrandService : GenericService<Brand>, IBrandService
    {

        public BrandService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public async Task CreateAsync(CreateBrandDto dto)
        {
            var category = _mapper.Map<Brand>(dto);
            await _collection.InsertOneAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(category => category.Id == id);
        }

        public async Task<List<ResultBrandDto>> GetAllAsync()
        {
            var categories = await _collection.Find(category => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(categories);
        }

        public async Task<GetByBrandIdDto> GetByIdAsync(string id)
        {
            var category = await _collection.Find(category => category.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByBrandIdDto>(category);
        }

        public async Task UpdateAsync(UpdateBrandDto dto)
        {
            var category = _mapper.Map<Brand>(dto);
            var filter = Builders<Brand>.Filter.Eq(category => category.Id, category.Id);
            await _collection.FindOneAndReplaceAsync(filter, category);
        }
    }
}
