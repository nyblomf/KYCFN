namespace KYC_Cache_Service.Interfaces
{
    public interface IDatabaseModel<T> where T : class
    {
        int Id { get; set; }
        string SSN { get; set; }
        DateTime CachedAt { get; set; }
        T Data { get; set; }
    }
}
