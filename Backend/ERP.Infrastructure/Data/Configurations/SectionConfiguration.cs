using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            // Đặt tên bảng
            builder.ToTable("BOPHAN");

            // Thiết lập MaBoPhan là khóa chính và tự động tăng
            builder.HasKey(s => s.MaBoPhan);

            builder.Property(s => s.MaBoPhan)
                   .ValueGeneratedOnAdd() // Tự tăng
                   .HasColumnType("int");

            // Thiết lập TenBoPhan: nvarchar(100), bắt buộc
            builder.Property(s => s.TenBoPhan)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");
        }
    }
}
