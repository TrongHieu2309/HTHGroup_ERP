using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.ToTable("VAITRO");

            builder.HasKey(r => r.MaVaiTro);

            builder.Property(r => r.MaVaiTro)
                   .HasColumnType("varchar(10)");

            builder.Property(r => r.TenVaiTro)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");
        }
    }
}
