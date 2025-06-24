using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TAI_CHINH_BLL
{
    public class KHOANTHU_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<THU> GetList()
        {
            try
            {
                return db.THUs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving insurance data: " + ex.Message);
            }
        }
    }
}
