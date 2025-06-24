using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class AuthorisationConfiguration : IEntityTypeConfiguration<Authorisation>
    {
        public void Configure(EntityTypeBuilder<Authorisation> builder)
        {
            builder.ToTable("QUYEN");

            builder.HasKey(a => a.MaQuyen);

            builder.Property(a => a.MaQuyen)
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.TenQuyen)
                   .IsRequired()
                   .HasColumnType("nvarchar(100)");
        }
    }
}
