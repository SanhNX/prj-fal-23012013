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
    public class CategoryDAL
    {
        //initialize connection string
        public CategoryDAL()
        {
        }

        /// <summary>
        /// get category by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<objCategory> GetCategoryByPaging(int pageIndex, int pageSize)
        {

            List<objCategory> lst = new List<objCategory>();
            objCategory obj = null;

            SqlParameter prTotal = new SqlParameter ("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;
          
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spCategoryGetByPaging", parameterList);
            while (dr.Read())
            {
                obj = new objCategory();
                obj.CategoryID = int.Parse(dr["CategoryID"].ToString());
                obj.CategoryName = dr["CategoryName"].ToString();
                lst.Add(obj);
            }

            //total = int.Parse( prTotal.Value.ToString());
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
            SqlDataReader dr = SQLHelper.ExecuteReader("spCategoryGetTotalCount", parameterList);
            int total = int.Parse( prTotal.Value.ToString());
            return total;
           
        }
        
        /// <summary>
        /// get all category
        /// </summary>
        /// <returns></returns>
        public List<objCategory> GetAllCategory()
        {

            List<objCategory> lst = new List<objCategory>();
            objCategory obj = null;

            SqlDataReader dr = SQLHelper.ExecuteReader("spCategoryGetAll");
            while (dr.Read())
            {
                obj = new objCategory();
                obj.CategoryID = int.Parse(dr["CategoryID"].ToString());
                obj.CategoryName = dr["CategoryName"].ToString();
                lst.Add(obj);
            }

            return lst;

        }

        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <returns></returns>
        public objCategory GetCategoryByID(int CategoryID)
        {

            objCategory obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@CategoryID", CategoryID));
            
            SqlDataReader dr = SQLHelper.ExecuteReader("spCategoryGetByID", parameterList);
            while (dr.Read())
            {
                obj = new objCategory();
                obj.CategoryID = int.Parse(dr["CategoryID"].ToString());
                obj.CategoryName = dr["CategoryName"].ToString();
            }

            return obj;

        }

        /// <summary>
        /// get by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public objCategory GetCategoryByName(string name)
        {

            objCategory obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@CategoryName", name));

            SqlDataReader dr = SQLHelper.ExecuteReader("spCategoryGetByName", parameterList);
            while (dr.Read())
            {
                obj = new objCategory();
                obj.CategoryID = int.Parse(dr["CategoryID"].ToString());
                obj.CategoryName = dr["CategoryName"].ToString();
            }

            return obj;

        }

        /// <summary>
        /// Insert record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertCategory(objCategory obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CategoryName", obj.CategoryName));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCategoryInsert", parameterList);
        }

        /// <summary>
        /// Update record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateCategory(objCategory obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CategoryID", obj.CategoryID));
            parameterList.Add(new SqlParameter("@CategoryName", obj.CategoryName));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCategoryUpdate", parameterList);

        }

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="CategoryID"></param>
        /// <param name="UpdateDate"></param>
        /// <param name="UpdateUser"></param>
        /// <returns></returns>
        public int DeleteCategory(int CategoryID, DateTime UpdateDate, string UpdateUser)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CategoryID", CategoryID));
            parameterList.Add(new SqlParameter("@UpdateDate", UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCategoryDelete", parameterList);

        }

    }
}
