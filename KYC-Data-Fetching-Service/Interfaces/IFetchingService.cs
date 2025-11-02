namespace KYC_Data_Fetching_Service.Interfaces
{
    public interface IFetchingService<T>
    {
        public Task<T?> Get(string path);
        public Task<T?> Get(string path, DateTime asOfDate);
    }
}
