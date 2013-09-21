using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Entity;

namespace BIZ
{
    public class BarCodeBIZ
    {
        BarCodeDAL DAL = new BarCodeDAL();
        public List<objFindBarCode> GetBarCodeByProductID(String productId)
        {
            try
            {
                List<objFindBarCode> lst = new List<objFindBarCode>();
                lst = DAL.GetBarCodeByProductID(productId);

                return lst;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
