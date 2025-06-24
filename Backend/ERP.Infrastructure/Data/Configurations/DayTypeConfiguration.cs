using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class DayTypeConfiguration : IEntityTypeConfiguration<DayType>
    {
        public void Configure(EntityTypeBuilder<DayType> builder)
        {
            builder.ToTable("LOAICONG");

            // Primary Key
            builder.HasKey(dt => dt.MaLoaiCong);

            builder.Property(dt => dt.MaLoaiCong)
                   .ValueGeneratedOnAdd();

            builder.Property(dt => dt.TenLoaiCong)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");

            builder.Property(dt => dt.HeSo)
                   .IsRequired()
                   .HasColumnType("float");
        }
    }
}
