using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_BAN_HANG
{
    public class XUATKHO_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<XUATKHO> GetList()
        {
            try
            {
                return db.XUATKHOes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data: " + ex.Message);
            }
        }

        public List<CHITIETXUATKHO> LayMAPHIEUXUAT(int maphieuxuat)
        {
            return db.CHITIETXUATKHOes.Where(ct => ct.MAPHIEUXUAT == maphieuxuat).ToList();
        }
    }
}
