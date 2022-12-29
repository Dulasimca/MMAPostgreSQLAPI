using System;
using Microsoft.EntityFrameworkCore;
using CommonUtilities;
//using MMAGlobalDAL.DB_Entity;
using MMAGlobalDAL.Database.DB_Entity;

namespace MMAGlobalDAL
{
    public class EF_MMADatabaseContext : DbContext
    {
        public EF_MMADatabaseContext(DbContextOptions<EF_MMADatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();

            // Configure StudentId as FK for StudentAddress

            //  modelBuilder.Entity<District_master>()
            // .HasOne(p => p.Zone_Masters)
            //.WithMany(b => b.District_masters)
            // .HasForeignKey(p => p.zoneid);
        }

        public DbSet<trainingdb> trainingdb { get; set; }

        public DbSet<statemasterdb> state_master { get; set; } 
        public DbSet<role_master> role_master { get; set; }
        public DbSet<country_master> country_master { get; set; }

    }
}
