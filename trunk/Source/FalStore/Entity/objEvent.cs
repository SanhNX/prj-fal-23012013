using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objEvent
    {
        //ID
        public int EventID { get; set; }
        //Branch object
        public objBranch Branch { get; set; }
        //Name
        public string EventName { get; set; }            
        //Start date
        public string StartDate { get; set; }
        //End date
        public string EndDate { get; set; }
        //Discount
        public string Discount { get; set; }

    }
}
