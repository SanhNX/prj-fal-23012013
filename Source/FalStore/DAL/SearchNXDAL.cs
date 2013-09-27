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
    public class SearchNXDAL
    {
        public List<objSearchNX> SearchPhieu(int loaiPhieu, int branchId, DateTime startDate, DateTime endDate)
        {

            List<objSearchNX> lst = new List<objSearchNX>();

            objSearchNX obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchId));


            parameterList.Add(new SqlParameter("@CreateDate1", startDate));

            parameterList.Add(new SqlParameter("@CreateDate2", endDate));

            SqlDataReader dr = null;

            if (loaiPhieu == 2)
            {
                dr = SQLHelper.ExecuteReader("spSearchPhieuXuat", parameterList);
            }

            if (loaiPhieu == 1)
            {
                dr = SQLHelper.ExecuteReader("spSearchPhieuNhap", parameterList);
            }


            while (dr.Read())
            {
                obj = new objSearchNX();

                obj.Log_StoreID = dr["Log_StoreID"].ToString();

                obj.EmployeeName = dr["EmployeeName"].ToString();

                obj.BranchNameNhap = dr["BranchName"].ToString();

                obj.CreateDate = dr["CreateDate"].ToString();

                obj.TotalAmount = float.Parse(dr["TotalAmount"].ToString());

                lst.Add(obj);
            }

            return lst;

        }

    }
}
