using KYC_Cache_Service.Interfaces;
using KYCCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYC_Cache_Service.Models
{
    [Table("Email")]
    public class EmailDbModel : IDatabaseModel<Email>
    {
        [Key]
        public int Id { get; set; }
        public required string SSN { get; set; }
        public DateTime CachedAt { get; set; } = DateTime.UtcNow;
        public required Email Data { get; set; }
    }
}
