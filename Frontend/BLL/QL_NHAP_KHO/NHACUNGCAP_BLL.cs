using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class NHACUNGCAP_BLL
    {
        private QUANLY_ERPH1Entities1 db;

        public NHACUNGCAP_BLL()
        {
            db = new QUANLY_ERPH1Entities1();
        }

        public List<NHACUNGCAP> GetList()
        {
            try
            {
                return db.NHACUNGCAPs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data: " + ex.Message);
            }
        }
    }
}
