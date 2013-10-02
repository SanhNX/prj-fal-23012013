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

        private int role() {
            int role = -1;
            if (Session["Role"] != null)
            {
                role = (int)Session["Role"];
            }
            return role;
        }

        private int branchID()
        {
            int branchId = -1;
            if (Session["BranchID"] != null)
            {
                branchId = (int)Session["BranchID"];
            }
            return branchId;
        }


        protected void Page_Load(object sender, EventArgs e)
        {




            switch (role())
            {
                case 1:
                    InitPage(role());
                    search("", -1, -1);
                    break;
                case 3:
                    InitPage(role());
                    search("", branchID(), role());
                    break;
                default:
                    Response.Redirect("~/Default.aspx?pageName=Home");  
                    break;
            }

        }

        protected void InitPage(int role)
        {
            try
            {

                List<objBranch> lstBranch = new List<objBranch>();
                objBranch objBra = null;
                if (role == 1)
                {
                    lstBranch = branBiz.ShowAll();
                }
                else {
                    objBra = new objBranch();
                    objBra = branBiz.ShowByBranchID((int)Session["BranchID"]);
                    lstBranch.Add(objBra);
                }

                
                drpBranchTo.DataSource = lstBranch;
                drpBranchTo.DataTextField = "BranchName";
                drpBranchTo.DataValueField = "BranchID";
                drpBranchTo.DataBind();

                // Add quyen

                List<objPermission> lstPer = new List<objPermission>();

                if (role == 1)
                {
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
                }
                else
                {
                    objPermission per3 = new objPermission();
                    per3.Name = "Nhan Vien";
                    per3.Id = "4";
                    lstPer.Add(per3);
                }

                

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
                        if (role() == 1)
                        {
                            search("", -1, -1);
                        }
                        else {
                            search("", branchID(), role());
                        }
                        

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

        private void search(string empName , int brachID , int role)
        {
            try
            {
                List<objEmployee> lstEmp = new List<objEmployee>();
                lstEmp = employeeBIZ.EmployeeSearch(empName, brachID, role);
                rptResult.DataSource = lstEmp;
                rptResult.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Literal map data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objEmployee data = e.Item.DataItem as objEmployee;

                    Literal ltrName = e.Item.FindControl("ltrName") as Literal;
                    ltrName.Text = data.EmployeeName.ToString();

                    Literal ltrUserName = e.Item.FindControl("ltrUserName") as Literal;
                    ltrUserName.Text = data.UserName.ToString();

                    Literal ltrChiNhanh = e.Item.FindControl("ltrChiNhanh") as Literal;
                    ltrChiNhanh.Text = data.BranchName.ToString();

                    if ("1".Equals(data.Gender.ToString()))
                    {
                        Literal ltrGioiTinh = e.Item.FindControl("ltrGioiTinh") as Literal;
                        ltrGioiTinh.Text = "Nam";
                    }
                    else {
                        Literal ltrGioiTinh = e.Item.FindControl("ltrGioiTinh") as Literal;
                        ltrGioiTinh.Text = "Nữ";
                    }
                   

                    Literal ltrDiaChi = e.Item.FindControl("ltrDiaChi") as Literal;
                    ltrDiaChi.Text = data.Address.ToString();

                    Literal ltrDienThoai = e.Item.FindControl("ltrDienThoai") as Literal;
                    ltrDienThoai.Text = data.Phone.ToString();

                    if ("1".Equals(data.Role.ToString()))
                    {
                        Literal ltrCapBat = e.Item.FindControl("ltrCapBat") as Literal;
                        ltrCapBat.Text = "Admin";
                    }
                    else if ("2".Equals(data.Role.ToString())) 
                    {
                        Literal ltrCapBat = e.Item.FindControl("ltrCapBat") as Literal;
                        ltrCapBat.Text = "Quản Lý Kho";
                    }
                    else if ("3".Equals(data.Role.ToString()))
                    {
                        Literal ltrCapBat = e.Item.FindControl("ltrCapBat") as Literal;
                        ltrCapBat.Text = "Quản Lý Chi Nhánh";
                    }
                    else if ("4".Equals(data.Role.ToString()))
                    {
                        Literal ltrCapBat = e.Item.FindControl("ltrCapBat") as Literal;
                        ltrCapBat.Text = "Nhân Viên";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// item command
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptResult_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Edit":
                        
                        //LoadDataUpdate(e.CommandArgument.ToString());
                        break;
                    case "Delete":
                        if (int.Parse(e.CommandArgument.ToString()) != role()) {
                            objEmployee objE = new objEmployee();
                            objE.EmployeeID = int.Parse(e.CommandArgument.ToString());
                            objE.UpdateDate = DateTime.Today;
                            objE.UpdateUser = (string)Session["EmployeeName"];
                            employeeBIZ.Delete(objE);
                            if (role() == 1)
                            {
                                search("", -1, -1);
                            }
                            else
                            {
                                search("", branchID(), role());
                            }
                            Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Đã Xóa Nhân Viên Thành Công\"); <" + "/script>"));
                        }
                        
                        //DeleteProduct(e.CommandArgument.ToString());
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}