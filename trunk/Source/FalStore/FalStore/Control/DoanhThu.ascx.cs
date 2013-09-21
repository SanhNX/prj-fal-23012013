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
namespace FalStore.Control
{
    public partial class DoanhThu : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        BillBIZ billBiz = new BillBIZ();
       
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

                    objDoanhThu data = e.Item.DataItem as objDoanhThu;

                    //Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    //ltrStt.Text = stt.ToString();
                    //stt++;

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
                    ltrSale.Text = data.Sale.ToString();

                    Literal ltrPrice2 = e.Item.FindControl("ltrPrice2") as Literal;
                    ltrPrice2.Text = data.ActualTotalPrice.ToString();

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
                dr["MaHD"] = item.BillID.ToString();
                dr["NhanVien"] = item.EmployeeName.ToString();
                dr["KhachHang"] = item.CustomerName.ToString();
                dr["ChiNhanh"] = item.BranchName.ToString();
                dr["NgayLap"] = item.CreateDate.ToLongDateString();
                dr["ThanhTien"] = item.TotalPrice.ToString();
                dr["GiamGia"] = item.Sale.ToString();
                dr["TongTien"] = item.ActualTotalPrice.ToString();

                tbl.Rows.Add(dr);
            }

            GenerateExcelFile(tbl, @"D:\demo123.xlsx");
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

            var columns = dataTable.Columns.Count;
            var rows = dataTable.Rows.Count;

            Excel.Range range = worksheet.Range["A1", String.Format("{0}{1}", GetExcelColumnName(columns), rows)];

            object[,] data = new object[rows,columns];

            for (int rowNumber = 0; rowNumber < rows; rowNumber++)
            {
                for (int columnNumber = 0; columnNumber < columns; columnNumber++)
                {
                    data[rowNumber, columnNumber] = dataTable.Rows[rowNumber][columnNumber].ToString();
                }
            }

            range.Value = data;

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