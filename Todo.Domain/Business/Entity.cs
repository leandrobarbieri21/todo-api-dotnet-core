using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todo.Domain.Business
{
    public class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
