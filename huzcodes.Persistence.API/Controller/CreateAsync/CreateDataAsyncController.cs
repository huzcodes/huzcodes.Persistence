using Dapper.Oracle;
using huzcodes.Persistence.Interfaces;
using huzcodes.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace huzcodes.Persistence.API.Controller.CreateAsync
{
    [ApiController]
    [Route("[controller]")]
    public class CreateDataAsyncController(IDataProvider dataProvider) : ControllerBase
    {
        private readonly IDataProvider _dataProvider = dataProvider;
        const string connectionStringKey = "DefaultConnectionString";
        const string createProcedureName = "Sp_CreateData";

        [HttpPost("/sqlCreateAsync")]
        public async Task<ActionResult> CreateSqlData([FromBody] DataModel dataModel)
        {
            var oParameter = new
            {
                Id = dataModel.Id,
                ProductCreationDate = dataModel.Date,
                PriceWithoutTax = dataModel.PriceWithoutTax,
                ProductName = dataModel.ProductName
            };

            await _dataProvider.ExecuteDataAsync(createProcedureName,
                                                 oParameter,
                                                 connectionStringKey);
            return Ok();
        }

        [HttpPost("/oracleCreateAsync")]
        public async Task<ActionResult> CreateOracleData([FromBody] DataModel dataModel)
        {
            var oParameter = new OracleDynamicParameters();
            oParameter.Add("Id", dataModel.Id, OracleMappingType.Int32, ParameterDirection.Input);
            oParameter.Add("ProductCreationDate", dataModel.Date, OracleMappingType.Date, ParameterDirection.Input);
            oParameter.Add("PriceWithoutTax", dataModel.PriceWithoutTax, OracleMappingType.Decimal, ParameterDirection.Input);
            oParameter.Add("ProductName", dataModel.ProductName, OracleMappingType.Varchar2, ParameterDirection.Input);

            await _dataProvider.ExecuteDataAsync(createProcedureName,
                                                 oParameter,
                                                 connectionStringKey,
                                                 storageProvider: DataStorageProvider.Oracle);
            return Ok();
        }
    }
}
