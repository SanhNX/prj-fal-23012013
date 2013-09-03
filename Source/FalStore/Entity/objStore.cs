using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objStore
    {
        //ID
        public int StoreID { get; set; }
        //Product object
        public objProduct Product { get; set; }
        //version
        public string VerID { get; set; }
        //color object
        public objColor Color { get; set; }
        //size object
        public string Size { get; set; }
        //branch object
        public objBranch Branch { get; set; }
        //export price
        public float ExportPrice { get; set; }
        //quantity
        public int Quantity { get; set; }
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
