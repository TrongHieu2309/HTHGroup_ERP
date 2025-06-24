using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            // Tên bảng
            builder.ToTable("PHANLOAIMATHANG");

            // Primary Key
            builder.HasKey(pc => pc.MaMatHang);

            // MaMatHang: int, tự tăng
            builder.Property(pc => pc.MaMatHang)
                   .ValueGeneratedOnAdd();

            // TenMatHang: nvarchar(100), not null
            builder.Property(pc => pc.TenMatHang)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            // SoLuong: int, not null
            builder.Property(pc => pc.SoLuong)
                   .IsRequired();

            // TongChiPhi: bigint, not null
            builder.Property(pc => pc.TongChiPhi)
                   .IsRequired()
                   .HasColumnType("bigint");
        }
    }
}
