using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objFindBarCode
    {
        public string BarCode { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        //Import price
        public float ImportPrice { get; set; }
        //Export price
        public float ExportPrice { get; set; }
    }
}
