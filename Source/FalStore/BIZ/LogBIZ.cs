using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BIZ
{
    class LogBIZ
    {
        LogStoreDAL logStr = new LogStoreDAL();
        LogDetailDAL logDetl = new LogDetailDAL();

        /// <summary>
        /// get all info log store
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objLogStore> ShowAllLogStore(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objLogStore> lst = new List<objLogStore>();
                lst = logStr.GetAllLogStore(pageIndex, pageSize, out result);
                total = result;

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// get all info log detail
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objLogDetail> ShowLogDetailByID(string logStoreID, int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objLogDetail> lst = new List<objLogDetail>();
                lst = logDetl.GetLogDetail(logStoreID, pageIndex, pageSize, out result);
                total = result;

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// add new record log store
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertlogStore(objLogStore obj)
        {
            try
            {

                int result = 0;

                if (obj != null)
                {
                    result = logStr.InsertLogStore(obj);
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
        /// add new record log detail
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertlogDetail(objLogDetail obj)
        {
            try
            {

                int result = 0;

                if (obj != null)
                {
                    result = logDetl.InsertLogDetail(obj);
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
