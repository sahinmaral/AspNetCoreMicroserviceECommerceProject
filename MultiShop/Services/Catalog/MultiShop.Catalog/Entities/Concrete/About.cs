using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities.Concrete
{
    public class About : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
