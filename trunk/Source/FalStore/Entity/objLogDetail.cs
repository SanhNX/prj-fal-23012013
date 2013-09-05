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
        public string Size { get; set; }
        ////ExportPrice
        //public float ExportPrice { get; set; }
        //Sale
        public float Sale { get; set; }
        //Quantity
        public int Quantity { get; set; }
        //Amount
        public float Amount { get; set; }
        //Status flag
        public int Status_Flg { get; set; }
        //Delete Flag
        public int Delete_Flg { get; set; }
     
    }
}
