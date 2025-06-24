namespace ERP.Core.Entities
{
    public class Roles
    {
        // Bảng vai trò có 1 PK
        public string MaVaiTro { get; set; } = null!; // primary key not null varchar 10
        public string TenVaiTro { get; set; } = null!; // nvarchar 100 not null

        // Navigation properties
        public ICollection<Authorise> Authorises { get; set; } = new List<Authorise>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
