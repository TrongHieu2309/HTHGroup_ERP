using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ProviderConfiguration : IEntityTypeConfiguration<ProviderEntity>
    {
        public void Configure(EntityTypeBuilder<ProviderEntity> builder)
        {
            // Đặt tên bảng
            builder.ToTable("NHACUNGCAP");

            // Thiết lập MaNCC là khóa chính và tự tăng
            builder.HasKey(p => p.MaNCC);
            builder.Property(p => p.MaNCC)
                .ValueGeneratedOnAdd() // tự động tăng
                .HasColumnType("int");

            // TenNCC, not null
            builder.Property(p => p.TenNCC)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            // DiaChi, not null
            builder.Property(p => p.DiaChi)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            // MoTa, not null
            builder.Property(p => p.MoTa)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            // SoDienThoai, not null
            builder.Property(p => p.SoDienThoai)
                .HasColumnType("varchar(10)")
                .IsRequired();

            // Email, not null
            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .IsRequired();

            // NguoiTiepNhan, not null
            builder.Property(p => p.NguoiTiepNhan)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
        }
    }
}
