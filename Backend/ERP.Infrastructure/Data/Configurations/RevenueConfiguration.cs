using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.ToTable("THU");

            // PK
            builder.HasKey(r => r.MaThu);
            builder.Property(r => r.MaThu)
                .ValueGeneratedOnAdd();

            // FK MaNV
            builder.HasOne(r => r.Employee)
                .WithMany(e => e.Revenues)
                .HasForeignKey(r => r.MaNV)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(r => r.NgayThu).HasColumnType("date");

            builder.Property(r => r.NoiDung)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(r => r.SoTien)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(r => r.NguoiThu)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(r => r.GhiChu)
                .HasColumnType("nvarchar(255)");
        }
    }
}
