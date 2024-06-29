using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Newtonsoft.Json;

namespace huzcodes.Persistence.Interfaces.Mongo
{
    public interface IMongoProviderEntity
    {
        /// <summary>
        /// Id property, object type id for mongo identifier BsonType
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonProperty("id")]
        public string? Id { get; set; }
    }
}
