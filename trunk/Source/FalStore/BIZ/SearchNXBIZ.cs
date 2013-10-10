using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BIZ
{
    public class SearchNXBIZ
    {
        SearchNXDAL DAL = new SearchNXDAL();
        /// <summary>
        /// get all info
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<objSearchNX> SearchNX(int loaiPhieu, string chiNhanhXuat, string loaiPhieuname, int branchId, DateTime startDate, DateTime endDate)
        {
            List<objSearchNX> lst = new List<objSearchNX>();
            if (loaiPhieu == 2) {
                try
                {
                    
                    lst = DAL.SearchPhieu(loaiPhieu, branchId, startDate, endDate);

                    for (int i = 0; i < lst.Count; i++ )
                    {
                        lst[i].LoaiPhieu = loaiPhieuname;
                        lst[i].BranchNameXuat = chiNhanhXuat;
                    }
   
                }
                catch (Exception)
                {

                    throw;
                }
            }

            if (loaiPhieu == 1)
            {
                try
                {

                    lst = DAL.SearchPhieu(loaiPhieu, branchId, startDate, endDate);

                    for (int i = 0; i < lst.Count; i++)
                    {
                        lst[i].LoaiPhieu = loaiPhieuname; 
                        lst[i].BranchNameXuat = "Nhà Cung Cấp";
                    }

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return lst;
           

        }

        public List<objSearchDetailNX> SearchDetailNX(int loaiPhieu, int branchId, DateTime startDate, DateTime endDate)
        {
            List<objSearchDetailNX> lst = new List<objSearchDetailNX>();
            try
            {

                lst = DAL.SearchPhieuDetail(loaiPhieu, branchId, startDate, endDate);

            }
            catch (Exception)
            {

                throw;
            }
           
            return lst;


        }
    }
}
