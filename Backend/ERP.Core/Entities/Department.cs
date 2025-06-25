namespace ERP.Core.Entities
{
    public class Department
    {
        // bảng phòng ban
        public int MaPhongBan { get; set; }
        public string TenPhongBan { get; set; } = null!; // nvarchar 100 not null

        // navigation property to Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
