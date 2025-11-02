using KYCCore.Models;

namespace KYC_Data_Fetching_Service.Models
{
    public class ContactDetails
    {
        public Address[]? Address { get; set; }
        public Email[]? Emails { get; set; }
        public PhoneNumber[]? PhoneNumbers { get; set; }

        public Email? PreferredEmail => Emails?.FirstOrDefault(email => email.Preferred);
        public PhoneNumber? PreferredPhoneNumber => PhoneNumbers?.FirstOrDefault(phoneNumber => phoneNumber.Preferred);
    }
}
