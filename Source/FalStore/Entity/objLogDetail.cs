using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objLogDetail
    {
        //ID
        public int LogDetailID { get; set; }
        //Log Store object
        public objLogStore LogStore { get; set; }
        //Product object
        public objProduct Product { get; set; }
        //Color object
        public objColor Color { get; set; }
        //Size object
        public objSize Size { get; set; }
        //Sale
        public float Sale { get; set; }
        //Quantity
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
