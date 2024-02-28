using huzcodes.Persistence.Models;

namespace huzcodes.Persistence.Interfaces
{
    //TODO summary
    public interface IDataProvider
    {
        //TODO summary explaination
        ValueTask<IEnumerable<TResult>> LoadDataAsync<TResult, UParameters>(string storedProcedureName,
                                                                            UParameters storedProcedureParameters,
                                                                            string appSettingsConnectionStringKey,
                                                                            int storageProvider = DataStorageProvider.Sql);
    }
}
