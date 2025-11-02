using KYC_Aggregation_API_Service.Interfaces;
using KYC_Cache_Service.Interfaces;
using KYC_Data_Fetching_Service.Interfaces;
using KYC_Data_Fetching_Service.Models;
using KYCCore.Models;

namespace KYC_Aggregation_API_Service.Services
{
    public class KYCDataService(
        ICachingService<ContactDetails> _contactCaching,
        ICachingService<KYCForm> _kycFormCaching,
        ICachingService<PersonalDetails> _personalCaching,
        IFetchingService<ContactDetails> _contactFetching,
        IFetchingService<KYCForm> _kycFormFetching,
        IFetchingService<PersonalDetails> _personalFetching) : IKYCDataService
    {

        public ContactDetails? GetContactDetails(string ssn) =>
            _contactCaching.Get(ssn) ?? _contactFetching.Get(ssn)?.Result;

        public KYCForm? GetKYCForm(string ssn)
        {
            var cachedKycForm = _kycFormCaching.Get(ssn);
            var newerForm = _kycFormFetching.Get(ssn, cachedKycForm?.KYCRegistrationDate ?? DateTime.MinValue).Result;

            return newerForm ?? cachedKycForm;
        }

        public PersonalDetails? GetPersonalDetails(string ssn) =>
            _personalCaching.Get(ssn) ?? _personalFetching.Get(ssn)?.Result;
    }
}
