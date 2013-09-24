using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objExpenses
    {
        //
        public int EmployeeID { get; set; }
        //
        public int BranchID { get; set; }
        //
        public string BranchName { get; set; }
        //
        public string Description { get; set; }
        //
        public float Amount { get; set; }
        //
        public int Delete_Flg { get; set; }
        //
        public DateTime CreateDate { get; set; }
        //
        public string CreateUser { get; set; }
        //
        public DateTime UpdateDate { get; set; }
        //
        public string UpdateUser { get; set; }
    }
}
