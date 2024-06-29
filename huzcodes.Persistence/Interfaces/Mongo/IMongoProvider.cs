namespace huzcodes.Persistence.Interfaces.Mongo
{
    public interface IMongoProvider<TDocument> where TDocument : IMongoProviderEntity
    {
        /// <summary>
        /// This function is used for reading list of records for a specific mongo collection,
        /// by returning List of your result type (Generic) that you are passing to the function.
        /// </summary>
        /// <param name="appSettingsConnectionString">The key of your mongo connection string from appSettings.json</param>
        /// <param name="appSettingsDataBaseName">The key of your mongo Database name from appSettings.json</param>
        /// <param name="appSettingsCollectionName">The key of your mongo collection name from appSettings.json</param>
        /// <returns>List of TDocument</returns>
        ValueTask<List<TDocument>> GetAsync(string appSettingsConnectionString,
                                            string appSettingsDataBaseName,
                                            string appSettingsCollectionName);
        /// <summary>
        /// This function is used for reading record by id for a specific mongo collection,
        /// by returning single item/record of your result type (Generic) that you are passing to the function.
        /// </summary>
        /// <param name="id">The id of the item/record that you want to read.</param>
        /// <param name="appSettingsConnectionString">The key of your mongo connection string from appSettings.json</param>
        /// <param name="appSettingsDataBaseName">The key of your mongo Database name from appSettings.json</param>
        /// <param name="appSettingsCollectionName">The key of your mongo collection name from appSettings.json</param>
        /// <returns>TDocument</returns>
        ValueTask<TDocument?> GetAsync(string id,
                                       string appSettingsConnectionString,
                                       string appSettingsDataBaseName,
                                       string appSettingsCollectionName);
        /// <summary>
        /// This function is used for creating/inserting new record into a specific mongo collection.
        /// </summary>
        /// <param name="document">The object that needs to be inserted/created.</param>
        /// <param name="appSettingsConnectionString">The key of your mongo connection string from appSettings.json</param>
        /// <param name="appSettingsDataBaseName">The key of your mongo Database name from appSettings.json</param>
        /// <param name="appSettingsCollectionName">The key of your mongo collection name from appSettings.json</param>
        /// <returns>void</returns>
        ValueTask CreateAsync(TDocument document,
                              string appSettingsConnectionString,
                              string appSettingsDataBaseName,
                              string appSettingsCollectionName);
        /// <summary>
        /// This function is used for creating/inserting list of new records into a specific mongo collection.
        /// </summary>
        /// <param name="documents">The List of objects that needs to be inserted/created.</param>
        /// <param name="appSettingsConnectionString">The key of your mongo connection string from appSettings.json</param>
        /// <param name="appSettingsDataBaseName">The key of your mongo Database name from appSettings.json</param>
        /// <param name="appSettingsCollectionName">The key of your mongo collection name from appSettings.json</param>
        /// <returns>void</returns>
        ValueTask CreateAsync(List<TDocument> documents,
                              string appSettingsConnectionString,
                              string appSettingsDataBaseName,
                              string appSettingsCollectionName);
        /// <summary>
        /// This function is used for updating/replacing exist record into a specific mongo collection.
        /// </summary>
        /// <param name="id">The id of the object that needs to be updated.</param>
        /// <param name="document">The object that needs to be updated/replaced.</param>
        /// <param name="appSettingsConnectionString">The key of your mongo connection string from appSettings.json</param>
        /// <param name="appSettingsDataBaseName">The key of your mongo Database name from appSettings.json</param>
        /// <param name="appSettingsCollectionName">The key of your mongo collection name from appSettings.json</param>
        /// <returns>void</returns>
        ValueTask UpdateAsync(string id,
                              TDocument document,
                              string appSettingsConnectionString,
                              string appSettingsDataBaseName,
                              string appSettingsCollectionName);
        /// <summary>
        /// This function is used for deleting/removing exist record from a specific mongo collection.
        /// </summary>
        /// <param name="id">The id of the object that needs to be deleted.</param>
        /// <param name="appSettingsConnectionString">The key of your mongo connection string from appSettings.json</param>
        /// <param name="appSettingsDataBaseName">The key of your mongo Database name from appSettings.json</param>
        /// <param name="appSettingsCollectionName">The key of your mongo collection name from appSettings.json</param>
        /// <returns></returns>
        ValueTask RemoveAsync(string id,
                              string appSettingsConnectionString,
                              string appSettingsDataBaseName,
                              string appSettingsCollectionName);
    }
}
