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

        private int role()
        {
            int role = -1;
            if (Session["Role"] != null)
            {
                role = (int)Session["Role"];
            }
            return role;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            ContentPlaceHolder cph = this.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder;
            UserControl uc = null;
            string pageName = HttpContext.Current.Request.QueryString["pageName"];
            switch (pageName)
            {
                case "Home":
                    uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    break;
                case "Category":
                    if (role() == 1 || role() == 2)
                    {
                        uc = this.LoadControl("~/Control/Category.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;
                case "Product":
                    if (role() == 1 || role() == 2)
                    {
                        uc = this.LoadControl("~/Control/Product.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;
                case "Receipt":
                    if (role() == 1 || role() == 2)
                    {
                        uc = this.LoadControl("~/Control/Receipt.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;
                case "ExportProduct":
                    if (role() == 1 || role() == 2)
                    {
                        uc = this.LoadControl("~/Control/ExportProduct.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;
                case "Store":
                    if (role() == 1 || role() == 2 || role() == 3)
                    {
                        uc = this.LoadControl("~/Control/Store.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;
                case "NhapXuat":
                    if (role() == 1 || role() == 2)
                    {
                        uc = this.LoadControl("~/Control/QuanLyNhapXuat.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;

                case "Branch":
                    if (role() == 1 || role() == 3)
                    {
                        uc = this.LoadControl("~/Control/Branch.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
                    break;
                case "Event":
                    if (role() == 1 || role() == 3)
                    {
                        uc = this.LoadControl("~/Control/Event.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
                    break;
                case "DoanhThu":
                    if (role() == 1 || role() == 3 || role() == 4)
                    {
                        uc = this.LoadControl("~/Control/DoanhThu.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
                    break;
                case "ThongKe":
                    if (role() == 1 || role() == 3)
                    {
                        uc = this.LoadControl("~/Control/ThongKe.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
                    break;
                case "ChiPhi":
                    if (role() == 1 || role() == 3)
                    {
                        uc = this.LoadControl("~/Control/ChiPhi.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
                    break;
                case "LoiNhuan":
                    if (role() == 1 || role() == 3)
                    {
                        //uc = this.LoadControl("~/Control/LoiNhuan.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    break;


                case "Employee":
                    if (role() == 1 || role() == 3)
                    {
                        uc = this.LoadControl("~/Control/Employee.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
                    break;
                case "User":
                    if (role() == 1)
                    {
                        uc = this.LoadControl("~/Control/User.ascx") as UserControl;
                    }
                    else
                    {
                        uc = this.LoadControl("~/Control/Home.ascx") as UserControl;
                    }
                    
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