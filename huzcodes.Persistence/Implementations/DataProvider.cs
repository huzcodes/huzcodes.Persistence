using huzcodes.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;

namespace huzcodes.Persistence.Implementations
{
    //TODO thinking about the name, leave it like that or change it
    // other options IServiceProvider, IPersistenceServices
    public partial class DataProvider(IConfiguration configuration) : IDataProvider
    {
        private readonly IConfiguration _configuration = configuration;
    }
}
