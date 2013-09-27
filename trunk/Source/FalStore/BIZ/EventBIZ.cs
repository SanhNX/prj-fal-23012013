using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;
namespace BIZ
{
    public class EventBIZ
    {
        EventDAL DAL = new EventDAL();
        BranchDAL DALBranch = new BranchDAL();

        /// <summary>
        /// get by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objEvent> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                List<objEvent> lst = new List<objEvent>();
                lst = DAL.GetEventByPaging(pageIndex, pageSize);
                total = DAL.GetTotal();

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// get all
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objEvent> ShowAll()
        {
            try
            {
                List<objEvent> lst = new List<objEvent>();
                lst = DAL.GetEventAll();

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public objEvent ShowByEventID(int EventID)
        {
            try
            {
                objEvent obj = new objEvent();
                objBranch objBranch = new objBranch();
                obj = DAL.GetEventByID(EventID);
                
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// add new record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Insert(objEvent obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertEvent(obj);
                }
                else
                {
                    result = 1;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// edit record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Update(objEvent obj)
        {
            try
            {
                int result = 0;
                if (obj != null)
                {
                    result = DAL.UpdateEvent(obj);
                }
                else
                {
                    result = 1;
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// delete record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Delete(int EventID, DateTime updateDate, string updateUser)
        {
            try
            {
                
                 return DAL.DeleteEvent(EventID,updateDate,updateUser);
                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
