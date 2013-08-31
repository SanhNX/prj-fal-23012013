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

        //call store procedure view all store
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
                obj.Size.SizeName = dr["SizeName"].ToString();
                obj.Branch.BranchName = dr["BranchName"].ToString();
                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());
                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;

        }

        //call store procedure insert store
        public int InsertStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@VerID", obj.VerID));
            parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@SizeID", obj.Size.SizeID));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spStoreInsert", parameterList);
        }

        //call store procedure update store
        public int UpdateStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@StoreID", obj.StoreID));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@VerID", obj.VerID));
            parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@SizeID", obj.Size.SizeID));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@ExportPrice", obj.ExportPrice));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spStoreUpdate", parameterList);
        }

        //call store procedure delete store
        public int DeleteStore(objStore obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@StoreID", obj.StoreID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spStoreDelete", parameterList);

        }

    }
}
