using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ReceiptDetailConfiguration : IEntityTypeConfiguration<ReceiptDetail>
    {
        public void Configure(EntityTypeBuilder<ReceiptDetail> builder)
        {
            builder.ToTable("CHITIETHOADON");

            // Primary key
            builder.HasKey(rd => rd.Id);

            builder.Property(rd => rd.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(rd => rd.SoLuong)
                   .IsRequired();

            builder.Property(rd => rd.DonGia)
                   .IsRequired();

            builder.Property(rd => rd.ChietKhau)
                   .HasDefaultValue(0f);

            builder.Property(rd => rd.VAT)
                   .IsRequired()
                   .HasDefaultValue(0.1f);

            builder.Property(rd => rd.GhiChu)
                   .HasColumnType("nvarchar(255)");

            // FK: MaHD → Receipt
            builder.HasOne(rd => rd.Receipt)
                   .WithMany(r => r.ReceiptDetails)
                   .HasForeignKey(rd => rd.MaHD)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaSP → Product
            builder.HasOne(rd => rd.Product)
                   .WithMany(p => p.ReceiptDetails)
                   .HasForeignKey(rd => rd.MaSP)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
