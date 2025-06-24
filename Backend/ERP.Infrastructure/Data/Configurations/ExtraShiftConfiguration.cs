using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ExtraShiftConfiguration : IEntityTypeConfiguration<ExtraShift>
    {
        public void Configure(EntityTypeBuilder<ExtraShift> builder)
        {
            builder.ToTable("TANGCA");

            // PK
            builder.HasKey(e => e.MaTangCa);
            builder.Property(e => e.MaTangCa)
                .ValueGeneratedOnAdd();

            // Ngày tăng ca
            builder.Property(e => e.Ngay)
                .IsRequired()
                .HasColumnType("date");

            // Số giờ
            builder.Property(e => e.SoGio)
                .IsRequired();

            // FK MaNV → Employee.MaNV
            builder.HasOne(e => e.Employee)
                .WithMany(emp => emp.ExtraShifts)
                .HasForeignKey(e => e.MaNV)
                .OnDelete(DeleteBehavior.Restrict);

            // FK MaLoaiCa
            builder.HasOne(e => e.ShiftType)
                .WithMany(st => st.ExtraShifts)
                .HasForeignKey(e => e.MaLoaiCa)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
