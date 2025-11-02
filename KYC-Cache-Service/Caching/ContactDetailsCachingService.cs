using KYC_Cache_Service.Models;
using KYC_Data_Fetching_Service.Models;
using Microsoft.IdentityModel.Tokens;

namespace KYC_Cache_Service.Caching
{
    public class ContactDetailsCachingService : CachingServiceBase<ContactDetails>
    {
        public ContactDetailsCachingService(KYCCachingContext context) : base(context)
        {
            _context = context;
        }

        public override ContactDetails? Get(string ssn)
        {
            var address = _context.Addresses.Where(contactDetails => contactDetails.SSN == ssn);
            var emails = _context.Emails.Where(contactDetails => contactDetails.SSN == ssn);
            var phoneNumbers = _context.PhoneNumbers.Where(contactDetails => contactDetails.SSN == ssn);

            if (address.IsNullOrEmpty() && emails.IsNullOrEmpty() && phoneNumbers.IsNullOrEmpty())
            {
                return null;
            }

            return new ContactDetails
            {
                Address = address.Select(address => address.Data).ToArray(),
                Emails = emails.Select(address => address.Data).ToArray(),
                PhoneNumbers = phoneNumbers.Select(address => address.Data).ToArray()
            };
        }

        public override void Put(string ssn, ContactDetails item)
        {
            //      customer = _context.Customers.Add(new Customer { SSN = ssn }).Entity;
            //  }
            //
            //  if (_context.Addresses.Any(address => address.CustomerId == customer.Id))
            //  {
            //      _context.Addresses.Update()
            //  }
            //  else
            //  {
            //      _context.Addresses.AddRange(item.Address);
            //      _context.Emails.AddRange(item.Address);
            //


            _context.SaveChanges();
        }
    }
}
