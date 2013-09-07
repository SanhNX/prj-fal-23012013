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

        //call store procedure view branch by paging
        public List<objBranch> GetBranchByPaging(int pageIndex, int pageSize)
        {
            List<objBranch> lst = new List<objBranch>();
            objBranch obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spBranchGetByPaging", parameterList);
            while (dr.Read())
            {
                obj = new objBranch();
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.BranchName = dr["BranchName"].ToString();
                obj.Address = dr["Address"].ToString();
                obj.Description = dr["Description"].ToString();
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
            SqlDataReader dr = SQLHelper.ExecuteReader("spBranchGetTotalCount", parameterList);
            int total = int.Parse(prTotal.Value.ToString());
            return total;

        }
        
        //call store procedure view all branch
        public List<objBranch> GetBranchAll()
        {
            List<objBranch> lst = new List<objBranch>();
            objBranch obj = null;

            SqlDataReader dr = SQLHelper.ExecuteReader("spBranchGetAll");
            while (dr.Read())
            {
                obj = new objBranch();
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.BranchName = dr["BranchName"].ToString();
                lst.Add(obj);
            }

            return lst;
        }

        public objBranch GetBranchByID(int BranchID)
        {

            objBranch obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@BranchID", BranchID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spBranchGetByID", parameterList);
            while (dr.Read())
            {
                obj = new objBranch();
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.BranchName= dr["BranchName"].ToString();
                obj.Address = dr["Address"].ToString();
                obj.Description = dr["Description"].ToString();
            }

            return obj;

        }

        //call store procedure insert branch
        public int InsertBranch(objBranch obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchName", obj.BranchName));
            parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@Description", obj.Description));
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
            parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spBranchUpdate", parameterList);
      
        }

        //call store procedure delete branch
        public int DeleteBranch(int branchID, DateTime updateDate, string updateUser)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@UpdateDate", updateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", updateUser));

            return SQLHelper.ExecuteNonQuery("spBranchDelete", parameterList);
      
        }

    }
}
