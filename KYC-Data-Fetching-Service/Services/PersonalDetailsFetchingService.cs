using KYCCore.Models;

namespace KYC_Data_Fetching_Service.Services
{
    public class PersonalDetailsFetchingService : FetchingServiceBase<PersonalDetails>
    {
        public PersonalDetailsFetchingService(HttpClient httpClient) : base(httpClient) { }

        public override async Task<PersonalDetails?> Get(string ssn) => await base.Get(ssn);
    }
}
