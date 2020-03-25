using Super.Digital.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Super.Digital.Data
{
    public class SuperDigitalDbContext : DbContext
    {

        public SuperDigitalDbContext(DbContextOptions<SuperDigitalDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CreateAccountMapping());
            modelBuilder.ApplyConfiguration(new AccountEntryMapping());
        }
    }
}
