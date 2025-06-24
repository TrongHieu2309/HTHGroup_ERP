using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class NHANSU_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<NHANSU> GetList()
        {
            try
            {
                return db.NHANSUs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving employee list: " + ex.Message);
            }
        }
    }
}
