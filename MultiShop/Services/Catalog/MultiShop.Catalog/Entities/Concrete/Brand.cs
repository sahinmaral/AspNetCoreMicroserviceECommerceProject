using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities.Concrete
{
    public class Brand: IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
