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

            // MaPhongBan là khóa chính và tự động tăng
            builder.HasKey(d => d.MaPhongBan);
            builder.Property(d => d.MaPhongBan)
                   .ValueGeneratedOnAdd() // Tự tăng
                   .HasColumnType("int");

            // TenPhongBan: nvarchar(100), not null
            builder.Property(d => d.TenPhongBan)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnType("nvarchar(100)");
        }
    }
}
