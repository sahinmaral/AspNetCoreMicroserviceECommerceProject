using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class FeatureSliderService : GenericService<FeatureSlider>, IFeatureSliderService
    {

        public FeatureSliderService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
        }

        public async Task CreateAsync(CreateFeatureSliderDto dto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(dto);
            await _collection.InsertOneAsync(featureSlider);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(featureSlider => featureSlider.Id == id);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllAsync()
        {
            var featureSliders = await _collection.Find(featureSlider => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(featureSliders);
        }

        public async Task<GetByFeatureSliderIdDto> GetByIdAsync(string id)
        {
            var featureSlider = await _collection.Find(featureSlider => featureSlider.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByFeatureSliderIdDto>(featureSlider);
        }

        public async Task UpdateAsync(UpdateFeatureSliderDto dto)
        {
            var featureSlider = _mapper.Map<FeatureSlider>(dto);
            var filter = Builders<FeatureSlider>.Filter.Eq(c => c.Id, featureSlider.Id);
            await _collection.FindOneAndReplaceAsync(filter, featureSlider);
        }
    }
}
