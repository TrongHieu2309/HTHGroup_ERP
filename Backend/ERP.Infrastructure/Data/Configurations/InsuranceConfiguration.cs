using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class InsuranceConfiguration : IEntityTypeConfiguration<Insurance>
    {
        public void Configure(EntityTypeBuilder<Insurance> builder)
        {
            builder.ToTable("BAOHIEM");

            // PK
            builder.HasKey(i => i.MaBH);
            builder.Property(i => i.MaBH)
                .ValueGeneratedOnAdd();

            // FK
            builder.HasOne(i => i.Employee)
                .WithMany(e => e.Insurances)
                .HasForeignKey(i => i.MaNV)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(i => i.LoaiBH)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(i => i.SoBH)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(i => i.BenhVien)
                .HasColumnType("nvarchar(100)");

            builder.Property(i => i.NgayCap)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(i => i.NgayHetHan)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(i => i.TinhTrang)
                .HasColumnType("nvarchar(50)");
        }
    }
}
