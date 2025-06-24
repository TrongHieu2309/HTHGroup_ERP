using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("PHONGBAN");

            // Primary Key
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(d => d.MaPhongBan)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasColumnType("varchar(20)");

            builder.HasIndex(d => d.MaPhongBan)
                   .IsUnique();

            builder.Property(d => d.TenPhongBan)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");
        }
    }
}
