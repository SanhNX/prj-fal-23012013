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
    public class ProductDAL
    {

        //initialize connection string
        public ProductDAL()
        {
        }

        //call store procedure view all product
        public List<objProduct> GetAllProduct(int pageIndex, int pageSize, out int total)
        {
            List<objProduct> lst = new List<objProduct>();
            objProduct obj = null;
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objProduct();
                obj.ProductID = dr["ProductID"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.Category.CategoryName = dr["CategoryName"].ToString();
                obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;


        }

        //call store procedure insert product
        public int InsertProduct(objProduct obj)
        {
            
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.ProductID));
            parameterList.Add(new SqlParameter("@ProductName", obj.ProductName));
            parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@CategoryID", obj.Category.CategoryID));
            parameterList.Add(new SqlParameter("@ImportPrice", obj.ImportPrice));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spProductInsert", parameterList);
        }

        //call store procedure update product
        public int UpdateCategory(objProduct obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.ProductID));
            parameterList.Add(new SqlParameter("@ProductName", obj.ProductName));
            parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@CategoryID", obj.Category.CategoryID));
            parameterList.Add(new SqlParameter("@ImportPrice", obj.ImportPrice));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spProductUpdate", parameterList);
        }

        //call store procedure delete product
        public int DeleteCategory(objProduct obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.ProductID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spProductDelete", parameterList);
        }

    }
}
