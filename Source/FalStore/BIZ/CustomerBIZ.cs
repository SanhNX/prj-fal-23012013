using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BIZ
{
    public class CustomerBIZ
    {
        CustomerDAL DAL = new CustomerDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objCustomer> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objCustomer> lst = new List<objCustomer>();
                lst = DAL.GetCustomerByPaging(pageIndex, pageSize, out result);
                total = result;

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<objCustomer> ShowAll()
        {
            try
            {
                List<objCustomer> lst = new List<objCustomer>();
                lst = DAL.GetCustomerAll();
                
                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        

        public objCustomer ShowByCustomerByCode(string CustomerCode)
        {
            try
            {
                objCustomer obj = new objCustomer();
                obj = DAL.GetCustomerByCode(CustomerCode);

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
        public string Insert(objCustomer obj)
        {
            try
            {

                string result = null;

                if (obj != null)
                {
                    result = DAL.InsertCustomer(obj);
                }
                else
                {
                    result = null;
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
        public int Update(objCustomer obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.UpdateCustomer(obj);
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

        public int UpdatePoint_Add(string cusCode, int point)
        {
            try
            {
                int result = 0;

                if (cusCode != null && point != null)
                {
                    result = DAL.UpdatePointByCustomerCode_Add(cusCode, point);
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
        public int Delete(objCustomer obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.DeleteCustomer(obj);
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
