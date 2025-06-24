namespace ERP.Core.Entities
{
    public class EmployeeAllowance
    {
        // Bảng Phụ cấp Nhân viên
        public int MaPhuCapNV { get; set; }

        // FK MaNV
        public int MaNV { get; set; }
        public Employee Employee { get; set; } = null!;

        // FK MaPC
        public int MaPC { get; set; }
        public Allowance Allowance { get; set; } = null!;

        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal SoTien { get; set; }
    }
}
