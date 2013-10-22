﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using BIZ;
using Entity;
using System.Data;
using Common;

namespace FalStore.Control
{
    public partial class SearchProduct : System.Web.UI.UserControl
    {
        #region .Property
        ProductBIZ productBIZ = new ProductBIZ();
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();
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

                List<objLoaiPhieu> lstLoai = new List<objLoaiPhieu>();
                objLoaiPhieu loai1 = new objLoaiPhieu();
                objLoaiPhieu loai2 = new objLoaiPhieu();
                loai1.TenPhieu = "Đã Xóa";
                loai1.PhieuID = 1;
                loai2.TenPhieu = "Chưa Xóa";
                loai2.PhieuID = 0;
                lstLoai.Add(loai1);
                lstLoai.Add(loai2);
                drpDelete.DataSource = lstLoai;
                drpDelete.DataTextField = "TenPhieu";
                drpDelete.DataValueField = "PhieuID";
                drpDelete.DataBind();


                List<objBarCode> lst = new List<objBarCode>();
                lst = productBIZ.Search(txtProductID.Text, txtProductName.Text, int.Parse(drpCategory.SelectedValue.ToString()), int.Parse(drpDelete.SelectedValue.ToString()));

                if (lst != null)
                {
                    rptResult.DataSource = lst;
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

                    objBarCode data = e.Item.DataItem as objBarCode;

                    //Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    //ltrStt.Text = stt.ToString();
                    //stt++;

                    Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                    ltrProductID.Text = data.Product.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.Product.ProductName.ToString();

                    Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                    ltrCategoryName.Text = data.Product.Category.CategoryName.ToString();

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = conV.FloatToMoneyString(data.Product.ExportPrice.ToString("0"));

                    Literal ltrImportPrice = e.Item.FindControl("ltrImportPrice") as Literal;
                    ltrImportPrice.Text = conV.FloatToMoneyString(data.Product.ImportPrice.ToString("0"));

                    Literal ltrColorName = e.Item.FindControl("ltrColorName") as Literal;
                    ltrColorName.Text = data.ColorName.ToString();

                    Literal ltrSizeName = e.Item.FindControl("ltrSizeName") as Literal;
                    ltrSizeName.Text = data.SizeName.ToString();

                    Literal ltrBarCode = e.Item.FindControl("ltrBarCode") as Literal;
                    ltrBarCode.Text = data.BarCode.ToString();

                    if ("0".Equals(data.Product.Delete_Flg))
                    {

                        LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                        lnkDelete.CommandName = "Delete";

                        Literal deleteName = e.Item.FindControl("deleteName") as Literal;
                        deleteName.Text = "Xóa";
                        
                    }
                    else {
                        LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                        lnkDelete.CommandName = "UnDelete";

                        Literal deleteName = e.Item.FindControl("deleteName") as Literal;
                        deleteName.Text = "Không Xóa";
                    }

                    

                    //Literal ltrValue = e.Item.FindControl("ltrValue") as Literal;
                    //ltrValue.Text = data.BarCode.ToString() + "=" + data.Product.ProductName.ToString() + "=" + data.Product.ImportPrice.ToString("0.") + "=" + data.Product.ExportPrice.ToString() + "=" + data.ColorName.ToString() + "=" + data.SizeName.ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            List<objBarCode> lst = new List<objBarCode>();
            lst = productBIZ.Search(txtProductID.Text, txtProductName.Text, int.Parse(drpCategory.SelectedValue.ToString()), int.Parse(drpDelete.SelectedValue.ToString()));

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
                switch (e.CommandName)
                {
                    case "UnDelete":
                        DeleteProduct(e.CommandArgument.ToString(), 0);
                        break;
                    case "Delete":
                        DeleteProduct(e.CommandArgument.ToString(), 1);
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

        private void DeleteProduct(string productID, int DeleteFlg)
        {
            DateTime updateDate = DateTime.Now;
            string updateUser = (string)Session["EmployeeName"];
            productBIZ.Delete(productID, updateDate, updateUser, DeleteFlg);
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
    }
}