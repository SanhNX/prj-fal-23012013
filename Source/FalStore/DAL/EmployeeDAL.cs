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
    public class EmployeeDAL
    {
        //initialize connection string
        public EmployeeDAL()
        {
        }

        //call store procedure view all employee
        public List<objEmployee> GetAllEmployee(int pageIndex, int pageSize, out int total)
        {
            List<objEmployee> lst = new List<objEmployee>();
            objEmployee obj = null;
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spEmployeeGetAll", parameterList);
            while (dr.Read())
            {
                obj = new objEmployee();
                obj.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                obj.EmployeeName = dr["EmployeeName"].ToString();
                obj.Gender = int.Parse(dr["Gender"].ToString());
                obj.Address = dr["Address"].ToString();
                obj.Phone = dr["Phone"].ToString();
                lst.Add(obj);
            }
            total = int.Parse(prTotal.Value.ToString());
            return lst;
        }

        //call store procedure insert employee
        public int InsertEmployee(objEmployee obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EmployeeName", obj.EmployeeName));
            parameterList.Add(new SqlParameter("@Gender", obj.Gender));
            parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@Phone", obj.Phone));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spEmployeeInsert", parameterList);

        }

        //call store procedure update employee
        public int UpdateEmployee(objEmployee obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EmployeeID", obj.EmployeeID));
            parameterList.Add(new SqlParameter("@EmployeeName", obj.EmployeeName));
            parameterList.Add(new SqlParameter("@Gender", obj.Gender));
            parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@Phone", obj.Phone));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spEmployeeInsert", parameterList);

        }

        //call store procedure delete employee
        public int DeleteEmployee(objEmployee obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EmployeeID", obj.EmployeeID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spEmployeeInsert", parameterList);

        }

    }
}
