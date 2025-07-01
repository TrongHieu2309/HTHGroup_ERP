using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("NGUOIDUNG");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.TenDangNhap)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.HasIndex(u => u.TenDangNhap).IsUnique();

            builder.Property(u => u.MatKhau)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.HasIndex(u => u.MatKhau).IsUnique();

            builder.Property(u => u.MaVaiTro)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            builder.HasOne(u => u.Roles)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.MaVaiTro)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
