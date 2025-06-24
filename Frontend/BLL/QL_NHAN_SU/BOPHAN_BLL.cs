using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class BOPHAN_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<BOPHAN> GetList()
        {
            try
            {
                return db.BOPHANs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving BOPHAN list: " + ex.Message);
            }
        }
    }
}
