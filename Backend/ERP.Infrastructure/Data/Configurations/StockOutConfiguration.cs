using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class StockOutConfiguration : IEntityTypeConfiguration<StockOut>
    {
        public void Configure(EntityTypeBuilder<StockOut> builder)
        {
            // Tên bảng
            builder.ToTable("XUATKHO");

            // Khóa chính
            builder.HasKey(s => s.MaPhieuXuat);

            // Cấu hình các cột
            builder.Property(s => s.MaPhieuXuat)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.NguoiXuat)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            builder.Property(s => s.NgayXuat)
                   .IsRequired();

            builder.Property(s => s.LyDoXuat)
                   .HasColumnType("nvarchar(255)")
                   .IsRequired(false);

            // FK: MaKho → Inventory.MaKho
            builder.HasOne(s => s.Inventory)
                   .WithMany(i => i.StockOuts) // bạn có thể thêm ICollection<StockOut> trong Inventory nếu cần
                   .HasForeignKey(s => s.MaKho)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
