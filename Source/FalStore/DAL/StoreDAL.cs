﻿using System;
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
    public class StoreDAL
    {
        //initialize connection string
        public StoreDAL()
        {
        }

        /// <summary>
        /// get all store
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objStore> GetAllStore(int pageIndex, int pageSize, out int total)
        {

            List<objStore> lst = new List<objStore>();
            objStore obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objStore();
                obj.StoreID = int.Parse(dr["StoreID"].ToString());
                obj.Product.ProductName = dr["ProductName"].ToString();
                obj.VerID = dr["VerId"].ToString();
                obj.Color.ColorName = dr["ColorName"].ToString();
                obj.Size = dr["SizeName"].ToString();
                obj.Branch.BranchName = dr["BranchName"].ToString();
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());
                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;

        }

        /// <summary>
        /// get product info : ProductID, ColorID, Size, Branch
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="colorID"></param>
        /// <param name="size"></param>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public objStore GetProductInfoByBranch(string productID, int colorID, string size, int branchID)
        {

            objStore obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@ColorID", colorID));
            parameterList.Add(new SqlParameter("@Size", size));
            parameterList.Add(new SqlParameter("@BranchID", branchID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreGetProductInfoByBranch", parameterList);
            while (dr.Read())
            {
                obj = new objStore();

                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());

            }

            return obj;
        }

        /// <summary>
        /// get product in store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public objProduct GetProductInStore(string productID, int branchID)
        {

            objProduct obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@BranchID", branchID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreGetProductID", parameterList);
            while (dr.Read())
            {
                obj = new objProduct();

                obj.ProductID = dr["ProductID"].ToString();
            }

            return obj;
        }

        /// <summary>
        /// get product in store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public int GetQuantityProductInStore(string productID, int branchID,int colorID, string size)
        {
            int quantity =0;
            
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@ColorID", colorID));
            parameterList.Add(new SqlParameter("@Size", size));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreGetQuantity", parameterList);
            while (dr.Read())
            {
                quantity= int.Parse(dr["Quantity"].ToString());
            }

            return quantity;
        }
        /// <summary>
        /// insert store
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            // parameterList.Add(new SqlParameter("@VerID", obj.VerID));
            parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@Size", obj.Size));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStore.LogStoreID));

            return SQLHelper.ExecuteNonQuery("spStoreInsert", parameterList);
        }

        /// <summary>
        /// update store
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int UpdateStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@StoreID", obj.StoreID));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@VerID", obj.VerID));
            parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@SizeID", obj.Size));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStore.LogStoreID));

            return SQLHelper.ExecuteNonQuery("spStoreUpdate", parameterList);
        }

        /// <summary> 
        /// update store quantity
        /// </summary>
        /// <param name="branchID"></param>
        /// <param name="productID"></param>
        /// <param name="colorID"></param>
        /// <param name="size"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int UpdateStoreQuantity(int branchID, string productID, int colorID, string size, int quantity)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@ColorID", colorID));
            parameterList.Add(new SqlParameter("@Size", size));
            parameterList.Add(new SqlParameter("@NewQuantity", quantity));

            return SQLHelper.ExecuteNonQuery("spStoreUpdateQuantity", parameterList);
        }
        
        /// <summary>
        /// delete store
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int DeleteStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@StoreID", obj.StoreID));

            return SQLHelper.ExecuteNonQuery("spStoreDelete", parameterList);

        }

        public List<objStore> GetStoreSearch(string productID, string productName, int branchID, int categoryID)
        {
            List<objStore> lst = new List<objStore>();
            objStore obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            if (productID != string.Empty)
            {
                parameterList.Add(new SqlParameter("@ProductID", "'%" + productID + "%'"));
            }
            else
            {
                parameterList.Add(new SqlParameter("@ProductID", productID ));
            }

            if (productName != string.Empty)
            {
                parameterList.Add(new SqlParameter("@ProductName", "'%" + productName + "%'"));
            }
            else
            {
                parameterList.Add(new SqlParameter("@ProductName",  productName ));
            }
           
            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@CategoryID", categoryID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreSearch", parameterList);
            while (dr.Read())
            {
                obj = new objStore();
                obj.Product = new objProduct();
                obj.Product.ProductID = dr["ProductID"].ToString();
                obj.Product.ProductName = dr["ProductName"].ToString();
                obj.Product.ImportPrice = float.Parse( dr["ImportPrice"].ToString());
                //obj.VerID = dr["VerId"].ToString();
                obj.Color = new objColor();
                obj.Color.ColorName = dr["ColorName"].ToString();
                obj.Size = dr["Size"].ToString();
                obj.Branch = new objBranch();
                obj.Branch.BranchName = dr["BranchName"].ToString();
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());
                lst.Add(obj);
            }

            return lst;

 
        }

    }
}