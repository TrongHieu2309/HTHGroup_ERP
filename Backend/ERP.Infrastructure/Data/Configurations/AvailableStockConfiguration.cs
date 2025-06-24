using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class AvailableStockConfiguration : IEntityTypeConfiguration<AvailableStock>
    {
        public void Configure(EntityTypeBuilder<AvailableStock> builder)
        {
            // Tên bảng
            builder.ToTable("TONKHO");

            // Khóa chính
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.TenSP)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            builder.Property(a => a.SoLuongTon)
                   .IsRequired();

            builder.Property(a => a.NgayCapNhat)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            // FK: MaSP → Product.MaSP
            builder.HasOne(a => a.Product)
                   .WithMany(p => p.AvailableStocks) // nếu có ICollection<AvailableStock> trong Product thì điền vào đây
                   .HasForeignKey(a => a.MaSP)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaKho → Inventory.MaKho
            builder.HasOne(a => a.Inventory)
                   .WithMany(p => p.AvailableStocks) // nếu có ICollection<AvailableStock> trong Inventory thì điền vào đây
                   .HasForeignKey(a => a.MaKho)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
