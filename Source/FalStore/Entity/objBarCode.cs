using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objBarCode
    {
        public string BarCode { get; set; }
        public objProduct Product { get; set; }
        public string ColorName { get; set; }
        public string SizeName { get; set; }
    }
}
