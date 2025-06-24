using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class WorkRecordConfiguration : IEntityTypeConfiguration<WorkRecord>
    {
        public void Configure(EntityTypeBuilder<WorkRecord> builder)
        {
            builder.ToTable("TINHCONG");

            // Primary Key
            builder.HasKey(w => w.MaTinhCong);

            // Ngày chấm công
            builder.Property(w => w.Ngay)
                   .IsRequired()
                   .HasColumnType("datetime");

            // Giờ vào
            builder.Property(w => w.GioVao)
                   .IsRequired()
                   .HasColumnType("time");

            // Giờ ra
            builder.Property(w => w.GioRa)
                   .IsRequired()
                   .HasColumnType("time");

            // FK: MaNhanVien → Employee
            builder.Property(w => w.MaNhanVien)
                   .IsRequired();

            builder.HasOne(w => w.Employee)
                   .WithMany(e => e.WorkRecords)
                   .HasForeignKey(w => w.MaNhanVien)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaLoaiCong → DayType
            builder.Property(w => w.MaLoaiCong)
                   .IsRequired();

            builder.HasOne(w => w.DayType)
                   .WithMany(d => d.WorkRecords)
                   .HasForeignKey(w => w.MaLoaiCong)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
