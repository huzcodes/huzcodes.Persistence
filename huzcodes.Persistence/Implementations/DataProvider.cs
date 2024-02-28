using Dapper;
using huzcodes.Persistence.Interfaces;
using huzcodes.Persistence.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace huzcodes.Persistence.Implementations
{
    //TODO thinking about the name, leave it like that or change it
    // other options IServiceProvider, IPersistenceServices
    public class DataProvider(IConfiguration configuration) : IDataProvider
    {
        private readonly IConfiguration _configuration = configuration;
        public async ValueTask<IEnumerable<TResult>> LoadDataAsync<TResult, UParameters>(string storedProcedureName,
                                                                                         UParameters storedProcedureParameters,
                                                                                         string appSettingsConnectionStringKey,
                                                                                         int storageProvider = DataStorageProvider.Sql)
        {
            try
            {
                switch (storageProvider)
                {
                    case DataStorageProvider.Sql:
                        {
                            using IDbConnection connection = new SqlConnection(_configuration[appSettingsConnectionStringKey]);
                            return await connection.QueryAsync<TResult>(storedProcedureName,
                                                                        storedProcedureParameters,
                                                                        commandType: CommandType.StoredProcedure);
                        }
                    case DataStorageProvider.Oracle:
                        {
                            using IDbConnection connection = new OracleConnection(_configuration[appSettingsConnectionStringKey]);
                            return await connection.QueryAsync<TResult>(storedProcedureName,
                                                                        storedProcedureParameters,
                                                                        commandType: CommandType.StoredProcedure);
                        }
                    default: throw new Exception("This provider is not supported, only sql server and oracle are supported for now!");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message,
                                    exception.InnerException);
            }
        }
    }
}
