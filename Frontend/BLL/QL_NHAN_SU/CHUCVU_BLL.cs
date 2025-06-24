using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class CHUCVU_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<CHUCVU> GetList()
        {
            try
            {
                return db.CHUCVUs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving CHUCVU list: " + ex.Message);
            }
        }
    }
}
