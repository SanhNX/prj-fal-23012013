using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objCustomer
    {
        //ID
        public int CustomerID { get; set; }
        //Name
        public string CustomerName { get; set; }
        //email
        public string Email { get; set; }
        //Phone
        public string Phone { get; set; }
        //Delete Flag
        public int Delete_Flg { get; set; }
        //Create date
        public string CreateDate { get; set; }
        //Create user
        public string CreateUser { get; set; }
        //Update date
        public string UpdateDate { get; set; }
        //Update user
        public string UpdateUser { get; set; }
        //Code Customer
        public string CodeCustomer { get; set; }
        // Discount
        public int DisCount { get; set; }
        //Start DisCount
        public string StartDiscount { get; set; }
        //End DisCount
        public string EndDiscount { get; set; }
        //Point
        public int Point { get; set; }

    }
}
