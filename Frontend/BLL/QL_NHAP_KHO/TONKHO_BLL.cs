using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_NHAP_KHO_BLL
{
    public class TONKHO_BLL
    {
        private QUANLY_ERPH1Entities1 db;

        public TONKHO_BLL()
        {
            db = new QUANLY_ERPH1Entities1();
        }

        public List<TONKHO> GetList()
        {
            try
            {
                return db.TONKHOes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving data: " + ex.Message);
            }
        }
    }
}
