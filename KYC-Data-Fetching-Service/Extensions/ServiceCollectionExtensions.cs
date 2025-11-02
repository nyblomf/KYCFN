using KYC_Data_Fetching_Service.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KYC_Data_Fetching_Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExternalDataClients(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ExternalApis:CustomerDataApiBaseUrl"];
            if (baseUrl is null)
                throw new ArgumentNullException("ExternalApis:CustomerDataApiBaseUrl configuration is missing");

            services.AddHttpClient<ContactDetailsFetchingService>(client => client.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<KYCFormFetchingService>(client => client.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<PersonalDetailsFetchingService>(client => client.BaseAddress = new Uri(baseUrl));

            return services;
        }
    }
}
