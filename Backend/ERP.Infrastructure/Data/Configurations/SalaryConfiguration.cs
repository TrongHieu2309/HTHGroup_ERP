using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class SalaryConfiguration : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.ToTable("LUONG");

            builder.HasKey(s => s.MaLuong);

            builder.Property(s => s.MaLuong)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Thang)
                .IsRequired();

            builder.Property(s => s.Nam)
                .IsRequired();

            builder.Property(s => s.LuongCoBan)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.TongTC)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.TongPC)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(s => s.ThucLinh)
                .HasColumnType("decimal(18,2)")
                .HasComputedColumnSql("[LuongCoBan] + [TongTC] + [TongPC]", stored: true);

            // FK MaNV → Employee
            builder.HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.MaNV)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
