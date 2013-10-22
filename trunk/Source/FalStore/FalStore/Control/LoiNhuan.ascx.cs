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
using Common;

namespace FalStore.Control
{
    public partial class LoiNhuan : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        LogStoreBIZ logStoreBIZ = new LogStoreBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();
        SearchNXBIZ searchNXBIZ = new SearchNXBIZ();
        ExpensesBIZ expensesBIZ = new ExpensesBIZ();
        BillBIZ billBiz = new BillBIZ();
        // luu phiu nhap or xuat
        public string luuLoaiPhieu {get; set;}

        private int role()
        {
            int role = -1;
            if (Session["Role"] != null)
            {
                role = (int)Session["Role"];
            }
            return role;
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            cpNhaphang.Text = "0";
            doanhthu.Text = "0";
            cpKinhDoanh.Text = "0";
            tongln.Text = "0";
            tongln.Text = "0";
            eDate.Text = "0";
            eDate1.Text = "0";
            eDate2.Text = "0";
            eDate3.Text = "0";
            sDate.Text = "0";
            sDate1.Text = "0";
            sDate2.Text = "0";
            sDate3.Text = "0";
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

                if (role() == 3)
                {
                    drpBranch.SelectedValue = Session["BranchID"].ToString();
                    drpBranch.Enabled = false;
                }
                else
                {
                    drpBranch.Enabled = true;
                }

                if ((int)Session["Role"] == 1)
                {
                    Button5.Enabled = true;
                    Button6.Enabled = true;
                }
                else {
                    Button5.Enabled = false;
                    Button6.Enabled = false;
                }

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
                float totalAmountLogBill = 0;

                float totalAmountLogStore = logStoreBIZ.SumTotalAmountLogStore(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

                if ("12".Equals(drpBranch.SelectedValue.ToString()))
                {
                    totalAmountLogBill = logStoreBIZ.SumTotalAmountLogStoreXuat(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
                    nameTc.Text = "Tổng Cộng Doanh Thu Xuất Kho Từ";
                }
                else {
                     totalAmountLogBill = logStoreBIZ.SumTotalAmountLogBill(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
                     nameTc.Text = "Tổng Cộng Doanh Thu Từ";
                }


                

                float totalAmountLogExpenses = logStoreBIZ.SumTotalAmountLogExpenses(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

                cpNhaphang.Text = conV.FloatToMoneyString(totalAmountLogStore.ToString("0"));
                doanhthu.Text = conV.FloatToMoneyString(totalAmountLogBill.ToString("0"));
                cpKinhDoanh.Text = conV.FloatToMoneyString(totalAmountLogExpenses.ToString("0"));

                float loiNhuan = totalAmountLogBill - (totalAmountLogStore + totalAmountLogExpenses);

                tongln.Text = conV.FloatToMoneyString(loiNhuan.ToString("0"));

                eDate.Text = TxtEndDate.Text;
                eDate1.Text = TxtEndDate.Text;
                eDate2.Text = TxtEndDate.Text;
                eDate3.Text = TxtEndDate.Text;
                sDate.Text = txtStartDate.Text;
                sDate1.Text = txtStartDate.Text;
                sDate2.Text = txtStartDate.Text;
                sDate3.Text = txtStartDate.Text;

                // xuat chi tiet excel chi phi nhap hang cua chi nhanh 
               // ExportPhieuNhap();
               

            }
            catch (Exception)
            {

                throw;
            }


        }


        // Xuat phieu nhap hang tu kho tong 
        protected void btnPn_Click(object sender, EventArgs e)
        {
            List<objSearchNX> lstObj = new List<objSearchNX>();

            lstObj = searchNXBIZ.SearchNX(1, drpBranch.SelectedItem.ToString(), "Phiếu Nhập", int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

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
                dr["TongTienPhieu"] = conV.FloatToMoneyString(item.TotalAmount.ToString("0"));

                tbl.Rows.Add(dr);
            }

            string fileName = "Phiếu Nhập" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateNhapXuat.xlsx");

            GenerateExcelFile(tbl, filePath, fileName, "thanh");
        }

        // Xuat chi tiet phieu nhap
        protected void btnCtPn_Click(object sender, EventArgs e)
        {
            List<objSearchDetailNX> lstObj = new List<objSearchDetailNX>();

            lstObj = searchNXBIZ.SearchDetailNX(1, int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

            DataTable tbl = new DataTable();
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("MaPhieu", typeof(string));
            tbl.Columns.Add("ChiNhanh", typeof(string));
            tbl.Columns.Add("CreateDate", typeof(string));
            tbl.Columns.Add("TotalAmount", typeof(string));
            tbl.Columns.Add("BarCode", typeof(string));
            tbl.Columns.Add("ProductID", typeof(string));
            tbl.Columns.Add("ProductName", typeof(string));
            tbl.Columns.Add("ColorName", typeof(string));
            tbl.Columns.Add("SizeName", typeof(string));
            tbl.Columns.Add("Price", typeof(string));
            tbl.Columns.Add("Sale", typeof(string));
            tbl.Columns.Add("Quantity", typeof(string));
            tbl.Columns.Add("Amount", typeof(string));

            DataRow dr;
            int stt2 = 1;
            foreach (var item in lstObj)
            {
                dr = tbl.NewRow();
                dr["STT"] = stt2.ToString();
                stt2++;
                dr["MaPhieu"] = "P" + item.Log_StoreID.ToString();
                dr["CreateDate"] = item.CreateDate;
                dr["TotalAmount"] = conV.FloatToMoneyString(item.TotalAmount);
                dr["BarCode"] = item.BarCode.ToString();
                dr["ProductID"] = item.ProductID.ToString();
                dr["ProductName"] = item.ProductName.ToString();
                dr["ColorName"] = item.ColorName;
                dr["SizeName"] = item.SizeName.ToString();
                dr["ChiNhanh"] = "Nhập Vào " + item.BranchName.ToString();
                //if ("1".Equals(drpPhieu.SelectedValue.ToString()))
                //{
                // nhap vào kho tổng thì giá khac , nhap vào kho chi nhanh thì giá khac
                //  12 là id cua kho tong
                if ("12".Equals(item.BranchTo.ToString()))
                {
                    dr["Price"] = item.ImportPrice.ToString();
                }
                else
                {
                    dr["Price"] = item.ExportPrice.ToString();
                }

                //}
                //else
                //{
                //    dr["Price"] = item.ExportPrice.ToString();
                //}

                dr["Sale"] = item.Sale.ToString();
                dr["Quantity"] = item.Quantity.ToString();
                dr["Amount"] = conV.FloatToMoneyString(item.Amount);

                tbl.Rows.Add(dr);
            }

            string fileName = "ChiTiếtPhiếuNhập" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateNhapXuatDetail.xlsx");

            GenerateExcelFile(tbl, filePath, fileName, "ChiTiet2");

            // doanh thu
            //DoanhThu();

        }

        // Xuat phieu xuat hang tu kho tong 
        protected void btnPx_Click(object sender, EventArgs e)
        {
            List<objSearchNX> lstObj = new List<objSearchNX>();

            lstObj = searchNXBIZ.SearchNX(2, drpBranch.SelectedItem.ToString(), "Phiếu Xuất", int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

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
                dr["TongTienPhieu"] = conV.FloatToMoneyString(item.TotalAmount.ToString("0"));

                tbl.Rows.Add(dr);
            }

            string fileName = "Phiếu Xuất" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateNhapXuat.xlsx");

            GenerateExcelFile(tbl, filePath, fileName, "thanh");
        }

        // Xuat chi tiet phieu xuat
        protected void btnCtPx_Click(object sender, EventArgs e)
        {
            List<objSearchDetailNX> lstObj = new List<objSearchDetailNX>();

            lstObj = searchNXBIZ.SearchDetailNX(2, int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

            DataTable tbl = new DataTable();
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("MaPhieu", typeof(string));
            tbl.Columns.Add("ChiNhanh", typeof(string));
            tbl.Columns.Add("CreateDate", typeof(string));
            tbl.Columns.Add("TotalAmount", typeof(string));
            tbl.Columns.Add("BarCode", typeof(string));
            tbl.Columns.Add("ProductID", typeof(string));
            tbl.Columns.Add("ProductName", typeof(string));
            tbl.Columns.Add("ColorName", typeof(string));
            tbl.Columns.Add("SizeName", typeof(string));
            tbl.Columns.Add("Price", typeof(string));
            tbl.Columns.Add("Sale", typeof(string));
            tbl.Columns.Add("Quantity", typeof(string));
            tbl.Columns.Add("Amount", typeof(string));

            DataRow dr;
            int stt2 = 1;
            foreach (var item in lstObj)
            {
                dr = tbl.NewRow();
                dr["STT"] = stt2.ToString();
                stt2++;
                dr["MaPhieu"] = "P" + item.Log_StoreID.ToString();
                dr["CreateDate"] = item.CreateDate;
                dr["TotalAmount"] = conV.FloatToMoneyString(item.TotalAmount);
                dr["BarCode"] = item.BarCode.ToString();
                dr["ProductID"] = item.ProductID.ToString();
                dr["ProductName"] = item.ProductName.ToString();
                dr["ColorName"] = item.ColorName;
                dr["SizeName"] = item.SizeName.ToString();

                //if ("1".Equals(drpPhieu.SelectedValue.ToString()))
                //{
                // nhap vào kho tổng thì giá khac , nhap vào kho chi nhanh thì giá khac
                //  12 là id cua kho tong
                if ("12".Equals(item.BranchTo.ToString()))
                {
                    dr["Price"] = item.ImportPrice.ToString();
                }
                else
                {
                    dr["Price"] = item.ExportPrice.ToString();
                }

                dr["ChiNhanh"] = "Xuất Đến " + item.BranchName.ToString();
                //}
                //else
                //{
                //    dr["Price"] = item.ExportPrice.ToString();
                //}

                dr["Sale"] = item.Sale.ToString();
                dr["Quantity"] = item.Quantity.ToString();
                dr["Amount"] = conV.FloatToMoneyString(item.Amount);

                tbl.Rows.Add(dr);
            }

            string fileName = "ChiTiếtPhiếuXuất" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateNhapXuatDetail.xlsx");

            GenerateExcelFile(tbl, filePath, fileName, "ChiTiet2");

            // doanh thu
            //DoanhThu();

        }


        // Xuất Tong doanh thu 

        protected void btnDt_Click(object sender, EventArgs e)
        {

            List<objDoanhThu> lstObj = new List<objDoanhThu>();

            lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

            DataTable tbl = new DataTable("Transactions");
            tbl.Columns.Add("MaHD", typeof(string));
            tbl.Columns.Add("NhanVien", typeof(string));
            tbl.Columns.Add("KhachHang", typeof(string));
            tbl.Columns.Add("ChiNhanh", typeof(string));
            tbl.Columns.Add("NgayLap", typeof(string));
            tbl.Columns.Add("ThanhTien", typeof(string));
            tbl.Columns.Add("GiamGia", typeof(string));
            tbl.Columns.Add("TongTien", typeof(string));

            DataRow dr;
            foreach (var item in lstObj)
            {
                dr = tbl.NewRow();
                dr["MaHD"] = "P" + item.BillID.ToString();
                dr["NhanVien"] = item.EmployeeName.ToString();
                dr["KhachHang"] = item.CustomerName.ToString();
                dr["ChiNhanh"] = item.BranchName.ToString();
                dr["NgayLap"] = item.CreateDate.ToLongDateString();
                dr["ThanhTien"] = conV.FloatToMoneyString(item.TotalPrice.ToString("0"));
                dr["GiamGia"] = item.Sale.ToString();
                dr["TongTien"] = conV.FloatToMoneyString(item.ActualTotalPrice.ToString("0"));

                tbl.Rows.Add(dr);
            }

            string fileName = "DoanhThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateDoanhThu.xlsx");

            GenerateExcelFile(tbl, filePath, fileName, "thanh");
        }


        protected void btnCpKd_Click(object sender, EventArgs e)
        {
            List<objExpenses> lstExpenses = new List<objExpenses>();

            lstExpenses = expensesBIZ.ExpensesSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

            DataTable tbl = new DataTable("Transactions");
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("ChiNhanh", typeof(string));
            tbl.Columns.Add("MoTa", typeof(string));
            tbl.Columns.Add("TongTien", typeof(string));
            tbl.Columns.Add("NgayLap", typeof(string));
            tbl.Columns.Add("NguoiLap", typeof(string));

            DataRow dr;
            int stt = 1;
            foreach (var item in lstExpenses)
            {
                dr = tbl.NewRow();
                dr["STT"] = stt;
                stt++;
                dr["ChiNhanh"] = item.BranchName.ToString();
                dr["MoTa"] = item.Description.ToString();
                dr["TongTien"] = conV.FloatToMoneyString(item.Amount.ToString("0"));
                dr["NgayLap"] = item.CreateDate.ToLongDateString();
                dr["NguoiLap"] = item.CreateUser.ToString();

                tbl.Rows.Add(dr);
            }

            string fileName = "TemplateChiPhiKinhDoanh" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateChiPhiKinhDoanh.xlsx");

            GenerateExcelFile(tbl, filePath, fileName, "ChiPhiKinhDoanh");
        }

        public void GenerateExcelFile(DataTable dataTable, string directoryTemplate, string fileName, string defindName)
        {
            using (SpreadsheetWorker worker = new SpreadsheetWorker())
            {

                //string filePath = Server.MapPath("~/TemplateDocs/TemplateDocument.xlsx");
                worker.Open(directoryTemplate);

                // string outputFileName = "GeneratedDocument.xlsx";

                //DataTable dataTable = GetTransactionDataTable();

                worker.FillData(defindName, dataTable);

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