using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objUser
    {
        //ID
        public string UserID { get; set; }
        //Password
        public string Password { get; set; }
        //Role
        public int Role { get; set; }
        //Employee object
        public objEmployee Employee { get; set; }
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

    }
}
