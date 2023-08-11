using ChallegeContactRecords.WebApi.Business.IServices;
using ChallegeContactRecords.WebApi.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ChallegeContactRecords.WebApi.Business.Extensions
{

    /// <summary>
    /// Agrega al contenedor las implementaciones del acceso a datos
    /// </summary>
    public static class ServicesCollectionBusinessExtensions
    {
        public static IServiceCollection AddServicesBusiness(this IServiceCollection services)
        {
            services.AddTransient<IContactRecordsService, ContactRecordsService>();
            services.AddTransient<IAddressService, AddressService>();

            return services;
        }
    }
}
