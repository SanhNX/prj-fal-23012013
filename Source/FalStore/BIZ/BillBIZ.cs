using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BIZ
{
    public class BillBIZ
    {
        BillDAL DAL = new BillDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objDoanhThu> GetBillSearch(int branchId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<objDoanhThu> lst = new List<objDoanhThu>();
                lst = DAL.GetBillSearch(branchId, startDate, endDate);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<objBill> GetBillByID(string billID)
        {
            try
            {
                List<objBill> lst = new List<objBill>();
                lst = DAL.GetBillByID(billID);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<objBillDetail> GetBillDetailByID(string billID, int branchID)
        {
            try
            {
                List<objBillDetail> lst = new List<objBillDetail>();
                lst = DAL.GetBillDetailByID(billID, branchID);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<objBillDetail> GetBillDetailCtByID(string billID, int branchID)
        {
            try
            {
                List<objBillDetail> lst = new List<objBillDetail>();
                lst = DAL.GetBillDetailCtByID(billID, branchID);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int GetNextId()
        {
            try
            {
                int nextId = DAL.GetNextId();

                return nextId;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int Insert(objBill obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertBill(obj);
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

        public int Update(objBill obj)
        {
            try
            {
                int result = 0;
                if (obj != null)
                {
                    result = DAL.UpdateBill(obj);
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
