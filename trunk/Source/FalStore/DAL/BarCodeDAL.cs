using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Common.Helper;

namespace DAL
{
    public class BarCodeDAL
    {
        public List<objFindBarCode> GetBarCodeByProductID(String productId)
        {

            List<objFindBarCode> lst = new List<objFindBarCode>();

            objFindBarCode obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@ProductID", productId));


            SqlDataReader dr = SQLHelper.ExecuteReader("spGetBarCodeByProductID", parameterList);
            while (dr.Read())
            {
                obj = new objFindBarCode();

                obj.BarCode = dr["BarCode"].ToString();

                obj.ProductID = dr["ProductID"].ToString();

                obj.ProductName = dr["ProductName"].ToString();

                obj.ColorName = dr["ColorName"].ToString();

                obj.SizeName = dr["SizeName"].ToString();

                obj.ImportPrice = float.Parse(dr["ImportPrice"].ToString());

                obj.ExportPrice = float.Parse(dr["ExportPrice"].ToString());

                lst.Add(obj);
            }

            return lst;

        }
    }
}
