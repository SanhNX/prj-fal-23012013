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
    public class LogStoreDAL
    {
        //initialize connection string
        public LogStoreDAL()
        {
        }

        //call store procedure view all log store
        public List<objLogStore> GetAllLogStore(int pageIndex, int pageSize, out int total)
        {

            List<objLogStore> lst = new List<objLogStore>();
            objLogStore obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spLogStoreGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objLogStore();
                obj.LogStoreID = dr["LogStoreID"].ToString();
                obj.LogType = int.Parse(dr["LogType"].ToString());
                obj.Employee.EmployeeName = dr["EmployeeName"].ToString();
                obj.LogDate = dr["LogDate"].ToString();
                obj.BranchFrom.BranchName = dr["BranchFromName"].ToString();
                obj.BranchTo.BranchName = dr["BranchToName"].ToString();
                obj.Description = dr["Description"].ToString();

                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;

        }

        //call store procedure view all log detail by log store id
        public List<objLogDetail> GetLogDetailByLogStoreID(string logStoreID, int statusFlag)
        {

            List<objLogDetail> lst = new List<objLogDetail>();
            objLogDetail obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@LogStoreID", logStoreID));
            parameterList.Add(new SqlParameter("@StatusFlg", statusFlag));

            SqlDataReader dr = SQLHelper.ExecuteReader("spLogDetailGetByLogStoreID", parameterList);
            while (dr.Read())
            {
                obj = new objLogDetail();
                obj.LogStore = new objLogStore();
                obj.LogStore.LogStoreID = dr["Log_StoreID"].ToString();
                obj.Product = new objProduct();
                obj.Product.ProductID = dr["ProductID"].ToString();
                obj.Product.ProductName = dr["ProductName"].ToString();
                obj.Product.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse( dr["Quantity"].ToString());
                obj.Sale = float.Parse(dr["Sale"].ToString());
                obj.Amount = float.Parse(dr["Amount"].ToString());
                obj.Color= new objColor();
                obj.Color.ColorID = int.Parse(dr["ColorID"].ToString());
                obj.Color.ColorName= dr["ColorName"].ToString();
                obj.Size= dr["Size"].ToString();
               
                lst.Add(obj);
            }

            return lst;

        }

        //call store procedure get lastest id
        public string GetLogStoreByLastID()
        {
            string logID = string.Empty;
            SqlDataReader dr = SQLHelper.ExecuteReader("spLogStoreGetLastID");
            while (dr.Read())
            {
                logID = dr["Log_StoreID"].ToString();
            }
            return logID;

        }

        //call store procedure insert log store
        public int InsertLogStore(objLogStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStoreID));
            parameterList.Add(new SqlParameter("@LogType", obj.LogType));
            parameterList.Add(new SqlParameter("@EmployeeID", obj.Employee.EmployeeID));
            parameterList.Add(new SqlParameter("@LogDate", obj.LogDate));
            if (obj.BranchFrom != null)
            {
                parameterList.Add(new SqlParameter("@BranchFrom", obj.BranchFrom.BranchID));
            }
            else
            {
                parameterList.Add(new SqlParameter("@BranchFrom", obj.BranchTo.BranchID));
            }
            parameterList.Add(new SqlParameter("@BranchTo", obj.BranchTo.BranchID));
            parameterList.Add(new SqlParameter("@NCC", obj.NCC));
            parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spLogStoreInsert", parameterList);
        }

        //call store procedure insert log detail
        public int InsertLogDetail(objLogDetail obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStore.LogStoreID));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@Size", obj.Size));
            parameterList.Add(new SqlParameter("@Sale", obj.Sale));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@Amount", obj.Amount));

            return SQLHelper.ExecuteNonQuery("spLogDetailInsert", parameterList);
        }

        public int UpdateStatusLogDetail(string LogStoreID)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@LogStoreID", LogStoreID));
           
            return SQLHelper.ExecuteNonQuery("spLogDetailUpdateStatus", parameterList);
        }

    }
}
