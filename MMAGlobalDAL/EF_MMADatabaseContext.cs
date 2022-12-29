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
        public DbSet<union_masters> union_master { get; set; }
        public DbSet<menu_master>menumaster { get; set; }
        public DbSet<expensescategory_master> expensescategorymaster { get; set; }
        public DbSet<city_master>citymaster { get; set; }
    }
}
