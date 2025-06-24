namespace ERP.Core.Entities
{
    public class Allowance
    {
        // Bảng Phụ cấp
        public int MaPC { get; set; } // PK int not null
        public string TenPhuCap { get; set; } = null!; // nvarchar 100 not null
        public decimal SoTien { get; set; } // decimal (18,2) not null

        // navigation property
        public ICollection<EmployeeAllowance> EmployeeAllowances { get; set; } = new List<EmployeeAllowance>();
    }
}
