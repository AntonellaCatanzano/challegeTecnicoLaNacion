using ChallegeContactRecords.WebApi.Repositories.IRepository;
using Microsoft.Extensions.DependencyInjection;

namespace ChallegeContactRecords.WebApi.Repositories.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddServicesRepository(this IServiceCollection services)
        {
            services.AddTransient<IContactRecordsRepository, ContactRecordsRepository>();
            services.AddSingleton<IAddressRepository, AddressRepository>();

            return services;
        }
    }
}
