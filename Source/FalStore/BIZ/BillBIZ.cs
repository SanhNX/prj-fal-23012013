using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BIZ
{
    public class BillBIZ
    {
        BillDAL DAL = new BillDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objDoanhThu> GetBillSearch(int branchId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<objDoanhThu> lst = new List<objDoanhThu>();
                lst = DAL.GetBillSearch(branchId, startDate, endDate);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
