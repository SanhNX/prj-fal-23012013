using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objBillDetail
    {
         public int Bill_DetailID { get; set; }

         public string  BillID { get; set; }

         public int BranchID { get; set; }

         public string BranchName { get; set; }

         public string BarCode { get; set; }

         public string ProductName { get; set; }

         public float ExportPrice { get; set; }

         public int Quantity { get; set; }

         public float Amount { get; set; }

         public int Delete_Flg { get; set; }

         public DateTime CreateDate { get; set; }

         public string CreateUser { get; set; }

         public DateTime UpdateDate { get; set; }

         public string UpdateUser { get; set; }
    }
}
