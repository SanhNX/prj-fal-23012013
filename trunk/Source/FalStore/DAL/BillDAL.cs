﻿using System;
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

        public List<objBillDetail> GetBillDetailByID(string billID)
        {

            List<objBillDetail> lst = new List<objBillDetail>();

            objBillDetail obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", billID));


            SqlDataReader dr = SQLHelper.ExecuteReader("spGetBillByID", parameterList);
            while (dr.Read())
            {
                obj = new objBillDetail();

                obj.Bill_DetailID =int.Parse(dr["Bill_DetailID"].ToString());

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

    }
}