using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using DAL;
using System.Data;

namespace BIZ
{
    public class LogStoreBIZ
    {
        LogStoreDAL logDal = new LogStoreDAL();
        ProductDAL proDal = new ProductDAL();
        StoreDAL stoDal = new StoreDAL();
        /// <summary>
        /// get all info log store
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objLogStore> ShowAllLogStore(int pageIndex, int pageSize, out int total)
        {
            try
            {
                int result;
                List<objLogStore> lst = new List<objLogStore>();
                lst = logDal.GetAllLogStore(pageIndex, pageSize, out result);
                total = result;

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// get all info log detail
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objLogDetail> ShowLogDetailByID(string logStoreID)
        {
            try
            {
                List<objLogDetail> lst = new List<objLogDetail>();
                lst = logDal.GetLogDetailByLogStoreID(logStoreID,1);

                return lst;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //}
        /// <summary>
        /// add new record log store
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertlogStore(objLogStore objLogStore)
        {
            try
            {
                objStore objSto;
             
                logDal.UpdateStatusLogDetail(objLogStore.LogStoreID);
                logDal.InsertLogStore(objLogStore);

                List<objLogDetail> lstLogDetail = new List<objLogDetail>();
                lstLogDetail = logDal.GetLogDetailByLogStoreID(objLogStore.LogStoreID,0);
                foreach (var item in lstLogDetail)
                {
                    objSto = new objStore();
                    objSto.Product = new objProduct();
                    objSto.Product.ProductID = item.Product.ProductID;
                    objSto.Color = new objColor();
                    objSto.Color.ColorID = item.Color.ColorID;
                    objSto.Size = item.Size;
                    objSto.Branch = new objBranch();
                    objSto.Branch.BranchID = objLogStore.BranchTo.BranchID;
                    objSto.ExportPrice = item.Product.ExportPrice;
                    objSto.Quantity = item.Quantity;
                    objSto.LogStore = new objLogStore();
                    objSto.LogStore.LogStoreID = item.LogStore.LogStoreID;

                    stoDal.InsertStore(objSto);
                    proDal.UpdateProductTotalQuantity(item.Product.ProductID, item.Quantity);
                }
                return 1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int InsertLogDetail(objLogDetail objLogDetail)
        {
            return logDal.InsertLogDetail(objLogDetail);
        }
        private int GetQuantity(string productID)
        {
            return 2;
        }

        /// <summary>
        /// add new record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertStore(objStore obj)
        {
            try
            {

                int result = 0;

                if (obj != null)
                {
                    result = stoDal.InsertStore(obj);
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
        public string NewLogStoreID()
        {
            int newID;
            string lastID;
            lastID = logDal.GetLogStoreByLastID();
            if (lastID != string.Empty)
            {
                newID = int.Parse(lastID) + 1;
            }
            else
            {
                newID = 1;
            }
           
            return newID.ToString().PadLeft(10, '0');
        }
    }
}
