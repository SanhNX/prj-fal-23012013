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
    public partial class ChangePass : System.Web.UI.Page
    {
        EmployeeBIZ employeeBIZ = new EmployeeBIZ();
        objEmployee objemployee = new objEmployee();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserName.Text = Session["EmployeeName"].ToString();
            }
            
        }

        /// <summary>
        /// Add new & update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnChangePass_Click(object sender, EventArgs e) {
            objemployee = employeeBIZ.ShowEmployeeByID(int.Parse(Session["EmployeeID"].ToString()));
            if (objemployee != null && txtOldPass.Text.Equals(objemployee.PassWord))
            {
                int isUpdate = employeeBIZ.UpdatePassword(int.Parse(Session["EmployeeID"].ToString()), txtNewPass.Text);
                if (isUpdate != -1)
                {
                    employeeBIZ.UpdateFirstFlag(int.Parse(Session["EmployeeID"].ToString()));
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Mật khẩu đã được thay đổi thành công\"); <" + "/script>"));
                    Response.Redirect("~/Default.aspx?pageName=Home");
                }
                else {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Lỗi trong quá trình thay đổi mật khẩu\"); <" + "/script>"));
                }
                lblMessage.Text = "";
                lblMessage.Visible = false;
            }
            else
            {
                lblMessage.Text = "Mật khẩu hiện tại chưa đúng!";
                lblMessage.Visible = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e) {
            txtOldPass.Text = "";
            txtNewPass.Text = "";
            txtNewPassConfirm.Text = "";
            lblMessage.Text = "";
            lblMessage.Visible = false;
        }
    }
}