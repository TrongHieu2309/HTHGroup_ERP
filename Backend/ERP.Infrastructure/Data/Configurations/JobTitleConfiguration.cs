using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.ToTable("CHUCVU");

            // PK: MaChucVu
            builder.HasKey(jt => jt.MaChucVu);
            builder.Property(jt => jt.MaChucVu)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            // TenChucVu: nvarchar(100) not null
            builder.Property(jt => jt.TenChucVu)
                .HasColumnType("nvarchar(100)")
                .IsRequired();
        }
    }
}
