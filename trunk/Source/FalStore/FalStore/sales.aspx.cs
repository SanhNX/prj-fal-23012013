using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using BIZ;
using DAL;
using Entity;

namespace FalStore
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string ID { get; set; }
        }
    }
}