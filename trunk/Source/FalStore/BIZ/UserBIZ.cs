using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BIZ
{
    public class UserBIZ
    {
        UserDAL DAL = new UserDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objUser> ShowAll(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objUser> lst = new List<objUser>();
                lst = DAL.GetAllUser(pageIndex, pageSize, out result);
                total = result;

                return lst;
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
        public int Insert(objUser obj)
        {
            try
            {

                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertUser(obj);
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
        public int Update(objUser obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.UpdateUser(obj);
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
        public int Delete(objUser obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.DeleteUser(obj);
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
    }
}
