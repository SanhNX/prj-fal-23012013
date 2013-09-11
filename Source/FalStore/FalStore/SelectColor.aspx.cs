using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FalStore
{
    public partial class SelectColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> lColor = new List<string>();
            if (!TextBox1.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox1.Text);
            }
            if (!TextBox2.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox2.Text);
            }
            if (!TextBox3.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox3.Text);
            }
            if (!TextBox4.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox4.Text);
            }
            if (!TextBox5.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox5.Text);
            }
            if (!TextBox6.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox6.Text);
            }
            if (!TextBox7.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox7.Text);
            }
            if (!TextBox8.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox8.Text);
            }
            if (!TextBox9.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox9.Text);
            }
            if (!TextBox10.Text.Equals(string.Empty))
            {
                lColor.Add(TextBox10.Text);
            }
           
            Session["ListColor"] = lColor;

        }
    }
}