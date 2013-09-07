using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace FalStore
{
    public partial class PageReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Server.MapPath(@"~\Report\ReportExport.rpt"));
            CrystalReportViewer1.ReportSource = cryRpt;
            // crytalReportViewer.Refresh();
        }
    }
}