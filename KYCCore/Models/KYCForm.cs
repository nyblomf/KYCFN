namespace KYCCore.Models
{
    public class KYCForm
    {
        public KYCItem[]? Items { get; init; }

        public string TaxCountry => Items?.FirstOrDefault(item => item.Key is SystemConstants.SystemConstants.KYCForm.Keys.TaxCountry)?.Value ?? string.Empty;
        public int Income => int.Parse(Items?.FirstOrDefault(item => item.Key is SystemConstants.SystemConstants.KYCForm.Keys.AnnualIncome)?.Value ?? string.Empty);
        public DateTime KYCRegistrationDate => DateTime.Parse(Items?.FirstOrDefault(item => item.Key is SystemConstants.SystemConstants.KYCForm.Keys.KYCRegistrationDate)?.Value ?? string.Empty);
    }
}
