using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class SpecialOfferService : GenericService<SpecialOffer>, ISpecialOfferService
    {

        public SpecialOfferService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
        }

        public async Task CreateAsync(CreateSpecialOfferDto dto)
        {
            var specialOffer = _mapper.Map<SpecialOffer>(dto);
            await _collection.InsertOneAsync(specialOffer);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(specialOffer => specialOffer.Id == id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllAsync()
        {
            var specialOffers = await _collection.Find(specialOffer => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(specialOffers);
        }

        public async Task<GetBySpecialOfferIdDto> GetByIdAsync(string id)
        {
            var specialOffer = await _collection.Find(specialOffer => specialOffer.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetBySpecialOfferIdDto>(specialOffer);
        }

        public async Task UpdateAsync(UpdateSpecialOfferDto dto)
        {
            var specialOffer = _mapper.Map<SpecialOffer>(dto);
            var filter = Builders<SpecialOffer>.Filter.Eq(specialOffer => specialOffer.Id, specialOffer.Id);
            await _collection.FindOneAndReplaceAsync(filter, specialOffer);
        }
    }
}
