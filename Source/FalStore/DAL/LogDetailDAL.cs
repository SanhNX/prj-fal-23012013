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
    public class LogDetailDAL
    {
        //initialize connection string
        public LogDetailDAL()
        {
        }

        //call store procedure view all LogDetail
        public List<objLogDetail> GetLogDetail(string logStoreID, int pageIndex, int pageSize, out int total)
        {

            List<objLogDetail> lst = new List<objLogDetail>();
            objLogDetail obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);
            parameterList.Add(new SqlParameter("@LogStoreID", pageIndex));

            SqlDataReader dr = SQLHelper.ExecuteReader("spLogDetailGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objLogDetail();
                obj.LogDetailID = int.Parse(dr["LogDetailID"].ToString());
                obj.LogStore.LogStoreID = dr["LogStoreID"].ToString();
                obj.Product.ProductName = dr["ProductName"].ToString();
                obj.Color.ColorName = dr["ColorName"].ToString();
                obj.Size = dr["SizeName"].ToString();
                obj.Sale = float.Parse(dr["Sale"].ToString());
                obj.Quantity = int.Parse(dr["Quantity"].ToString());

                lst.Add(obj);
            }

            total = int.Parse(prTotal.Value.ToString());
            return lst;

        }

        //call store procedure insert log detail
        public int InsertLogDetail(objLogDetail obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@LogStoreID", obj.LogStore.LogStoreID));
            parameterList.Add(new SqlParameter("@ProductID", obj.Product.ProductID));
            parameterList.Add(new SqlParameter("@ColorID", obj.Color.ColorID));
            parameterList.Add(new SqlParameter("@SizeID", obj.Size));
            parameterList.Add(new SqlParameter("@Sale", obj.Sale));
            parameterList.Add(new SqlParameter("@Quantity", obj.Quantity));
            //parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            //parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            //parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            //parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spLogDetailInsert", parameterList);
        }
    }
}
