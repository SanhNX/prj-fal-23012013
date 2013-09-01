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
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objCategory> ShowAll(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objCategory> lst = new List<objCategory>();
                lst = DAL.GetAllCategory(pageIndex, pageSize, out result);
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
        public int Insert(objCategory obj)
        {
            try
            {

                int result = 0;

                if (obj != null)
                {
                    result = DAL.InsertCategory(obj);
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
        public int Update(objCategory obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.UpdateCategory(obj);
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
        public int Delete(objCategory obj)
        {
            try
            {
                int result = 0;

                if (obj != null)
                {
                    result = DAL.DeleteCategory(obj);
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
