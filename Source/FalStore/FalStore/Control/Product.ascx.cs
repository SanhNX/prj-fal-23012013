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
using System.Web.Services;
using Common;
namespace FalStore.Control
{
    public partial class Product : System.Web.UI.UserControl
    {
        
        #region .Property
        ProductBIZ productBIZ = new ProductBIZ();
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        string id = string.Empty;
        string name = string.Empty;
        private int pageSize;
        int stt = 1;
        ConvertMoneyString conV = new ConvertMoneyString();

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

        #region .Event

      
        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
           
            InitPage();
            if (Session["id"] != null)
            {
                txtProductID.Text = Session["id"].ToString();
            }
            if (Session["Name"] != null)
            {
                txtProductName.Text = Session["Name"].ToString();
            }
           
           

            //}
        }

        /// <summary>
        /// initial page
        /// </summary>
        protected void InitPage()
        {
            try
            {
                int count;
                pageSize = 50;
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

                if (txtTemp.Text != string.Empty)
                {
                    btnAdd.Text = "Chỉnh sửa";
                    txtProductID.Enabled = false;
                }
                else
                {
                    btnAdd.Text = "Tạo mới";
                    txtProductID.Enabled = true;
                }
                if (Session["ListColor"] != null)
                {
                    List<string> l = new List<string>();
                    l = (List<string>)Session["ListColor"];
                    bLstColor.DataSource = l;
                    bLstColor.DataBind();
                }
                else
                {
                    List<string> l = new List<string>();
                    bLstColor.DataSource = l;
                    bLstColor.DataBind();
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

                    objProduct data = e.Item.DataItem as objProduct;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                    ltrProductID.Text = data.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.ProductName.ToString();

                    Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                    ltrCategoryName.Text = data.Category.CategoryName.ToString();

                    Literal ltrImportPrice = e.Item.FindControl("ltrImportPrice") as Literal;
                    ltrImportPrice.Text = conV.FloatToMoneyString(data.ImportPrice.ToString("0"));

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = conV.FloatToMoneyString(data.ExportPrice.ToString("0"));
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
                        LoadDataUpdate(e.CommandArgument.ToString());
                        txtImportPrice.Enabled = false;
                        txtExportPrice.Enabled = false;
                        drpCategory.Enabled = false;
                        break;
                    case "Delete":
                        DeleteProduct(e.CommandArgument.ToString());
                        break;
                    case "Barcode":
                        Response.Redirect("~/Default.aspx?pageName=PrintBarCode&id=" + e.CommandArgument.ToString());
                        break;
                }
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
            try
            {
                bool flag;
                stt = 1;
                string id = txtTemp.Text;
                int result;
                objProduct objProduct = new objProduct();
                objProduct.ProductID = txtProductID.Text;
                objProduct.ProductName = txtProductName.Text;
                objProduct.Category = new objCategory();
                objProduct.Category.CategoryID = int.Parse(drpCategory.SelectedValue);
                objProduct.ImportPrice = float.Parse(txtImportPrice.Text);
                objProduct.ExportPrice = float.Parse(txtExportPrice.Text);

                List<string> lColor = new List<string>();

                if (Session["ListColor"] != null)
                {
                    lColor = (List<string>)Session["ListColor"];
                }

                if (lColor.Count == 0 && string.Empty.Equals(id))
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Chưa chọn màu sắc\"); <" + "/script>"));
                    return;

                }
                if (float.Parse(txtImportPrice.Text) > float.Parse(txtExportPrice.Text))
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Giá nhập lớn hơn giá bán\"); <" + "/script>"));
                    return;

                }
                //List<objColor> lstColor = new List<objColor>();
                //objColor objColor = null;
                List<objBarCode> lstBarcode = new List<objBarCode>();
                objBarCode objBar = null;
                //foreach (var item in lColor)
                //{
                //    objBar = new objBarCode();
                //    //objColor = new objColor();
                //    //objColor.ColorName = item;
                //    //objColor.Product = new objProduct();
                //    //objColor.Product.ProductID = txtProductID.Text;

                //    //lstColor.Add(objColor);
                //}
                for (int i = 0; i < lColor.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            objBar = new objBarCode();
                            objBar.BarCode = txtProductID.Text + i + "S";
                            objBar.Product = new Entity.objProduct();
                            objBar.Product.ProductID = txtProductID.Text;
                            objBar.ColorName = lColor[i].ToString();
                            objBar.SizeName = "S";
                            lstBarcode.Add(objBar);
                        }
                        else if (j == 1)
                        {
                            objBar = new objBarCode();
                            objBar.BarCode = txtProductID.Text + i + "M";
                            objBar.Product = new Entity.objProduct();
                            objBar.Product.ProductID= txtProductID.Text;
                            objBar.ColorName = lColor[i].ToString();
                            objBar.SizeName = "M";
                            lstBarcode.Add(objBar);
                        }
                        else if (j == 2)
                        {
                            objBar = new objBarCode();
                            objBar.BarCode = txtProductID.Text + i + "L";
                            objBar.Product = new Entity.objProduct();
                            objBar.Product.ProductID = txtProductID.Text;
                            objBar.ColorName = lColor[i].ToString();
                            objBar.SizeName = "L";
                            lstBarcode.Add(objBar);
                        }
                        else if (j == 3)
                        {
                            objBar = new objBarCode();
                            objBar.BarCode = txtProductID.Text + i + "XL";
                            objBar.Product = new Entity.objProduct();
                            objBar.Product.ProductID = txtProductID.Text;
                            objBar.ColorName = lColor[i].ToString();
                            objBar.SizeName = "XL";
                            lstBarcode.Add(objBar);
                        }
                    }
                   
                }

                if (string.Empty.Equals(id))
                {
                    flag = CheckProductID(txtProductID.Text);
                    if (flag)
                    {
                        SetUpdateInfo(objProduct, 0);
                        result = productBIZ.Insert(objProduct, lstBarcode);
                    }
                    else
                    {
                        //thông báo sau khi thành congo
                        Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Mã sản phẩm đã tồn tại\"); <" + "/script>"));
                        // Response.Write("<script language='javascript'>alert(Mã sản phẩm đã tồn tại)</script>");
                        //lblMessage.Text = "Mã sản phẩm đã tồn tại";
                        txtProductID.Text = string.Empty;
                    }
                }
                else
                {
                    SetUpdateInfo(objProduct, 1);
                    result = productBIZ.Update(objProduct);
                    txtImportPrice.Enabled = true;
                    txtExportPrice.Enabled = true;
                    drpCategory.Enabled = true;
                }

                clear();
                InitPage();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        #endregion

        #region .Method
        //Set info for Create and Update
        //Type 0: Create    Type 1: Update
        private void SetUpdateInfo(objProduct obj, int type)
        {

            if (type == 0)
            {
                obj.CreateDate = System.DateTime.Now;
                obj.CreateUser = (string)Session["EmployeeName"];
                obj.UpdateDate = System.DateTime.Now;
                obj.UpdateUser = "";
            }
            else
            {
                obj.UpdateDate = System.DateTime.Now;
                obj.UpdateUser = (string)Session["EmployeeName"];
            }
        }

        /// <summary>
        /// Load data to update
        /// </summary>
        /// <param name="productID"></param>
        private void LoadDataUpdate(string productID)
        {
            objProduct obj = new objProduct();
            obj = productBIZ.ShowByID(productID);
            txtProductID.Text = obj.ProductID;
            txtProductName.Text = obj.ProductName;
            txtImportPrice.Text = obj.ImportPrice.ToString();
            txtExportPrice.Text = obj.ExportPrice.ToString();
            drpCategory.SelectedValue = obj.Category.CategoryID.ToString();
            txtTemp.Text = obj.ProductID;

            //List<objColor> lstColor = new List<objColor>();
            //lstColor = productBIZ.ShowColorByProductID(productID);

            //txtColor1.Text = lstColor[0].ColorName.ToString();
            //txtColor2.Text = lstColor[1].ColorName.ToString();
            //txtColor3.Text = lstColor[2].ColorName.ToString();
            //txtColor4.Text = lstColor[3].ColorName.ToString();
            //txtColor5.Text = lstColor[4].ColorName.ToString();
            //txtColor6.Text = lstColor[5].ColorName.ToString();
            //txtColor7.Text = lstColor[6].ColorName.ToString();
            InitPage();
        }

        /// <summary>
        /// delete product
        /// </summary>
        /// <param name="productID"></param>
        private void DeleteProduct(string productID)
        {
            DateTime updateDate = DateTime.Now;
            string updateUser = (string)Session["EmployeeName"];
            productBIZ.Delete(productID, updateDate, updateUser, 1);
            InitPage();
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

        /// <summary>
        /// clear textbox
        /// </summary>
        private void clear()
        {
            txtTemp.Text = string.Empty;
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtImportPrice.Text = string.Empty;
            txtExportPrice.Text = string.Empty;
            Session["ListColor"] = null;
            //txtColor1.Text = string.Empty;
            //txtColor2.Text = string.Empty;
            //txtColor3.Text = string.Empty;
            //txtColor4.Text = string.Empty;
            //txtColor5.Text = string.Empty;
            //txtColor6.Text = string.Empty;
            //txtColor7.Text = string.Empty;
        }

        /// <summary>
        /// Check product id exist
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        private bool CheckProductID(string productID)
        {
            bool flag = true;
            flag = productBIZ.CheckProduct(productID);
            return flag;
        }

        #endregion

        public void GetColor()
        {
            if (Session["ListColor"] != null)
            {
                List<string> l = new List<string>();
                l = (List<string>)Session["ListColor"];
                bLstColor.DataSource = l;
                bLstColor.DataBind();
            }
        }
     
    }
}