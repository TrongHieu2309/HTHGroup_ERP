using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            // Đặt tên bảng
            builder.ToTable("HOADON");

            // Khóa chính
            builder.HasKey(r => r.MaHD);

            // Cột MaHD sinh tự động
            builder.Property(r => r.MaHD)
                   .ValueGeneratedOnAdd();

            // FK: MaKH → Customer.MaKH
            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Receipts)
                   .HasForeignKey(r => r.MaKH)
                   .OnDelete(DeleteBehavior.Restrict);

            // LoaiHD: nvarchar(50) not null
            builder.Property(r => r.LoaiHD)
                   .IsRequired()
                   .HasColumnType("nvarchar(50)");

            // NgayLap: datetime not null
            builder.Property(r => r.NgayLap)
                   .IsRequired()
                   .HasColumnType("datetime");

            // NguoiLap: nvarchar(100) not null
            builder.Property(r => r.NguoiLap)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");

            // TongTien: bigint not null
            builder.Property(r => r.TongTien)
                   .IsRequired()
                   .HasColumnType("bigint");

            // TrangThai: nvarchar(20) not null
            builder.Property(r => r.TrangThai)
                   .IsRequired()
                   .HasColumnType("nvarchar(20)");
        }
    }
}
