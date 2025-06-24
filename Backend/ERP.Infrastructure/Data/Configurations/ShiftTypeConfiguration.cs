using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ShiftTypeConfiguration : IEntityTypeConfiguration<ShiftType>
    {
        public void Configure(EntityTypeBuilder<ShiftType> builder)
        {
            builder.ToTable("LOAICA");

            builder.HasKey(s => s.MaLoaiCa);
            builder.Property(s => s.MaLoaiCa)
                .ValueGeneratedOnAdd();

            builder.Property(s => s.CaLamViec)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(s => s.HeSoTangCa)
                .IsRequired()
                .HasDefaultValue(1.0f);
        }
    }
}
