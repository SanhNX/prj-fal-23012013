using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objColor
    {
        //ID
        public int ColorID { get; set; }
        //Name
        public string ColorName { get; set; }
        //Product object
        public objProduct Product { get; set; }
        //Delete Flag
        public int Delete_Flg { get; set; }
     
    }
}
