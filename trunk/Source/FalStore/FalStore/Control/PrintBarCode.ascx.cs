using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FalStore.Common;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using BIZ;
using Entity;
using System.Data;
using System.Drawing.Printing;
using System.Drawing.Text;

namespace FalStore.Control
{
    public partial class PrintBarCode : System.Web.UI.UserControl
    {
        ProductBIZ proBiz = new ProductBIZ();

        BarCodeBIZ barBiz = new BarCodeBIZ();
        List<objFindBarCode> lstObj = new List<objFindBarCode>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = HttpContext.Current.Request.QueryString["id"];

            if (!string.Empty.Equals(id)) {
                try
                {
                    

                    lstObj = barBiz.GetBarCodeByProductID(id);

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
            



            //txtBarCode.Text = id;
            //txtBarCode_TextChanged(sender, e);


            //string file = HttpContext.Current.Server.MapPath("Font\\s128ah.TTF");
            //txtBarCode.Text = file;
        }

        protected void ClickShow_Click(object sender, EventArgs e)
        {

            // Session["prstr"] = TextBox1.Text;


            // Page.ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Common/PrintProduct.aspx','PrintMe','height=300px,width=300px,scrollbars=1');</script>");
            //System.Web.UI.Control ctrl = (System.Web.UI.Control)Session["ctrl"];
            //PrintHelper.PrintWebControl(Panel1);

            DrawBarcode(txtBarCode.Text);
        }

        private void DrawBarcode(string productcode)
        {
            #region
            //int w = productcode.Length * 60;
            //Bitmap onBitmap = new Bitmap(w, 100);
            //MemoryStream stream = new MemoryStream();
            //Graphics onGraphics = Graphics.FromImage(onBitmap);


            //Font font = new Font("Tahoma", 4);

            //PointF oPoint = new PointF(2f, 2f);
            //SolidBrush oBrushWrite = new SolidBrush(Color.Black);
            //SolidBrush oBrush = new SolidBrush(Color.White);

            //onGraphics.FillRectangle(oBrush, 0, 0, w, 100);

            //onGraphics.DrawString(productcode, font, oBrushWrite, 10, 10);
            ////Bitmap newBitmap = new Bitmap(onBitmap);
            ////Response.ContentType = "image/png";

            ////newBitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Png);


            ////onBitmap.Dispose();
            ////onGraphics.Dispose();

            ////return onBitmap;

            //Bitmap bm3 = new Bitmap(onBitmap);

            //Response.ContentType = "image/jpeg";
            //bm3.Save(HttpContext.Current.Server.MapPath("/img/bitmap.png"));

            //bm3.Dispose();
            //onBitmap.Dispose();

            //onGraphics.Dispose();

            //Response.End();
            #endregion

           // Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("s128ah.TTF");
            PrivateFontCollection pfcoll =new PrivateFontCollection();
            string file = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~"), "Font\\s128ah.TTF");
           // string file = "http://fal.vn/Font/s128ah.TTF";
            pfcoll.AddFontFile(file);
             FontFamily ff = pfcoll.Families[0];
            
            string barCode = Bar128(productcode);
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            using (Bitmap bitMap = new Bitmap(barCode.Length * 40, 80))
            {
                using (Graphics graphics = Graphics.FromImage(bitMap))
                {
                    Font oFont = new Font(ff, 36);
                    PointF point = new PointF(2f, 2f);
                  //  SolidBrush blackBrush = new SolidBrush(Color.Black);
                    SolidBrush whiteBrush = new SolidBrush(Color.White);
                    //graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);
                    graphics.DrawString(barCode, oFont, Brushes.Black, point);
                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();

                    Convert.ToBase64String(byteImage);
                    //imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                    addDynamicTable("data:image/png;base64," + Convert.ToBase64String(byteImage));

                }
            }
        }

        private void addDynamicTable(string url)
        {
            // Total number of rows.
            int rowCnt;
            // Current row count.
            int rowCtr;
            // Total number of cells per row (columns).
            int cellCtr;
            // Current cell counter
            int cellCnt;

            rowCnt = int.Parse("20");
            cellCnt = int.Parse("3");
            Font font = new Font("Tahoma", 3);
            for (rowCtr = 1; rowCtr <= rowCnt; rowCtr++)
            {
                // Create new row and add it to the table.
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                if (rowCtr % 2 != 0)
                {
                    //tieu de
                    for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++)
                    {
                        // Create a new cell and add it to the row.
                        TableCell tCell = new TableCell();
                        tCell.VerticalAlign = VerticalAlign.Bottom;
                        tCell.Text = txtProductName.Text + "<Br/>" + txtPrice.Text + "VND";
                        tRow.Cells.Add(tCell);
                    }
                }
                else
                {
                    //noi dung
                    for (cellCtr = 1; cellCtr <= cellCnt; cellCtr++)
                    {
                        System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                        // Create a new cell and add it to the row.
                        TableCell tCell = new TableCell();
                        imgBarCode.ImageUrl = url;
                        tCell.VerticalAlign = VerticalAlign.Top;
                        tCell.Controls.Add(imgBarCode);
                        tRow.Cells.Add(tCell);
                    }
                }
            }
        }

