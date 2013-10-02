using BIZ;
using Entity;
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
        EmployeeBIZ employeeBIZ = new EmployeeBIZ();
        BranchBIZ branchBIZ = new BranchBIZ();
        objEmployee objemployee = new objEmployee();
        objBranch objbranch = new objBranch();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            objemployee = employeeBIZ.ShowByEmployeeByNameAndPass(txtUser.Text, txtPass.Text);

            if (objemployee != null)
            {
                Session["EmployeeID"] = objemployee.EmployeeID;
                Session["EmployeeName"] = objemployee.EmployeeName;
                Session["BranchID"] = objemployee.BranchID;
                Session["BranchName"] = branchBIZ.ShowByBranchID(objemployee.BranchID).BranchName;
                if (objemployee.First_Flg == 0)
                { // change pass
                    Response.Redirect("~/ChangePass.aspx");
                }
                else 
                {
                    Response.Redirect("~/Default.aspx?pageName=Home");    
                }
            }
            else 
            {
                Response.Redirect("~/ErrorPage.aspx");
            }
            txtUser.Text = string.Empty;
            txtPass.Text = string.Empty;

        }   

    }
}