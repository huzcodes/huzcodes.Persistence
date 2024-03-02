using huzcodes.Persistence.Models;

namespace huzcodes.Persistence.Interfaces
{
    public interface IDataProvider
    {
        /// <summary>
        /// this function is for Loading/Reading data <b>Async</b> from Sql, Oracle db using stored procedures,
        /// by defining the name of the stored procedure created in db, and the parameters for this procedure,
        /// and the db key for the connection string from app.settings,
        /// and to define the db provider if Sql or Oracle,
        /// and returning IEnumerable of your result type that you are passing to the function.
        /// </summary>
        /// <typeparam name="TResult">type of the expected return result from procedure as IEnumerable type of your class</typeparam>
        /// <typeparam name="UParameters">type of the class the continas your parameters in case of Sql, and for Oracle you need to pass OracleDynamicParameters</typeparam>
        /// <param name="storedProcedureName">the name of your stored procedure</param>
        /// <param name="storedProcedureParameters">the object that contains your stored procedure's parameters</param>
        /// <param name="appSettingsConnectionStringKey">the key of your connection string from appSettings.json</param>
        /// <param name="storageProvider">the provider that you are using Sql or Oracle passing it using this enum: DataStorageProvider by default it is SQL</param>
        /// <returns>ValueTask IEnumerable of type generic T</returns>
        ValueTask<IEnumerable<TResult>> LoadDataAsync<TResult, UParameters>(string storedProcedureName,
                                                                            string appSettingsConnectionStringKey,
                                                                            UParameters storedProcedureParameters = default!,
                                                                            int storageProvider = DataStorageProvider.Sql);

        /// <summary>
        /// this function is for Loading/Reading data <b>Sync</b> from Sql, Oracle db using stored procedures,
        /// by defining the name of the stored procedure created in db, and the parameters for this procedure,
        /// and the db key for the connection string from app.settings,
        /// and to define the db provider if Sql or Oracle,
        /// and returning IEnumerable of your result type that you are passing to the function.
        /// </summary>
        /// <typeparam name="TResult">type of the expected return result from procedure as IEnumerable type of your class</typeparam>
        /// <typeparam name="UParameters">type of the class the continas your parameters in case of Sql, and for Oracle you need to pass OracleDynamicParameters</typeparam>
        /// <param name="storedProcedureName">the name of your stored procedure</param>
        /// <param name="storedProcedureParameters">the object that contains your stored procedure's parameters</param>
        /// <param name="appSettingsConnectionStringKey">the key of your connection string from appSettings.json</param>
        /// <param name="storageProvider">the provider that you are using Sql or Oracle passing it using this enum: DataStorageProvider by default it is SQL</param>
        /// <returns>IEnumerable of type generic T</returns>
        IEnumerable<TResult> LoadData<TResult, UParameters>(string storedProcedureName,
                                                            string appSettingsConnectionStringKey,
                                                            UParameters storedProcedureParameters = default!,
                                                            int storageProvider = DataStorageProvider.Sql);

        /// <summary>
        /// this function is for Inserting/Creating data <b>Async</b> for Sql, Oracle db using stored procedures,
        /// by defining the name of the stored procedure created in db, and the parameters for this procedure,
        /// and the db key for the connection string from app.settings,
        /// and to define the db provider if Sql or Oracle,
        /// and returning IEnumerable of your result type that you are passing to the function.
        /// </summary>
        /// <typeparam name="TResult">type of the expected return result from procedure as IEnumerable type of your class</typeparam>
        /// <typeparam name="UParameters">type of the class the continas your parameters in case of Sql, and for Oracle you need to pass OracleDynamicParameters</typeparam>
        /// <param name="storedProcedureName">the name of your stored procedure</param>
        /// <param name="storedProcedureParameters">the object that contains your stored procedure's parameters</param>
        /// <param name="appSettingsConnectionStringKey">the key of your connection string from appSettings.json</param>
        /// <param name="storageProvider">the provider that you are using Sql or Oracle passing it using this enum: DataStorageProvider by default it is SQL</param>
        /// <returns>ValueTask int</returns>
        ValueTask<int> ExecuteDataAsync<UParameters>(string storedProcedureName,
                                                     UParameters storedProcedureParameters,
                                                     string appSettingsConnectionStringKey,
                                                     int storageProvider = DataStorageProvider.Sql);

        /// <summary>
        /// this function is for Inserting/Creating data <b>Sync</b> for Sql, Oracle db using stored procedures,
        /// by defining the name of the stored procedure created in db, and the parameters for this procedure,
        /// and the db key for the connection string from app.settings,
        /// and to define the db provider if Sql or Oracle.
        /// </summary>
        /// <typeparam name="TResult">type of the expected return result from procedure as IEnumerable type of your class</typeparam>
        /// <typeparam name="UParameters">type of the class the continas your parameters in case of Sql, and for Oracle you need to pass OracleDynamicParameters</typeparam>
        /// <param name="storedProcedureName">the name of your stored procedure</param>
        /// <param name="storedProcedureParameters">the object that contains your stored procedure's parameters</param>
        /// <param name="appSettingsConnectionStringKey">the key of your connection string from appSettings.json</param>
        /// <param name="storageProvider">the provider that you are using Sql or Oracle passing it using this enum: DataStorageProvider by default it is SQL</param>
        /// <returns>int</returns>
        int ExecuteData<UParameters>(string storedProcedureName,
                                     UParameters storedProcedureParameters,
                                     string appSettingsConnectionStringKey,
                                     int storageProvider = DataStorageProvider.Sql);
    }
}
