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
    public class CustomerDAL
    {
        //initialize connection string
        public CustomerDAL()
        {
        }

        //call store procedure view Customer by paging
        public List<objCustomer> GetCustomerByPaging(int pageIndex, int pageSize, out int total)
        {
            List<objCustomer> lst = new List<objCustomer>();
            objCustomer obj = null;
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spCustomerGetByPaging", parameterList);
            while (dr.Read())
            {
                obj = new objCustomer();
                obj.CustomerID = int.Parse(dr["CustomerID"].ToString());
                obj.CustomerName = dr["CustomerName"].ToString();
                //obj.Gender = int.Parse(dr["Gender"].ToString());
                //obj.Address = dr["Address"].ToString();
                obj.Phone = dr["Phone"].ToString();
                lst.Add(obj);
            }
            total = int.Parse(prTotal.Value.ToString());
            return lst;
        }

        //call store procedure view all Customer
        public List<objCustomer> GetCustomerAll()
        {
            List<objCustomer> lst = new List<objCustomer>();
            objCustomer obj = null;
           SqlDataReader dr = SQLHelper.ExecuteReader("spCustomerGetAll");
            while (dr.Read())
            {
                obj = new objCustomer();
                obj.CustomerID = int.Parse(dr["CustomerID"].ToString());
                obj.CustomerName = dr["CustomerName"].ToString();
              
                lst.Add(obj);
            }

            return lst;
        }

        

        public objCustomer GetCustomerByID(int CustomerID)
        {

            objCustomer obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@CustomerID", CustomerID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spCustomerGetByID", parameterList);
            while (dr.Read())
            {
                obj = new objCustomer();
                obj.CustomerID = int.Parse(dr["CustomerID"].ToString());
                obj.CustomerName = dr["CustomerName"].ToString();
                obj.Email = dr["Email"].ToString(); 
                obj.Phone = dr["Phone"].ToString();
                obj.Delete_Flg = int.Parse(dr["Delete_Flg"].ToString());
                obj.CreateDate = dr["CreateDate"].ToString();
                obj.CreateUser = dr["CreateUser"].ToString();
                obj.UpdateDate = dr["UpdateDate"].ToString();
                obj.UpdateUser = dr["UpdateUser"].ToString();
                obj.CodeCustomer = dr["CodeCustomer"].ToString();
                obj.DisCount = int.Parse(dr["DisCount"].ToString());
                obj.StartDiscount = dr["StartDiscout"].ToString();
                obj.EndDiscount = dr["EndDiscount"].ToString();
                obj.Point = int.Parse(dr["Point"].ToString() == "" ? "0" : dr["Point"].ToString());
            }

            return obj;

        }
        public objCustomer GetCustomerByCode(string CodeCustomer)
        {

            objCustomer obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@CodeCustomer", CodeCustomer));

            SqlDataReader dr = SQLHelper.ExecuteReader("spCustomerGetByCode", parameterList);
            while (dr.Read())
            {
                obj = new objCustomer();
                obj.CustomerID = int.Parse(dr["CustomerID"].ToString());
                obj.CustomerName = dr["CustomerName"].ToString();
                obj.Email = dr["Email"].ToString();
                obj.Phone = dr["Phone"].ToString();
                obj.CreateDate = dr["CreateDate"].ToString();
                obj.CreateUser = dr["CreateUser"].ToString();
                obj.UpdateDate = dr["UpdateDate"].ToString();
                obj.UpdateUser = dr["UpdateUser"].ToString();
                obj.CodeCustomer = dr["CodeCustomer"].ToString();
                obj.DisCount = int.Parse(dr["DisCount"].ToString() == "" ? "0" : dr["DisCount"].ToString());
                obj.StartDiscount = dr["StartDiscout"].ToString();
                obj.EndDiscount = dr["EndDiscount"].ToString();
                obj.Point = int.Parse(dr["Point"].ToString() == "" ? "0" : dr["Point"].ToString());
            }

            return obj;

        }

        //call store procedure insert Customer
        public string InsertCustomer(objCustomer obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CodeCustomer", obj.CodeCustomer));
            parameterList.Add(new SqlParameter("@CustomerName", obj.CustomerName));
            parameterList.Add(new SqlParameter("@Phone", obj.Phone));
            parameterList.Add(new SqlParameter("@Email", obj.Email));
            parameterList.Add(new SqlParameter("@DisCount", obj.DisCount));
            parameterList.Add(new SqlParameter("@CreateDate", obj.CreateDate));
            parameterList.Add(new SqlParameter("@Point", obj.Point));
            if (SQLHelper.ExecuteNonQuery("spCustomerInsert", parameterList) == 1)
            {
                return obj.CodeCustomer;
            }
            else {
                return null;
            }

        }

        public int UpdatePointByCustomerCode_Add(string cusCode, int point)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CodeCustomer", cusCode));
            parameterList.Add(new SqlParameter("@NewPoint", point));

            return SQLHelper.ExecuteNonQuery("spUpdatePointByCustomerCode_Add", parameterList);

        }

        //call store procedure update Customer
        public int UpdateCustomer(objCustomer obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            parameterList.Add(new SqlParameter("@CustomerName", obj.CustomerName));
            //parameterList.Add(new SqlParameter("@Gender", obj.Gender));
            //parameterList.Add(new SqlParameter("@Address", obj.Address));
            parameterList.Add(new SqlParameter("@Phone", obj.Phone));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCustomerInsert", parameterList);

        }

        //call store procedure delete Customer
        public int DeleteCustomer(objCustomer obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@CustomerID", obj.CustomerID));
            parameterList.Add(new SqlParameter("@UpdateDate", obj.UpdateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", obj.UpdateUser));

            return SQLHelper.ExecuteNonQuery("spCustomerInsert", parameterList);

        }

    }
}
