using KYC_Cache_Service.Interfaces;
using KYCCore.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KYC_Cache_Service.Models
{
    [Table("PersonalDetails")]
    public class PersonalDetailsDbModel : IDatabaseModel<PersonalDetails>
    {
        [Key]
        public int Id { get; set; }
        public required string SSN { get; set; }
        public DateTime CachedAt { get; set; } = DateTime.UtcNow;
        public required PersonalDetails Data { get; set; }
    }
}
