
using KYC_Data_Fetching_Service.Interfaces;
using KYC_Data_Fetching_Service.Models;
using KYCCore.Models;
using System.Net.Http.Json;

namespace KYC_Data_Fetching_Service.Services
{
    public abstract class FetchingServiceBase<T> : IFetchingService<T>
    {
        protected readonly HttpClient _httpClient;
        protected FetchingServiceBase(HttpClient httpClient) => _httpClient = httpClient;

        public virtual async Task<T?> Get(string ssn)
        {
            var response = await _httpClient.GetAsync(TypeToPath(ssn));

            if (response.IsSuccessStatusCode is false)
                return default;

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public virtual async Task<T?> Get(string ssn, DateTime asOfDate)
        {
            var response = await _httpClient.GetAsync(TypeToPath(ssn, asOfDate));

            if (response.IsSuccessStatusCode is false)
                return default;

            return await response.Content.ReadFromJsonAsync<T>();
        }

        private string TypeToPath(string ssn, DateTime? asOfDate = null) => typeof(T) switch
        {
            var t when t == typeof(ContactDetails) => $"contact-details/{ssn}",
            var t when t == typeof(KYCForm) => $"kyc-form/{ssn}{(asOfDate)}",
            var t when t == typeof(PersonalDetails) => $"personal-details/{ssn}",
            _ => throw new NotSupportedException($"Type {typeof(T).Name} is not supported.")
        };
    }
}
