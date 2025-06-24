namespace ERP.Core.Entities
{
    public class Salary
    {
        // Bảng Lương
        public int MaLuong { get; set; } // PK int not null

        public int MaNV { get; set; } // FK đến Employee
        public Employee Employee { get; set; } = null!; // Navigation property to Employee

        public int Thang { get; set; } // Tháng tính lương, int not null
        public int Nam { get; set; } // Năm tính lương, int not null

        public decimal LuongCoBan { get; set; } // Lương cơ bản
        public decimal TongTC { get; set; } // Tổng tiền tăng ca
        public decimal TongPC { get; set; } // Tổng tiền phụ cấp

        // cột này tự tính toán từ các cột bên trên: LCB + TongTC + TongPC
        public decimal ThucLinh { get; private set; } // Thực lĩnh, ko cho set trực tiếp từ ngoài
    }
}
