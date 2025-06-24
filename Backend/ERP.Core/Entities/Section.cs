namespace ERP.Core.Entities
{
    public class Section
    {
        // bảng bộ phận
        public int Id { get; set; } // PK
        public string MaBoPhan { get; set; } = null!; // mã bộ phận unique varchar 20 notnull
        public string TenBoPhan { get; set; } = null!; //tên bộ phận nvarchar 100 not null

        // navigation property to Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
