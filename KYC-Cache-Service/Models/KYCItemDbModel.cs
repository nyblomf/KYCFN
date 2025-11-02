using KYC_Cache_Service.Interfaces;
using KYCCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYC_Cache_Service.Models
{
    [Table("KYCItem")]
    public class KYCItemDbModel : IDatabaseModel<KYCItem>
    {
        [Key]
        public int Id { get; set; }
        public required string SSN { get; set; }
        public DateTime CachedAt { get; set; } = DateTime.UtcNow;
        public required KYCItem Data { get; set; }
        public required int KYCFormId { get; set; }
    }
}
