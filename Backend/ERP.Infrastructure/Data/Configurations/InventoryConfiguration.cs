using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            // tên bảng
            builder.ToTable("KHOHANG");

            // Khóa chính
            builder.HasKey(a => a.MaKho);

            builder.Property(a => a.MaKho)
                   .ValueGeneratedOnAdd();

            // TenKho
            builder.Property(a => a.TenKho)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            // DiaChi
            builder.Property(a => a.DiaChi)
                   .HasColumnType("nvarchar(255)")
                   .IsRequired();

            // NguoiQuanLy
            builder.Property(a => a.NguoiQuanLy)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            // GhiChu
            builder.Property(a => a.GhiChu)
                   .HasColumnType("nvarchar(255)");
        }
    }
}
