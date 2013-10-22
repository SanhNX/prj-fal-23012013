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
    public class ExpensesDAL
    {


        //call store procedure insert branch
        public int InsertExpenses(objExpenses obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", obj.BranchID));
            parameterList.Add(new SqlParameter("@EmployeeID", obj.EmployeeID));
            parameterList.Add(new SqlParameter("@Description", obj.Description));
            parameterList.Add(new SqlParameter("@Amount", obj.Amount));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spExpensesInsert", parameterList);

        }


        public List<objExpenses> ExpensesSearch(int branchID, DateTime startDate, DateTime endDate)
        {


            List<objExpenses> lst = new List<objExpenses>();

            objExpenses obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", branchID));

            parameterList.Add(new SqlParameter("@CreateDate1", startDate));

            parameterList.Add(new SqlParameter("@CreateDate2", endDate));

            SqlDataReader dr = SQLHelper.ExecuteReader("spExpensesSearch", parameterList);
            while (dr.Read())
            {
                obj = new objExpenses();

                obj.Description = dr["Description"].ToString();

                obj.Amount = float.Parse(dr["Amount"].ToString());

                obj.BranchName = dr["BranchName"].ToString();

                obj.CreateUser = dr["CreateUser"].ToString();

                obj.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());

                lst.Add(obj);
            }

            dr.Close();

            return lst;

        }








    }
}
