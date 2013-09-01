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
    public partial class Category : System.Web.UI.UserControl
    {
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        string id = string.Empty;
        string name = string.Empty;
        private int pageSize;
        int stt = 1;
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

        #region .Event
        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            InitPage();
            id = HttpContext.Current.Request.QueryString["id"];
            name = HttpContext.Current.Request.QueryString["name"];
            txtCategoryID.Text = id;
            txtCategoryName.Text = name;
            if (txtCategoryID.Text != string.Empty)
            {
                btnAdd.Text = "Chỉnh sửa";
            }
            else
            {
                btnAdd.Text = "Tạo mới";
            }
            // }
        }

        /// <summary>
        /// initial page
        /// </summary>
        protected void InitPage()
        {
            int count;
            pageSize = int.Parse(drpSelect.Text);
            //this.pager.ItemCount = 21;
            List<objCategory> tbl = new List<objCategory>();
            tbl = categoryBIZ.ShowByPaging(currentPageIndex, pageSize, out count);
            this.pager.ItemCount = count;
            if (tbl != null)
            {
                rptResult.DataSource = tbl;
                rptResult.DataBind();
            }
        }

        /// <summary>
        /// Literal map data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                objCategory data = e.Item.DataItem as objCategory;

                Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                ltrStt.Text = stt.ToString();
                stt++;

                Literal ltrCategoryID = e.Item.FindControl("ltrCategoryID") as Literal;
                ltrCategoryID.Text = data.CategoryID.ToString();

                Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                ltrCategoryName.Text = data.CategoryName.ToString();

                Literal ltrEdit = e.Item.FindControl("ltrEdit") as Literal;
                ltrEdit.Text = "Chỉnh sửa";

                Literal ltrDelete = e.Item.FindControl("ltrDelete") as Literal;
                ltrDelete.Text = "Xóa";

                HyperLink hypEdit = new HyperLink();
                hypEdit = (HyperLink)e.Item.FindControl("hypEdit");
                hypEdit.NavigateUrl = string.Format("http://localhost:17449/Default.aspx?pageName=Category&id={0}&name={1}", data.CategoryID, data.CategoryName);

                HyperLink hypDelete = new HyperLink();
                hypDelete = (HyperLink)e.Item.FindControl("hypDelete");
                hypDelete.NavigateUrl = string.Format("http://localhost:17449/SelectProduct.aspx?id={0}", data.CategoryID);


            }
        }

        /// <summary>
        /// Add new & update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            stt = 1;
            string categoryID = txtCategoryID.Text;
            int result;
            objCategory obj = new objCategory();
            obj.CategoryName = txtCategoryName.Text;

            if (string.Empty.Equals(categoryID))
            {
                SetUpdateInfo(obj, 0);
                result = categoryBIZ.Insert(obj);
            }
            else
            {
                SetUpdateInfo(obj, 1);
                result = categoryBIZ.Update(obj);
            }

            if (result == 1)
            {
                lblMessage.Text = "Thực thi thành công";
            }
            else
            {
                lblMessage.Text = "Thực thi thất bại";
            }
            InitPage();
            clear();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void pager_Command(object sender, CommandEventArgs e)
        {
            this.currentPageIndex = Convert.ToInt32(e.CommandArgument);
            pager.CurrentIndex = this.currentPageIndex;
            InitPage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region .Method
        //Set info for Create and Update
        //Type 0: Create    Type 1: Update
        private static void SetUpdateInfo(objCategory obj, int type)
        {
            if (type == 0)
            {
                obj.CreateDate = System.DateTime.Now;
                obj.CreateUser = "";
                obj.UpdateDate = System.DateTime.Now;
                obj.UpdateUser = "";
            }
            else
            {
                obj.UpdateDate = System.DateTime.Now;
                obj.UpdateUser = "";
            }
        }

        private void clear()
        {
            txtCategoryID.Text = string.Empty;
            txtCategoryName.Text = string.Empty;

        }
        #endregion

    }
}