namespace ERP.Core.Entities
{
    public class User
    {
        // Bảng Người dùng
        public int Id { get; set; } // int primary key
        public string TenDangNhap { get; set; } = null!; // varchar 50 not null unique
        public string MatKhau { get; set; } = null!; // varchar 50 not null unique
        public string MaVaiTro { get; set; } = null!; // varchar 10 not null, FK to Roles.MaVaiTro
        public Roles Roles { get; set; } = null!; // Navigation property to Roles
    }
}
