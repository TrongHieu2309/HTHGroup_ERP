namespace ERP.Core.Entities
{
    public class Section
    {
        // bảng bộ phận
        public int MaBoPhan { get; set; } // khóa chính, tự động tăng, int not null
        public string TenBoPhan { get; set; } = null!; //tên bộ phận nvarchar 100 not null

        // navigation property to Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
