namespace ERP.Core.Entities
{
    public class EducationLevel
    {
        // bảng TrinhDoHocVan
        public int MaTDHV { get; set; } // PK, mã trình độ học vấn
        public string TrinhDoHocVan { get; set; } = null!; // nvarchar 100 not null

        // navigation property to Employee
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
