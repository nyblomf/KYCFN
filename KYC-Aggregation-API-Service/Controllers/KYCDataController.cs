using KYC_Aggregation_API_Service.Models;
using KYC_Aggregation_API_Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace KYC_Aggregation_API_Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KYCDataController(ILogger<KYCDataController> logger, KYCDataService service) : ControllerBase
    {
        private readonly ILogger<KYCDataController> _logger = logger;
        private readonly KYCDataService _service = service;

        [HttpGet("{ssn}")]
        public IActionResult GetAggregatedKYCData(string ssn)
        {
            try
            {
                var contactDetails = _service.GetContactDetails(ssn);
                var personalDetails = _service.GetPersonalDetails(ssn);
                var kycForm = _service.GetKYCForm(ssn);

                if (contactDetails is null ||
                    personalDetails is null ||
                    kycForm is null)
                {
                    return NotFound(new { description = "Customer data not found", error = "Customer data not found for the provided SSN." });
                }

                return Ok(new AggregatedKYCData
                {
                    SSN = ssn,
                    FirstName = personalDetails.FirstName ?? "No registered first name",
                    LastName = personalDetails.SurName ?? "No registered custom first name",
                    Address = contactDetails.Address?.FirstOrDefault()?.FullSwedishAddress ?? "No registered address",
                    PhoneNumber = contactDetails.PreferredPhoneNumber?.Number ?? "No registered phone number",
                    Email = contactDetails.PreferredEmail?.EmailAddress ?? "No registered email address",
                    TaxCountry = kycForm.TaxCountry,
                    Income = kycForm.Income
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { description = "Internal server error", error = "An unexpected error occurred while processing the request." });
            }
        }
    }
}
