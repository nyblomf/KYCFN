using KYC_Cache_Service.Models;
using Microsoft.EntityFrameworkCore;

namespace KYC_Cache_Service.Caching
{
    public class KYCCachingContext(DbContextOptions<KYCCachingContext> options) : DbContext(options)
    {
        public DbSet<AddressDbModel> Addresses { get; set; }
        public DbSet<EmailDbModel> Emails { get; set; }
        public DbSet<KYCItemDbModel> KYCItems { get; set; }
        public DbSet<PersonalDetailsDbModel> PersonalDetails { get; set; }
        public DbSet<PhoneNumberDbModel> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressDbModel>().OwnsOne(c => c.Data);
            modelBuilder.Entity<EmailDbModel>().OwnsOne(c => c.Data);
            modelBuilder.Entity<KYCItemDbModel>().OwnsOne(c => c.Data);
            modelBuilder.Entity<PersonalDetailsDbModel>().OwnsOne(c => c.Data);
            modelBuilder.Entity<PhoneNumberDbModel>().OwnsOne(c => c.Data);
        }
    }
}
