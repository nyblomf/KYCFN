using KYC_Data_Fetching_Service.Models;

namespace KYC_Data_Fetching_Service.Services
{
    public class ContactDetailsFetchingService : FetchingServiceBase<ContactDetails>
    {
        public ContactDetailsFetchingService(HttpClient httpClient) : base(httpClient) { }

        public override async Task<ContactDetails?> Get(string ssn) => await base.Get(ssn);
    }
}
