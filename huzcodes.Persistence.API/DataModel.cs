using huzcodes.Persistence.API.Models;

namespace huzcodes.Persistence.API
{
    public class DataModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public int PriceWithoutTax { get; set; }

        public decimal Price => 32 + (int)(PriceWithoutTax / 0.5556);

        public string ProductName { get; set; } = string.Empty;
    }

    public class MongoDataModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
    }

    public class MongoDataModelResponse : MongoDataModel
    {
        public string Id { get; set; }

        public MongoDataModelResponse(MongoDocumentTest dataModel)
        {
            Id = dataModel.Id;
            Name = dataModel.Name;
            Description = dataModel.Description;
            Major = dataModel.Major;
        }
    }
}
