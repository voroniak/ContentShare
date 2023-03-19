using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Notes.API.Entities
{
    public class EntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [BsonDateTimeOptions]
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
    }
}
