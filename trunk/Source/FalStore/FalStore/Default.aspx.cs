using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalStore
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ContentPlaceHolder cph = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = null;
            string pageName = HttpContext.Current.Request.QueryString["pageName"];
            switch (pageName)
            {
                case "Category":
                    uc = this.LoadControl("~/Control/Category.ascx") as UserControl;
                    break;
                case "Product":
                    uc = this.LoadControl("~/Control/Product.ascx") as UserControl;
                    break;
                case "Employee":
                    uc = this.LoadControl("~/Control/Employee.ascx") as UserControl;
                    break;
                case "User":
                    uc = this.LoadControl("~/Control/User.ascx") as UserControl;
                    break;
                case "Branch":
                    uc = this.LoadControl("~/Control/Branch.ascx") as UserControl;
                    break;
                case "Receipt":
                    uc = this.LoadControl("~/Control/Receipt.ascx") as UserControl;
                    break;
                case "Store":
                    uc = this.LoadControl("~/Control/Store.ascx") as UserControl;
                    break;
                case "ExportProduct":
                    uc = this.LoadControl("~/Control/ExportProduct.ascx") as UserControl;
                    break;
                case "PrintBarCode":
                    uc = this.LoadControl("~/Control/PrintBarCode.ascx") as UserControl;
                    break;

            }

            if ((cph != null) && (uc != null))
            {
                cph.Controls.Add(uc);
            }

        }
    }
}