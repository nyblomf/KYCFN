namespace KYCCore.Models
{
    public class Address
    {
        public string? Street { get; init; }
        public string? City { get; init; }
        public string? State { get; init; }
        public string? PostalCode { get; init; }
        public string? Country { get; init; }

        public string FullSwedishAddress => $"{Street}, {PostalCode} {City}";
    }
}
