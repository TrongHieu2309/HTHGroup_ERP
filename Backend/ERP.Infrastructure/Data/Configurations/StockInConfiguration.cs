using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class StockInConfiguration : IEntityTypeConfiguration<StockIn>
    {
        public void Configure(EntityTypeBuilder<StockIn> builder)
        {
            // Đặt tên bảng tương ứng với SQL
            builder.ToTable("NHAPKHO");

            // Khoá chính: MaPhieuNhap
            builder.HasKey(s => s.MaPhieuNhap);

            builder.Property(s => s.MaPhieuNhap)
                   .ValueGeneratedOnAdd(); // Identity (tự tăng)

            // Ngày nhập - not null
            builder.Property(s => s.NgayNhap)
                   .IsRequired()
                   .HasColumnType("date");

            // Ghi chú - nullable
            builder.Property(s => s.GhiChu)
                   .HasColumnType("nvarchar(255)");

            // FK: MaNCC → ProviderEntity.Id
            builder.HasOne(s => s.Provider)
                   .WithMany(p => p.StockIns) // bạn sẽ thêm ICollection<StockIn> trong Provider sau
                   .HasForeignKey(s => s.MaNCC)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaKho → Inventory.MaKho
            builder.HasOne(s => s.Inventory)
                   .WithMany(p => p.StockIns) // bạn sẽ thêm ICollection<StockIn> trong Inventory sau
                   .HasForeignKey(s => s.MaKho)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
