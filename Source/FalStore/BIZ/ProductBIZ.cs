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
                int result;
                List<objProduct> lst = new List<objProduct>();
                lst = DAL.GetProductByPaging(pageIndex, pageSize, out result);
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
        /// add new record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int Insert(objProduct objProduct,List<objColor> lstColor)
        {
            try
            {

                int result = 0;

                if (objProduct != null  )
                {
                    result = DAL.InsertProduct(objProduct);
                    foreach (var item in lstColor)
                    {
                        DAL.InsertColor(item);
                    }
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
        public int Update(objProduct objProduct, List<objColor> lstColor)
        {
            try
            {
                int result = 0;

                if (objProduct != null)
                {
                    result = DAL.UpdateProduct(objProduct);
                    foreach (var item in lstColor)
                    {
                        DAL.UpdateColor(item);
                    }
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
        public int Delete(objProduct obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.DeleteProduct(obj);
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
