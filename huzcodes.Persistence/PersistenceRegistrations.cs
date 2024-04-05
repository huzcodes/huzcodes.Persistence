using huzcodes.Persistence.Implementations;
using huzcodes.Persistence.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace huzcodes.Persistence
{
    public static class PersistenceRegistrations
    {
        /// <summary>
        /// This function to be called in the program cs class,
        /// for adding registration for the persistence services.
        /// Note: the service life time by default is scoped,
        /// and in case you want to change the service life time, 
        /// you can pass the int paramter serviceLifetime.
        /// </summary>
        /// <param name="serviceLifetime">parameter to define the service life time by deafult scoped
        /// ex: (int)ServiceLifetime.Scoped, (int)ServiceLifetime.Transient, (int)ServiceLifetime.Singleton</param>
        public static void AddPersistenceServices(this IServiceCollection services, int serviceLifetime = (int)ServiceLifetime.Scoped)
        {
            switch (serviceLifetime)
            {
                case (int)ServiceLifetime.Transient:
                    services.AddTransient<IDataProvider, DataProvider>();
                    break;
                case (int)ServiceLifetime.Scoped:
                    services.AddScoped<IDataProvider, DataProvider>();
                    break;
                case (int)ServiceLifetime.Singleton:
                    services.AddSingleton<IDataProvider, DataProvider>();
                    break;
            }
        }
    }
}
