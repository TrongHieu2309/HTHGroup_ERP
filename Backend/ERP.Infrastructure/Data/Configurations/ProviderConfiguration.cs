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
            builder.ToTable("NhaCungCap");

            // Khoá chính và identity cho ID
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); // Tự động tăng id

            // MaNCC: đặt mã dựa theo tên NCC, not null
            builder.Property(p => p.MaNCC)
                .HasColumnType("varchar(15)")
                .IsRequired();
            builder.HasIndex(p => p.MaNCC)
                .IsUnique();

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
