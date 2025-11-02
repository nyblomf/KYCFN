using KYC_Cache_Service.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KYC_Cache_Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var baseUrl = configuration["ExternalApis:CustomerDataApiBaseUrl"];
            if (baseUrl is null)
                throw new ArgumentNullException("ExternalApis:CustomerDataApiBaseUrl configuration is missing");

            services.AddScoped<ContactDetailsCachingService>();
            services.AddScoped<KYCFormCachingService>();
            services.AddScoped<PersonalDetailsCachingService>();

            return services;
        }
    }
}
