using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalStore
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = "admin";
            string pass = "admin";
            if (txtUser.Text.Equals(user) && txtPass.Text.Equals(pass))
            {
                Session["User"] = txtUser.Text;
                Response.Redirect("~/Default.aspx?pageName=Home");
                
            }
            else
            {
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
            }

        }   

    }
}