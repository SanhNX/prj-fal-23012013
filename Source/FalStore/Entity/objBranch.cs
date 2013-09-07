using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objBranch
    {
        //ID
        public int BranchID { get; set; }
        //Name
        public string BranchName { get; set; }
        //Address
        public string Address { get; set; }
        //Description
        public string Description { get; set; }
        //Delete_Flg
        public int Delete_Flg { get; set; }       
        //Create date
        public DateTime CreateDate { get; set; }
        //Create user
        public string CreateUser { get; set; }
        //Update date
        public DateTime UpdateDate { get; set; }
        //Update user
        public string UpdateUser { get; set; }

    }
}
