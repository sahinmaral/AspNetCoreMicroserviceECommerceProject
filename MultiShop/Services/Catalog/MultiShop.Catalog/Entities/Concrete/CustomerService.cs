using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities.Concrete
{
    public class CustomerService : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
