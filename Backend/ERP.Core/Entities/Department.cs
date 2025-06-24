namespace ERP.Core.Entities
{
    public class Department
    {
        // bảng phòng ban
        public int Id { get; set; } // PK
        public string MaPhongBan { get; set; } = null!; // unique varchar 20 not null
        public string TenPhongBan { get; set; } = null!; // nvarchar 100 not null

        // navigation property to Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
