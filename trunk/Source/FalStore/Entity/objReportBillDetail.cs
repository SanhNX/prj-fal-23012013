using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objReportBillDetail
    {
        public string BarCode { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public int CategoryID { get; set; }
    }
}
