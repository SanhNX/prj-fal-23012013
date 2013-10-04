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
            if (role() == 1 || role() == 3 || role() == 4)
            {
                lblEmployeeName.Text = "Nhân Viên : " + Session["EmployeeName"].ToString();
                lblBranchName.Text = "Chi Nhánh " + Session["BranchName"].ToString();
            }
            else
            {
                Response.Redirect("~/Default.aspx?pageName=Home");
            }
            
        }

        public class Employee
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string ID { get; set; }
        }
    }
}