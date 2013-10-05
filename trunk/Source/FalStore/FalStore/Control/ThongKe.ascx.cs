using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Entity;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using OpenXml.Sandpit.FormattedExcel.Library;


namespace FalStore.Control
{
    public partial class ThongKe : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        CategoryBIZ categoryBIZ = new CategoryBIZ();
        ReportBillDetailBIZ reportBillDetailBIZ = new ReportBillDetailBIZ();

        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        protected void InitPage()
        {
            try
            {
                objBranch objb = new objBranch();
                objb.BranchName = "Tất Cả";
                objb.BranchID = 0;
                List<objBranch> lstBranch = new List<objBranch>();
                lstBranch = branBiz.ShowAll();
                lstBranch.Add(objb);
                drpBranch.DataSource = lstBranch;
                drpBranch.DataTextField = "BranchName";
                drpBranch.DataValueField = "BranchID";
                drpBranch.DataBind();


                objCategory objc = new objCategory();
                objc.CategoryName = "Tất Cả";
                objc.CategoryID = 0;
                List<objCategory> lstCategory = new List<objCategory>();
                lstCategory = categoryBIZ.ShowAll();
                lstCategory.Add(objc);
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<objReportBillDetail> lstObj = new List<objReportBillDetail>();

                lstObj = reportBillDetailBIZ.GetBillDetailSearch(
                    int.Parse(drpBranch.SelectedValue.ToString()), int.Parse(drpCategory.SelectedValue.ToString()), txtTenSanPham.Text, txtProductID.Text, DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
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
        int stt = 1;
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objReportBillDetail data = e.Item.DataItem as objReportBillDetail;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrBarCode = e.Item.FindControl("ltrBarCode") as Literal;
                    ltrBarCode.Text = data.BarCode.ToString();

                    Literal ltrProductID = e.Item.FindControl("ltrProductID") as Literal;
                    ltrProductID.Text = data.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.ProductName.ToString();

                    Literal ltrColorName = e.Item.FindControl("ltrColorName") as Literal;
                    ltrColorName.Text = data.ColorName.ToString();

                    Literal ltrSizeName = e.Item.FindControl("ltrSizeName") as Literal;
                    ltrSizeName.Text = data.SizeName.ToString();

                    Literal ltrQuantity = e.Item.FindControl("ltrQuantity") as Literal;
                    ltrQuantity.Text = data.Quantity.ToString();

                    Literal ltrCategoryName = e.Item.FindControl("ltrCategoryName") as Literal;
                    ltrCategoryName.Text = data.CategoryName.ToString();

                    //LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                    //lnkDelete.CommandArgument = data.CategoryID.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<objReportBillDetail> lstObj = new List<objReportBillDetail>();
            try
            {
                lstObj = reportBillDetailBIZ.GetBillDetailSearch(
                    int.Parse(drpBranch.SelectedValue.ToString()), int.Parse(drpCategory.SelectedValue.ToString()), txtTenSanPham.Text, txtProductID.Text, DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
            }
            catch (Exception)
            {

                throw;
            }

            DataTable tbl = new DataTable();
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("BarCode", typeof(string));
            tbl.Columns.Add("MaSanPham", typeof(string));
            tbl.Columns.Add("TenSanPham", typeof(string));
            tbl.Columns.Add("MauSanPham", typeof(string));
            tbl.Columns.Add("Size", typeof(string));
            tbl.Columns.Add("SoLuongBan", typeof(string));
            tbl.Columns.Add("loaiSanPham", typeof(string));

            DataRow dr;

            int stt1 = 1;
            foreach (var item in lstObj)
            {
                dr = tbl.NewRow();
                dr["STT"] = stt1.ToString();
                dr["BarCode"] = item.BarCode.ToString();
                dr["MaSanPham"] = item.ProductID.ToString();
                dr["TenSanPham"] = item.ProductName.ToString();
                dr["MauSanPham"] = item.ColorName.ToString();
                dr["Size"] = item.SizeName.ToString();
                dr["SoLuongBan"] = item.Quantity.ToString();
                dr["loaiSanPham"] = item.CategoryName.ToString();

                tbl.Rows.Add(dr);

                stt1++;
            }

            string fileName = "ThongKe" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateThongKe.xlsx");

            GenerateExcelFile(tbl, filePath, fileName);
        }

        public void GenerateExcelFile(DataTable dataTable, string directoryTemplate, string fileName)
        {
            using (SpreadsheetWorker worker = new SpreadsheetWorker())
            {

                //string filePath = Server.MapPath("~/TemplateDocs/TemplateDocument.xlsx");
                worker.Open(directoryTemplate);

                // string outputFileName = "GeneratedDocument.xlsx";

                //DataTable dataTable = GetTransactionDataTable();

                worker.FillData("thanh", dataTable);

                byte[] outputFileBytes = worker.SaveAs();
                worker.Close();

                Response.ClearHeaders();
                Response.ClearContent();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
                Response.BinaryWrite(outputFileBytes);
                Response.Flush();
                Response.End();
            }
        }

        //public void GenerateExcelFile(DataTable dataTable, string directory)
        //{
        //    Excel.Application application = new Excel.Application();
        //    Excel.Workbook workbook = application.Workbooks.Add();
        //    Excel.Worksheet worksheet = workbook.Sheets[1];

        //    //DataTable dataTable = new DataTable();
        //    //DataColumn column = new DataColumn("My Datacolumn");

        //    //dataTable.Columns.Add(column);
        //    //dataTable.Rows.Add(new object[] {"Foobar"});

        //    var columns = dataTable.Columns.Count + 1;
        //    var rows = dataTable.Rows.Count + 1;

        //    Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];

        //    object[,] data = new object[rows, columns];


        //    data[0, 0] = "STT";
        //    data[0, 1] = "Bar Code";
        //    data[0, 2] = "Mã Sản Phẩm";
        //    data[0, 3] = "Tên Sản Phẩm";
        //    data[0, 4] = "Màu Sản Phẩm";
        //    data[0, 5] = "Size";
        //    data[0, 6] = "Số lượng Bán";
        //    data[0, 7] = "Loại Sản Phẩm";

        //    for (int rowNumber = 1; rowNumber < rows; rowNumber++)
        //    {
        //        for (int columnNumber = 1; columnNumber < columns; columnNumber++)
        //        {
        //            data[rowNumber, columnNumber - 1] = dataTable.Rows[rowNumber - 1][columnNumber - 1].ToString();
        //        }
        //    }

        //    range.Value = data;




        //    range = worksheet.get_Range("A1", "A1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("B1", "B1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("C1", "C1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("D1", "D1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("E1", "E1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("F1", "F1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("G1", "G1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;

        //    range = worksheet.get_Range("H1", "H1");
        //    range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
        //    range.Borders.Color = System.Drawing.Color.Black.ToArgb();
        //    range.Font.Bold = true;



        //    //SaveFileDialog exportSaveFileDialog = new SaveFileDialog();
            
        //    //    exportSaveFileDialog.Title = "Select Excel File";
        //    //    exportSaveFileDialog.Filter = "Microsoft Office Excel Workbook(*.xlsx)|*.xlsx";

        //    //    if (DialogResult.OK == exportSaveFileDialog.ShowDialog())
        //    //    {
        //    //        string fullFileName = exportSaveFileDialog.FileName;
        //    //        // currentWorkbook.SaveCopyAs(fullFileName);
        //    //        // indicating that we already saved the workbook, otherwise call to Quit() will pop up
        //    //        // the save file dialogue box

        //    //        currentWorkbook.SaveAs(fullFileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, System.Reflection.Missing.Value, Missing.Value, false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlUserResolution, true, Missing.Value, Missing.Value, Missing.Value);
        //    //        currentWorkbook.Saved = true;
        //    //        MessageBox.Show("Error memory exported successfully", "Exported to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    }
            



        //    workbook.SaveAs(directory);
        //    workbook.Close();
        //}

        //private static string GetExcelColumnName(int columnNumber)
        //{
        //    int dividend = columnNumber;
        //    string columnName = String.Empty;
        //    int modulo;

        //    while (dividend > 0)
        //    {
        //        modulo = (dividend - 1) % 26;
        //        columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
        //        dividend = (int)((dividend - modulo) / 26);
        //    }

        //    return columnName;
        //}
    }
}