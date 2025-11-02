using KYCCore.Models;

namespace KYC_Data_Fetching_Service.Services
{
    public class KYCFormFetchingService : FetchingServiceBase<KYCForm>
    {
        public KYCFormFetchingService(HttpClient httpClient) : base(httpClient) { }

        public override async Task<KYCForm?> Get(string ssn, DateTime asOfDate) => await base.Get(ssn, asOfDate);
    }
}
