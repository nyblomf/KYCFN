

namespace KYC_Aggregation_API_Service.Models
{
    public class AggregatedKYCData
    {
        public required string SSN { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Address { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Email { get; init; }
        public required string TaxCountry { get; init; }
        public int? Income { get; init; }
    }
}
