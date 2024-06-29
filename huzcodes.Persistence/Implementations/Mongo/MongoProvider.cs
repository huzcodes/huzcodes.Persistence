using huzcodes.Persistence.Interfaces.Mongo;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace huzcodes.Persistence.Implementations.Mongo
{
    public class MongoProvider<TDocument>(IConfiguration configuration) : IMongoProvider<TDocument> where TDocument : IMongoProviderEntity
    {
        private readonly IConfiguration _configuration = configuration;
        private IMongoCollection<TDocument>? _collection;
        public async ValueTask CreateAsync(TDocument document,
                                           string appSettingsConnectionString,
                                           string appSettingsDataBaseName,
                                           string appSettingsCollectionName)
        {
            _collection = GetCollection(appSettingsConnectionString,
                                        appSettingsDataBaseName,
                                        appSettingsCollectionName);

            await _collection.InsertOneAsync(document);
        }

        public async ValueTask CreateAsync(List<TDocument> documents,
                                           string appSettingsConnectionString,
                                           string appSettingsDataBaseName,
                                           string appSettingsCollectionName)
        {
            _collection = GetCollection(appSettingsConnectionString,
                                        appSettingsDataBaseName,
                                        appSettingsCollectionName);

            await _collection.InsertManyAsync(documents);
        }

        public async ValueTask<List<TDocument>> GetAsync(string appSettingsConnectionString,
                                                         string appSettingsDataBaseName,
                                                         string appSettingsCollectionName)
        {
            _collection = GetCollection(appSettingsConnectionString,
                                        appSettingsDataBaseName,
                                        appSettingsCollectionName);

            var oResult = await _collection.Find(_ => true).ToListAsync();

            if (oResult != null && oResult.Count > 0)
                return oResult;
            else return default!;
        }

        public async ValueTask<TDocument?> GetAsync(string id,
                                                    string appSettingsConnectionString,
                                                    string appSettingsDataBaseName,
                                                    string appSettingsCollectionName)
        {
            _collection = GetCollection(appSettingsConnectionString,
                                        appSettingsDataBaseName,
                                        appSettingsCollectionName);

            var oResult = await _collection.Find(o => o.Id == id).FirstOrDefaultAsync();

            if (oResult != null)
                return oResult;
            else return default!;
        }

        public async ValueTask RemoveAsync(string id,
                                           string appSettingsConnectionString,
                                           string appSettingsDataBaseName,
                                           string appSettingsCollectionName)
        {
            _collection = GetCollection(appSettingsConnectionString,
                                        appSettingsDataBaseName,
                                        appSettingsCollectionName);

            await _collection.DeleteOneAsync(id);
        }
        public async ValueTask UpdateAsync(string id,
                                           TDocument document,
                                           string appSettingsConnectionString,
                                           string appSettingsDataBaseName,
                                           string appSettingsCollectionName)
        {
            _collection = GetCollection(appSettingsConnectionString,
                                        appSettingsDataBaseName,
                                        appSettingsCollectionName);

            await _collection.ReplaceOneAsync(o => o.Id == id, document);
        }

        private IMongoCollection<TDocument> GetCollection(string appSettingsConnectionString,
                                                          string appSettingsDataBaseName,
                                                          string appSettingsCollectionName)
        {
            if(string.IsNullOrEmpty(appSettingsConnectionString))
                throw new ArgumentNullException("app settings connection string can't be empty, please check that you have added it into app settings and the key you provided is right!");

            if (string.IsNullOrEmpty(appSettingsDataBaseName))
                throw new ArgumentNullException("app settings data base name can't be empty, please check that you have added it into app settings and the key you provided is right!");

            if (string.IsNullOrEmpty(appSettingsCollectionName))
                throw new ArgumentNullException("app settings collection name can't be empty, please check that you have added it into app settings and the key you provided is right!");

            var client = new MongoClient(_configuration[appSettingsConnectionString]);
            if(client == null)
                throw new ArgumentNullException("Connection string error, your connection string is wrong or there is a problem with the connection!");

            var database = client.GetDatabase(_configuration[appSettingsDataBaseName]);
            if (database == null)
                throw new ArgumentNullException("Database error, your DB can't be found!");

            var collection = database.GetCollection<TDocument>(_configuration[appSettingsCollectionName]);

            if (collection == null)
                throw new ArgumentNullException("Collection error, your collection can't be found!");

            return collection;
        }
    }
}
