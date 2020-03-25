using Microsoft.EntityFrameworkCore;
using Super.Digital.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super.Digital.Data
{
    public class SuperDigitalDbContext : DbContext
    {

        public SuperDigitalDbContext(DbContextOptions<SuperDigitalDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountMapping());
        }
    }
}
