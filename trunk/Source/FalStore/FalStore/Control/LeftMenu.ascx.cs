using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalStore.Control
{
    public partial class leftmenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hypCategory.HRef = "http://localhost:1596/Default.aspx?pageName=Category";
                this.hypProduct.HRef = "http://localhost:1596/Default.aspx?pageName=Product";
                this.hypEmployee.HRef = "http://localhost:1596/Default.aspx?pageName=Employee";
                this.hypUser.HRef = "http://localhost:1596/Default.aspx?pageName=User";
                this.hypBranch.HRef = "http://localhost:1596/Default.aspx?pageName=Branch";
                this.hypReceipt.HRef = "http://localhost:1596/Default.aspx?pageName=Receipt";
            }
          
        }
    }
}