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
        LogStoreBIZ logBiz = new LogStoreBIZ();
        EmployeeBIZ empBiz = new EmployeeBIZ();
        BranchBIZ branBiz = new BranchBIZ();
        ProductBIZ proBiz = new ProductBIZ();

        #region .Event
        /// <summary>
        /// page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitPage();
                //lstObjLogDetail = new List<objLogDetail>();
                ShowControl(false);
                txtLogDate.Text = DateTime.Now.Date.ToShortDateString();
            }

        }

        /// <summary>
        /// initial page
        /// </summary>
        protected void InitPage()
        {
            try
            {

                List<objBranch> lstBranch = new List<objBranch>();
                lstBranch = branBiz.ShowAll();
                drpBranchTo.DataSource = lstBranch;
                drpBranchTo.DataTextField = "BranchName";
                drpBranchTo.DataValueField = "BranchID";
                drpBranchTo.DataBind();

                BindRepeater();
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// event add product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text != string.Empty)
                {
                    objLogDetail obj = new objLogDetail();
                    obj.BarCode = new objBarCode();
                    obj.BarCode.BarCode = txtBarCode.Text;
                    obj.LogStore = new objLogStore();
                    obj.LogStore.LogStoreID = txtLogStoreID.Text;
                    // obj.Size = drpSize.SelectedItem.ToString();
                    float exportPrice = float.Parse(txtExportPrice.Text);
                    obj.Sale = float.Parse(txtSale.Text);
                    obj.Quantity = int.Parse(txtQuantity.Text);
                    if (obj.Sale != 0)
                    {
                        obj.Amount = (exportPrice - (exportPrice / obj.Sale)) * obj.Quantity;
                    }
                    else
                    {
                        obj.Amount = exportPrice * obj.Quantity;
                    }

                    logBiz.InsertLogDetail(obj, 0);

                    BindRepeater();
                    ClearProductInfo();
                }
                else
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Vui lòng nhập thông tin sản phẩm\"); <" + "/script>"));
                    return;

                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// event add log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                objLogStore objLgStore = new objLogStore();
                objLgStore.LogStoreID = txtLogStoreID.Text;
                objLgStore.LogType = 0;
                objLgStore.Employee = new objEmployee();
                objLgStore.Employee.EmployeeID = 1;
                objLgStore.LogDate = txtLogDate.Text;
                objLgStore.BranchFrom = new objBranch();
                objLgStore.BranchFrom.BranchID = 0;
                objLgStore.BranchTo = new objBranch();
                objLgStore.BranchTo.BranchID = int.Parse(drpBranchTo.SelectedValue.ToString());
                objLgStore.NCC = txtNcc.Text;
                objLgStore.Description = txtDescription.Text;
                objLgStore.TotalAmount = float.Parse(txtTotal.Text);

                SetUpdateInfo(objLgStore, 0);
                logBiz.InsertlogStore(objLgStore,0, 0);
                //InitPage();
                BindRepeater();
                ClearLogStoreInfo();
                ShowControl(false);

                Response.Write("<script type='text/javascript'>window.open('PageReport2.aspx?id=" + txtLogStoreID.Text + "','_blank');</script>");

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// event load product
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadProductByBarCode(txtBarCode.Text);
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

                    objLogDetail data = e.Item.DataItem as objLogDetail;


                    Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                    ltrProductID.Text = data.BarCode.Product.ProductID;

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.BarCode.Product.ProductName;

                    Literal ltrColor = e.Item.FindControl("ltrColor") as Literal;
                    ltrColor.Text = data.BarCode.ColorName;

                    Literal ltrSize = e.Item.FindControl("ltrSize") as Literal;
                    ltrSize.Text = data.BarCode.SizeName;

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = data.BarCode.Product.ExportPrice.ToString();

                    Literal ltrQuantity = e.Item.FindControl("ltrQuantity") as Literal;
                    ltrQuantity.Text = data.Quantity.ToString();

                    Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                    ltrSale.Text = data.Sale.ToString();

                    Literal ltrAmount = e.Item.FindControl("ltrAmount") as Literal;
                    ltrAmount.Text = data.Amount.ToString();
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
                if (e.CommandName == "Delete")
                {
                    logBiz.DeleteLogDetail(int.Parse(e.CommandArgument.ToString()));
                    BindRepeater();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// event create log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                string id = logBiz.NewLogStoreID();
                txtLogStoreID.Text = id;
                ShowControl(true);
                BindRepeater();
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region .Method
        /// <summary>
        /// bind repeater
        /// </summary>
        private void BindRepeater()
        {
            float total;
            List<objLogDetail> lstLogDetail = new List<objLogDetail>();
            lstLogDetail = logBiz.ShowLogDetailByID(txtLogStoreID.Text,0, 1, out total);
            if (lstLogDetail != null)
            {
                rptResult.DataSource = lstLogDetail;
                rptResult.DataBind();
                txtTotal.Text = total.ToString();
            }
        }

        /// <summary>
        /// load product
        /// </summary>
        /// <param name="productID"></param>
        private void LoadProductByBarCode(string barCode)
        {
            objBarCode objBar = new objBarCode();
            //List<objColor> lstObjCol = new List<objColor>();
            objBar = proBiz.ShowProductByBarCode(barCode);
            if (objBar != null)
            {
                txtProductName.Text = objBar.Product.ProductName;
                txtExportPrice.Text = objBar.Product.ImportPrice.ToString();
                txtColor.Text = objBar.ColorName;
                txtSize.Text = objBar.SizeName;
                //lstObjCol = proBiz.ShowColorByProductID(productID);
                //drpColor.DataSource = lstObjCol;
                //drpColor.DataTextField = "ColorName";
                //drpColor.DataValueField = "ColorID";
                //drpColor.DataBind();

            }

        }

        /// <summary>
        /// show control
        /// </summary>
        /// <param name="flag"></param>
        private void ShowControl(bool flag)
        {
            // txtLogStoreID.Enabled = flag;
            //txtLogDate.Enabled = flag;
            txtNcc.Enabled = flag;
            txtDescription.Enabled = flag;
            txtBarCode.Enabled = flag;
            //txtColor.Enabled = flag;
            //txtSize.Enabled = flag;
            //txtSale.Enabled = flag;
            txtQuantity.Enabled = flag;
            btnAddProduct.Enabled = flag;
            btnAdd.Enabled = flag;
            btnCreate.Enabled = !flag;
        }

        /// <summary>
        /// Set info for Create and Update
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type">Type 0: Create    Type 1: Update</param>
        private static void SetUpdateInfo(objLogStore obj, int type)
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

        /// <summary>
        /// clear control product
        /// </summary>
        private void ClearProductInfo()
        {
            txtBarCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = "1";
            txtSale.Text = "0";
            txtExportPrice.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtSize.Text = string.Empty;
        }

        /// <summary>
        /// clear control log
        /// </summary>
        private void ClearLogStoreInfo()
        {
            // txtLogStoreID.Text = string.Empty;
            txtNcc.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }


        #endregion

    }
}