using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class PHANQUYEN_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<PHANQUYEN> GetList()
        {
            try
            {
                return db.PHANQUYENs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching data: " + ex.Message);
            }
        }
    }
}
