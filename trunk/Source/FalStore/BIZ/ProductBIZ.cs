using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BIZ
{
    public class ProductBIZ
    {
        ProductDAL DAL = new ProductDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objProduct> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result = DAL.GetTotal();
                List<objProduct> lst = new List<objProduct>();
                lst = DAL.GetProductByPaging(pageIndex, pageSize);
                total = result;

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objColor> ShowColorByProductID(string productID)
        {
            try
            {
                List<objColor> lst = new List<objColor>();
                lst = DAL.GetColorByProductID(productID);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// show by ID
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public objBarCode ShowProductByBarCode(string barcode)
        {
            try
            {
                objBarCode obj = new objBarCode();
                obj = DAL.GetProductByBarCode(barcode);

                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public objProduct ShowByID(string productID)
        {
            try
            {
                objProduct obj = new objProduct();
                obj = DAL.GetProductByID(productID);

                return obj;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// search product
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<objProduct> Search(string productName, int categoryID)
        {
            try
            {
                List<objProduct> lst = new List<objProduct>();
                lst = DAL.GetProductSearch(productName, categoryID);

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
        public int Insert(objProduct objProduct, List<objBarCode> lstBarCode)
        {
            try
            {

                foreach (var item in lstBarCode)
                {
                    DAL.InsertBarCode(item);
                }
                return DAL.InsertProduct(objProduct);

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
        public int Update(objProduct objProduct)
        {
            try
            {
                return DAL.UpdateProduct(objProduct);

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
        public int Delete(string productID, DateTime updateDate, string updateUser)
        {
            try
            {
                return DAL.DeleteProduct(productID, updateDate, updateUser);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckProduct(string productID)
        {
            try
            {
                objProduct obj = new objProduct();
                obj = DAL.GetProductByID(productID);
                if (obj != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
          
        }
    }
}
