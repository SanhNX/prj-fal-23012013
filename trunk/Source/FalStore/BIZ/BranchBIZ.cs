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
        /// get by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objBranch> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                List<objBranch> lst = new List<objBranch>();
                lst = DAL.GetBranchByPaging(pageIndex, pageSize);
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
        public List<objBranch> ShowAll()
        {
            try
            {
                List<objBranch> lst = new List<objBranch>();
                lst = DAL.GetBranchAll();

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public objBranch ShowByBranchID(int branchID)
        {
            try
            {
                objBranch obj = new objBranch();
                obj = DAL.GetBranchByID(branchID);

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
        public int Delete(int branchID, DateTime updateDate, string updateUser)
        {
            try
            {
                
                 return DAL.DeleteBranch(branchID,updateDate,updateUser);
                
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
