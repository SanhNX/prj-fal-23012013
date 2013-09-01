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
    public partial class Product : System.Web.UI.UserControl
    {
        ProductBIZ productBIZ = new ProductBIZ();
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        string id = string.Empty;
        string name = string.Empty;
        private int pageSize;
        int stt = 1;
        int type;
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
       
        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            objProduct obj = new objProduct();
            List<objColor> lstColor = new List<objColor>();
            //if (!Page.IsPostBack)
            //{
            InitPage();
            id = HttpContext.Current.Request.QueryString["id"];
            name = HttpContext.Current.Request.QueryString["name"];
            txtProductID.Text = id;
            if (txtProductID.Text != string.Empty)
            {
                type = 1;
                obj = productBIZ.ShowByID(id);

                txtProductName.Text = obj.ProductName;
                txtImportPrice.Text = obj.ImportPrice.ToString();
                txtExportPrice.Text = obj.ExportPrice.ToString();
                drpCategory.SelectedValue = obj.Category.CategoryID.ToString();

                lstColor = productBIZ.ShowColorByProductID(id);
                txtColor1.Text = lstColor[0].ColorName.ToString();
                txtColor2.Text = lstColor[1].ColorName.ToString();
                txtColor3.Text = lstColor[2].ColorName.ToString();
                txtColor4.Text = lstColor[3].ColorName.ToString();
                txtColor5.Text = lstColor[4].ColorName.ToString();
            }

           // txtCategoryName.Text = name;
            if (txtProductID.Text != string.Empty)
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
            List<objProduct> tbl = new List<objProduct>();
            tbl = productBIZ.ShowByPaging(currentPageIndex, pageSize, out count);
            this.pager.ItemCount = count;
            if (tbl != null)
            {
                rptResult.DataSource = tbl;
                rptResult.DataBind();
            }
            List<objCategory> lstCategory = new List<objCategory>();
            lstCategory = categoryBIZ.ShowAll();
            drpCategory.DataSource = lstCategory;
            drpCategory.DataTextField = "CategoryName";
            drpCategory.DataValueField = "CategoryID";
            drpCategory.DataBind();

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

                objProduct data = e.Item.DataItem as objProduct;

                Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                ltrStt.Text = stt.ToString();
                stt++;

                Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                ltrProductID.Text = data.ProductID.ToString();

                Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                ltrProductName.Text = data.ProductName.ToString();

                Literal ltrColorName = e.Item.FindControl("ltrColorName") as Literal;
                ltrColorName.Text = data.Color.ColorName.ToString();

                Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                ltrCategoryName.Text = data.Category.CategoryName.ToString();

                Literal ltrImportPrice = e.Item.FindControl("ltrImportPrice") as Literal;
                ltrImportPrice.Text = data.ImportPrice.ToString();

                Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                ltrExportPrice.Text = data.ExportPrice.ToString();

                Literal ltrEdit = e.Item.FindControl("ltrEdit") as Literal;
                ltrEdit.Text = "Chỉnh sửa";

                Literal ltrDelete = e.Item.FindControl("ltrDelete") as Literal;
                ltrDelete.Text = "Xóa";

                HyperLink hypEdit = new HyperLink();
                hypEdit = (HyperLink)e.Item.FindControl("hypEdit");
                hypEdit.NavigateUrl = string.Format("http://localhost:17449/Default.aspx?pageName=Product&id={0}", data.ProductID);

                HyperLink hypDelete = new HyperLink();
                hypDelete = (HyperLink)e.Item.FindControl("hypDelete");
                hypDelete.NavigateUrl = string.Format("http://localhost:17449/SelectProduct.aspx?id={0}", data.ProductID);

            }

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            stt = 1;
            
            int result;
            objProduct objProduct = new objProduct();
            objProduct.ProductID = txtProductID.Text;
            objProduct.ProductName = txtProductName.Text;
            objProduct.Category = new objCategory();
            objProduct.Category.CategoryID = int.Parse(drpCategory.SelectedValue);
            objProduct.ImportPrice = float.Parse(txtImportPrice.Text);
            objProduct.ExportPrice = float.Parse(txtExportPrice.Text);

            List<string> lColor = new List<string>();
            if (!txtColor1.Text.Equals(string.Empty))
            {
                lColor.Add(txtColor1.Text);
            }
            if (!txtColor2.Text.Equals(string.Empty))
            {
                lColor.Add(txtColor2.Text);
            }
            if (!txtColor3.Text.Equals(string.Empty))
            {
                lColor.Add(txtColor3.Text);
            }
            if (!txtColor4.Text.Equals(string.Empty))
            {
                lColor.Add(txtColor4.Text);
            }
            if (!txtColor5.Text.Equals(string.Empty))
            {
                lColor.Add(txtColor5.Text);
            }
           
            List<objColor> lstColor = new List<objColor>();
            objColor objColor = null;
            foreach (var item in lColor)
            {
                objColor = new objColor();
                objColor.ColorName = item;
                objColor.Product = new objProduct();
                objColor.Product.ProductID = txtProductID.Text;
                if (type == 0)
                {
                    SetUpdateInfo(objColor, 0);
                }
                else
                {
                    //objColor.ColorID= 
                    SetUpdateInfo(objColor, 1);
                }
                lstColor.Add(objColor);
            }
            
     
            if (type ==0)
            {
                SetUpdateInfo(objProduct, 0);
                result = productBIZ.Insert(objProduct,lstColor);
            }
            else
            {
                SetUpdateInfo(objProduct, 1);
                result = productBIZ.Update(objProduct, lstColor);
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

        //Set info for Create and Update
        //Type 0: Create    Type 1: Update
        private static void SetUpdateInfo(objProduct obj, int type)
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

        //Set info for Create and Update
        //Type 0: Create    Type 1: Update
        private static void SetUpdateInfo(objColor obj, int type)
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
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtImportPrice.Text = string.Empty;
            txtExportPrice.Text = string.Empty;
            txtColor1.Text = string.Empty;
            txtColor2.Text = string.Empty;
            txtColor3.Text = string.Empty;
            txtColor4.Text = string.Empty;
            txtColor5.Text = string.Empty;
        }

    }
}