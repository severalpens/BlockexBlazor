using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlockexBlazor.Models
{
    [BsonIgnoreExtraElements]
    public class SourceHeader
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

       // [BsonElement("Blockchain")]
        public string blockchain { get; set; }
        public string source { get; set; }
    }
}