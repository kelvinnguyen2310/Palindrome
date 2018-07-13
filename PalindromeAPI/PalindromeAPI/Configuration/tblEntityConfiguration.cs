using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalindromeAPI.Configuration
{
    public class tblEntityConfiguration : IEntityTypeConfiguration<Tbl>
    {
        public void Configure(EntityTypeBuilder<Tbl> builder)
        {
            builder.ToTable("Tbl");
            builder.HasKey(s => s.Desc);
            builder.Property(p => p.Desc).HasColumnName("Desc");            
        }
    }
}
