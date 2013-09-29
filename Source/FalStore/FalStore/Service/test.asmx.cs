using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace FalStore.Service
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class test : System.Web.Services.WebService
    {
        ProductDAL productDAL = new ProductDAL();
        BillDAL billDAL = new BillDAL();
        CustomerDAL customerDAL = new CustomerDAL();
        objProduct objproduct = new objProduct();
        
        objCustomer objcustomer = new objCustomer();
        [WebMethod]
        public object getData(string productId, string sl)
        {
            objproduct = productDAL.GetProductByID(productId);
            //JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //object json = oSerializer.DeserializeObject(oSerializer.Serialize(objproduct));
            return new { id = productId, name = objproduct.ProductName, price = objproduct.ExportPrice, sl = sl };
        }

        [WebMethod]
        public object getInfoCustomer(string codeCustomer)
        {
            object customer = null;
            objcustomer = customerDAL.GetCustomerByCode(int.Parse(codeCustomer == "" ? "0" : codeCustomer));
            //JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //object json = oSerializer.DeserializeObject(oSerializer.Serialize(objproduct));
            if(objcustomer != null){
                customer = new { id = objcustomer.CustomerID, code = objcustomer.CodeCustomer, name = objcustomer.CustomerName, phone = objcustomer.Phone, email = objcustomer.Email, discount = objcustomer.DisCount };
            }
            return customer;
        }
        [WebMethod]
        public object saveInfoCustomer(string codeCustomer, string cusName, string cusPhone, string cusEmail, string discount, string tc,string tt)
        {
            Boolean flag = false;
            objCustomer objcustomer = new objCustomer();
            objcustomer.CodeCustomer = codeCustomer;
            objcustomer.CustomerName = cusName;
            objcustomer.Phone = cusPhone;
            objcustomer.Email = cusEmail;
            objcustomer.DisCount = int.Parse(discount);
            objcustomer.CreateDate = DateTime.Now.ToString();
            int isInsertCus = customerDAL.InsertCustomer(objcustomer);
            if (isInsertCus != 0)
            {
                objBill objbill = new objBill();
                string nextId = billDAL.GetNextId().ToString();
                int lengthNextBillId = 10 - nextId.Length;
                string zeroString = "";
                for (int i = 0; i < lengthNextBillId; i++) {
                    zeroString = zeroString + "0";
                }
                nextId = zeroString + nextId;

                int customerId = customerDAL.GetCustomerByCode(isInsertCus).CustomerID;
                //TODO
                int employeeId = 1;
                int branchId = 3;
                string createUser = "Nhân Viên " + isInsertCus;

                objbill.BillID = nextId;
                objbill.EmployeeID = employeeId;
                objbill.BranchID = branchId;
                objbill.CustomerID = customerId;
                objbill.TotalPrice = float.Parse(tc);
                objbill.Sale = float.Parse(discount);    
                objbill.ActualTotalPrice = float.Parse(tt);
                objbill.CreateDate = DateTime.Now;
                objbill.CreateUser = createUser;
                objbill.UpdateDate = DateTime.Now;

                int isInsertBill = billDAL.InsertBill(objbill);
            }
            return flag;
        }
    }
}
