using huzcodes.Persistence.API.Models;
using huzcodes.Persistence.Interfaces.Mongo;
using Microsoft.AspNetCore.Mvc;

namespace huzcodes.Persistence.API.Controller.Mongoz
{
    [Route("[controller]")]
    [ApiController]
    public class MongoController(IMongoProvider<MongoDocumentTest> provider) : ControllerBase
    {
        private readonly IMongoProvider<MongoDocumentTest> _provider = provider;
        const string ConnectionStringKey = "Mongo:ConnectionString";
        const string DataBaseNameKey = "Mongo:MongoDbName";
        const string CollectionNameKey = "Mongo:MongoCollectionName";

        [HttpPost("/create")]
        public async Task<ActionResult> CreateMongo([FromBody] MongoDataModel dataModel)
        {
            var oData = new MongoDocumentTest(dataModel);
            await _provider.CreateAsync(oData,
                                        ConnectionStringKey,
                                        DataBaseNameKey,
                                        CollectionNameKey);
            return Ok();
        }

        [HttpGet("/read")]
        public async Task<ActionResult<List<MongoDataModelResponse>>> ReadMongo()
        {
            var oDataResult = await _provider.GetAsync(ConnectionStringKey,
                                                   DataBaseNameKey,
                                                   CollectionNameKey);
            var oResult = oDataResult.Select(o => new MongoDataModelResponse(o)).ToList();
            return Ok(oResult);
        }

        [HttpGet("/readById/{id}")]
        public async Task<ActionResult<List<MongoDataModelResponse>>> ReadMongoById(string id)
        {
            var oDataResult = await _provider.GetAsync(id,
                                                       ConnectionStringKey,
                                                       DataBaseNameKey,
                                                       CollectionNameKey);
            var oResult = new MongoDataModelResponse(oDataResult!);
            return Ok(oResult);
        }

        [HttpPut("/update/{id}")]
        public async Task<ActionResult> UpdateMongo([FromBody] MongoDataModel dataModel, string id)
        {
            var oData = new MongoDocumentTest(dataModel);
            await _provider.UpdateAsync(id,
                                        oData,
                                        ConnectionStringKey,
                                        DataBaseNameKey,
                                        CollectionNameKey);
            return Ok();
        }

        [HttpDelete("/delete/{id}")]
        public async Task<ActionResult> DeleteMongo(string id)
        {
             await _provider.RemoveAsync(id,
                                         ConnectionStringKey,
                                         DataBaseNameKey,
                                         CollectionNameKey);
            return Ok();
        }
    }
}
