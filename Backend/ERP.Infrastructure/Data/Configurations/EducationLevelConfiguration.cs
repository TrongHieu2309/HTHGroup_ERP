using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
    {
        public void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.ToTable("TRINHDOHOCVAN");

            // Int Primary key: Cột MaTDHV
            builder.HasKey(e => e.MaTDHV);
            builder.Property(e => e.MaTDHV)
                .ValueGeneratedOnAdd();

            // Cột TrinhDoHocVan
            builder.Property(e => e.TrinhDoHocVan)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();
        }
    }
}
