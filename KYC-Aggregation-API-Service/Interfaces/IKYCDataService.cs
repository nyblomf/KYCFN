using KYC_Data_Fetching_Service.Models;
using KYCCore.Models;

namespace KYC_Aggregation_API_Service.Interfaces
{
    public interface IKYCDataService
    {
        ContactDetails? GetContactDetails(string ssn);
        KYCForm? GetKYCForm(string ssn);
        PersonalDetails? GetPersonalDetails(string ssn);
    }
}
