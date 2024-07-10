using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities.Concrete
{
    public class Product: IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
        public List<string> AdditionalImageUrls { get; set; }
    }
}
