using KYCCore.Models;

namespace KYC_Cache_Service.Caching
{
    public class KYCFormCachingService : CachingServiceBase<KYCForm>
    {
        public KYCFormCachingService(KYCCachingContext context) : base(context)
        {
            _context = context;
        }

        public KYCForm? Get(string ssn, DateTime asOfDate)
        {
            var customersItems = _context.KYCItems.Where(item => item.SSN == ssn);
            var itemsByFormId = customersItems.GroupBy(item => item.KYCFormId);
            var kycForms = itemsByFormId.Select(items => new KYCForm { Items = items.Select(item => item.Data).ToArray() });
            var latestKYCForm = kycForms
                .Where(form => form.KYCRegistrationDate > asOfDate)
                .OrderByDescending(form => form.KYCRegistrationDate)
                .FirstOrDefault();

            return latestKYCForm;
        }

        public override void Put(string ssn, KYCForm item)
        {
            throw new NotImplementedException();
        }
    }
}
