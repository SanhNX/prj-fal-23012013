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

        /// <summary>
        /// get by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<objProduct> GetProductByPaging(int pageIndex, int pageSize)
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
                obj.Category = new objCategory();
                obj.Category.CategoryName = dr["CategoryName"].ToString();
                obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                lst.Add(obj);
            }

            return lst;

        }

        /// <summary>
        /// get total row
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(prTotal);
            SqlDataReader dr = SQLHelper.ExecuteReader("spProductGetTotalCount", parameterList);
            int total = int.Parse(prTotal.Value.ToString());
            return total;

        }

        /// <summary>
        /// get product by ID
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public objProduct GetProductByID(string ProductID)
        {
            objProduct obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", ProductID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductGetByID", parameterList);

            while (dr.Read())
            {
                obj = new objProduct();
                obj.ProductID = dr["ProductID"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.Category = new objCategory();
                obj.Category.CategoryID = int.Parse(dr["CategoryID"].ToString());
                obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
            }
            return obj;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public objBarCode GetProductByBarCode(string barCode)
        {
            objBarCode obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@BarCode", barCode));

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductGetByBarCode", parameterList);

            while (dr.Read())
            {
                obj = new objBarCode();
                obj.Product = new objProduct();
                obj.Product.ProductID = dr["ProductID"].ToString();
                obj.Product.ProductName = dr["ProductName"].ToString();
                obj.Product.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                obj.Product.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.BarCode = dr["BarCode"].ToString();
                obj.ColorName = dr["ColorName"].ToString();
                obj.SizeName = dr["SizeName"].ToString();
            }
            return obj;

        }

        /// <summary>
        /// get product by ID
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
        public List<objBarCode> GetProductSearch(string ProductID, string ProductName, int categoryID)
        {
            List<objBarCode> lst = new List<objBarCode>();
            objBarCode obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", ProductID));
            parameterList.Add(new SqlParameter("@ProductName", ProductName));

            parameterList.Add(new SqlParameter("@CategoryID", categoryID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spProductSearch", parameterList);

            while (dr.Read())
            {
                obj = new objBarCode();
                obj.Product= new objProduct();
                obj.Product.ProductID = dr["ProductID"].ToString();
                obj.Product.ProductName = dr["ProductName"].ToString();
                obj.Product.Category = new objCategory();
                obj.Product.Category.CategoryName = dr["CategoryName"].ToString();
                obj.Product.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                obj.Product.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.ColorName = dr["ColorName"].ToString();
                obj.SizeName = dr["SizeName"].ToString();
                obj.BarCode = dr["BarCode"].ToString();
                lst.Add(obj);
            }
            return lst;

        }
        /// <summary>
        /// Add record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Edit record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update total quantity
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int UpdateProductTotalQuantity(string productID, int quantity)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@Quantity", quantity));

            return SQLHelper.ExecuteNonQuery("spProductUpdateTotalQuantity", parameterList);
        }

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="updateDate"></param>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        public int DeleteProduct(string productID, DateTime updateDate, string updateUser)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@UpdateDate", updateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", updateUser));

            return SQLHelper.ExecuteNonQuery("spProductDelete", parameterList);
        }

        /// <summary>
        /// add color
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertColor(objColor obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ColorName", obj.ColorName));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));

            return SQLHelper.ExecuteNonQuery("spColorInsert", parameterList);
        }

        //update color
        public int UpdateColor(objColor obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ColorID", obj.ColorID));
            parameterList.Add(new SqlParameter("@ColorName", obj.ColorName));

            return SQLHelper.ExecuteNonQuery("spColorUpdate", parameterList);
        }

        /// <summary>
        /// get color by product
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns></returns>
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
                obj.ColorID = int.Parse(dr["ColorID"].ToString());
                obj.ColorName = dr["ColorName"].ToString();

                lst.Add(obj);
            }
            return lst;

        }


        /// <summary>
        /// insert barcode
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertBarCode(objBarCode obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BarCodeID", obj.BarCode));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@ColorName", obj.ColorName));
            parameterList.Add(new SqlParameter("@SizeName", obj.SizeName));

            return SQLHelper.ExecuteNonQuery("spBarCodeInsert", parameterList);
        }


    }
}
