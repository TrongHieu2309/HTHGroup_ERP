using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class TINHCONG_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<TINHCONG> GetList()
        {
            try
            {
                return db.TINHCONGs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving insurance data: " + ex.Message);
            }
        }
    }
}
