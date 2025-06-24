using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class NGUOIDUNG_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<NGUOIDUNG> GetList()
        {
            try
            {
                return db.NGUOIDUNGs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching user list: " + ex.Message);
            }
        }
    }
}
