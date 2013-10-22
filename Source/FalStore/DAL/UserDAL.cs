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
    public class UserDAL
    {
        //initialize connection string
        public UserDAL()
        {
        }
       
        //call store procedure view all user
        public List<objUser> GetAllUser(int pageIndex, int pageSize, out int total)
        {
                List<objUser> lst = new List<objUser>();
                objUser obj = null;
                SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
                prTotal.Direction = ParameterDirection.Output;

                Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
                parameterList.Add(new SqlParameter("@pageSize", pageSize));
                parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
                parameterList.Add(prTotal);

                SqlDataReader dr = SQLHelper.ExecuteReader("spUserGetAll", parameterList);
                while (dr.Read())
                {
                    obj = new objUser();
                    obj.UserID = dr["UserID"].ToString();
                    obj.Password = dr["Password"].ToString();
                    obj.Role = int.Parse(dr["Role"].ToString());
                    obj.Employee.EmployeeName = dr["EmployeeName"].ToString();
                    lst.Add(obj);
                }
                dr.Close();
                total = int.Parse(prTotal.Value.ToString());
                return lst;
        }

        //call store procedure insert user
        public int InsertUser(objUser obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@UserID", obj.UserID));
            parameterList.Add(new SqlParameter("@Password", obj.Password));
            parameterList.Add(new SqlParameter("@Role", obj.Role));
            parameterList.Add(new SqlParameter("@EmployeeID", obj.Employee.EmployeeID));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@CreateUser", obj.CreateUser));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spUserInsert", parameterList);
        }

        //call store procedure update user
        public int UpdateUser(objUser obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@UserID", obj.UserID));
            parameterList.Add(new SqlParameter("@Password", obj.Password));
            parameterList.Add(new SqlParameter("@Role", obj.Role));
            parameterList.Add(new SqlParameter("@EmployeeID", obj.Employee.EmployeeID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spUserUpdate", parameterList);
        }

        //call store procedure delete user
        public int DeleteUser(objUser obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@UserID", obj.UserID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spUserDelete", parameterList);
        }

    }
}
