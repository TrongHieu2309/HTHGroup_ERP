using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class SANPHAM_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<SANPHAM> GetList()
        {
            try
            {
                return db.SANPHAMs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving insurance data: " + ex.Message);
            }
        }
    }
}
