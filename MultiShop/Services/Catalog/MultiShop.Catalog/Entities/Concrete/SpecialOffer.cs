using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Entities.Concrete
{
    public class SpecialOffer: IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
