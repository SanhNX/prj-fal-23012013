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

            SqlParameter prTotal = new SqlParameter ("@total", SqlDbType.Int);
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
                obj.LogDate = DateTime.Parse( dr["LogDate"].ToString());
                obj.BranchFrom.BranchName = dr["BranchFromName"].ToString();
                obj.BranchTo.BranchName = dr["BranchToName"].ToString();
                obj.Description = dr["Description"].ToString();

                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;
           
        }

        //call store procedure insert log store
        public int InsertLogStore(objLogStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStoreID));
            parameterList.Add(new SqlParameter("@LogType", obj.LogType));
            parameterList.Add(new SqlParameter("@EmployeeID", obj.Employee.EmployeeID));
            parameterList.Add(new SqlParameter("@LogDate", obj.LogDate));
            parameterList.Add(new SqlParameter("@BranchFrom", obj.BranchFrom.BranchID));
            parameterList.Add(new SqlParameter("@BranchTo", obj.BranchTo.BranchName));
            parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spLogStoreInsert", parameterList);
        }

    }
}
