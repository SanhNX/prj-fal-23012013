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
    public class EventDAL
    {
        BranchDAL DALBranch = new BranchDAL();
        //initialize connection string
        public EventDAL()
        {
        }

        //call store procedure view Event by paging
        public List<objEvent> GetEventByPaging(int pageIndex, int pageSize)
        {
            List<objEvent> lst = new List<objEvent>();
            objEvent obj = null;

            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@pageSize", pageSize));
            parameterList.Add(new SqlParameter("@pageIndex", pageIndex));
            parameterList.Add(prTotal);

            SqlDataReader dr = SQLHelper.ExecuteReader("spEventGetByPaging", parameterList);
            while (dr.Read())
            {
                obj = new objEvent();
                obj.EventID = int.Parse(dr["EventID"].ToString());
                obj.EventName = dr["EventName"].ToString();
                //obj.BranchID = dr["BranchID"].ToString();
                //obj.BranchName = dr["BranchName"].ToString();
                //obj.StartDate = dr["StartDate"].ToString();
                //obj.EndDate = dr["EndDate"].ToString();
                obj.Discount = dr["DisCount"].ToString();
                lst.Add(obj);
            }

            //total = int.Parse(prTotal.Value.ToString());
            return lst;
        }

        /// <summary>
        /// get toal row
        /// </summary>
        /// <returns></returns>
        public int GetTotal()
        {
            SqlParameter prTotal = new SqlParameter("@total", SqlDbType.Int);
            prTotal.Direction = ParameterDirection.Output;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(prTotal);
            SqlDataReader dr = SQLHelper.ExecuteReader("spEventGetTotalCount", parameterList);
            int total = int.Parse(prTotal.Value.ToString());
            return total;

        }
        
        //call store procedure view all Event
        public List<objEvent> GetEventAll()
        {
            List<objEvent> lst = new List<objEvent>();
            
            objEvent obj = null;

            SqlDataReader dr = SQLHelper.ExecuteReader("spEventGetAll");
            while (dr.Read())
            {
                obj = new objEvent();
                obj.EventID = int.Parse(dr["EventID"].ToString());
                obj.EventName = dr["Name"].ToString();
                obj.Branch = DALBranch.GetBranchByID(int.Parse(dr["BranchID"].ToString()));
                obj.StartDate = dr["StartDate"].ToString();
                obj.EndDate = dr["EndDate"].ToString();
                obj.Discount = dr["DisCount"].ToString();
                lst.Add(obj);
            }

            return lst;
        }

        public objEvent GetEventByID(int EventID)
        {

            objEvent obj = null;

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();
            parameterList.Add(new SqlParameter("@EventID", EventID));

            SqlDataReader dr = SQLHelper.ExecuteReader("spEventGetByID", parameterList);
            while (dr.Read())
            {
                obj = new objEvent();
                obj.EventID = int.Parse(dr["EventID"].ToString());
                obj.EventName = dr["Name"].ToString();
                obj.Branch = DALBranch.GetBranchByID(int.Parse(dr["BranchID"].ToString()));
                obj.StartDate = dr["StartDate"].ToString();
                obj.EndDate = dr["EndDate"].ToString();
                obj.Discount = dr["DisCount"].ToString();
            }

            return obj;

        }

        //call store procedure insert Event
        public int InsertEvent(objEvent obj)
        {

            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@Name", obj.EventName));
            parameterList.Add(new SqlParameter("@StartDate", obj.StartDate));
            parameterList.Add(new SqlParameter("@EndDate", obj.EndDate));
            parameterList.Add(new SqlParameter("@DisCount", obj.Discount));

            return SQLHelper.ExecuteNonQuery("spEventInsert", parameterList);
      
        }

        //call store procedure update Event
        public int UpdateEvent(objEvent obj)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EventID", obj.EventID));
            parameterList.Add(new SqlParameter("@BranchID", obj.Branch.BranchID));
            parameterList.Add(new SqlParameter("@Name", obj.EventName));
            parameterList.Add(new SqlParameter("@StartDate", obj.StartDate));
            parameterList.Add(new SqlParameter("@EndDate", obj.EndDate));
            parameterList.Add(new SqlParameter("@DisCount", obj.Discount));

            return SQLHelper.ExecuteNonQuery("spEventUpdate", parameterList);
      
        }

        //call store procedure delete Event
        public int DeleteEvent(int EventID, DateTime updateDate, string updateUser)
        {
            Collection<SqlParameter> parameterList = new Collection<SqlParameter>();

            parameterList.Add(new SqlParameter("@EventID", EventID));
            parameterList.Add(new SqlParameter("@UpdateDate", updateDate));
            parameterList.Add(new SqlParameter("@UpdateUser", updateUser));

            return SQLHelper.ExecuteNonQuery("spEventDelete", parameterList);
      
        }

    }
}
