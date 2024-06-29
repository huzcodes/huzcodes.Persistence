using huzcodes.Persistence.Interfaces.Mongo;
using Newtonsoft.Json;

namespace huzcodes.Persistence.API.Models
{
    public class MongoDocumentTest : IMongoProviderEntity
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("major")]
        public string Major { get; set; } = string.Empty;

        public MongoDocumentTest(MongoDataModel dataModel)
        {
            Name = dataModel.Name;
            Description = dataModel.Description;
            Major = dataModel.Major;
        }
    }
}
