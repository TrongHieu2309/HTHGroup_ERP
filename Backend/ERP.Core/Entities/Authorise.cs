namespace ERP.Core.Entities
{
    public class Authorise
    {
        // Bảng Phân quyền
        public string MaVaiTro { get; set; } = null!;
        public Roles Roles { get; set; } = null!;

        public int MaQuyen { get; set; }
        public Authorisation Authorisation { get; set; } = null!;

        public string? HanhDong { get; set; }
    }
}
