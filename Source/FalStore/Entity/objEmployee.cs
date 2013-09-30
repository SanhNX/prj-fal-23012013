using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objEmployee
    {
        //ID
        public int EmployeeID { get; set; }
        //Name
        public string EmployeeName { get; set; }
        //
        public string UserName { get; set; }
        //
        public string PassWord { get; set; }
        //Gender
        public int Gender { get; set; }
        //Address
        public string Address { get; set; }
        //Phone
        public string Phone { get; set; }
        //Delete Flag
        public int Delete_Flg { get; set; }
        //Create date
        public DateTime CreateDate { get; set; }
        //Create user
        public string CreateUser { get; set; }
        //Update date
        public DateTime UpdateDate { get; set; }
        //Update user
        public string UpdateUser { get; set; }

        public int First_Flg { get; set; }

        public int Role { get; set; }

        public int BranchID { get; set; }

        public string BranchName { get; set; }

    }
}
