using AutoMapper;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MultiShop.Catalog.Entities.Abstract;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.Concrete
{
    public abstract class GenericService<T> where T:class,IEntity
    {
        protected IMongoCollection<T> _collection;
        protected readonly IMapper _mapper;
        protected readonly DatabaseSettings _databaseSettings;
        protected readonly IMongoDatabase _database;
        public GenericService(IMapper mapper, IOptions<DatabaseSettings> databaseSettingOptions)
        {
            _databaseSettings = databaseSettingOptions.Value;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            _database = client.GetDatabase(_databaseSettings.DatabaseName);
            _mapper = mapper;
        }

    }
}