        private string Bar128(string bartextin)
        {
            string bartextout;
            int nsum;
            int nlen;
            int checksumv;
            int thisc, nchar;
            string thiss;
            int charv;
            string startchar, checksumc;

            bartextout = "";
            bartextin = bartextin.Trim();
            nlen = bartextin.Length;
            nsum = 0;
            startchar = "{";
            for (int i = 1; i <= nlen; i++)
            {
                thiss = Mid(bartextin, i, 1);
                thisc = asc(thiss);

                if (thisc < 127)
                {
                    charv = thisc - 32;
                }
                else
                {
                    charv = thisc - 103;
                }

                nsum = nsum + (charv * i);
                if (thiss == " ")
                {
                    bartextout += chr(228);
                }

                else
                {
                    nchar = thisc;
                    switch (nchar)
                    {
                        case 34:
                            bartextout += chr(226);
                            break;
                        case 123:
                            bartextout += chr(194);
                            break;
                        case 124:
                            bartextout += chr(195);
                            break;
                        case 125:
                            bartextout += chr(196);
                            break;
                        case 126:
                            bartextout += chr(197);
                            break;
                        default:
                            bartextout += thiss;
                            break;
                    }
                }

                nsum = nsum % 103;
            }

            checksumv = nsum % 103;

            if (checksumv > 90)
            {
                checksumc = Convert.ToString(chr(checksumv + 103));
            }
            else if (checksumv > 0)
            {
                checksumc = Convert.ToString(chr(checksumv + 32));
            }
            else
            {
                checksumc = Convert.ToString(chr(228));
            }

            bartextout = startchar + bartextout + checksumc + "~ ";

            return bartextout;

        }
        private string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex - 1, length);
            //return the result of the operation
            return result;
        }
        private char chr(int i)
        {
            return Convert.ToChar(i);
        }
        private int asc(string chr)
        {
            return (int)Encoding.ASCII.GetBytes(chr)[0];
        }

        protected void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBarCode.Text != string.Empty)
                {
                    ShowProductByID(txtBarCode.Text);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Load product
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="branchID"></param>
        private void ShowProductByID(string productID)
        {
            objProduct objPro = new objProduct();
            List<objColor> lstObjCol = new List<objColor>();
            objPro = proBiz.ShowByID(productID);
            if (objPro != null)
            {
                txtProductName.Text = objPro.ProductName;
                txtPrice.Text = objPro.ExportPrice.ToString();
            }
        }

        int stt = 1;
        protected void rptResult_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    objFindBarCode data = e.Item.DataItem as objFindBarCode;

                    Literal ltrStt = e.Item.FindControl("ltrStt") as Literal;
                    ltrStt.Text = stt.ToString();
                    stt++;

                    Literal ltrBarCode = e.Item.FindControl("ltrBarCode") as Literal;
                    ltrBarCode.Text = data.BarCode.ToString();

                    Literal ltrProducID = e.Item.FindControl("ltrProducID") as Literal;
                    ltrProducID.Text = data.ProductID.ToString();

                    Literal ltrProductName = e.Item.FindControl("ltrProductName") as Literal;
                    ltrProductName.Text = data.ProductName.ToString();

                    Literal ltrColor = e.Item.FindControl("ltrColor") as Literal;
                    ltrColor.Text = data.ColorName.ToString();

                    Literal ltrSize = e.Item.FindControl("ltrSize") as Literal;
                    ltrSize.Text = data.SizeName.ToString();

                    Literal ltrImportPrice = e.Item.FindControl("ltrImportPrice") as Literal;
                    ltrImportPrice.Text = data.ImportPrice.ToString();

                    Literal ltrExportPrice = e.Item.FindControl("ltrExportPrice") as Literal;
                    ltrExportPrice.Text = data.ExportPrice.ToString();

                    //Literal priBarCode = e.Item.FindControl("priBarCode") as Literal;
                    //priBarCode.Text = data.BarCode.ToString()  + "-" + data.ProductName.ToString() + " " + data.ColorName.ToString() + " " + data.SizeName.ToString() + "-" + data.ExportPrice.ToString();
                    
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void rptResult_ItemCommand(object sender, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Barcode":
                        txtBarCode.Text = e.CommandArgument.ToString();

                        for (int i = 0; i < lstObj.Count; i++) {
                            if (lstObj[i].BarCode.Equals(e.CommandArgument.ToString()))
                            {
                                txtPrice.Text = lstObj[i].ExportPrice.ToString();
                                txtProductName.Text = lstObj[i].ProductName + " " + lstObj[i].ColorName + " Size" + lstObj[i].SizeName;
                            }
                        }
                            break;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

}
