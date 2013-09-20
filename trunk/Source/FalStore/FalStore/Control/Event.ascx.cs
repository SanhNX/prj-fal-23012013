using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BIZ;
using Entity;

namespace FalStore.Control
{
    public partial class Event : System.Web.UI.UserControl
    {

        BranchBIZ branBiz = new BranchBIZ();

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
            //try
            //{
            //    List<objDoanhThu> lstObj = new List<objDoanhThu>();

            //    lstObj = billBiz.GetBillSearch(int.Parse(drpBranch.SelectedValue.ToString()), DateTime.Parse(txtStartDate.Text), DateTime.Parse(TxtEndDate.Text));
            //    if (lstObj != null)
            //    {
            //        rptResult.DataSource = lstObj;
            //        rptResult.DataBind();
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


        }
    }
}