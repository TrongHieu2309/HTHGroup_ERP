namespace ERP.Core.Entities
{
    public class Employee
    {
        // bảng Nhân sự: NHANSU
        public int MaNV { get; set; } // PK int notnull, identity
        public string HoTen { get; set; } = null!; // nvarchar 100 not null
        public DateTime NgaySinh { get; set; } // NgaySinh: date, not null
        public string GioiTinh { get; set; } = null!; // GioiTinh: nvarchar(10), not null
        public string SoDienThoai { get; set; } = null!; // SoDienThoai: varchar(15), not null
        public string CCCD { get; set; } = null!; // CCCD: varchar(12), not null
        public string Email { get; set; } = null!; // Email: varchar(100), nullable
        public string DiaChi { get; set; } = null!; // DiaChi: nvarchar(255), not null

        // FK MaPhongBan là cột Id, PK của Department
        public int MaPhongBan { get; set; }
        public Department Department { get; set; } = null!; // Navigation property to Department

        // FK MaBoPhan là cột Id, PK của Section
        public int MaBoPhan { get; set; }
        public Section Section { get; set; } = null!; // Navigation property to Section

        // FK MaChucVu
        public int MaChucVu { get; set; }
        public JobTitle JobTitle { get; set; } = null!; // Navigation property to JobTitle

        // FK MaTrinhDoHocVan
        public int MaTDHV { get; set; }
        public EducationLevel EducationLevel { get; set; } = null!; // Navigation property to EducationLevel

        // navigation properties to other entities
        public ICollection<WorkRecord> WorkRecords { get; set; } = new List<WorkRecord>(); // TINHCONG
        public ICollection<Salary> Salaries { get; set; } = new List<Salary>(); // LUONG
        public ICollection<Insurance> Insurances { get; set; } = new List<Insurance>(); // BHXH, BHYT, BHTN
        public ICollection<ExtraShift> ExtraShifts { get; set; } = new List<ExtraShift>(); // TANGCA
        public ICollection<EmployeeAllowance> EmployeeAllowances { get; set; } = new List<EmployeeAllowance>(); // PHUCAPNV
        public ICollection<Revenue> Revenues { get; set; } = new List<Revenue>(); // THU
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>(); // CHI
    }
}
