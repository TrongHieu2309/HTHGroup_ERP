using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class StockInDetailConfiguration : IEntityTypeConfiguration<StockInDetail>
    {
        public void Configure(EntityTypeBuilder<StockInDetail> builder)
        {
            // Đặt tên bảng trong database
            builder.ToTable("CHITIETNHAPKHO");

            // Khóa chính
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd(); // Identity

            // FK: MaPhieuNhap → StockIn.MaPhieuNhap
            builder.HasOne(s => s.StockIn)
                   .WithMany(s => s.StockInDetails)
                   .HasForeignKey(s => s.MaPhieuNhap)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaSP → Product.MaSP
            builder.HasOne(s => s.Product)
                   .WithMany(p => p.StockInDetails)
                   .HasForeignKey(s => s.MaSP)
                   .OnDelete(DeleteBehavior.Restrict);

            // SoLuongNhap - int not null
            builder.Property(s => s.SoLuongNhap)
                   .IsRequired();

            // DonGia - bigint not null
            builder.Property(s => s.DonGia)
                   .IsRequired()
                   .HasColumnType("bigint");
        }
    }
}
