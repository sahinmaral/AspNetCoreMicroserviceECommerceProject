using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Dtos.Contact;
using MultiShop.Catalog.Entities.Concrete;
using MultiShop.Catalog.Services.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public class ContactService : GenericService<Contact>, IContactService
    {

        public ContactService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions) : base(mapper, databaseSettingOptions)
        {
            _collection = _database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
        }

        public async Task CreateAsync(CreateContactDto dto)
        {
            var about = _mapper.Map<Contact>(dto);
            about.SendDate = DateTime.Now;
            await _collection.InsertOneAsync(about);
        }

        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(about => about.Id == id);
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            var abouts = await _collection.Find(about => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(abouts);
        }

        public async Task<GetByContactIdDto> GetByIdAsync(string id)
        {
            var about = await _collection.Find(about => about.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByContactIdDto>(about);
        }

        public async Task UpdateAsync(UpdateContactDto dto)
        {
            var about = _mapper.Map<Contact>(dto);
            var filter = Builders<Contact>.Filter.Eq(about => about.Id, about.Id);
            await _collection.FindOneAndReplaceAsync(filter, about);
        }
    }
}
