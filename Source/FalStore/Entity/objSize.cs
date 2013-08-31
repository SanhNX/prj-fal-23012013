using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objSize
    {
        //ID
        public int SizeID { get; set; }
        //Name
        public string SizeName { get; set; }
        //Color ID
        public int ColorID { get; set; }
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
