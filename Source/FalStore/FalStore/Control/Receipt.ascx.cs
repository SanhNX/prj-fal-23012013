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
    public partial class Receipt : System.Web.UI.UserControl
    {
        List<objLogDetail> lstObjLogDetail = new List<objLogDetail>();
        
        LogStoreBIZ logBiz = new LogStoreBIZ();
        EmployeeBIZ empBiz = new EmployeeBIZ();
        BranchBIZ branBiz = new BranchBIZ();
        ProductBIZ proBiz = new ProductBIZ();
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
            // }
        }

        /// <summary>
        /// initial page
        /// </summary>
        protected void InitPage()
        {
            List<objEmployee> lstEmployee = new List<objEmployee>();
            lstEmployee = empBiz.ShowAll();
            drpEmployee.DataSource = lstEmployee;
            drpEmployee.DataTextField = "EmployeeName";
            drpEmployee.DataValueField = "EmployeeID";
            drpEmployee.DataBind();

            List<objBranch> lstBranch = new List<objBranch>();
            lstBranch = branBiz.ShowAll();
            drpBranchTo.DataSource = lstBranch;
            drpBranchTo.DataTextField = "BranchName";
            drpBranchTo.DataValueField = "BranchID";
            drpBranchTo.DataBind();
        }
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            objLogDetail obj = new objLogDetail();
            obj.Product = new objProduct();
            obj.Product.ProductID = txtProductID.Text;
            obj.Color = new objColor();
            obj.Color.ColorID = int.Parse(drpColor.SelectedValue.ToString());
            obj.LogStore = new objLogStore();
            obj.LogStore.LogStoreID = txtLogStoreID.Text;
            obj.Size = drpSize.SelectedItem.ToString();
            obj.ExportPrice = float.Parse(lblExportPrice.Text);
            obj.Sale = float.Parse(txtSale.Text);
            obj.Quantity = int.Parse(txtQuantity.Text);
            obj.Amount =(obj.ExportPrice - (obj.ExportPrice / obj.Sale)) * obj.Quantity;

            lstObjLogDetail.Add(obj);

            rptResult.DataSource = lstObjLogDetail;
            rptResult.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            int result;
            objLogStore objLgStore = new objLogStore();
            objLgStore.LogStoreID = txtLogStoreID.Text;
            objLgStore.LogType = 1;
            objLgStore.Employee.EmployeeID =int.Parse( drpEmployee.SelectedValue.ToString());
            objLgStore.LogDate = txtLogDate.Text;
            objLgStore.BranchTo.BranchID = int.Parse(drpBranchTo.SelectedValue.ToString());
            objLgStore.NCC = txtNcc.Text;
            objLgStore.Description = txtDescription.Text;

            result = logBiz.InsertlogStore(objLgStore, lstObjLogDetail);

         
            if (result == 1)
            {
                lblMessage.Text = "Thực thi thành công";
            }
            else
            {
                lblMessage.Text = "Thực thi thất bại";
            }
            //InitPage();
            //clear();
        }

        protected void txtProductID_TextChanged(object sender, EventArgs e)
        {
            LoadProductByID(txtProductID.Text);
        }

        private void LoadProductByID(string productID)
        {
            objProduct objPro = new objProduct();
            List<objColor> lstObjCol = new List<objColor>();
            objPro = proBiz.ShowByID(productID);
            if (objPro != null)
            {
                lblProductName.Text = objPro.ProductName;
                lblExportPrice.Text = objPro.ExportPrice.ToString();
                drpColor.Enabled = true;
                lstObjCol = proBiz.ShowColorByProductID(productID);
                drpColor.DataSource = lstObjCol;
                drpColor.DataTextField = "ColorName";
                drpColor.DataValueField = "ColorID";
                drpColor.DataBind();

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

                objLogDetail data = e.Item.DataItem as objLogDetail;

              
                Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                ltrProductID.Text = data.Product.ProductID.ToString();

                Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
             //   ltrProductName.Text = data.Product.ProductName.ToString();

                Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                ltrExportPrice.Text = data.ExportPrice.ToString(); ;

                Literal ltrQuantity = e.Item.FindControl("ltrQuantity") as Literal;
                ltrQuantity.Text = data.Quantity.ToString();

                Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                ltrSale.Text = data.Sale.ToString();

                Literal ltrAmount = e.Item.FindControl("ltrAmount") as Literal;
                ltrAmount.Text = data.Amount.ToString();
            }
        }

    }
}