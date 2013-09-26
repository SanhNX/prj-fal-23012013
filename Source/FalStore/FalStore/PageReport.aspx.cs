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
namespace FalStore
{
    public partial class PageReport : System.Web.UI.Page
    {
        LogStoreBIZ logBiz = new LogStoreBIZ();
        protected void Page_Load(object sender, EventArgs e)
        {
            string storeID =  HttpContext.Current.Request.QueryString["id"];
            //string storeID = "0000000004";
            List<objLogDetail> lstLogDetail = new List<objLogDetail>();
            DataTable tblLogDetail = new DataTable();
            tblLogDetail.Columns.Add("STT", typeof(int));
            tblLogDetail.Columns.Add("ProductID", typeof(string));
            tblLogDetail.Columns.Add("ProductName", typeof(string));
            tblLogDetail.Columns.Add("ColorName", typeof(string));
            tblLogDetail.Columns.Add("Size", typeof(string));
            tblLogDetail.Columns.Add("ExportPrice", typeof(float));
            tblLogDetail.Columns.Add("Sale", typeof(float));
            tblLogDetail.Columns.Add("Quantity", typeof(int));
            tblLogDetail.Columns.Add("Amount", typeof(float));
            tblLogDetail.Columns.Add("LogStoreID", typeof(string));
            tblLogDetail.Columns.Add("EmployeeName", typeof(string));
            tblLogDetail.Columns.Add("LogDate", typeof(string));
            tblLogDetail.Columns.Add("BranchFrom", typeof(string));
            tblLogDetail.Columns.Add("BranchTo", typeof(string));
            

            DataRow row; 
            int stt =1;
            lstLogDetail = logBiz.ShowReport(storeID);
            foreach (var item in lstLogDetail)
            {
                
                row = tblLogDetail.NewRow();
                row["STT"] = stt;
                stt++;
                //item.BarCode = new objBarCode();
                //item.BarCode.Product = new objProduct();
                row["ProductID"] = item.BarCode.BarCode;
                row["ProductName"] = item.BarCode.Product.ProductName;
                row["ColorName"] = item.BarCode.ColorName;
                row["Size"] = item.BarCode.SizeName;
                row["ExportPrice"] = item.BarCode.Product.ExportPrice;
                row["Sale"] = item.Sale;
                row["Quantity"] = item.Quantity;
                row["Amount"] = item.Amount;

                row["LogStoreID"] = item.LogStore.LogStoreID;
                row["EmployeeName"] = item.LogStore.Employee.EmployeeName;
                row["LogDate"] = item.LogStore.LogDate;
                row["BranchFrom"] = item.LogStore.BranchFrom.BranchName;
                row["BranchTo"] = item.LogStore.BranchTo.BranchName;


                tblLogDetail.Rows.Add(row);
            }
            
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Server.MapPath(@"~\Report\ReportExport.rpt"));
            cryRpt.SetDataSource(tblLogDetail);
            CrystalReportViewer1.ReportSource = cryRpt;
            // crytalReportViewer.Refresh();
        }
    }
}