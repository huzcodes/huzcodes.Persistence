using Dapper.Oracle;
using huzcodes.Persistence.Interfaces;
using huzcodes.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace huzcodes.Persistence.API.Controller.CreateSync
{
    [ApiController]
    [Route("[controller]")]
    public class CreateDataSyncController(IDataProvider dataProvider) : ControllerBase
    {
        private readonly IDataProvider _dataProvider = dataProvider;
        const string connectionStringKey = "DefaultConnectionString";
        const string createProcedureName = "Sp_CreateData";

        [HttpPost("/sqlCreateSync")]
        public ActionResult CreateSqlData([FromBody] DataModel dataModel)
        {
            var oParameter = new
            {
                Id = dataModel.Id,
                ProductCreationDate = dataModel.Date,
                PriceWithoutTax = dataModel.PriceWithoutTax,
                ProductName = dataModel.ProductName
            };

            _dataProvider.ExecuteData(createProcedureName,
                                      oParameter,
                                      connectionStringKey);
            return Ok();
        }

        [HttpPost("/oracleCreateSync")]
        public ActionResult CreateOracleData([FromBody] DataModel dataModel)
        {
            var oParameter = new OracleDynamicParameters();
            oParameter.Add("Id", dataModel.Id, OracleMappingType.Int32, ParameterDirection.Input);
            oParameter.Add("ProductCreationDate", dataModel.Date, OracleMappingType.Date, ParameterDirection.Input);
            oParameter.Add("PriceWithoutTax", dataModel.PriceWithoutTax, OracleMappingType.Decimal, ParameterDirection.Input);
            oParameter.Add("ProductName", dataModel.ProductName, OracleMappingType.Varchar2, ParameterDirection.Input);

            _dataProvider.ExecuteData(createProcedureName,
                                      oParameter,
                                      connectionStringKey,
                                      storageProvider: DataStorageProvider.Oracle);
            return Ok();
        }
    }
}
