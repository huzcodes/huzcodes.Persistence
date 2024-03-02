using Dapper.Oracle;
using huzcodes.Persistence.Interfaces;
using huzcodes.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace huzcodes.Persistence.API.Controller.ReadAsync
{
    [ApiController]
    [Route("[controller]")]
    public class DataAsyncController(IDataProvider dataProvider) : ControllerBase
    {
        private readonly IDataProvider _dataProvider = dataProvider;
        const string connectionStringKey = "DefaultConnectionString";
        const string readProcedureName = "Sp_ReadData";

        [HttpGet("/sqlAsync")]
        public async Task<ActionResult<IEnumerable<DataModel>>> GetSqlData()
        {
            var oData = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName,
                                                                              connectionStringKey);
            return Ok(oData);
        }

        [HttpGet("/sqlByIdAsync")]
        public async Task<ActionResult<DataModel>> GetSqlDataById(int id)
        {
            var oParameter = new
            {
                Id = id
            };
            var oData = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName,
                                                                              connectionStringKey,
                                                                              oParameter);
            return Ok(oData.FirstOrDefault());
        }

        [HttpGet("/oracleAsync")]
        public async Task<ActionResult<IEnumerable<DataModel>>> GetOracleData()
        {
            var oData = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName,
                                                                              connectionStringKey,
                                                                              storageProvider: DataStorageProvider.Oracle);
            return Ok(oData);
        }

        [HttpGet("/oracleByIdAsync")]
        public async Task<ActionResult<DataModel>> GetOracleDataById(int id)
        {
            var oParameter = new OracleDynamicParameters();
            oParameter.Add("Id", id, OracleMappingType.Int32, ParameterDirection.Input);
            oParameter.Add(name: "DataResult", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            var oData = await _dataProvider.LoadDataAsync<DataModel, dynamic>(readProcedureName,
                                                                              connectionStringKey,
                                                                              oParameter,
                                                                              DataStorageProvider.Oracle);
            return Ok(oData.FirstOrDefault());
        }
    }
}
