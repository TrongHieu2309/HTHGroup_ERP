using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class TRINHDO_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<TRINHDO> GetList()
        {
            try
            {
                return db.TRINHDOes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving TRINHDO list: " + ex.Message);
            }
        }
    }
}
