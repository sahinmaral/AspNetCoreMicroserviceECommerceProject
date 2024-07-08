using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.About;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class AboutService : GenericService<About>, IAboutService
    {

        public AboutService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<About>(_databaseSettings.AboutCollectionName);
        }

        public async Task CreateAsync(CreateAboutDto dto)
        {
            var about = _mapper.Map<About>(dto);
            await _collection.InsertOneAsync(about);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(about => about.Id == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var abouts = await _collection.Find(about => true).ToListAsync();
            return _mapper.Map<List<ResultAboutDto>>(abouts);
        }

        public async Task<GetByAboutIdDto> GetByIdAsync(string id)
        {
            var about = await _collection.Find(about => about.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByAboutIdDto>(about);
        }

        public async Task UpdateAsync(UpdateAboutDto dto)
        {
            var about = _mapper.Map<About>(dto);
            var filter = Builders<About>.Filter.Eq(about => about.Id, about.Id);
            await _collection.FindOneAndReplaceAsync(filter, about);
        }
    }
}
