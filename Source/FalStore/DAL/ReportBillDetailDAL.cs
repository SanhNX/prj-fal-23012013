using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Common.Helper;

namespace DAL
{
    public class ReportBillDetailDAL
    {
        public List<objReportBillDetail> GetBillDetailSearch(int branchID, int CategoryID, string ProductName, string ProductID, DateTime startDate, DateTime endDate)
        {


            List<objReportBillDetail> lst = new List<objReportBillDetail>();

            objReportBillDetail obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchID));

            parameterList.Add(new SqlParameter("@CategoryID", CategoryID));

            parameterList.Add(new SqlParameter("@ProductName", ProductName));

            parameterList.Add(new SqlParameter("@ProductID", ProductID));

            parameterList.Add(new SqlParameter("@CreateDate1", startDate));

            parameterList.Add(new SqlParameter("@CreateDate2", endDate));

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductBillDetailSearch", parameterList);
            while (dr.Read())
            {
                obj = new objReportBillDetail();

                obj.BarCode = dr["BarCode"].ToString();

                obj.ProductID = dr["ProductID"].ToString();

                obj.ProductName = dr["ProductName"].ToString();

                obj.ColorName = dr["ColorName"].ToString();

                obj.SizeName = dr["SizeName"].ToString();

                obj.CategoryName = dr["CategoryName"].ToString();

                obj.CategoryID = int.Parse(dr["CategoryID"].ToString());

                obj.Quantity = int.Parse(dr["Quantity"].ToString());


                lst.Add(obj);
            }

            return lst;
        
        }
    }
}
