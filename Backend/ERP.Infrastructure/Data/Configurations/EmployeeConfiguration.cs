using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("NHANSU");

            // PK MaNV
            builder.HasKey(e => e.MaNV);
            builder.Property(e => e.MaNV)
                .ValueGeneratedOnAdd();

            // HoTen
            builder.Property(e => e.HoTen)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            // NgaySinh
            builder.Property(e => e.NgaySinh)
                .IsRequired()
                .HasColumnType("date");

            // GioiTinh
            builder.Property(e => e.GioiTinh)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            // SoDienThoai
            builder.Property(e => e.SoDienThoai)
                .IsRequired()
                .HasColumnType("varchar(15)");

            // CCCD
            builder.Property(e => e.CCCD)
                .IsRequired()
                .HasColumnType("varchar(12)");

            // Email
            builder.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar(100)");

            // DiaChi
            builder.Property(e => e.DiaChi)
                .IsRequired()
                .HasColumnType("nvarchar(255)");

            // FK MaPhongBan
            builder.HasOne(e => e.Department) // bảng có PK
                .WithMany(d => d.Employees) // bảng có FK, trong Department sẽ có ICollection<Employee> Employees
                .HasForeignKey(e => e.MaPhongBan) // MaPhongBan là FK trỏ đến Department.Id
                .OnDelete(DeleteBehavior.Restrict);

            // FK MaBoPhan
            builder.HasOne(e => e.Section) // bảng có PK
                .WithMany(s => s.Employees) // bảng có FK, trong Section sẽ có ICollection<Employee> Employees
                .HasForeignKey(e => e.MaBoPhan) // MaBoPhan là FK trỏ đến Section.Id
                .OnDelete(DeleteBehavior.Restrict);

            // FK MaChucVu
            builder.HasOne(e => e.JobTitle) // bảng có PK
                .WithMany(j => j.Employees) // bảng có FK, trong JobTitle sẽ có ICollection<Employee> Employees
                .HasForeignKey(e => e.MaChucVu) // MaChucVu là FK trỏ đến JobTitle.Id
                .OnDelete(DeleteBehavior.Restrict);

            // FK MaTrinhDoHocVan
            builder.HasOne(e => e.EducationLevel) // bảng có PK
                .WithMany(el => el.Employees) // bảng có FK, trong EducationLevel sẽ có ICollection<Employee> Employees
                .HasForeignKey(e => e.MaTDHV) // MaTDHV là FK trỏ đến EducationLevel.Id
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
