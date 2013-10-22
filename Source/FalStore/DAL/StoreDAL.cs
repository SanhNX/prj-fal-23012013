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
                obj.ProductName = dr["ProductName"].ToString();
                obj.VerID = dr["VerId"].ToString();
                //obj.Color.ColorName = dr["ColorName"].ToString();
                //obj.Size = dr["SizeName"].ToString();
                obj.Branch.BranchName = dr["BranchName"].ToString();
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());
                lst.Add(obj);
            }

            dr.Close();


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
        public objStore GetBarCodeInfoByBranch(string barCode, int branchID)
        {

            objStore obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@BarCode", barCode));
            parameterList.Add(new SqlParameter("@BranchID", branchID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreGetBarCodeByBranch", parameterList);
            while (dr.Read())
            {
                obj = new objStore();

                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());

            }

            dr.Close();

            return obj;
        }

        /// <summary>
        /// get product in store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public objStore GetStoreByBarCodeAndBranch(string barCode, int branchID)
        {

            objStore obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@BarCode", barCode));
            parameterList.Add(new SqlParameter("@BranchID", branchID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spGetStoreByBarCodeAndBranch", parameterList);
            while (dr.Read())
            {
                obj = new objStore();

                obj.StoreID = int.Parse(dr["StoreID"].ToString());
                obj.BarCode = new objBarCode();
                obj.BarCode.BarCode = dr["BarCode"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                obj.Branch = new objBranch();
                obj.Branch.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());
            }

            dr.Close();

            return obj;
        }

        /// <summary>
        /// get product in store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public int GetQuantityProductInStore(string barCode, int branchID)
        {
            int quantity = 0;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@BarCode", barCode));
            parameterList.Add(new SqlParameter("@BranchID", branchID));
            //parameterList.Add(new SqlParameter("@ColorID", colorID));
            //parameterList.Add(new SqlParameter("@Size", size));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreGetQuantity", parameterList);
            while (dr.Read())
            {
                quantity = int.Parse(dr["Quantity"].ToString());
            }

            dr.Close();

            return quantity;
        }

        public int UpdateQuantity(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BarCode", obj.BarCode.BarCode));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@NewQuantity", obj.Quantity));

            return SQLHelper.ExecuteNonQuery("spStoreUpdateQuantity_Sub", parameterList);
        }

        public int UpdateSumQuantity(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BarCode", obj.BarCode.BarCode));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@NewQuantity", obj.Quantity));

            return SQLHelper.ExecuteNonQuery("spStoreUpdateSumQuantity", parameterList);
        }
        /// <summary>
        /// insert store
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BarCode", obj.BarCode.BarCode));
            parameterList.Add(new SqlParameter("@ProductName", obj.ProductName));
            //parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@ImportPrice", obj.ImportPrice));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStoreID));

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
            // parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@VerID", obj.VerID));
            //parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            //parameterList.Add(new SqlParameter("@SizeID", obj.Size));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStoreID));

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
        public int UpdateStoreQuantity(int branchID, string barCode, int quantity)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@BarCode", barCode));
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
            parameterList.Add(new SqlParameter("@ProductID", productID));
            parameterList.Add(new SqlParameter("@ProductName", productName));

            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@CategoryID", categoryID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spStoreSearch", parameterList);
            while (dr.Read())
            {
                obj = new objStore();
                obj.BarCode = new objBarCode();
                obj.BarCode.BarCode = dr["BarCode"].ToString();
                obj.ProductName = dr["ProductName"].ToString();
                // obj.Product.ProductName = dr["ProductName"].ToString();
                obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());
                // obj.VerID = dr["VerId"].ToString();
                //obj.Color = new objColor();
                obj.BarCode.ColorName = dr["ColorName"].ToString();
                obj.BarCode.SizeName = dr["SizeName"].ToString();
                obj.Branch = new objBranch();
                obj.Branch.BranchName = dr["BranchName"].ToString();
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());
                lst.Add(obj);
            }

            dr.Close();

            return lst;


        }

    }
}
