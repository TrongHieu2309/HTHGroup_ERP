using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_TAI_CHINH_BLL
{
    public class PHUCAP_NV_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<PHUCAPNV> GetList()
        {
            try
            {
                return db.PHUCAPNVs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving insurance data: " + ex.Message);
            }
        }
    }
}
