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

        //call store procedure view product by paging
        public List<objProduct> GetProductByPaging(int pageIndex, int pageSize, out int total)
        {
            List<objProduct> lst = new List<objProduct>();
            objProduct obj = null;
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductGetByPaging", parameterList);
            while (dr.Read())
            {
                obj = new objProduct();
                obj.ProductID = dr["ProductID"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.Color = new objColor();
                obj.Color.ColorName = dr["ColorName"].ToString();
                obj.Category = new objCategory();
                obj.Category.CategoryName = dr["CategoryName"].ToString();
                obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                lst.Add(obj);
            }

            total = 20;
            return lst;


        }

        //call store procedure view product by id
        public objProduct GetProductByID(string ProductID)
        {
            objProduct obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", ProductID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductGetByID", parameterList);

            dr.Read();
            obj = new objProduct();
            //obj.ProductID = dr["ProductID"].ToString();
            obj.ProductName = dr["ProductName"].ToString();
            //obj.Color = new objColor();
            //obj.Color.ColorName = dr["ColorName"].ToString();
            obj.Category = new objCategory();
            obj.Category.CategoryID = int.Parse(dr["CategoryID"].ToString());
            obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
            obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());

            return obj;

        }

        //call store procedure insert product
        public int InsertProduct(objProduct obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.ProductID));
            parameterList.Add(new SqlParameter("@ProductName", obj.ProductName));
            //parameterList.Add(new SqlParameter("@Description", obj.Description));
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
        public int UpdateProduct(objProduct obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.ProductID));
            parameterList.Add(new SqlParameter("@ProductName", obj.ProductName));
            //parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@CategoryID", obj.Category.CategoryID));
            parameterList.Add(new SqlParameter("@ImportPrice", obj.ImportPrice));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spProductUpdate", parameterList);
        }

        //call store procedure delete product
        public int DeleteProduct(objProduct obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.ProductID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spProductDelete", parameterList);
        }

        //call store procedure insert color
        public int InsertColor(objColor obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ColorName", obj.ColorName));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spColorInsert", parameterList);
        }

        //call store procedure Update color
        public int UpdateColor(objColor obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ColorID", obj.ColorID));
            parameterList.Add(new SqlParameter("@ColorName", obj.ColorName));
            //parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spColorUpdate", parameterList);
        }

        //call store procedure view color by product id
        public List<objColor> GetColorByProductID(string ProductID)
        {
            List<objColor> lst = new List<objColor>();
            objColor obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", ProductID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spColorGetByProductID", parameterList);

            while (dr.Read())
            {
                obj = new objColor();
                obj.ColorName = dr["ColorName"].ToString();
      
                lst.Add(obj);
            }
            return lst;

        }

    }
}
