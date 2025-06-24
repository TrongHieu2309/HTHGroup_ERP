using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class PHONGBAN_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<PHONGBAN> GetList()
        {
            try
            {
                return db.PHONGBANs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving PHONGBAN list: " + ex.Message);
            }
        }
    }
}
