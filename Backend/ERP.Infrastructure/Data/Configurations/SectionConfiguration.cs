using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            // Tên bảng
            builder.ToTable("BOPHAN");

            // Khóa chính
            builder.HasKey(s => s.Id);

            // Tự sinh giá trị Id nếu là Identity
            builder.Property(s => s.Id)
                   .ValueGeneratedOnAdd();

            // MaBoPhan: varchar(20), not null, unique
            builder.Property(s => s.MaBoPhan)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnType("varchar(20)");

            builder.HasIndex(s => s.MaBoPhan)
                   .IsUnique();

            // TenBoPhan: nvarchar(100), not null
            builder.Property(s => s.TenBoPhan)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");
        }
    }
}
