using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class OfferDiscountService : GenericService<OfferDiscount>, IOfferDiscountService
    {

        public OfferDiscountService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
        }

        public async Task CreateAsync(CreateOfferDiscountDto dto)
        {
            var offerDiscount = _mapper.Map<OfferDiscount>(dto);
            await _collection.InsertOneAsync(offerDiscount);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(offerDiscount => offerDiscount.Id == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllAsync()
        {
            var offerDiscounts = await _collection.Find(offerDiscount => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(offerDiscounts);
        }

        public async Task<GetByOfferDiscountIdDto> GetByIdAsync(string id)
        {
            var offerDiscount = await _collection.Find(offerDiscount => offerDiscount.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByOfferDiscountIdDto>(offerDiscount);
        }

        public async Task UpdateAsync(UpdateOfferDiscountDto dto)
        {
            var offerDiscount = _mapper.Map<OfferDiscount>(dto);
            var filter = Builders<OfferDiscount>.Filter.Eq(offerDiscount => offerDiscount.Id, offerDiscount.Id);
            await _collection.FindOneAndReplaceAsync(filter, offerDiscount);
        }
    }
}
