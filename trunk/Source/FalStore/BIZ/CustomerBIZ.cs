﻿using System;
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


        public int UpdatePointByCustomerCode(string cusCode, int point, string billID)
        {
            try
            {
                int result = 0;

                if (cusCode != null && point != null)
                {
                    result = DAL.UpdatePointByCustomerCode(cusCode, point, billID);
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

        public int UpdatePointWithExistCustomer(string cusCode, int point)
        {
            try
            {
                int result = 0;

                if (cusCode != null && point != null)
                {
                    result = DAL.UpdatePointWithExistCustomer(cusCode, point);
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

        public List<objCustomer> SearchCustomer(int point, int branchId, int discount, string createDate1, string createDate2) {
            try
            {
                List<objCustomer> lstCus = new List<objCustomer>();


                lstCus = DAL.SearchCustomer(point, branchId, discount, createDate1, createDate2);


                return lstCus;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateDiscountByCodeCustomer(objCustomer obj)
        {
            try
            {
                int result = 0;

                result = DAL.UpdateDiscountByCodeCustomer(obj);

                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int CheckDisCount(int point, int branchId, int discountSearch, DateTime startDisCount, DateTime EndDisCount, int disCount, string userUpdate) {

            int abc = -1;


            try
            {
                List<objCustomer> lstCus = new List<objCustomer>();


                lstCus = SearchCustomer(point, branchId, discountSearch, "", "");

                if (lstCus.Count > 0) {

                    objCustomer objCusUpdate = null;

                    foreach (var item in lstCus)
                    {
                        objCusUpdate = new objCustomer();

                        if (int.Parse(item.DisCount.ToString()) == 0 ) {
                            objCusUpdate.CodeCustomer = item.CodeCustomer;
                            objCusUpdate.DisCount = disCount;
                            objCusUpdate.StartDiscount = startDisCount.ToString();
                            objCusUpdate.EndDiscount = EndDisCount.ToString();
                            objCusUpdate.UpdateDate = DateTime.Today.ToString();
                            objCusUpdate.UpdateUser = userUpdate;
                            objCusUpdate.Point = point;

                            abc = UpdateDiscountByCodeCustomer(objCusUpdate);
                        }

                    }

                    abc = 1;
                
                } else {
                    abc = 0;
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return abc;
        
        }

        public int UpdateDisCountToZero(int branchId, int discountSearch, string userUpdate)
        {

            int abc = -1;


            try
            {
                List<objCustomer> lstCus = new List<objCustomer>();


                lstCus = SearchCustomer(0, branchId, discountSearch, "", "");

                if (lstCus.Count > 0)
                {

                    objCustomer objCusUpdate = null;

                    foreach (var item in lstCus)
                    {

                        if (!string.Empty.Equals(item.EndDiscount) && !item.EndDiscount.Equals(null)) 
                        {
                            objCusUpdate = new objCustomer();

                            DateTime arg1 = DateTime.Parse(item.EndDiscount);
                            DateTime arg2 = DateTime.Now;

                            if (DateTime.Compare(arg1, arg2) < 0 || DateTime.Compare(arg1, arg2) == 0 )
                            {
                                objCusUpdate.CodeCustomer = item.CodeCustomer;
                                objCusUpdate.DisCount = 0;
                                objCusUpdate.StartDiscount = item.StartDiscount;
                                objCusUpdate.EndDiscount = item.EndDiscount;
                                objCusUpdate.UpdateDate = DateTime.Today.ToString();
                                objCusUpdate.UpdateUser = userUpdate;
                                objCusUpdate.Point = 0;

                                abc = UpdateDiscountByCodeCustomer(objCusUpdate);
                            }
                        }

                        

                    }

                    abc = 1;

                }
                else
                {
                    abc = 0;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return abc;

        }
    }
}
