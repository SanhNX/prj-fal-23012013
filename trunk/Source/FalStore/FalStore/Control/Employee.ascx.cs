using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BIZ;
using Entity;
using System.Data;

namespace FalStore.Control
{
    public partial class Employee : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        EmployeeBIZ employeeBIZ = new EmployeeBIZ();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        protected void InitPage()
        {
            try
            {

                List<objBranch> lstBranch = new List<objBranch>();
                lstBranch = branBiz.ShowAll();
                drpBranchTo.DataSource = lstBranch;
                drpBranchTo.DataTextField = "BranchName";
                drpBranchTo.DataValueField = "BranchID";
                drpBranchTo.DataBind();

                // Add quyen

                List<objPermission> lstPer = new List<objPermission>();
                objPermission per = new objPermission();
                per.Name = "Admin";
                per.Id = "1";
                objPermission per1 = new objPermission();
                per1.Name = "Quan Ly Kho";
                per1.Id = "2";
                objPermission per2 = new objPermission();
                per2.Name = "Quan Ly Chi Nhanh";
                per2.Id = "3";
                objPermission per3 = new objPermission();
                per3.Name = "Nhan Vien";
                per3.Id = "4";

                lstPer.Add(per);
                lstPer.Add(per1);
                lstPer.Add(per2);
                lstPer.Add(per3);

                drpPermission.DataSource = lstPer;
                drpPermission.DataTextField = "Name";
                drpPermission.DataValueField = "Id";
                drpPermission.DataBind();


                // add gioi tinh
                
                 List<objPermission> lstGioiTinh = new List<objPermission>();
                objPermission per4 = new objPermission();
                per4.Name = "Nam";
                per4.Id = "1";
                objPermission per5 = new objPermission();
                per5.Name = "Nữ";
                per5.Id = "0";
                lstGioiTinh.Add(per4);
                lstGioiTinh.Add(per5);
                drpGender.DataSource = lstGioiTinh;
                drpGender.DataTextField = "Name";
                drpGender.DataValueField = "Id";
                drpGender.DataBind();

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// event add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            objEmployee objE = new objEmployee();

            
            int result = 0;

            objE.UserName = TextUsername.Text;
            objE.PassWord = TextPassWord.Text;
            objE.EmployeeName = textEmpName.Text;
            objE.Gender = int.Parse(drpGender.SelectedValue.ToString());
            objE.Address = TextAdress.Text;
            objE.Phone = TextPhone.Text;
            objE.BranchID = int.Parse(drpBranchTo.SelectedValue.ToString());
            objE.Role = int.Parse(drpPermission.SelectedValue.ToString());
            objE.CreateDate = DateTime.Today;
            objE.CreateUser = "thanh";

            try
            {

                Boolean checkUser = employeeBIZ.EmployeeGetByUserName(TextUsername.Text);

                if (checkUser == true)
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"User đã tồn tại\"); <" + "/script>"));
                    return;

                }
                else {

                    result = employeeBIZ.Insert(objE);

                    if (result > 0)
                    {
                        Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Đã tạo nhân viên thành công\"); <" + "/script>"));
                        return;

                    }
                    else {
                        Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Đã tạo nhân viên không thành công\"); <" + "/script>"));
                        return;
                    }

                
                }




            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void txtTextChanged(object sender, EventArgs e)
        {
            try
            {
                Boolean result = employeeBIZ.EmployeeGetByUserName(TextUsername.Text);

                if (result == true)
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"User đã tồn tại\"); <" + "/script>"));
                    return;
                
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}