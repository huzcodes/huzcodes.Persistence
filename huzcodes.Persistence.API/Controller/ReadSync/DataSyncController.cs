using Dapper.Oracle;
using huzcodes.Persistence.Interfaces;
using huzcodes.Persistence.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace huzcodes.Persistence.API
{
    [ApiController]
    [Route("[controller]")]
    public class DataSyncController(IDataProvider dataProvider) : ControllerBase
    {
        private readonly IDataProvider _dataProvider = dataProvider;
        const string connectionStringKey = "DefaultConnectionString";
        const string readProcedureName = "Sp_ReadData";
        const string createProcedureName = "Sp_CreateData";

        [HttpGet("/sqlSync")]
        public ActionResult<IEnumerable<DataModel>> GetSqlData()
        {
            var oData = _dataProvider.LoadData<DataModel, dynamic>(readProcedureName,
                                                                   connectionStringKey);
            return Ok(oData);
        }

        [HttpGet("/sqlByIdSync")]
        public ActionResult<DataModel> GetSqlDataById(int id)
        {
            var oParameter = new
            {
                Id = id
            };
            var oData = _dataProvider.LoadData<DataModel, dynamic>(readProcedureName,
                                                                   connectionStringKey,
                                                                   oParameter);
            return Ok(oData.FirstOrDefault());
        }

        [HttpGet("/oracleSync")]
        public ActionResult<IEnumerable<DataModel>> GetOracleData()
        {
            var oData = _dataProvider.LoadData<DataModel, dynamic>(readProcedureName,
                                                                   connectionStringKey,
                                                                   storageProvider: DataStorageProvider.Oracle);
            return Ok(oData);
        }

        [HttpGet("/oracleByIdSync")]
        public ActionResult<DataModel> GetOracleDataById(int id)
        {
            var oParameter = new OracleDynamicParameters();
            oParameter.Add("Id", id, OracleMappingType.Int32, ParameterDirection.Input);
            oParameter.Add(name: "DataResult", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);

            var oData = _dataProvider.LoadData<DataModel, dynamic>(readProcedureName,
                                                                   connectionStringKey,
                                                                   oParameter,
                                                                   DataStorageProvider.Oracle);
            return Ok(oData.FirstOrDefault());
        }
    }
}
