using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Entity;

namespace FalStore.Control
{
    public partial class DoanhThu : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        BillBIZ billBiz = new BillBIZ();

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

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<objDoanhThu> lstObj = new List<objDoanhThu>();

                lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
                if (lstObj != null)
                {
                    rptResult.DataSource = lstObj;
                    rptResult.DataBind();
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

                    objDoanhThu data = e.Item.DataItem as objDoanhThu;

                    //Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    //ltrStt.Text = stt.ToString();
                    //stt++;

                    Literal ltrBillId = e.Item.FindControl("ltrBillId") as Literal;
                    ltrBillId.Text = data.BillID.ToString();

                    Literal ltrEmpName = e.Item.FindControl("ltrEmpName") as Literal;
                    ltrEmpName.Text = data.EmployeeName.ToString();

                    Literal ltrCusName = e.Item.FindControl("ltrCusName") as Literal;
                    ltrCusName.Text = data.CustomerName.ToString();

                    Literal ltrBranchName = e.Item.FindControl("ltrBranchName") as Literal;
                    ltrBranchName.Text = data.BranchName.ToString();

                    Literal ltrDate = e.Item.FindControl("ltrDate") as Literal;
                    ltrDate.Text = data.CreateDate.ToString();

                    Literal ltrPrice1 = e.Item.FindControl("ltrPrice1") as Literal;
                    ltrPrice1.Text = data.TotalPrice.ToString();

                    Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                    ltrSale.Text = data.Sale.ToString();

                    Literal ltrPrice2 = e.Item.FindControl("ltrPrice2") as Literal;
                    ltrPrice2.Text = data.ActualTotalPrice.ToString();

                    //LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                    //lnkDelete.CommandArgument = data.CategoryID.ToString();

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
                        //LoadDataUpdate(int.Parse(e.CommandArgument.ToString()));
                        break;
                    case "Delete":
                        // DeleteCategory(int.Parse(e.CommandArgument.ToString()));
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