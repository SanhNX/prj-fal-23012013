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
   public class BillDAL
    {

        public List<objDoanhThu> GetBillSearch(int branchId, DateTime startDate, DateTime endDate)
        {

            List<objDoanhThu> lst = new List<objDoanhThu>();

            objDoanhThu obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchId));


            parameterList.Add(new SqlParameter("@CreateDate1", startDate));

            parameterList.Add(new SqlParameter("@CreateDate2", endDate));

            SqlDataReader dr = SQLHelper.ExecuteReader("spBillSearch", parameterList);
            while (dr.Read())
            {
                obj = new objDoanhThu();

                obj.BillID = dr["BillID"].ToString();

                obj.EmployeeName = dr["EmployeeName"].ToString();

                obj.CustomerName = dr["CustomerName"].ToString();

                obj.BranchName = dr["BranchName"].ToString();

                obj.TotalPrice = float.Parse(dr["TotalPrice"].ToString());

                obj.Sale = float.Parse(dr["Sale"].ToString());

                obj.ActualTotalPrice =float.Parse(dr["ActualTotalPrice"].ToString());

                obj.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());

                obj.CreateUser = dr["CreateUser"].ToString();

                obj.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());

                obj.UpdateUser = dr["UpdateUser"].ToString();

                obj.Update_Flg = int.Parse(dr["Update_Flg"].ToString());

                lst.Add(obj);
            }

            return lst;

        }

        public List<objBill> GetBillByID(string billID)
        {

            List<objBill> lst = new List<objBill>();

            objBill obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", billID));


            SqlDataReader dr = SQLHelper.ExecuteReader("spGetBillByID", parameterList);
            while (dr.Read())
            {
                obj = new objBill();

                obj.BillID = dr["BillID"].ToString();

                obj.EmployeeName = dr["EmployeeName"].ToString();

                obj.CustomerName = dr["CustomerName"].ToString();

                obj.CustomerID = int.Parse(dr["CustomerID"].ToString());

                obj.BranchID = int.Parse(dr["BranchID"].ToString());

                obj.BranchName = dr["BranchName"].ToString();

                obj.TotalPrice = float.Parse(dr["TotalPrice"].ToString());

                obj.Sale = float.Parse(dr["Sale"].ToString());

                obj.ActualTotalPrice = float.Parse(dr["ActualTotalPrice"].ToString());

                obj.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());

                obj.CreateUser = dr["CreateUser"].ToString();

                obj.UpdateDate = DateTime.Parse(dr["UpdateDate"].ToString());

                obj.UpdateUser = dr["UpdateUser"].ToString();

                obj.Update_Flg = int.Parse(dr["Update_Flg"].ToString());

                lst.Add(obj);
            }

            return lst;

        }

        public List<objBillDetail> GetBillDetailByID(string billID, int branchID)
        {

            List<objBillDetail> lst = new List<objBillDetail>();

            objBillDetail obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", billID));
            parameterList.Add(new SqlParameter("@BranchID", branchID));


            SqlDataReader dr = SQLHelper.ExecuteReader("spGetBillDetailByID", parameterList);
            while (dr.Read())
            {
                obj = new objBillDetail();

                obj.BillDetailID = int.Parse(dr["Bill_DetailID"].ToString());

                obj.BarCode = dr["BarCode"].ToString();

                obj.Quantity = int.Parse(dr["Quantity"].ToString());

                obj.Amount = float.Parse(dr["Amount"].ToString());

                obj.Delete_Flg = int.Parse(dr["Delete_Flg"].ToString());

                obj.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());

                obj.CreateUser = dr["CreateUser"].ToString();

                obj.ProductName = dr["ProductName"].ToString();

                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());


                lst.Add(obj);
            }

            return lst;

        }

        public List<objBillDetail> GetBillDetailCtByID(string billID, int branchID)
        {

            List<objBillDetail> lst = new List<objBillDetail>();

            objBillDetail obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", billID));
            parameterList.Add(new SqlParameter("@BranchID", branchID));


            SqlDataReader dr = SQLHelper.ExecuteReader("spGetBillDetailCtByID", parameterList);
            while (dr.Read())
            {
                obj = new objBillDetail();

                obj.BillDetailID = int.Parse(dr["Bill_DetailID"].ToString());

                obj.BarCode = dr["BarCode"].ToString();

                obj.Quantity = int.Parse(dr["Quantity"].ToString());

                obj.Amount = float.Parse(dr["Amount"].ToString());

                obj.Delete_Flg = int.Parse(dr["Delete_Flg"].ToString());

                obj.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());

                obj.CreateUser = dr["CreateUser"].ToString();

                obj.ProductName = dr["ProductName"].ToString();

                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());


                lst.Add(obj);
            }

            return lst;

        }

        public int GetNextId()
        {
            int id = 0;
            SqlDataReader dr = SQLHelper.ExecuteReader("[spBillGetMaxId]");
            if(dr.Read())
            {
                id = int.Parse(dr["MaxID"].ToString() == "" ? "000000000" : dr["MaxID"].ToString()) + 1;
            }

            return id;
        }

        //call store procedure insert Bill
        public int InsertBill(objBill obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", obj.BillID));
            parameterList.Add(new SqlParameter("@EmployeeID", obj.EmployeeID));
            parameterList.Add(new SqlParameter("@BranchID", obj.BranchID));
            parameterList.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            parameterList.Add(new SqlParameter("@TotalPrice", obj.TotalPrice));
            parameterList.Add(new SqlParameter("@Sale", obj.Sale));
            parameterList.Add(new SqlParameter("@ActualTotalPrice", obj.ActualTotalPrice));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            int result = SQLHelper.ExecuteNonQuery("spBillInsert", parameterList);
            return result;

        }

        public int UpdateBill(objBill obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", obj.BillID));
            parameterList.Add(new SqlParameter("@TotalPrice", obj.TotalPrice));
            parameterList.Add(new SqlParameter("@Sale", obj.Sale));
            parameterList.Add(new SqlParameter("@ActualTotalPrice", obj.ActualTotalPrice));
            parameterList.Add(new SqlParameter("@UpdateDate", DateTime.Now));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBillUpdate", parameterList);

        }

    }
}