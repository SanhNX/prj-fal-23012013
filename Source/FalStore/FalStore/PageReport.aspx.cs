using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Entity;
using BIZ;
using System.Data;
using System.IO;
namespace FalStore
{
    public partial class PageReport : System.Web.UI.Page
    {
        LogStoreBIZ logBiz = new LogStoreBIZ();
        protected void Page_Load(object sender, EventArgs e)
        {
            //string storeID =  HttpContext.Current.Request.QueryString["id"];
            ////string storeID = "0000000004";
            //List<objLogDetail> lstLogDetail = new List<objLogDetail>();
            //DataTable tblLogDetail = new DataTable();
            //tblLogDetail.Columns.Add("STT", typeof(int));
            //tblLogDetail.Columns.Add("ProductID", typeof(string));
            //tblLogDetail.Columns.Add("ProductName", typeof(string));
            //tblLogDetail.Columns.Add("ColorName", typeof(string));
            //tblLogDetail.Columns.Add("Size", typeof(string));
            //tblLogDetail.Columns.Add("ExportPrice", typeof(float));
            //tblLogDetail.Columns.Add("Sale", typeof(float));
            //tblLogDetail.Columns.Add("Quantity", typeof(int));
            //tblLogDetail.Columns.Add("Amount", typeof(float));
            //tblLogDetail.Columns.Add("LogStoreID", typeof(string));
            //tblLogDetail.Columns.Add("EmployeeName", typeof(string));
            //tblLogDetail.Columns.Add("LogDate", typeof(string));
            //tblLogDetail.Columns.Add("BranchFrom", typeof(string));
            //tblLogDetail.Columns.Add("BranchTo", typeof(string));
            

            //DataRow row; 
            //int stt =1;
            //lstLogDetail = logBiz.ShowReport(storeID);
            //foreach (var item in lstLogDetail)
            //{
                
            //    row = tblLogDetail.NewRow();
            //    row["STT"] = stt;
            //    stt++;
            //    //item.BarCode = new objBarCode();
            //    //item.BarCode.Product = new objProduct();
            //    row["ProductID"] = item.BarCode.BarCode;
            //    row["ProductName"] = item.BarCode.Product.ProductName;
            //    row["ColorName"] = item.BarCode.ColorName;
            //    row["Size"] = item.BarCode.SizeName;
            //    row["ExportPrice"] = item.BarCode.Product.ExportPrice;
            //    row["Sale"] = item.Sale;
            //    row["Quantity"] = item.Quantity;
            //    row["Amount"] = item.Amount;

            //    row["LogStoreID"] = item.LogStore.LogStoreID;
            //    row["EmployeeName"] = item.LogStore.Employee.EmployeeName;
            //    row["LogDate"] = item.LogStore.LogDate;
            //    row["BranchFrom"] = item.LogStore.BranchFrom.BranchName;
            //    row["BranchTo"] = item.LogStore.BranchTo.BranchName;


            //    tblLogDetail.Rows.Add(row);
            //}
            
            //ReportDocument cryRpt = new ReportDocument();
            ////string file = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~"), "Report\\ReportExport.rpt");
            //string file = Server.MapPath("~/Report/ReportExport.rpt");
            //cryRpt.Load(file);
            //cryRpt.SetDataSource(tblLogDetail);
            //CrystalReportViewer1.ReportSource = cryRpt;
            //// crytalReportViewer.Refresh();

             //

            string storeID = HttpContext.Current.Request.QueryString["id"];
            //string storeID = "0000000004";
            List<objLogDetail> lstLogDetail = new List<objLogDetail>();
            lstLogDetail = logBiz.ShowReport2(storeID);

            if (lstLogDetail.Count > 0)
            {
                int check = 1;
                float total = 0;
                foreach (var item in lstLogDetail)
                {

                    if (check == 1)
                    {
                        Literal0.Text = item.LogStore.LogStoreID.ToString();

                        Literal1.Text = item.LogStore.LogDate.ToString();


                        Literal2.Text = item.LogStore.Employee.EmployeeName.ToString();


                        Literal3.Text = item.LogStore.NCC.ToString();

                        Literal4.Text = item.LogStore.BranchFrom.BranchName.ToString();
                    }

                    check++;


                    total = total + item.Amount ;

                }

                Literal5.Text = total.ToString("0.0") + " VNĐ";
               

                rptResult.DataSource = lstLogDetail;
                rptResult.DataBind();
            }
        }

        int stt = 1;
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objLogDetail data = e.Item.DataItem as objLogDetail;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrbarcode = e.Item.FindControl("ltrbarcode") as Literal;
                    ltrbarcode.Text = data.BarCode.BarCode.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.BarCode.Product.ProductName.ToString();

                    Literal ltrColor = e.Item.FindControl("ltrColor") as Literal;
                    ltrColor.Text = data.BarCode.ColorName.ToString();

                    Literal ltrSize = e.Item.FindControl("ltrSize") as Literal;
                    ltrSize.Text = data.BarCode.SizeName.ToString();

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = data.BarCode.Product.ImportPrice.ToString("0.0");

                    Literal ltrCk = e.Item.FindControl("ltrCk") as Literal;
                    ltrCk.Text = data.Sale.ToString();

                    Literal ltrSl = e.Item.FindControl("ltrSl") as Literal;
                    ltrSl.Text = data.Quantity.ToString();

                    Literal ltrAmount = e.Item.FindControl("ltrAmount") as Literal;
                    ltrAmount.Text = data.Amount.ToString("0.0");

                    

                }
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}