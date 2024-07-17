using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {

        public CategoryService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _collection.InsertOneAsync(category);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(category => category.Id == id);
        }

        public async Task<int> CountAsync()
        {
            var count = await _collection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
            return Convert.ToInt16(count);
        }

        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            var categories = await _collection.Find(category => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<GetByCategoryIdDto> GetByIdAsync(string id)
        {
            var category = await _collection.Find(category => category.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByCategoryIdDto>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            var filter = Builders<Category>.Filter.Eq(category => category.Id, category.Id);
            await _collection.FindOneAndReplaceAsync(filter, category);
        }
    }
}
