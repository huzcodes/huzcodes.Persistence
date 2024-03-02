using huzcodes.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;

namespace huzcodes.Persistence.Implementations
{
    public partial class DataProvider(IConfiguration configuration) : IDataProvider
    {
        private readonly IConfiguration _configuration = configuration;
    }
}
