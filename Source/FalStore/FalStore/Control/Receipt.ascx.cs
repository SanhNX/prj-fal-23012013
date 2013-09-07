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
                objLogDetail obj = new objLogDetail();
                obj.Product = new objProduct();
                obj.Product.ProductID = txtProductID.Text;
                obj.Color = new objColor();
                obj.Color.ColorID = int.Parse(drpColor.SelectedValue.ToString());
                obj.LogStore = new objLogStore();
                obj.LogStore.LogStoreID = txtLogStoreID.Text;
                obj.Size = drpSize.SelectedItem.ToString();
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

                logBiz.InsertLogDetail(obj);

                BindRepeater();
                ClearProductInfo();

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
                objLgStore.Employee.EmployeeID = int.Parse(drpEmployee.SelectedValue.ToString());
                objLgStore.LogDate = txtLogDate.Text;
                objLgStore.BranchFrom = new objBranch();
                objLgStore.BranchFrom.BranchID = 0;
                objLgStore.BranchTo = new objBranch();
                objLgStore.BranchTo.BranchID = int.Parse(drpBranchTo.SelectedValue.ToString());
                objLgStore.NCC = txtNcc.Text;
                objLgStore.Description = txtDescription.Text;
                SetUpdateInfo(objLgStore, 0);
                logBiz.InsertlogStore(objLgStore, 0);
                //InitPage();
                ClearLogStoreInfo();
                ShowControl(false);

                List<objLogDetail> lstObjDetail = new List<objLogDetail>();
                lstObjDetail = logBiz.ShowLogDetailByID(objLgStore.LogStoreID,0);
                ExportTapp(lstObjDetail);
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
        protected void txtProductID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadProductByID(txtProductID.Text);
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
                    ltrProductID.Text = data.Product.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.Product.ProductName.ToString();

                    Literal ltrColor = e.Item.FindControl("ltrColor") as Literal;
                    ltrColor.Text = data.Color.ColorName.ToString();

                    Literal ltrSize = e.Item.FindControl("ltrSize") as Literal;
                    ltrSize.Text = data.Size.ToString();

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = data.Product.ExportPrice.ToString(); ;

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
            List<objLogDetail> lstLogDetail = new List<objLogDetail>();
            lstLogDetail = logBiz.ShowLogDetailByID(txtLogStoreID.Text,1);
            if (lstLogDetail != null)
            {
                rptResult.DataSource = lstLogDetail;
                rptResult.DataBind();
            }
        }

        /// <summary>
        /// load product
        /// </summary>
        /// <param name="productID"></param>
        private void LoadProductByID(string productID)
        {
            objProduct objPro = new objProduct();
            List<objColor> lstObjCol = new List<objColor>();
            objPro = proBiz.ShowByID(productID);
            if (objPro != null)
            {
                txtProductName.Text = objPro.ProductName;
                txtExportPrice.Text = objPro.ExportPrice.ToString();
                drpColor.Enabled = true;
                lstObjCol = proBiz.ShowColorByProductID(productID);
                drpColor.DataSource = lstObjCol;
                drpColor.DataTextField = "ColorName";
                drpColor.DataValueField = "ColorID";
                drpColor.DataBind();

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
            txtProductID.Enabled = flag;
            txtSale.Enabled = flag;
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
            txtProductID.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtSale.Text = string.Empty;
            txtExportPrice.Text = string.Empty;
        }

        /// <summary>
        /// clear control log
        /// </summary>
        private void ClearLogStoreInfo()
        {
            txtLogStoreID.Text = string.Empty;
            txtNcc.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void ExportTapp(List<objLogDetail> lstObjLogDetail)
        {
            //Tạo các đối tượng application, document, table của MS Word
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc;
            Microsoft.Office.Interop.Word.Table table;

            //Hiện (mở) ứng dụng word
            app.Visible = true;

            //Tham số truyền vào các hàm có đối là tuỳ chọn
            object obj = Type.Missing;
            object oTrue = true;
            object oFalse = false;

            //Tạo một tài liệu mới (để chứa dữ liệu xuất ra)
            doc = app.Documents.Add(ref obj, ref  obj, ref obj, ref  obj);
            Microsoft.Office.Interop.Word.Range range = doc.Range(ref obj, ref obj);

            //EMBEDDING LOGOS IN THE DOCUMENT
            //SETTING FOCUES ON THE PAGE HEADER TO EMBED THE WATERMARK
            app.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekCurrentPageHeader;

            //THE LOGO IS ASSIGNED TO A SHAPE OBJECT SO THAT WE CAN USE ALL THE
            //SHAPE FORMATTING OPTIONS PRESENT FOR THE SHAPE OBJECT
            Microsoft.Office.Interop.Word.Shape logoCustom = null;

            //THE PATH OF THE LOGO FILE TO BE EMBEDDED IN THE HEADER
            String logoPath = "C:\\Users\\DUONG\\Desktop\\Image\\banner_Falshop.png";
            logoCustom = app.Selection.HeaderFooter.Shapes.AddPicture(logoPath,
                ref oFalse, ref oTrue, ref obj, ref obj, ref obj, ref obj, ref obj);

            logoCustom.Select(ref obj);
            logoCustom.Name = "CustomLogo";
            logoCustom.Left = (float)Microsoft.Office.Interop.Word.WdShapePosition.wdShapeLeft;

            //SETTING FOCUES BACK TO DOCUMENT
            app.ActiveWindow.ActivePane.View.SeekView = Microsoft.Office.Interop.Word.WdSeekView.wdSeekMainDocument;

            //INSERTING TEXT IN THE CENTRE RIGHT, TILTED AT 90 DEGREES
            Microsoft.Office.Interop.Word.Shape midRightText =null;
            midRightText = app.Selection.HeaderFooter.Shapes.AddTextEffect(
                Microsoft.Office.Core.MsoPresetTextEffect.msoTextEffect1,
                "Text Goes Here", "Arial", (float)10,
                Microsoft.Office.Core.MsoTriState.msoTrue,
                Microsoft.Office.Core.MsoTriState.msoFalse,
                0, 0, ref obj);

            //FORMATTING THE SECURITY CLASSIFICATION TEXT
            midRightText.Select(ref obj);
            midRightText.Name = "PowerPlusWaterMarkObject2";
            midRightText.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
            midRightText.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
            midRightText.Fill.Solid();
            midRightText.Fill.ForeColor.RGB = (int)Microsoft.Office.Interop.Word.WdColor.wdColorGray375;

            //MAKING THE TEXT VERTICAL & ALIGNING
            //midRightText.Rotation = (float)90;
            //midRightText.RelativeHorizontalPosition =
            //    Word.WdRelativeHorizontalPosition.wdRelativeHorizontalPositionMargin;
            //midRightText.RelativeVerticalPosition =
            //    Word.WdRelativeVerticalPosition.wdRelativeVerticalPositionMargin;
            //midRightText.Top = (float)Word.WdShapePosition.wdShapeCenter;
            //midRightText.Left = (float)480;
        

            //Thêm một bảng có 2 cột và số hàng bằng với số hàng trong datatable.
            table = doc.Tables.Add(range, lstObjLogDetail.Count, 8, ref obj, ref obj);

            //Xuất dữ liệu từ datatable sang bảng (trong word). Chú ý: đối với các đối tượng tập hợp
            // trong word thì phần tử đầu tiên có chỉ số là 1 thay vì 0 như trong C#
            for (int i = 0; i < lstObjLogDetail.Count; i++)
            {
                doc.Tables[1].Rows[i + 1].Cells[1].Range.Text = lstObjLogDetail[i].Product.ProductID;
                doc.Tables[1].Rows[i + 1].Cells[2].Range.Text = lstObjLogDetail[i].Product.ProductName;
                doc.Tables[1].Rows[i + 1].Cells[3].Range.Text = lstObjLogDetail[i].Color.ColorName;
                doc.Tables[1].Rows[i + 1].Cells[4].Range.Text = lstObjLogDetail[i].Size;
                doc.Tables[1].Rows[i + 1].Cells[5].Range.Text = lstObjLogDetail[i].Product.ExportPrice.ToString();
                doc.Tables[1].Rows[i + 1].Cells[6].Range.Text = lstObjLogDetail[i].Quantity.ToString();
                doc.Tables[1].Rows[i + 1].Cells[7].Range.Text = lstObjLogDetail[i].Sale.ToString();
                doc.Tables[1].Rows[i + 1].Cells[8].Range.Text = lstObjLogDetail[i].Amount.ToString();

            }
            //Thêm đường viền cho Table nếu cần.
            doc.Select();
            Microsoft.Office.Interop.Word.WdLineStyle BorderValue = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            app.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderTop].LineStyle = BorderValue;
            app.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderBottom].LineStyle = BorderValue;
            app.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderLeft].LineStyle = BorderValue;
            app.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderRight].LineStyle = BorderValue;
            app.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderVertical].LineStyle = BorderValue;
            app.Selection.Borders[Microsoft.Office.Interop.Word.WdBorderType.wdBorderHorizontal].LineStyle = BorderValue;

        }
        #endregion
    }
}