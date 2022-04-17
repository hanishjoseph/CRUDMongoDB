using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUDMongoDB.Models
{
    public class Submission
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string UserId { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
