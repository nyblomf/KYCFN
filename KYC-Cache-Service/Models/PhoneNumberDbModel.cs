using KYC_Cache_Service.Interfaces;
using KYCCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYC_Cache_Service.Models
{
    [Table("PhoneNumber")]
    public class PhoneNumberDbModel : IDatabaseModel<PhoneNumber>
    {
        [Key]
        public int Id { get; set; }
        public required string SSN { get; set; }
        public DateTime CachedAt { get; set; } = DateTime.UtcNow;
        public required PhoneNumber Data { get; set; }
    }
}
