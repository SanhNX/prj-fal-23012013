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
    public partial class QuanLyNhapXuat : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        SearchNXBIZ searchNXBIZ = new SearchNXBIZ();

        // luu phiu nhap or xuat
        public string luuLoaiPhieu {get; set;}
    
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
        }

        protected void InitPage()
        {
            try
            {

                List<objBranch> lstBranch = new List<objBranch>();
                lstBranch = branBiz.ShowAll();
                drpBranch.DataSource = lstBranch;
                drpBranch.DataTextField = "BranchName";
                drpBranch.DataValueField = "BranchID";
                drpBranch.DataBind();

                List<objLoaiPhieu> objLp = new List<objLoaiPhieu>();
                objLoaiPhieu loaiPhieu = new objLoaiPhieu();
                loaiPhieu.TenPhieu = "Phiếu Nhập";
                loaiPhieu.PhieuID = 1;
                objLp.Add(loaiPhieu);
                objLoaiPhieu loaiPhieu1 = new objLoaiPhieu();
                loaiPhieu1.TenPhieu = "Phiếu Xuất";
                loaiPhieu1.PhieuID = 2;
                objLp.Add(loaiPhieu1);
                drpPhieu.DataSource = objLp;
                drpPhieu.DataTextField = "TenPhieu";
                drpPhieu.DataValueField = "PhieuID";
                drpPhieu.DataBind();


                ltrDoanhThu.Text = " ";
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["FirstName"] = drpPhieu.SelectedValue.ToString();
            try
            {
                List<objSearchNX> lstObj = new List<objSearchNX>();

                lstObj = searchNXBIZ.SearchNX(int.Parse(drpPhieu.SelectedValue.ToString()), drpBranch.SelectedItem.ToString(), drpPhieu.SelectedItem.ToString(), int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
                float tc = 0;
                if (lstObj != null)
                {
                    foreach (objSearchNX lst in lstObj)
                    {
                        tc = tc + lst.TotalAmount;
                    }

                    ltrDoanhThu.Text = "  Tổng Cộng " + drpPhieu.SelectedItem.ToString() + " Là " + tc.ToString("0.0") + "  VNĐ";

                    rptResult.DataSource = lstObj;
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
        int stt = 1;
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objSearchNX data = e.Item.DataItem as objSearchNX;

                    Literal ltrstt = e.Item.FindControl("ltrstt") as Literal;
                    ltrstt.Text = stt.ToString();
                    stt++;

                    Literal ltrLogID = e.Item.FindControl("ltrLogID") as Literal;
                    ltrLogID.Text = data.Log_StoreID.ToString();

                    Literal ltrLoai = e.Item.FindControl("ltrLoai") as Literal;
                    ltrLoai.Text = data.LoaiPhieu.ToString();

                    Literal ltrEmpName = e.Item.FindControl("ltrEmpName") as Literal;
                    ltrEmpName.Text = data.EmployeeName.ToString();

                    Literal ltrBranch1 = e.Item.FindControl("ltrBranch1") as Literal;
                    ltrBranch1.Text = data.BranchNameXuat.ToString();

                    Literal ltrBranch2 = e.Item.FindControl("ltrBranch2") as Literal;
                    ltrBranch2.Text = data.BranchNameNhap.ToString();

                    Literal ltrDate = e.Item.FindControl("ltrDate") as Literal;
                    ltrDate.Text = data.CreateDate.ToString();

                    Literal ltrPrice = e.Item.FindControl("ltrPrice") as Literal;
                    ltrPrice.Text = data.TotalAmount.ToString("0.0");

                    LinkButton lnkView = e.Item.FindControl("lnkView") as LinkButton;
                    lnkView.CommandArgument = data.Log_StoreID.ToString();

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void rptResult_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "View":
                        //LoadDataUpdate(int.Parse(e.CommandArgument.ToString()));
                        if ("1".Equals(Session["FirstName"]))
                        {
                            Response.Write("<script type='text/javascript'>window.open('PageReport2.aspx?id=" + e.CommandArgument.ToString() + "','_blank');</script>");
                        }

                        if ("2".Equals(Session["FirstName"]))
                        {
                            Response.Write("<script type='text/javascript'>window.open('PageReport.aspx?id=" + e.CommandArgument.ToString() + "','_blank');</script>");
                        }

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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<objSearchNX> lstObj = new List<objSearchNX>();

            lstObj = searchNXBIZ.SearchNX(int.Parse(drpPhieu.SelectedValue.ToString()), drpBranch.SelectedItem.ToString(), drpPhieu.SelectedItem.ToString(), int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

            DataTable tbl = new DataTable();
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("MaPhieu", typeof(string));
            tbl.Columns.Add("LoaiPhieu", typeof(string));
            tbl.Columns.Add("NhanVienLapPhieu", typeof(string));
            tbl.Columns.Add("XuatKho", typeof(string));
            tbl.Columns.Add("NhapKho", typeof(string));
            tbl.Columns.Add("NgayLapPhieu", typeof(string));
            tbl.Columns.Add("TongTienPhieu", typeof(string));

            DataRow dr;
            int stt2 = 1;
            foreach (var item in lstObj)
            {
                dr = tbl.NewRow();
                dr["STT"] = stt2.ToString();
                stt2++;
                dr["MaPhieu"] = "P" + item.Log_StoreID.ToString();
                dr["LoaiPhieu"] = item.LoaiPhieu.ToString();
                dr["NhanVienLapPhieu"] = item.EmployeeName.ToString();
                dr["XuatKho"] = item.BranchNameXuat.ToString();
                dr["NhapKho"] = item.BranchNameNhap.ToString();
                dr["NgayLapPhieu"] = item.CreateDate.ToString();
                dr["TongTienPhieu"] = item.TotalAmount.ToString("0");

                tbl.Rows.Add(dr);
            }

            string fileName = drpPhieu.SelectedItem.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateNhapXuat.xlsx");

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

    }
}