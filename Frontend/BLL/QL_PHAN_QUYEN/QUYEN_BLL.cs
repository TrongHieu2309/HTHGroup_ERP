using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.QL_PHAN_QUYEN
{
    public class QUYEN_BLL
    {
        QUANLY_ERPH1Entities1 db = new QUANLY_ERPH1Entities1();

        public List<QUYEN> GetList()
        {
            return db.QUYENs.ToList();
        }
    }
}
