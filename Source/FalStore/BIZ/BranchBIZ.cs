using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;
namespace BIZ
{
    public class BranchBIZ
    {
        BranchDAL DAL = new BranchDAL();

        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objBranch> ShowAll(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objBranch> lst = new List<objBranch>();
                lst = DAL.GetAllBranch(pageIndex, pageSize, out result);
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
        public int Insert(objBranch obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertBranch(obj);
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
        public int Update(objBranch obj)
        {
            try
            {
                int result = 0;
                if (obj != null)
                {
                    result = DAL.UpdateBranch(obj);
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
        public int Delete(objBranch obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.DeleteBranch(obj);
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
