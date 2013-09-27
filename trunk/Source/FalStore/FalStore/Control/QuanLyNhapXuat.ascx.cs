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

                    ltrDoanhThu.Text = "  Tổng Cộng " + drpPhieu.SelectedItem.ToString() + " Là " + tc.ToString() + "  VNĐ";

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
                    ltrPrice.Text = data.TotalAmount.ToString();

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
                dr["TongTienPhieu"] = item.TotalAmount.ToString();

                tbl.Rows.Add(dr);
            }
            string file = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~"), "FileExport\\ThongKeNX" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            // string abc = @"D:\DoanhThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            GenerateExcelFile(tbl, file);

            Response.Redirect(file);
        }

        public void GenerateExcelFile(DataTable dataTable, string directory)
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];

            //DataTable dataTable = new DataTable();
            //DataColumn column = new DataColumn("My Datacolumn");

            //dataTable.Columns.Add(column);
            //dataTable.Rows.Add(new object[] {"Foobar"});

            var columns = dataTable.Columns.Count + 1;
            var rows = dataTable.Rows.Count + 1;

            Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];

            object[,] data = new object[rows, columns];


            data[0, 0] = "STT";
            data[0, 1] = "Mã Phiếu";
            data[0, 2] = "Loại Phiếu";
            data[0, 3] = "Nhân Viên Lập Phiếu";
            data[0, 4] = "Xuất Kho";
            data[0, 5] = " Nhập Kho";
            data[0, 6] = "Ngày Lập Phiếu";
            data[0, 7] = "Tổng Tiền Phiếu";

            for (int rowNumber = 1; rowNumber < rows; rowNumber++)
            {
                for (int columnNumber = 1; columnNumber < columns; columnNumber++)
                {
                    data[rowNumber, columnNumber - 1] = dataTable.Rows[rowNumber - 1][columnNumber - 1].ToString();
                }
            }

            range.Value = data;




            range = worksheet.get_Range("A1", "A1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("B1", "B1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("C1", "C1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("D1", "D1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("E1", "E1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("F1", "F1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("G1", "G1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;

            range = worksheet.get_Range("H1", "H1");
            range.Interior.Color = System.Drawing.Color.Gray.ToArgb();
            range.Borders.Color = System.Drawing.Color.Black.ToArgb();
            range.Font.Bold = true;


            workbook.SaveAs(directory);
            workbook.Close();
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

    }
}