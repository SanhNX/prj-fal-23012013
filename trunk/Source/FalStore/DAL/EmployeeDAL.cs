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

        //call store procedure view employee by paging
        public List<objEmployee> GetEmployeeByPaging(int pageIndex, int pageSize, out int total)
        {
            List<objEmployee> lst = new List<objEmployee>();
            objEmployee obj = null;
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spEmployeeGetByPaging", parameterList);
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

        //call store procedure view all employee
        public List<objEmployee> GetEmployeeAll()
        {
            List<objEmployee> lst = new List<objEmployee>();
            objEmployee obj = null;
           SqlDataReader dr = SQLHelper.ExecuteReader("spEmployeeGetAll");
            while (dr.Read())
            {
                obj = new objEmployee();
                obj.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                obj.EmployeeName = dr["EmployeeName"].ToString();
              
                lst.Add(obj);
            }

            return lst;
        }

        public objEmployee GetEmployeeByNameAndPass(string username, string password)
        {

            objEmployee obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@UserName", username));
            parameterList.Add(new SqlParameter("@PassWord", password));

            SqlDataReader dr = SQLHelper.ExecuteReader("spGetEmployeeByNameAndPass", parameterList);
            while (dr.Read())
            {
                obj = new objEmployee();
                obj.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.EmployeeName = dr["EmployeeName"].ToString();
                obj.Gender = int.Parse(dr["Gender"].ToString());
                obj.Address = dr["Address"].ToString();
                obj.Phone = dr["Phone"].ToString();
                obj.Role = int.Parse(dr["Role"].ToString());
                obj.First_Flg = int.Parse(dr["First_Flg"].ToString());
            }

            return obj;

        }

        public objEmployee GetEmployeeByID(int id)
        {

            objEmployee obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@EmployeeID", id));

            SqlDataReader dr = SQLHelper.ExecuteReader("spGetEmployeeByID", parameterList);
            while (dr.Read())
            {
                obj = new objEmployee();
                obj.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                obj.UserName = dr["UserName"].ToString();
                obj.PassWord = dr["PassWord"].ToString();
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.EmployeeName = dr["EmployeeName"].ToString();
                obj.Gender = int.Parse(dr["Gender"].ToString());
                obj.Address = dr["Address"].ToString();
                obj.Phone = dr["Phone"].ToString();
                obj.Role = int.Parse(dr["Role"].ToString());
                obj.First_Flg = int.Parse(dr["First_Flg"].ToString());
            }

            return obj;

        }

        public int UpdatePassword(int employeeID, string newPass)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EmployeeID", employeeID));
            parameterList.Add(new SqlParameter("@PassWord", newPass));

            return SQLHelper.ExecuteNonQuery("spUpdatePassword", parameterList);

        }

        public int UpdateFirstFlag(int employeeID)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EmployeeID", employeeID));

            return SQLHelper.ExecuteNonQuery("spUpdateFirstFlag", parameterList);

        }

        //call store procedure insert employee
        public int InsertEmployee(objEmployee obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EmployeeName", obj.EmployeeName));
            parameterList.Add(new SqlParameter("@UserName", obj.UserName));
            parameterList.Add(new SqlParameter("@PassWord", obj.PassWord));
            parameterList.Add(new SqlParameter("@BranchID", obj.BranchID));
            parameterList.Add(new SqlParameter("@Gender", obj.Gender));
            parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@Phone", obj.Phone));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@Role", obj.Role));

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

        //call store procedure delete employee
        public Boolean EmployeeGetByUserName(string username)
        {
            Boolean abc = false;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@UserName", username));

            SqlDataReader dr = SQLHelper.ExecuteReader("spEmployeeGetByUserName", parameterList);

            int count = 0;

            while (dr.Read()) {
                count++;
            }
            if (count > 0)
            {
                abc = true;
            }

            return abc;
        }

        public List<objEmployee> EmployeeSearch(string employeeName, int branchID, int role)
        {
            List<objEmployee> lstEm = new List<objEmployee>();

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@EmployeeName", employeeName));
            parameterList.Add(new SqlParameter("@BranchID", branchID));
            parameterList.Add(new SqlParameter("@Role", role));

            SqlDataReader dr = SQLHelper.ExecuteReader("spEmployeeSearch", parameterList);

            objEmployee obj = null;
            while (dr.Read())
            {
                obj = new objEmployee();
                obj.EmployeeID = int.Parse(dr["EmployeeID"].ToString());
                obj.UserName = dr["UserName"].ToString();
                obj.BranchID = int.Parse(dr["BranchID"].ToString());
                obj.BranchName = dr["BranchName"].ToString();
                obj.EmployeeName = dr["EmployeeName"].ToString();
                obj.Gender = int.Parse(dr["Gender"].ToString());
                obj.Address = dr["Address"].ToString();
                obj.Phone = dr["Phone"].ToString();
                obj.Role = int.Parse(dr["Role"].ToString());

                lstEm.Add(obj);

            }

            return lstEm;
        }



    }
}
