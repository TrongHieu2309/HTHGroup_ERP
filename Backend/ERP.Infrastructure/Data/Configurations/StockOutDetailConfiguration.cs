using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class StockOutDetailConfiguration : IEntityTypeConfiguration<StockOutDetail>
    {
        public void Configure(EntityTypeBuilder<StockOutDetail> builder)
        {
            // Tên bảng
            builder.ToTable("CHITIETXUATKHO");

            // Khóa chính
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(s => s.SoLuongXuat)
                   .IsRequired();

            builder.Property(s => s.GhiChu)
                   .HasColumnType("nvarchar(255)")
                   .IsRequired(false);

            // FK: MaPhieuXuat → StockOut.MaPhieuXuat
            builder.HasOne(s => s.StockOut)
                   .WithMany(s => s.StockOutDetails) // thêm ICollection<StockOutDetail> trong StockOut nếu cần
                   .HasForeignKey(s => s.MaPhieuXuat)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaSP → Product.MaSP
            builder.HasOne(s => s.Product)
                   .WithMany(s => s.StockOutDetails) // thêm ICollection<StockOutDetail> trong Product nếu cần
                   .HasForeignKey(s => s.MaSP)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
