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
    public partial class NhapXuatDetail : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        SearchNXBIZ searchNXBIZ = new SearchNXBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();

        // luu phiu nhap or xuat
        public string luuLoaiPhieu { get; set; }

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
            //Session["FirstName"] = drpPhieu.SelectedValue.ToString();
            try
            {
                List<objSearchDetailNX> lstObj = new List<objSearchDetailNX>();

                lstObj = searchNXBIZ.SearchDetailNX(int.Parse(drpPhieu.SelectedValue.ToString()), int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
                float tc = 0;
                if (lstObj != null)
                {
                    foreach (objSearchDetailNX lst in lstObj)
                    {
                        tc = tc + float.Parse(lst.Amount);
                    }

                    ltrDoanhThu.Text = "  Tổng Cộng " + drpPhieu.SelectedItem.ToString() + " Là " + conV.FloatToMoneyString(tc.ToString("0")) + "  VNĐ";

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

                    objSearchDetailNX data = e.Item.DataItem as objSearchDetailNX;

                    Literal ltrstt = e.Item.FindControl("ltrstt") as Literal;
                    ltrstt.Text = stt.ToString();
                    stt++;

                    //Literal ltrDate = e.Item.FindControl("ltrDate") as Literal;
                    //ltrDate.Text = data.CreateDate.ToString();

                    Literal ltrLogID = e.Item.FindControl("ltrLogID") as Literal;
                    ltrLogID.Text = data.Log_StoreID.ToString();

                    Literal ltrBarCode = e.Item.FindControl("ltrBarCode") as Literal;
                    ltrBarCode.Text = data.BarCode.ToString();

                    Literal ltrProID = e.Item.FindControl("ltrProID") as Literal;
                    ltrProID.Text = data.ProductID.ToString();

                    Literal ltrProName = e.Item.FindControl("ltrProName") as Literal;
                    ltrProName.Text = data.ProductName.ToString();

                    Literal ltrColor = e.Item.FindControl("ltrColor") as Literal;
                    ltrColor.Text = data.ColorName.ToString();

                     Literal ltrSize = e.Item.FindControl("ltrSize") as Literal;
                    ltrSize.Text = data.SizeName.ToString();

                    if ("1".Equals(drpPhieu.SelectedValue.ToString()))
                    {
                        // nhap vào kho tổng thì giá khac , nhap vào kho chi nhanh thì giá khac
                        //  12 là id cua kho tong
                        if ("12".Equals(data.BranchTo.ToString()))
                        {
                            Literal ltrPrice = e.Item.FindControl("ltrPrice") as Literal;
                            ltrPrice.Text = conV.FloatToMoneyString(data.ImportPrice);
                        }
                        else
                        {
                            Literal ltrPrice = e.Item.FindControl("ltrPrice") as Literal;
                            ltrPrice.Text = conV.FloatToMoneyString(data.ExportPrice);
                        }

                    }
                    else {
                        Literal ltrPrice = e.Item.FindControl("ltrPrice") as Literal;
                        ltrPrice.Text = conV.FloatToMoneyString(data.ExportPrice);
                    }


                    Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                    ltrSale.Text = data.Sale;

                    Literal LitSl = e.Item.FindControl("LitSl") as Literal;
                    LitSl.Text = data.Quantity;


                    Literal LitTotalAmount = e.Item.FindControl("LitTotalAmount") as Literal;
                    LitTotalAmount.Text = conV.FloatToMoneyString(data.Amount);


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //protected void rptResult_ItemCommand(object sender, RepeaterCommandEventArgs e)
        //{
        //    try
        //    {
        //        switch (e.CommandName)
        //        {
        //            case "View":
        //                //LoadDataUpdate(int.Parse(e.CommandArgument.ToString()));
        //                if ("1".Equals(Session["FirstName"]))
        //                {
        //                    Response.Write("<script type='text/javascript'>window.open('PageReport.aspx?id=" + e.CommandArgument.ToString() + "','_blank');</script>");
        //                }

        //                if ("2".Equals(Session["FirstName"]))
        //                {
        //                    Response.Write("<script type='text/javascript'>window.open('PageReport2.aspx?id=" + e.CommandArgument.ToString() + "','_blank');</script>");
        //                }

        //                break;
        //            case "Delete":
        //                // DeleteCategory(int.Parse(e.CommandArgument.ToString()));
        //                break;

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        protected void btnExport_Click(object sender, EventArgs e)
        {
            List<objSearchDetailNX> lstObj = new List<objSearchDetailNX>();

            lstObj = searchNXBIZ.SearchDetailNX(int.Parse(drpPhieu.SelectedValue.ToString()), int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));

            DataTable tbl = new DataTable();
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("MaPhieu", typeof(string));
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
                if ("1".Equals(drpPhieu.SelectedValue.ToString()))
                {
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

                }
                else
                {
                    dr["Price"] = item.ExportPrice.ToString();
                }
                
                dr["Sale"] = item.Sale.ToString();
                dr["Quantity"] = item.Quantity.ToString();
                dr["Amount"] = conV.FloatToMoneyString(item.Amount);

                tbl.Rows.Add(dr);
            }

            string fileName ="ChiTiet"+ drpPhieu.SelectedItem.ToString() + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateNhapXuatDetail.xlsx");

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

                worker.FillData("chitiet", dataTable);

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