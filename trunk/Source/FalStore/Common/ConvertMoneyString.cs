using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Common
{
    public class ConvertMoneyString
    {
        public String FloatToMoneyString(String param) {

            var info = System.Globalization.CultureInfo.GetCultureInfo("vi-VN");
           // String abc = String.Format(info, "{0:c}", param);

            string abc = double.Parse(param).ToString("#,###", info.NumberFormat);

            abc =  abc.Replace(".", ",");
            return abc;
        }
    }
}
