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
        /// get log store by paging
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
        /// show report
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objLogDetail> ShowReport(string logID)
        {
            try
            {
                List<objLogDetail> lst = new List<objLogDetail>();
                lst = logDal.ShowReport(logID);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// get log detail by logStore 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objLogDetail> ShowLogDetailByID(string logStoreID,int status_flg)
        {
            try
            {
                List<objLogDetail> lst = new List<objLogDetail>();
                lst = logDal.GetLogDetailByLogStoreID(logStoreID, status_flg);

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
        /// <param name="type"> 0: nhap phieu   1: xuat phieu</param>
        public void InsertlogStore(objLogStore objLogStore, int type)
        {
            try
            {
                objStore objSto;
                //update status log detail
                logDal.UpdateStatusLogDetail(objLogStore.LogStoreID);
                //insert log store
                logDal.InsertLogStore(objLogStore);

                List<objLogDetail> lstLogDetail = new List<objLogDetail>();
                //get info log detail with new status 
                lstLogDetail = logDal.GetLogDetailByLogStoreID(objLogStore.LogStoreID, 0);
                //loop
                foreach (var item in lstLogDetail)
                {
                    //get info product in store --> check exist product
                    objSto = stoDal.GetProductInfoByBranch(item.Product.ProductID, int.Parse(item.Color.ColorID.ToString()), item.Size, int.Parse(objLogStore.BranchTo.BranchID.ToString()));

                    //no exist --> create new record 
                    if (objSto == null)
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

                    }
                    else
                    {
                        //exist record --> update quantity
                        stoDal.UpdateStoreQuantity(objLogStore.BranchTo.BranchID, item.Product.ProductID, item.Color.ColorID, item.Size, item.Quantity);
                    }

                    if (type == 0)
                    {
                        //update total quantity
                        proDal.UpdateProductTotalQuantity(item.Product.ProductID, item.Quantity);
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// insert log detail
        /// </summary>
        /// <param name="objLogDetail"></param>
        /// <returns></returns>
        public int InsertLogDetail(objLogDetail objLogDetail)
        {
            try
            {
                return logDal.InsertLogDetail(objLogDetail);
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// add new store record
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int InsertStore(objStore obj)
        {
            try
            {

                return stoDal.InsertStore(obj);

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// create new log store 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// check exist product in store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="branchID"></param>
        /// <returns></returns>
        public bool CheckProductInStore(string productID, int branchID)
        {
            try
            {
                objProduct obj = new objProduct();
                obj = stoDal.GetProductInStore(productID, branchID);

                if (obj == null)
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
