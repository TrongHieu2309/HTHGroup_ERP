namespace ERP.Core.Entities
{
    public class DayType
    {
        // bảng Loại Công
        public int MaLoaiCong { get; set; } // PK
        public string TenLoaiCong { get; set; } = null!; // nvarchar 100 not null
        public float HeSo { get; set; } // HeSo: float, not null

        // navigation property to WorkRecord
        public ICollection<WorkRecord> WorkRecords { get; set; } = new List<WorkRecord>();
    }
}
