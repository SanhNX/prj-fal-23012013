using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalStore.Control
{
    public partial class leftmenu : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.hypCategory.HRef = "~/Default.aspx?pageName=Category";
                this.hypProduct.HRef = "~/Default.aspx?pageName=Product";
                this.hypEmployee.HRef = "~/Default.aspx?pageName=Employee";
                //this.hypUser.HRef = "~/Default.aspx?pageName=User";
                this.hypBranch.HRef = "~/Default.aspx?pageName=Branch";
                this.hypDoanhThu.HRef = "~/Default.aspx?pageName=DoanhThu";
                this.hypReceipt.HRef = "~/Default.aspx?pageName=Receipt";
                this.hypStore.HRef = "~/Default.aspx?pageName=Store";
                this.hypExportProduct.HRef = "~/Default.aspx?pageName=ExportProduct";
                this.hypEvent.HRef = "~/Default.aspx?pageName=Event";
                this.hypThongKe.HRef = "~/Default.aspx?pageName=ThongKe";
                this.hypChiPhi.HRef = "~/Default.aspx?pageName=ChiPhi";
                this.hypNhapXuat.HRef = "~/Default.aspx?pageName=NhapXuat";
                this.hypLoiNhuan.HRef = "~/Default.aspx?pageName=LoiNhuan";
                this.hypSearchProduct.HRef = "~/Default.aspx?pageName=SearchProduct";
                this.hypNhapXuatDetail.HRef = "~/Default.aspx?pageName=NhapXuatDetail";
                this.hypCustomer.HRef = "~/Default.aspx?pageName=Customer";
                
            }
          
        }
    }
}