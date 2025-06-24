using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BAOHIEM_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<BAOHIEM> GetList()
        {
            try
            {
                return db.BAOHIEMs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving insurance data: " + ex.Message);
            }
        }
    }
}
