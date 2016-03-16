using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class PurchaseOrder
    {
        DBHelper dbh = new DBHelper();

        public DataTable GetPurchaseOrder(DateTime d1, DateTime d2)
        {
            string SQL = string.Format(@"SELECT * From [PurchaseOrder] WHERE ('{1}' IS NULL OR ValidFrom <= '{1}') AND ('{0}' IS NULL OR ValidThru >= '{0}') ", d1,d2);

            return dbh.GetListBySQL(SQL);

        }

    }
}
