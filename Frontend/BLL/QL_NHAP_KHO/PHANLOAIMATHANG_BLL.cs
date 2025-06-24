using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO
{
    public class PHANLOAIMATHANG_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<PHANLOAIMATHANG> GetList()
        {
            try
            {
                return db.PHANLOAIMATHANGs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data: " + ex.Message);
            }
        }
    }
}
