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
    public partial class DoanhThu : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        BillBIZ billBiz = new BillBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();
       
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

                    ltrDoanhThu.Text = conV.FloatToMoneyString(tc.ToString("0")) + "  VNĐ";
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
                    ltrPrice1.Text = conV.FloatToMoneyString(data.TotalPrice.ToString("0"));

                    Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                    ltrSale.Text = data.Sale.ToString() + "%";

                    Literal ltrPrice2 = e.Item.FindControl("ltrPrice2") as Literal;
                    ltrPrice2.Text = conV.FloatToMoneyString(data.ActualTotalPrice.ToString("0"));


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