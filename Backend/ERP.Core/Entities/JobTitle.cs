namespace ERP.Core.Entities
{
    public class JobTitle
    {
        // bảng Chức vụ
        public int MaChucVu { get; set; } // PK, tự tăng từ 1
        public string TenChucVu { get; set; } = null!; // tên chức vụ, nvarchar(100), not null

        // navigation property to Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
