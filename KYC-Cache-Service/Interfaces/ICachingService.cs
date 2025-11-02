using KYC_Cache_Service.Caching;

namespace KYC_Cache_Service.Interfaces
{
    public interface ICachingService<T>
    {
        protected KYCCachingContext _context { get; init; }
        public T? Get(string ssn);
        public void Put(string ssn, T item);
    }
}
