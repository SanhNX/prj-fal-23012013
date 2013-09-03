using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objProduct
    {
        //ID
        public string ProductID { get; set; }
        //Name
        public string ProductName { get; set; }
        //Category object
        public objCategory Category { get; set; }
        //Color object
        public objColor Color { get; set; }
        //Import price
        public float ImportPrice { get; set; }
        //Export price
        public float ExportPrice { get; set; }
        //Total quantity
        public int TotalQuantity { get; set; }
        //Delete Flag
        public string Delete_Flg { get; set; }
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
