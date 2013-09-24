using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BIZ
{
    public class ReportBillDetailBIZ
    {
        ReportBillDetailDAL DAL = new ReportBillDetailDAL();
        public List<objReportBillDetail> GetBillDetailSearch(int branchID, int CategoryID, string ProductName, string ProductID, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<objReportBillDetail> lst = new List<objReportBillDetail>();
                lst = DAL.GetBillDetailSearch(branchID, CategoryID, ProductName, ProductID, startDate, endDate);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
