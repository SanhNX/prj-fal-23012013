using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;
namespace BIZ
{
    public class CategoryBIZ
    {
        CategoryDAL DAL = new CategoryDAL();

        /// <summary>
        /// get by paging
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objCategory> ShowByPaging(int pageIndex, int pageSize, out int total)
        {
            try
            {
                List<objCategory> lst = new List<objCategory>();
                lst = DAL.GetCategoryByPaging(pageIndex, pageSize);
                total = GetTotal();

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
        /// <returns></returns>
        public List<objCategory> ShowAll()
        {
            try
            {
                List<objCategory> lst = new List<objCategory>();
                lst = DAL.GetAllCategory();

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
        /// <returns></returns>
        public objCategory ShowByCategoryID(int categoryID)
        {
            try
            {
                objCategory obj = new objCategory();
                obj = DAL.GetCategoryByID(categoryID);

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
        public int Insert(objCategory obj)
        {
            try
            {
               return DAL.InsertCategory(obj);
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
        public int Update(objCategory obj)
        {
            try
            {
                return DAL.UpdateCategory(obj);   
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
        public int Delete(int CategoryID, DateTime UpdateDate, string UpdateUser)
        {
            try
            {
                return DAL.DeleteCategory(CategoryID,UpdateDate,UpdateUser);  
            }
            catch (Exception)
            {   
                throw;
            }
        }

        /// <summary>
        /// get total row
        /// </summary>
        /// <returns></returns>
        private int GetTotal()
        {
            return DAL.GetTotal();
        }
    }
}
