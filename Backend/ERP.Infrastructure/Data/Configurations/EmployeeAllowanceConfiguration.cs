using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class EmployeeAllowanceConfiguration : IEntityTypeConfiguration<EmployeeAllowance>
    {
        public void Configure(EntityTypeBuilder<EmployeeAllowance> builder)
        {
            builder.ToTable("PHUCAPNV");

            // PK
            builder.HasKey(ea => ea.MaPhuCapNV);
            builder.Property(ea => ea.MaPhuCapNV)
                .ValueGeneratedOnAdd();

            // FK MaNV
            builder.HasOne(ea => ea.Employee)
                .WithMany(e => e.EmployeeAllowances)
                .HasForeignKey(ea => ea.MaNV)
                .OnDelete(DeleteBehavior.Restrict);

            // FK MaPhuCap
            builder.HasOne(ea => ea.Allowance)
                .WithMany(a => a.EmployeeAllowances)
                .HasForeignKey(ea => ea.MaPC)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ea => ea.Thang).IsRequired();
            builder.Property(ea => ea.Nam).IsRequired();
            builder.Property(ea => ea.SoTien)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
