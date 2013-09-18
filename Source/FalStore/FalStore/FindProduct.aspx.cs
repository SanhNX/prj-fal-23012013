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
namespace FalStore
{
    public partial class FindProduct : System.Web.UI.Page
    {
        #region .Property
        ProductBIZ productBIZ = new ProductBIZ();
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        string id = string.Empty;
        string name = string.Empty;
        private int pageSize;
        int stt = 1;

        #endregion

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
            }
            string ma = HttpContext.Current.Request.QueryString["ma"];
            Session["ma"] = ma;
            string ncc = HttpContext.Current.Request.QueryString["ncc"];
            Session["ncc"] = name;
            string nd = HttpContext.Current.Request.QueryString["nd"];
            Session["nd"] = nd;
             
        }

        protected void InitPage()
        {
            try
            {
                //int count;
                //pageSize = int.Parse(drpSelect.Text);
                ////this.pager.ItemCount = 21;
                //List<objProduct> tbl = new List<objProduct>();
                //tbl = productBIZ.ShowByPaging(currentPageIndex, pageSize, out count);
                //this.pager.ItemCount = count;
                //if (tbl != null)
                //{
                //    rptResult.DataSource = tbl;
                //    rptResult.DataBind();
                //}
                List<objCategory> lstCategory = new List<objCategory>();
                lstCategory = categoryBIZ.ShowAll();
                drpCategory.DataSource = lstCategory;
                drpCategory.DataTextField = "CategoryName";
                drpCategory.DataValueField = "CategoryID";
                drpCategory.DataBind();
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

                    objProduct data = e.Item.DataItem as objProduct;

                    //Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    //ltrStt.Text = stt.ToString();
                    //stt++;

                    Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                    ltrProductID.Text = data.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.ProductName.ToString();

                    Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                    ltrCategoryName.Text = data.Category.CategoryName.ToString();

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = data.ExportPrice.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            List<objProduct> lst = new List<objProduct>();
            lst = productBIZ.Search(txtProductName.Text, int.Parse(drpCategory.SelectedValue.ToString()));

            if (lst != null)
            {
                rptResult.DataSource = lst;
                rptResult.DataBind();
            }
        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("~/Default.aspx?pageName=Product");
        }

        protected void rptResult_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Select")
                {
                    Session["ProductID"] = e.CommandArgument.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// paging
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pager_Command(object sender, CommandEventArgs e)
        {
            this.currentPageIndex = Convert.ToInt32(e.CommandArgument);
            pager.CurrentIndex = this.currentPageIndex;
            InitPage();
        }
    }
}