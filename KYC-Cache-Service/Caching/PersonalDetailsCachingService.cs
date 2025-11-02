using KYCCore.Models;

namespace KYC_Cache_Service.Caching
{
    public class PersonalDetailsCachingService : CachingServiceBase<PersonalDetails>
    {
        public PersonalDetailsCachingService(KYCCachingContext context) : base(context) { _context = context; }

        public override PersonalDetails? Get(string ssn) =>
            _context.PersonalDetails.FirstOrDefault(personalDetail => personalDetail.SSN == ssn)?.Data;

        public override void Put(string ssn, PersonalDetails item)
        {
            throw new NotImplementedException();
        }
    }
}
