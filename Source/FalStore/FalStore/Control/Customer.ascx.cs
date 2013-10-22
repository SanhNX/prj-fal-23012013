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
    public partial class Customer : System.Web.UI.UserControl
    {
        BranchBIZ branBiz = new BranchBIZ();
        CustomerBIZ cusBiz = new CustomerBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();

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

                //if (role() == 3)
                //{
                //    drpBranch.SelectedValue = Session["BranchID"].ToString();
                //    drpBranch.Enabled = false;
                //}
                //else
                //{
                //    drpBranch.Enabled = true;
                //}


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
                List<objCustomer> lstObj = new List<objCustomer>();

                lstObj = cusBiz.SearchCustomer(
                  int.Parse(txtPoint.Text == "" ? "0" : txtPoint.Text)
                  , int.Parse(drpBranch.SelectedValue.ToString())
                  , int.Parse(txtDiscount.Text == "" ? "0" : txtDiscount.Text)
                  , txtStartDate.Text, TxtEndDate.Text);
      
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
        int stt = 1;
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objCustomer data = e.Item.DataItem as objCustomer;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrCusName = e.Item.FindControl("ltrCusName") as Literal;
                    ltrCusName.Text = data.CustomerName.ToString();

                    Literal ltrCusPhone = e.Item.FindControl("ltrCusPhone") as Literal;
                    ltrCusPhone.Text = data.Phone.ToString();

                    Literal ltrCusMail = e.Item.FindControl("ltrCusMail") as Literal;
                    ltrCusMail.Text = data.Email.ToString();

                    Literal ltrBranchName = e.Item.FindControl("ltrBranchName") as Literal;
                    ltrBranchName.Text = data.BranchName.ToString();

                    Literal ltrCodeCus = e.Item.FindControl("ltrCodeCus") as Literal;
                    ltrCodeCus.Text = data.CodeCustomer.ToString();

                    Literal ltrSale = e.Item.FindControl("ltrSale") as Literal;
                    ltrSale.Text = data.DisCount.ToString();

                    if (!string.Empty.Equals(data.StartDiscount.ToString()))
                    {
                        Literal ltrStartDate = e.Item.FindControl("ltrStartDate") as Literal;
                        ltrStartDate.Text = data.StartDiscount.ToString();

                        Literal ltrEndDate = e.Item.FindControl("ltrEndDate") as Literal;
                        ltrEndDate.Text = data.EndDiscount.ToString();

                    }
                    else {
                        Literal ltrStartDate = e.Item.FindControl("ltrStartDate") as Literal;
                        ltrStartDate.Text = "0";

                        Literal ltrEndDate = e.Item.FindControl("ltrEndDate") as Literal;
                        ltrEndDate.Text = "0";
                    }


                    Literal ltrPoint = e.Item.FindControl("ltrPoint") as Literal;
                    ltrPoint.Text = data.Point.ToString();


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
            List<objCustomer> lstObj = new List<objCustomer>();

            lstObj = cusBiz.SearchCustomer(
                int.Parse(txtPoint.Text == "" ? "0" : txtPoint.Text)
                , int.Parse(drpBranch.SelectedValue.ToString())
                , int.Parse(txtDiscount.Text == "" ? "0" : txtDiscount.Text)
                , txtStartDate.Text, TxtEndDate.Text);

            DataTable tbl = new DataTable("Transactions");
            tbl.Columns.Add("STT", typeof(string));
            tbl.Columns.Add("NameCus", typeof(string));
            tbl.Columns.Add("Phone", typeof(string));
            tbl.Columns.Add("Email", typeof(string));
            tbl.Columns.Add("BranChName", typeof(string));
            tbl.Columns.Add("CodeCus", typeof(string));
            tbl.Columns.Add("Discount", typeof(string));
            tbl.Columns.Add("StartDiscount", typeof(string));
            tbl.Columns.Add("EndDiscount", typeof(string));
            tbl.Columns.Add("Point", typeof(string));

            DataRow dr;
            int indexStt = 1;
            foreach (var item in lstObj)
            {
                dr = tbl.NewRow();

                dr["STT"] = indexStt ;
                dr["NameCus"] = item.CustomerName.ToString();
                dr["Phone"] = item.Phone.ToString();
                dr["Email"] = item.Email.ToString();
                dr["BranChName"] = item.BranchName.ToString();
                dr["CodeCus"] = item.CodeCustomer.ToString();
                dr["Discount"] = item.DisCount.ToString() + " %";
                dr["StartDiscount"] = item.StartDiscount.ToString();
                dr["EndDiscount"] = item.EndDiscount.ToString();
                dr["Point"] = item.Point.ToString();

                indexStt++;

                tbl.Rows.Add(dr);
            }

            string fileName = "Customer" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

            string filePath = Server.MapPath("~/TemplateDocs/TemplateCustomer.xlsx");

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

                worker.FillData("Customer", dataTable);

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

        protected void btnDiscount_Click(object sender, EventArgs e) {

            try
            {

                string updateUser = (string)Session["EmployeeName"];

                int result = cusBiz.CheckDisCount(int.Parse(txtPoint.Text), int.Parse(drpBranch.SelectedValue.ToString()), 0, DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text), 5, updateUser);

                if (result > 0)
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Kiểm tra giảm giá thành công\"); <" + "/script>"));

                }
                else {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Kiểm tra giảm giá thất bại\"); <" + "/script>"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        
        
        }

        protected void btnDeleteDiscount_Click(object sender, EventArgs e)
        {

            try
            {

                string updateUser = (string)Session["EmployeeName"];

                int result = cusBiz.UpdateDisCountToZero(int.Parse(drpBranch.SelectedValue.ToString()), 0, updateUser);

                if (result > 0)
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Delete giảm giá thành công\"); <" + "/script>"));

                }
                else
                {
                    Page.Controls.Add(new LiteralControl("<script language='javascript'> window.alert(\"Delete giảm giá thất bại\"); <" + "/script>"));
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}