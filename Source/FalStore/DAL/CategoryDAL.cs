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

        //call store procedure view all category
        public List<objCategory> GetAllCatagory(int pageIndex, int pageSize, out int total)
        {

            List<objCategory> lst = new List<objCategory>();
            objCategory obj = null;

            SqlParameter prTotal = new SqlParameter ("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;
          
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spCategoryGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objCategory();
                obj.CategoryID = int.Parse(dr["CategoryID"].ToString());
                obj.CategoryName = dr["CategoryName"].ToString();
                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;
           
        }

        //call store procedure insert category
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

        //call store procedure update category
        public int UpdateCategory(objCategory obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CategoryID", obj.CategoryID));
            parameterList.Add(new SqlParameter("@CategoryName", obj.CategoryID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCategoryUpdate", parameterList);

        }

        //call store procedure delete category
        public int DeleteCategory(objCategory obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CategoryID", obj.CategoryID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCategoryDelete", parameterList);

        }

    }
}
