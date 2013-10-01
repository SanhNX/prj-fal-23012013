using BIZ;
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
    /// <summary>
    /// Summary description for SaleService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SaleService : System.Web.Services.WebService
    {
        StoreBIZ storeBIZ = new StoreBIZ();
        EventBIZ eventBIZ = new EventBIZ();
        ProductDAL productDAL = new ProductDAL();
        BillDAL billDAL = new BillDAL();
        BillDetailDAL billDetailDAL = new BillDetailDAL();
        CustomerDAL customerDAL = new CustomerDAL();
        

        objProduct objproduct = new objProduct();
        objEvent objevent = new objEvent();
        objCustomer objcustomer = new objCustomer();
        objStore objstore = new objStore();
        [WebMethod]
        public string getCurrentEventByBranch()
        {
            //TODO get current branch from session
            int currBranchID = 3;
            objevent = eventBIZ.ShowCurrentEventByBranch(currBranchID);
            int discountEventOfCurrentBranch = int.Parse(objevent != null ? objevent.Discount : "0");
            return discountEventOfCurrentBranch.ToString();
        }

        [WebMethod]
        public object getData(string barCode, string sl)
        {
            //TODO get current branch from session
            int currBranchID = 3;
            objstore = storeBIZ.ShowStoreByBarCodeAndBranch(barCode, currBranchID);

            if(objstore != null){ // ton tai
                if(objstore.Quantity > 0){ // con hang
                    if (objstore.Quantity >= int.Parse(sl)) // san pham hop le
                    {
                        return new { barCode = barCode, name = objstore.ProductName, price = objstore.ExportPrice, sl = sl, amount = (objstore.ExportPrice * int.Parse(sl)) };
                    }
                    else { // san pham chi con lai ... it hon so luong can mua
                        return new { error = "Sản phẩm chỉ còn lại " + objstore.Quantity };
                    }
                } else { // het hang
                    return new { error = "Sản phẩm này đang hết hàng !" };
                }
            }
            else{ // khong ton tai trong he thong hoac chi nhanh
                return new { error = "Sản phẩm không tồn tại trong hệ thống hoặc chi nhánh"};
            }
        }

        [WebMethod]
        public object getInfoCustomer(string codeCustomer)
        {
            object customer = null;
            objcustomer = customerDAL.GetCustomerByCode(int.Parse(codeCustomer == "" ? "0" : codeCustomer));
            //JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //object json = oSerializer.DeserializeObject(oSerializer.Serialize(objproduct));
            if (objcustomer != null)
            {
                customer = new { id = objcustomer.CustomerID, code = objcustomer.CodeCustomer, name = objcustomer.CustomerName, phone = objcustomer.Phone, email = objcustomer.Email, discount = objcustomer.DisCount };
            }
            return customer;
        }
        [WebMethod]
        public object saveInfoCustomer(string codeCustomer, string cusName, string cusPhone,
            string cusEmail, string discount, string tc, string tt, string currOrder)
        {
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();

            Boolean flag = false;
            objCustomer objcustomer = new objCustomer();
            objcustomer.CodeCustomer = codeCustomer;
            objcustomer.CustomerName = cusName;
            objcustomer.Phone = cusPhone;
            objcustomer.Email = cusEmail;
            objcustomer.DisCount = int.Parse(discount);
            objcustomer.CreateDate = DateTime.Now.ToString();
            int customerId = 0;
            int isInsertCus = 0;
            var isExistCustomer = customerDAL.GetCustomerByCode(int.Parse(codeCustomer));
            if (isExistCustomer != null) // exist
            {
                isInsertCus = int.Parse(codeCustomer);
                customerId = isExistCustomer.CustomerID;
            }
            else // not exist
            {
                isInsertCus = customerDAL.InsertCustomer(objcustomer); // return codeCustomer if exist
                customerId = customerDAL.GetCustomerByCode(isInsertCus).CustomerID;
            }

            if (isInsertCus != 0)
            {
                objBill objbill = new objBill();
                string nextId = billDAL.GetNextId().ToString();
                int lengthNextBillId = 10 - nextId.Length;
                string zeroString = "";
                for (int i = 0; i < lengthNextBillId; i++)
                {
                    zeroString = zeroString + "0";
                }
                nextId = zeroString + nextId;
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
                if (isInsertBill == 1)
                {
                    var jsonCurrOrder = oSerializer.Deserialize<List<item>>(currOrder);
                    Boolean flagTemp = false;
                    foreach (var item in jsonCurrOrder)
                    {
                        objBillDetail objbillDetail = new objBillDetail();

                        objbillDetail.BillID = objbill.BillID;
                        objbillDetail.BranchID = objbill.BranchID;
                        objbillDetail.BarCode = item.barCode;
                        objbillDetail.Quantity = int.Parse(item.sl);
                        objbillDetail.Amount = float.Parse(item.amount);
                        objbillDetail.CreateDate = DateTime.Now;
                        objbillDetail.CreateUser = createUser;

                        int isInsertBillDetail = billDetailDAL.InsertBillDetail(objbillDetail);
                        if (isInsertBillDetail == 1)
                        {
                            objStore objstoreTemp = new objStore();
                            objstoreTemp.BarCode = new objBarCode();
                            objstoreTemp.BarCode.BarCode = objbillDetail.BarCode;
                            objstoreTemp.Branch = new objBranch();
                            objstoreTemp.Branch.BranchID = objbillDetail.BranchID;
                            objstoreTemp.Quantity = objbillDetail.Quantity;
                            int isUpdateStore = storeBIZ.UpdateQuantity(objstoreTemp);
                            if (isUpdateStore == 1)
                            {
                                flag = true;
                            }
                        }
                    }
                }
            }
            return flag;
        }
    }

    public class item
    {
        public string barCode;
        public string name;
        public string price;
        public string sl;
        public string amount;
    }
}
