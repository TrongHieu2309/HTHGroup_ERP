using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class NHAPKHO_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<NHAPKHO> GetList()
        {
            try
            {
                return db.NHAPKHOes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data: " + ex.Message);
            }
        }

        public List<CHITIETNHAPKHO> LayMAPHIEUNHAP(int maphieunhap)
        {
            return db.CHITIETNHAPKHOes.Where(ct => ct.MAPHIEUNHAP == maphieunhap).ToList();
        }
    }
}
