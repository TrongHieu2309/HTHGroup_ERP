namespace ERP.Core.Entities
{
    public class ShiftType
    {
        // bảng loại ca làm việc
        public int MaLoaiCa { get; set; }
        public string CaLamViec { get; set; } = null!; // nvarchar 50 not null
        public float HeSoTangCa { get; set; } = 1.0f; // HeSoTangCa: float, not null default 1.0

        // navigation property to ExtraShift
        public ICollection<ExtraShift> ExtraShifts { get; set; } = new List<ExtraShift>();
    }
}
