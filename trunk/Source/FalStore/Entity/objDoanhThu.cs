using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objDoanhThu
    {
        //ID
        public string BillID { get; set; }
        //
        public string EmployeeName { get; set; }
        //
        public string CustomerName { get; set; }
        //
        public string BranchName { get; set; }
        //
        public float TotalPrice { get; set; }
        //
        public float Sale { get; set; }
        //
        public float ActualTotalPrice { get; set; }
        //
        public DateTime CreateDate { get; set; }
        //
        public string CreateUser { get; set; }
        //
        public DateTime UpdateDate { get; set; }
        //
        public string UpdateUser { get; set; }
        //
        public int Update_Flg { get; set; }
    }
}
