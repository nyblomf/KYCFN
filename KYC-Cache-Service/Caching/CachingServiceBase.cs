
using KYC_Cache_Service.Interfaces;

namespace KYC_Cache_Service.Caching
{
    public abstract class CachingServiceBase<T> : ICachingService<T>
    {
        public KYCCachingContext _context { get; init; }

        protected CachingServiceBase(KYCCachingContext context) { _context = context; }

        public virtual T? Get(string ssn) => throw new NotImplementedException();
        public virtual T? Get(string ssn, DateTime asOfDate) => throw new NotImplementedException();

        public virtual void Put(string ssn, T item) => throw new NotImplementedException();

    }
}
