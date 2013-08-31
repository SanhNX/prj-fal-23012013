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
    public class BranchDAL
    {
        //initialize connection string
        public BranchDAL()
        {
        }

        //call store procedure view all branch
        public List<objBranch> GetAllBranch(int pageIndex, int pageSize, out int total)
        {
            List<objBranch> lst = new List<objBranch>();
            objBranch obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spBranchGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objBranch();
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.BranchName = dr["BranchName"].ToString();
                obj.Address = dr["Address"].ToString();
                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;
        }

        //call store procedure insert branch
        public int InsertBranch(objBranch obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchName", obj.BranchName));
            parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBranchInsert", parameterList);
      
        }

        //call store procedure update branch
        public int UpdateBranch(objBranch obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", obj.BranchID));
            parameterList.Add(new SqlParameter("@BranchName", obj.BranchName));
            parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBranchUpdate", parameterList);
      
        }

        //call store procedure delete branch
        public int DeleteBranch(objBranch obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", obj.BranchID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBranchDelete", parameterList);
      
        }

    }
}
