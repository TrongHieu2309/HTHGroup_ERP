using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class LOAICA_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<LOAICA> GetList()
        {
            try
            {
                return db.LOAICAs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving fish type list: " + ex.Message);
            }
        }
    }
}
