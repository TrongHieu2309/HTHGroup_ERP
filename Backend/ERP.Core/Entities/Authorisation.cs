namespace ERP.Core.Entities
{
    public class Authorisation
    {
        // Bảng Quyền hạn
        public int MaQuyen { get; set; } // primary key int
        public string TenQuyen { get; set; } = null!; // nvarchar 100 not null

        public ICollection<Authorise> Authorises { get; set; } = new List<Authorise>();
    }
}
