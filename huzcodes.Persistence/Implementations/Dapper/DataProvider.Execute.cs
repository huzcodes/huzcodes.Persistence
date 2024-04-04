using Dapper;
using huzcodes.Persistence.Models;
using Microsoft.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace huzcodes.Persistence.Implementations
{
    public partial class DataProvider
    {
        public async ValueTask<int> ExecuteDataAsync<UParameters>(string storedProcedureName,
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
                            return await connection.ExecuteAsync(storedProcedureName,
                                                                 storedProcedureParameters,
                                                                 commandType: CommandType.StoredProcedure);
                        }
                    case DataStorageProvider.Oracle:
                        {
                            using IDbConnection connection = new OracleConnection(_configuration[appSettingsConnectionStringKey]);
                            return await connection.ExecuteAsync(storedProcedureName,
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

        public int ExecuteData<UParameters>(string storedProcedureName,
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
                            return connection.Execute(storedProcedureName,
                                                      storedProcedureParameters,
                                                      commandType: CommandType.StoredProcedure);
                        }
                    case DataStorageProvider.Oracle:
                        {
                            using IDbConnection connection = new OracleConnection(_configuration[appSettingsConnectionStringKey]);
                            return connection.Execute(storedProcedureName,
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
