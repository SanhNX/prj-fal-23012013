using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace FalStore
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Employee oEmployee1 =
            //        new Employee { Name = "Pini", ID = "111", Age = "30" };

            //Employee oEmployee2 =
            //      new Employee { Name = "Yaniv", ID = "Cohen", Age = "31" };

            //Employee oEmployee3 =
            //      new Employee { Name = "Yoni", ID = "Biton", Age = "20" };

            //List<Employee> oList = new List<Employee>() { oEmployee1, oEmployee2, oEmployee3 };

            //if ((Request.Form != null) && (Request.Form.Count > 0))
            //{
            //    // Process HTTP POST Request
            //    string strFilterID = Request.Form["ID"].ToString();
            //    // List<clsContacts> lstContacts = getContactByID(strFilterID);
            //    //Response.Write(buildXML(lstContacts));

            //    JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //    string sJSON = oSerializer.Serialize(oList);
            //    Response.Write(sJSON);
            //}
            //else
            //{
            //    // Process HTTP GET Request
            //    string strFilterID = Request.QueryString["ID"].ToString();
            //    //
            //    // List<clsContacts> lstContacts = getContactByID(strFilterID);
            //    JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //    string sJSON = oSerializer.Serialize(oList);
            //    Response.Write(sJSON);
            //}

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Employee oEmployee1 =
            //        new Employee { Name = "Pini", ID = "111", Age = "30" };

            //Employee oEmployee2 =
            //      new Employee { Name = "Yaniv", ID = "Cohen", Age = "31" };

            //Employee oEmployee3 =
            //      new Employee { Name = "Yoni", ID = "Biton", Age = "20" };

            //List<Employee> oList = new List<Employee>() { oEmployee1, oEmployee2, oEmployee3 };

            //if ((Request.Form != null) && (Request.Form.Count > 0))
            //{
            //    // Process HTTP POST Request
            //    string strFilterID = Request.Form["ID"].ToString();
            //   // List<clsContacts> lstContacts = getContactByID(strFilterID);
            //    //Response.Write(buildXML(lstContacts));

            //    JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //    string sJSON = oSerializer.Serialize(oList);
            //    Response.Write(sJSON);
            //}
            //else
            //{
            //    // Process HTTP GET Request
            //    string strFilterID = Request.QueryString["ID"].ToString();
            //    //
            //   // List<clsContacts> lstContacts = getContactByID(strFilterID);
            //    JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //    string sJSON = oSerializer.Serialize(oList);
            //    Response.Write(sJSON);
            //}

        }

        public class Employee
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string ID { get; set; }
        }
    }
}