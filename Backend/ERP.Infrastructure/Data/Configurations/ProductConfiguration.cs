using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("SANPHAM");

            // Primary Key
            builder.HasKey(p => p.MaSP);

            builder.Property(p => p.MaSP)
                   .ValueGeneratedOnAdd();

            builder.Property(p => p.TenSanPham)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.MoTa)
                   .HasMaxLength(255);

            builder.Property(p => p.DonGia)
                   .IsRequired();

            builder.Property(p => p.SoLuongTon)
                   .IsRequired();

            builder.Property(p => p.NgayNhap)
                    .IsRequired();

            builder.Property(p => p.TrangThai)
                   .IsRequired()
                   .HasMaxLength(10);

            // FK: MaNCC → ProviderEntity
            builder.HasOne(p => p.Provider)
                   .WithMany(pv => pv.Products)
                   .HasForeignKey(p => p.MaNCC)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaMatHang → ProductCategory
            builder.HasOne(p => p.ProductCategory)
                   .WithMany(pc => pc.Products)
                   .HasForeignKey(p => p.MaMatHang)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
