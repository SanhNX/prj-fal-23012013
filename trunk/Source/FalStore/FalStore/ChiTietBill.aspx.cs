using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BIZ;
using Common;

namespace FalStore
{
    public partial class ChiTietBill : System.Web.UI.Page
    {
        BillBIZ billBIZ = new BillBIZ();
        ConvertMoneyString conV = new ConvertMoneyString();
        protected void Page_Load(object sender, EventArgs e)
        {
            string billID = HttpContext.Current.Request.QueryString["billID"];
            
            List<objBill> lstBill = billBIZ.GetBillByID(billID);

            foreach (objBill tem in lstBill) {
                Literal0.Text = tem.CustomerName.ToString();
                Literal1.Text = tem.EmployeeName.ToString();
                Literal2.Text = tem.CreateDate.ToString();
                Literal3.Text = tem.BranchName.ToString();
                Literal4.Text = conV.FloatToMoneyString(tem.TotalPrice.ToString("0")) + " VNĐ";
                Literal5.Text = tem.Sale.ToString() + " %";
                Literal6.Text = conV.FloatToMoneyString(tem.ActualTotalPrice.ToString("0")) + " VNĐ";
            }

            List<objBillDetail> lstBillDetail = billBIZ.GetBillDetailCtByID(billID, (int)Session["BranchID"]);

            if (lstBillDetail != null)
            {
                rptResult.DataSource = lstBillDetail;
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

                    objBillDetail data = e.Item.DataItem as objBillDetail;


                    if ("1".Equals(data.Delete_Flg.ToString()))
                    {
                        Literal ltrCss = e.Item.FindControl("ltrCss") as Literal;
                        ltrCss.Text = "style=\"background-color: rgba(19, 202, 218, 0.31);\"";
                    }
                    else
                    {
                        Literal ltrCss = e.Item.FindControl("ltrCss") as Literal;
                        ltrCss.Text = "";
                    }

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrMaVach = e.Item.FindControl("ltrMaVach") as Literal;
                    ltrMaVach.Text = data.BarCode.ToString();

                    Literal ltrTenSp = e.Item.FindControl("ltrTenSp") as Literal;
                    ltrTenSp.Text = data.ProductName.ToString();

                    Literal ltrGiaBan = e.Item.FindControl("ltrGiaBan") as Literal;
                    ltrGiaBan.Text = conV.FloatToMoneyString(data.ExportPrice.ToString("0"));

                    Literal ltrSoluong = e.Item.FindControl("ltrSoluong") as Literal;
                    ltrSoluong.Text = data.Quantity.ToString();

                    Literal ltrThanhTien = e.Item.FindControl("ltrThanhTien") as Literal;
                    ltrThanhTien.Text = conV.FloatToMoneyString(data.Amount.ToString("0"));

                    Literal ltrNhanVien = e.Item.FindControl("ltrNhanVien") as Literal;
                    ltrNhanVien.Text = data.CreateUser.ToString();

                    Literal ltrNgayBan = e.Item.FindControl("ltrNgayBan") as Literal;
                    ltrNgayBan.Text = data.CreateDate.ToString();

                    if ("1".Equals(data.Delete_Flg.ToString()))
                    {
                        Literal ltrCss = e.Item.FindControl("ltrCss") as Literal;
                        ltrCss.Text = "style=\"background-color: cyan;\"";
                       
                    }
                    else {
                        Literal ltrCss = e.Item.FindControl("ltrCss") as Literal;
                        ltrCss.Text = "";
                    }
                    
                    //Literal ltrNgayTra = e.Item.FindControl("ltrNgayTra") as Literal;
                    //ltrNgayTra.Text = data.UpdateDate.ToString();


                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}