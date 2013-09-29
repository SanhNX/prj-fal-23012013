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
    public partial class DoanhThu : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        BillBIZ billBiz = new BillBIZ();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            InitPage();
            ltrDoanhThu.Text = "0  VNĐ";
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
                List<objDoanhThu> lstObj = new List<objDoanhThu>();

                lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
                  float tc = 0;
                if (lstObj != null)
                {
                    foreach (objDoanhThu objItem in lstObj)
                    {
                        tc = tc + objItem.ActualTotalPrice;
                    }

                    ltrDoanhThu.Text = tc.ToString() + "  VNĐ";
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

                    objDoanhThu data = e.Item.DataItem as objDoanhThu;

                    if ("1".Equals(data.Update_Flg.ToString()))
                    {
                        Literal ltrCss = e.Item.FindControl("ltrCss") as Literal;
                        ltrCss.Text = "style=\"background-color: rgba(19, 202, 218, 0.31);\"";
                    }
                    else {
                        Literal ltrCss = e.Item.FindControl("ltrCss") as Literal;
                        ltrCss.Text = "";
                    }



                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;
                    
                    Literal ltrBillId = e.Item.FindControl("ltrBillId") as Literal;
                    ltrBillId.Text = data.BillID.ToString();

                    Literal ltrEmpName = e.Item.FindControl("ltrEmpName") as Literal;
                    ltrEmpName.Text = data.EmployeeName.ToString();

                    Literal ltrCusName = e.Item.FindControl("ltrCusName") as Literal;
                    ltrCusName.Text = data.CustomerName.ToString();

                    Literal ltrBranchName = e.Item.FindControl("ltrBranchName") as Literal;
                    ltrBranchName.Text = data.BranchName.ToString();

                    Literal ltrDate = e.Item.FindControl("ltrDate") as Literal;
                    ltrDate.Text = data.CreateDate.ToString();

                    Literal ltrPrice1 = e.Item.FindControl("ltrPrice1") as Literal;
                    ltrPrice1.Text = data.TotalPrice.ToString();

                    Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                    ltrSale.Text = data.Sale.ToString() + "%";

                    Literal ltrPrice2 = e.Item.FindControl("ltrPrice2") as Literal;
                    ltrPrice2.Text = data.ActualTotalPrice.ToString();


                    Literal ltrLink = e.Item.FindControl("ltrLink") as Literal;
                    ltrLink.Text = "ChiTietBill.aspx?billID=" + data.BillID.ToString();


                    Literal ltrLinkEdit = e.Item.FindControl("ltrLinkEdit") as Literal;
                    ltrLinkEdit.Text = "sales.aspx?billID=" + data.BillID.ToString();
                    //LinkButton lnkDelete = e.Item.FindControl("lnkDelete") as LinkButton;
                    //lnkDelete.CommandArgument = data.CategoryID.ToString();

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
                        //LoadDataUpdate(int.Parse(e.CommandArgument.ToString()));
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
            List<objDoanhThu> lstObj = new List<objDoanhThu>();

            lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
 
            DataTable tbl = new DataTable();
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
                dr["ThanhTien"] = item.TotalPrice.ToString();
                dr["GiamGia"] = item.Sale.ToString();
                dr["TongTien"] = item.ActualTotalPrice.ToString();

                tbl.Rows.Add(dr);
            }

            string fileName = "DoanhThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";
            string file = Server.MapPath("~/FileExport/" + fileName);//Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~"),"FileExport\\" + fileName);
            //string abc = "D:\\df.xlsx";
            GenerateExcelFile(tbl, file);
            FileInfo fileReport = new FileInfo(file);
           // Response.Redirect(file);

           // Response.Write("<script type='text/javascript'>window.open("+file+",'_blank');</script>");

            //string aaa = Server.MapPath("~/FileExport/DoanhThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            //Response.TransmitFile(Server.MapPath("~/FileExport/DoanhThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx"));
            //Response.End();

           // Response.Redirect("~/FileExport/DoanhThu" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
            Response.Clear();

            Response.ClearHeaders();

            Response.ClearContent();

            Response.AddHeader("Content-Disposition", "attachment; filename=" + fileReport.Name);

            Response.AddHeader("Content-Length", fileReport.Length.ToString());

            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            Response.Flush();

            Response.TransmitFile(fileReport.FullName);

            Response.End();
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

            object[,] data = new object[rows,columns];
            

            data[0,0] = "MaHD";
            data[0, 1] = "NhanVien";
            data[0, 2] = "KhachHang";
            data[0, 3] = "ChiNhanh";
            data[0, 4] = "NgayLap";
            data[0, 5] = "ThanhTien";
            data[0, 6] = "GiamGia";
            data[0, 7] = "TongTien";

            for(int rowNumber = 1; rowNumber < rows; rowNumber++)
            {
                for (int columnNumber = 1; columnNumber < columns; columnNumber++)
                {
                    data[rowNumber, columnNumber- 1] = dataTable.Rows[rowNumber-1][columnNumber-1].ToString();
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