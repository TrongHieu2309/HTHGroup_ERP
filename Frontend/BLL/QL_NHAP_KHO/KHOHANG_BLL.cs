using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO
{
    public class KHOHANG_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<KHOHANG> GetList()
        {
            try
            {
                return db.KHOHANGs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving insurance data: " + ex.Message);
            }
        }
    }
}
