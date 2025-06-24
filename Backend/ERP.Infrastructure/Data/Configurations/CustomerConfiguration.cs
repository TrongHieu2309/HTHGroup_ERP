using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Đặt tên bảng
            builder.ToTable("KHACHHANG");

            // Khóa chính
            builder.HasKey(c => c.MaKH);

            // MaKH sẽ được tự tăng (identity)
            builder.Property(c => c.MaKH)
                   .ValueGeneratedOnAdd();

            // TenKhachHang: nvarchar(100), not null
            builder.Property(c => c.TenKhachHang)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();

            // DiaChi: nvarchar(255), not null
            builder.Property(c => c.DiaChi)
                   .HasColumnType("nvarchar(255)")
                   .IsRequired();

            // SoDienThoai: varchar(15), not null
            builder.Property(c => c.SoDienThoai)
                   .HasColumnType("varchar(15)")
                   .IsRequired();

            // Email: varchar(100), nullable
            builder.Property(c => c.Email)
                   .HasColumnType("varchar(100)");

            // GhiChu: nvarchar(255), nullable
            builder.Property(c => c.GhiChu)
                   .HasColumnType("nvarchar(255)");

            // TichDiem: int, not null, default = 0
            builder.Property(c => c.TichDiem)
                   .HasDefaultValue(0);
        }
    }
}
