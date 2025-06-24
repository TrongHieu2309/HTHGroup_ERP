using ERP.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Data.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("CHI");

            // PK
            builder.HasKey(ex => ex.MaChi);
            builder.Property(ex => ex.MaChi)
                .ValueGeneratedOnAdd();

            // FK: MaNV
            builder.HasOne(ex => ex.Employee)
                .WithMany(e => e.Expenses)
                .HasForeignKey(ex => ex.MaNV)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(ex => ex.NgayChi)
                .HasColumnType("date"); // kiểu date - datetime thì ko cần IsRequired()

            builder.Property(ex => ex.NoiDung)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(ex => ex.SoTien).HasColumnType("decimal(18,2)");

            builder.Property(ex => ex.NguoiChi)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(ex => ex.GhiChu).HasColumnType("nvarchar(255)");
        }
    }
}
