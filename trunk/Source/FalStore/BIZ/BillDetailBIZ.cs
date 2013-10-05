using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;
namespace BIZ
{
    public class BillDetailBIZ
    {
        BillDetailDAL DAL = new BillDetailDAL();
        BranchDAL DALBranch = new BranchDAL();

        /// <summary>
        /// get by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objBillDetail> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                List<objBillDetail> lst = new List<objBillDetail>();
                lst = DAL.GetBillDetailByPaging(pageIndex, pageSize);
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
        public List<objBillDetail> ShowAll()
        {
            try
            {
                List<objBillDetail> lst = new List<objBillDetail>();
                lst = DAL.GetBillDetailAll();

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public objBillDetail ShowByBillDetailID(int BillDetailID)
        {
            try
            {
                objBillDetail obj = new objBillDetail();
                objBranch objBranch = new objBranch();
                obj = DAL.GetBillDetailByID(BillDetailID);
                
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
        public int Insert(objBillDetail obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertBillDetail(obj);
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
        public int Update(objBillDetail obj)
        {
            try
            {
                int result = 0;
                if (obj != null)
                {
                    result = DAL.UpdateBillDetail(obj);
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
        public int Delete(objBillDetail obj)
        {
            try
            {

                return DAL.DeleteBillDetail(obj);
                
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
