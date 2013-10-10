using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BIZ;
using Common;

namespace FalStore.Control
{
    public partial class ChiPhi : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        ExpensesBIZ expensesBIZ = new ExpensesBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        protected void InitPage()
        {
            try
            {

                List<objBranch> lstBranch = new List<objBranch>();
                objBranch objB = new objBranch();
                lstBranch = branBiz.ShowAll();
                objB.BranchID = 0;
                objB.BranchName = "Tất Cả";
                lstBranch.Add(objB);
                drpBranch.DataSource = lstBranch;
                drpBranch.DataTextField = "BranchName";
                drpBranch.DataValueField = "BranchID";
                drpBranch.DataBind();


                // 
                stt = 1;
                Search();
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void Search() {
            List<objExpenses> lstExpenses = new List<objExpenses>();
            // khi init data thì  branch id là phai lấy từ session của user login
            lstExpenses = expensesBIZ.ExpensesSearch(0, GetFirstDayOfMonth(DateTime.Today), GetLastDayOfMonth(DateTime.Today));
            rptResult.DataSource = lstExpenses;
            rptResult.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            stt = 1;
            List<objExpenses> lstExpenses = new List<objExpenses>();
            lstExpenses = expensesBIZ.ExpensesSearch(int.Parse(drpBranch.SelectedValue), GetFirstDayOfMonth(DateTime.Today), GetLastDayOfMonth(DateTime.Today));
            rptResult.DataSource = lstExpenses;
            rptResult.DataBind();
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                // Check input 
                if (string.Empty.Equals(txtDescription.Text)) {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"MÔ TẢ  không được tróng !!!\"); <" + "/script>"));
                    return;
                }
                try {
                    if (int.Parse(txtTien.Text) <= 0)
                    {
                        Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Tổng Tiền phải là số và lớn hơn 0 Đ !!!\"); <" + "/script>"));
                        return;
                    }
                }
                catch (Exception)
                {

                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Tổng Tiền phải là số và lớn hơn 0 Đ !!!\"); <" + "/script>"));
                    return;
                }

                if(int.Parse(txtTien.Text) <= 0){
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Tổng Tiền phải là số và lớn hơn 0 Đ !!!\"); <" + "/script>"));
                    return;
                }

                if (int.Parse(drpBranch.SelectedValue) == 0) {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Khi nhập thông tin chi phí không được chọn chi nhánh : TẤT CẢ !!!\"); <" + "/script>"));
                    return;
                }
                
                objExpenses objExpense = new objExpenses();

                objExpense.BranchID = int.Parse(drpBranch.SelectedValue.ToString());
                // todo kho login lay tu session gan vao.
                objExpense.EmployeeID = 3;
                objExpense.Amount = float.Parse(txtTien.Text);
                objExpense.Description = txtDescription.Text;
                objExpense.CreateDate = DateTime.Today;
                // User se lay tu session
                objExpense.CreateUser = (String)Session["EmployeeName"];
                objExpense.UpdateDate = DateTime.Today;
                objExpense.UpdateUser = (String)Session["EmployeeName"];

                expensesBIZ.InsertExpenses(objExpense);

                Search();
                //InitPage();
            }
            catch (Exception)
            {

                throw;
            }
            stt = 1;

        }

        /// Lấy ra ngày đầu tiên trong tháng có chứa 
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtDate">Ngày nhập vào</param>
        /// <returns>Ngày đầu tiên trong tháng</returns>
        public static DateTime GetFirstDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddDays((-dtResult.Day) + 1);
            return dtResult;
        }

        /// <summary>
        /// Lấy ra ngày cuối cùng trong tháng có chứa 
        /// 1 ngày bất kỳ được truyền vào
        /// </summary>
        /// <param name="dtInput">Ngày nhập vào</param>
        /// <returns>Ngày cuối cùng trong tháng</returns>
        public static DateTime GetLastDayOfMonth(DateTime dtInput)
        {
            DateTime dtResult = dtInput;
            dtResult = dtResult.AddMonths(1);
            dtResult = dtResult.AddDays(-(dtResult.Day));
            return dtResult;
        }

        /// <summary>
        /// Literal map data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        int stt = 1;
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objExpenses data = e.Item.DataItem as objExpenses;

                    //Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    //ltrStt.Text = stt.ToString();
                    //stt++;

                    Literal ltr1 = e.Item.FindControl("ltr1") as Literal;
                    ltr1.Text = stt.ToString();
                    stt++;

                    Literal ltr2 = e.Item.FindControl("ltr2") as Literal;
                    ltr2.Text = data.BranchName.ToString();

                    Literal ltr3 = e.Item.FindControl("ltr3") as Literal;
                    ltr3.Text = data.Description.ToString();

                    Literal ltr4 = e.Item.FindControl("ltr4") as Literal;
                    ltr4.Text = conV.FloatToMoneyString(data.Amount.ToString("0"));

                    Literal ltr5 = e.Item.FindControl("ltr5") as Literal;
                    ltr5.Text = data.CreateDate.ToString();

                    Literal ltr6 = e.Item.FindControl("ltr6") as Literal;
                    ltr6.Text = data.CreateUser.ToString();

                

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}