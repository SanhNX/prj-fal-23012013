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
    public partial class Store : System.Web.UI.UserControl
    {
        CategoryBIZ catBiz = new CategoryBIZ();
        BranchBIZ branBiz = new BranchBIZ();
        #region  Viewstate
        protected int currentPageIndex
        {
            get
            {
                if (ViewState["CurrentPageIndex"] != null)
                    return int.Parse(ViewState["CurrentPageIndex"].ToString());
                else
                    return 1;
            }
            set
            {
                ViewState["CurrentPageIndex"] = value;
            }
        }
        #endregion

        protected void InitPage()
        {
            try
            {
                List<objCategory> lstCategory = new List<objCategory>();
                lstCategory = catBiz.ShowAll();
                drpCategory.DataSource = lstCategory;
                drpCategory.DataTextField = "CategoryID";
                drpCategory.DataValueField = "CategoryName";
                drpCategory.DataBind();

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

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
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

                    objStore data = e.Item.DataItem as objStore;

                    //Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    //ltrStt.Text = stt.ToString();
                    //stt++;

                    Literal ltrBranchName = e.Item.FindControl("ltrBranchName") as Literal;
                    ltrBranchName.Text = data.Branch.BranchName.ToString();

                    Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                    ltrProductID.Text = data.Product.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.Product.ProductName.ToString();

                    Literal ltrImportPrice = e.Item.FindControl("ltrImportPrice") as Literal;
                    ltrImportPrice.Text = data.Product.ImportPrice.ToString();

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = data.ExportPrice.ToString();

                    Literal ltrQuantity = e.Item.FindControl("ltrQuantity") as Literal;
                    ltrQuantity.Text = data.Quantity.ToString();

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