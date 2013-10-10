using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Entity;
using DAL;

namespace FalStore.Control
{
    public partial class Event : System.Web.UI.UserControl
    {
        #region .Property
        BranchBIZ branBiz = new BranchBIZ();
        EventBIZ eventBiz = new EventBIZ();
        BranchDAL DALBranch = new BranchDAL();
        int stt = 1;
        #endregion
        #region .Event
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
            InitPage();
        }

        protected void InitPage()
        {
            try
            {

                List<objBranch> lstBranch = new List<objBranch>();
                lstBranch = branBiz.ShowAll();
                drpBranch.DataSource = lstBranch;
                drpBranch.DataTextField = "BranchName";
                drpBranch.DataValueField = "BranchID";
                drpBranch.DataBind();

                List<objEvent> lstEvent = new List<objEvent>();
                if (role() == 3)
                {
                    drpBranch.SelectedValue = Session["BranchID"].ToString();
                    drpBranch.Enabled = false;
                    lstEvent = eventBiz.ShowAllByBranch(int.Parse(Session["BranchID"].ToString()));
                }
                else
                {
                    drpBranch.Enabled = true;
                    lstEvent = eventBiz.ShowAll();
                }
                
                rptResult.DataSource = lstEvent;
                rptResult.DataBind();
                if (txtTemp.Text != string.Empty)
                {
                    btnAdd.Text = "Chỉnh sửa";
                }
                else
                {
                    btnAdd.Text = "Tạo mới";
                }
                

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

                    objEvent data = e.Item.DataItem as objEvent;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrEventName = e.Item.FindControl("ltrEventName") as Literal;
                    ltrEventName.Text = data.EventName.ToString();

                    Literal ltrDiscount = e.Item.FindControl("ltrDiscount") as Literal;
                    ltrDiscount.Text = data.Discount.ToString();

                    Literal ltrBranchName = e.Item.FindControl("ltrBranchName") as Literal;
                    ltrBranchName.Text = data.Branch.BranchName;

                    Literal ltrStartDate = e.Item.FindControl("ltrStartDate") as Literal;
                    DateTime StartDate = DateTime.Parse(data.StartDate);
                    ltrStartDate.Text = StartDate.ToString("yyyy-dd-MM");

                    Literal ltrEndDate = e.Item.FindControl("ltrEndDate") as Literal;
                    DateTime EndDate = DateTime.Parse(data.EndDate);
                    ltrEndDate.Text = EndDate.ToString("yyyy-dd-MM");

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Add new & update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtTemp.Text;
                int result = 0;
                objEvent obj = new objEvent();
                obj.Branch = DALBranch.GetBranchByID(int.Parse(drpBranch.Text));
                obj.EventName = txtEventName.Text;
                obj.Discount = txtDiscount.Text;
                obj.StartDate = txtStartDate.Text;
                obj.EndDate = txtEndDate.Text;
                if (string.Empty.Equals(id)) // add new
                {
                    stt = 1;
                    result = eventBiz.Insert(obj);
                }
                else // update
                {
                    obj.EventID = int.Parse(txtEventID.Text);
                    result = eventBiz.Update(obj);
                }

                if (result == 1)
                {
                    lblMessage.Text = "Thực thi thành công";
                }
                else
                {
                    lblMessage.Text = "Thực thi thất bại";
                }
                txtTemp.Text = "";
                clear();
                InitPage();
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
                        LoadDataUpdate(int.Parse(e.CommandArgument.ToString()));
                        break;
                    case "Delete":
                        DeleteEvent(int.Parse(e.CommandArgument.ToString()));
                        break;

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Delete record
        /// </summary>
        /// <param name="EventID"></param>
        private void DeleteEvent(int EventID)
        {
            DateTime updateDate = DateTime.Now;
            string updateUser = "";
            eventBiz.Delete(EventID, updateDate, updateUser);
            InitPage();
        }

        /// <summary>
        /// Load info to update
        /// </summary>
        /// <param name="BranchID"></param>
        private void LoadDataUpdate(int EventID)
        {
            objEvent obj = new objEvent();
            obj = eventBiz.ShowByEventID(EventID);
            txtEventName.Text = obj.EventName.ToString();
            txtDiscount.Text = obj.Discount.ToString();

            DateTime StartDate = DateTime.Parse(obj.StartDate);
            txtStartDate.Text = StartDate.ToString("MM/dd/yyyy hh:mm");
            DateTime EndDate = DateTime.Parse(obj.EndDate);
            txtEndDate.Text = EndDate.ToString("MM/dd/yyyy hh:mm");
            drpBranch.SelectedValue = obj.Branch.BranchID.ToString();
            txtTemp.Text = obj.EventID.ToString();
            txtEventID.Text = obj.EventID.ToString();
            InitPage();
        }

        protected void CompareFromAndStartDate(object sender, ServerValidateEventArgs e)
        {
            DateTime start = DateTime.Parse(txtStartDate.Text);
            DateTime end = DateTime.Parse(txtEndDate.Text);

            e.IsValid = start <= end;
        }

        /// <summary>
        /// clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    List<objDoanhThu> lstObj = new List<objDoanhThu>();

            //    lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
            //    if (lstObj != null)
            //    {
            //        rptResult.DataSource = lstObj;
            //        rptResult.DataBind();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    List<objDoanhThu> lstObj = new List<objDoanhThu>();

            //    lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
            //    if (lstObj != null)
            //    {
            //        rptResult.DataSource = lstObj;
            //        rptResult.DataBind();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


        }

        private void clear()
        {
            txtEventName.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            lblMessage.Text = string.Empty;
        }
        #endregion
    }
}