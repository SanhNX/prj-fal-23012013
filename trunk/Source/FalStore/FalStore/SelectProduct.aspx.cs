using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalStore
{
    public partial class SelectProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          string  id = HttpContext.Current.Request.QueryString["id"];
        }
    }
}