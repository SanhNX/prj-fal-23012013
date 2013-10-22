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
            if (role() == 3 || role() == 4 || (role() == 1 && Request.QueryString["billID"] != null))
            {
                lblEmployeeName.Text = "Nhân Viên : " + Session["EmployeeName"].ToString();
                lblBranchName.Text = "Chi Nhánh " + Session["BranchName"].ToString();
                lblBranchAddress.Text = Session["BranchAddress"].ToString();

                Literal0.Text = "<input id=\"sessionEmpId\" type=\"hidden\" value=\"" + int.Parse(Session["EmployeeID"].ToString()) +"\"  >";
                Literal6.Text = "<input id=\"sessionEmployeeName\" type=\"hidden\" value=\"" + Session["EmployeeName"].ToString() + "\"  >";
                Literal7.Text = "<input id=\"sessionBranchID\" type=\"hidden\" value=\"" + int.Parse(Session["BranchID"].ToString()) + "\"  >";
                Literal8.Text = "<input id=\"sessionBranchName\" type=\"hidden\" value=\"" + Session["BranchName"].ToString() + "\"  >";
                Literal9.Text = "<input id=\"sessionBranchAddress\" type=\"hidden\" value=\"" + Session["BranchAddress"].ToString() + "\"  >";
                Literal10.Text = "<input id=\"sessionRole\" type=\"hidden\" value=\"" + int.Parse(Session["Role"].ToString()) + "\"  >";

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