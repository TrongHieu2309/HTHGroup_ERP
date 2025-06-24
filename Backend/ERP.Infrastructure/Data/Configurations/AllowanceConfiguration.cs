using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class AllowanceConfiguration : IEntityTypeConfiguration<Allowance>
    {
        public void Configure(EntityTypeBuilder<Allowance> builder)
        {
            builder.ToTable("PHUCAP");

            // PK
            builder.HasKey(a => a.MaPC);
            builder.Property(a => a.MaPC)
                .ValueGeneratedOnAdd();

            builder.Property(a => a.TenPhuCap)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(a => a.SoTien)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
