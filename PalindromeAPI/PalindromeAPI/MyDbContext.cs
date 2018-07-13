using Microsoft.EntityFrameworkCore;
using PalindromeAPI.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalindromeAPI
{
    public class MyDbContext: DbContext
    {
        public DbSet<Tbl> tbl { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Personnel>(new PersonnelEntityConfiguration());
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Personnel>()
            //    .ToTable("MIC_Personnel");            
            //modelBuilder.Entity<Personnel>()
            //    .Property(s => s.PersonnelID).HasColumnName("ID_PERSONNEL");
            //modelBuilder.Entity<Personnel>()
            //    .Property(s => s.ClockingID).HasColumnName("TX_Clocking_ID");
            modelBuilder.ApplyConfiguration(new tblEntityConfiguration());            

        }
    }
}
