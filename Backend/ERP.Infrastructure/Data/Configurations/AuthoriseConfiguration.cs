using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class AuthoriseConfiguration : IEntityTypeConfiguration<Authorise>
    {
        public void Configure(EntityTypeBuilder<Authorise> builder)
        {
            builder.ToTable("PHANQUYEN");

            // Composite Primary Key
            builder.HasKey(a => new { a.MaVaiTro, a.MaQuyen });

            // MaVaiTro: varchar(10) NOT NULL (match with Roles)
            builder.Property(a => a.MaVaiTro)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            // MaQuyen: int NOT NULL (match with Authorisation)
            builder.Property(a => a.MaQuyen)
                   .IsRequired();

            // HanhDong: nvarchar(100) NULL
            builder.Property(a => a.HanhDong)
                   .HasColumnType("nvarchar(100)");

            // FK: MaVaiTro → Roles
            builder.HasOne(a => a.Roles)
                   .WithMany(r => r.Authorises)
                   .HasForeignKey(a => a.MaVaiTro)
                   .OnDelete(DeleteBehavior.Restrict);

            // FK: MaQuyen → Authorisation
            builder.HasOne(a => a.Authorisation)
                   .WithMany(q => q.Authorises)
                   .HasForeignKey(a => a.MaQuyen)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
