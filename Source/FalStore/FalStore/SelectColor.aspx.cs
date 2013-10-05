using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
namespace FalStore
{
    public partial class SelectColor : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
             string id = HttpContext.Current.Request.QueryString["id"];
             if (!string.Empty.Equals(id)) {
                 Session["id"] = id;
             }
                
             string name = HttpContext.Current.Request.QueryString["name"];
             if (!string.Empty.Equals(id)) {
                 Session["name"] = name;
             }
             
              
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
           // Session["Ma"] = TextBox1.Text;

            List<String> lst = new List<string>();
            if (!TextBox1.Text.Equals(string.Empty))
            {
                lst.Add(TextBox1.Text);
            }
            if (!TextBox2.Text.Equals(string.Empty))
            {
                lst.Add(TextBox2.Text);
            }
            if (!TextBox3.Text.Equals(string.Empty))
            {
                lst.Add(TextBox3.Text);
            }
            if (!TextBox4.Text.Equals(string.Empty))
            {
                lst.Add(TextBox4.Text);
            }
            if (!TextBox5.Text.Equals(string.Empty))
            {
                lst.Add(TextBox5.Text);
            }
            if (!TextBox6.Text.Equals(string.Empty))
            {
                lst.Add(TextBox6.Text);
            }
            if (!TextBox7.Text.Equals(string.Empty))
            {
                lst.Add(TextBox7.Text);
            }
            if (!TextBox8.Text.Equals(string.Empty))
            {
                lst.Add(TextBox8.Text);
            }
            if (!TextBox9.Text.Equals(string.Empty))
            {
                lst.Add(TextBox9.Text);
            }
            if (!TextBox10.Text.Equals(string.Empty))
            {
                lst.Add(TextBox10.Text);
            }

            Session["ListColor"] = lst;

        }
    }
}