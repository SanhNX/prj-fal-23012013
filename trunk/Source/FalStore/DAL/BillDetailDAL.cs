using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Common.Constants;
using Common.Helper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
namespace DAL
{
    public class BillDetailDAL
    {
        BranchDAL DALBranch = new BranchDAL();
        //initialize connection string
        public BillDetailDAL()
        {
        }

        //call store procedure view BillDetail by paging
        public List<objBillDetail> GetBillDetailByPaging(int pageIndex, int pageSize)
        {
            List<objBillDetail> lst = new List<objBillDetail>();
            objBillDetail obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spBillDetailGetByPaging", parameterList);
            while (dr.Read())
            {
                obj = new objBillDetail();
                obj.BillDetailID = int.Parse(dr["BillDetailID"].ToString());
                //obj.BillDetailName = dr["BillDetailName"].ToString();
                //obj.BranchID = dr["BranchID"].ToString();
                //obj.BranchName = dr["BranchName"].ToString();
                //obj.StartDate = dr["StartDate"].ToString();
                //obj.EndDate = dr["EndDate"].ToString();
                //obj.Discount = dr["DisCount"].ToString();
                lst.Add(obj);
            }

            //total = int.Parse(prTotal.Value.ToString());
            return lst;
        }

        /// <summary>
        /// get toal row
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(prTotal);
            SqlDataReader dr = SQLHelper.ExecuteReader("spBillDetailGetTotalCount", parameterList);
            int total = int.Parse(prTotal.Value.ToString());
            return total;

        }
        
        //call store procedure view all BillDetail
        public List<objBillDetail> GetBillDetailAll()
        {
            List<objBillDetail> lst = new List<objBillDetail>();
            
            objBillDetail obj = null;

            SqlDataReader dr = SQLHelper.ExecuteReader("spBillDetailGetAll");
            while (dr.Read())
            {
                obj = new objBillDetail();
                obj.BillDetailID = int.Parse(dr["BillDetailID"].ToString());
                //obj.BillDetailName = dr["Name"].ToString();
                //obj.Branch = DALBranch.GetBranchByID(int.Parse(dr["BranchID"].ToString()));
                //obj.StartDate = dr["StartDate"].ToString();
                //obj.EndDate = dr["EndDate"].ToString();
                //obj.Discount = dr["DisCount"].ToString();
                lst.Add(obj);
            }

            return lst;
        }

        public objBillDetail GetBillDetailByID(int BillDetailID)
        {

            objBillDetail obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@BillDetailID", BillDetailID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spBillDetailGetByID", parameterList);
            while (dr.Read())
            {
                obj = new objBillDetail();
                obj.BillDetailID = int.Parse(dr["BillDetailID"].ToString());
                //obj.BillDetailName = dr["Name"].ToString();
                //obj.Branch = DALBranch.GetBranchByID(int.Parse(dr["BranchID"].ToString()));
                //obj.StartDate = dr["StartDate"].ToString();
                //obj.EndDate = dr["EndDate"].ToString();
                //obj.Discount = dr["DisCount"].ToString();
            }

            return obj;

        }

        //call store procedure insert BillDetail
        public int InsertBillDetail(objBillDetail obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", obj.BillID));
            parameterList.Add(new SqlParameter("@BranchID", obj.BranchID));
            parameterList.Add(new SqlParameter("@BarCode", obj.BarCode));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@Amount", obj.Amount));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));

            return SQLHelper.ExecuteNonQuery("spBillDetailInsert", parameterList);
      
        }

        //call store procedure update BillDetail
        public int UpdateBillDetail(objBillDetail obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", obj.BillID));
            parameterList.Add(new SqlParameter("@BarCode", obj.BarCode));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@Amount", obj.Amount));
            parameterList.Add(new SqlParameter("@UpdateDate", DateTime.Now));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBillDetailUpdate", parameterList);
      
        }

        //call store procedure delete BillDetail
        public int DeleteBillDetail(objBillDetail obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BillID", obj.BillID));
            parameterList.Add(new SqlParameter("@BarCode", obj.BarCode));
            parameterList.Add(new SqlParameter("@UpdateDate", DateTime.Now));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBillDetailDelete", parameterList);
      
        }

    }
}
