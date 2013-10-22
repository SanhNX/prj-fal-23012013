﻿using BIZ;
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
        BillDetailBIZ billDetailBIZ = new BillDetailBIZ();
        CustomerDAL customerDAL = new CustomerDAL();
        CustomerBIZ customerBIZ = new CustomerBIZ();
        BillBIZ billBIZ = new BillBIZ();
        objBill objbill = new objBill();
        objBillDetail objBillDetail = new objBillDetail();
        List<objBillDetail> listBillDetail = new List<objBillDetail>();

        objProduct objproduct = new objProduct();
        objEvent objevent = new objEvent();
        objCustomer objcustomer = new objCustomer();
        objStore objstore = new objStore();


        //// thanh
        //[WebMethod(EnableSession = true)]
        //public object loadSession(
        //    string sessionEmpId, string sessionEmployeeName, string sessionBranchID, string sessionBranchName, string sessionBranchAddress, string sessionRole)
        //{
        //    Session["BranchID"] = sessionEmpId;
        //    Session["EmployeeName"] = sessionEmployeeName;
        //    Session["BranchID"] = sessionBranchID;
        //    Session["BranchName"] = sessionBranchName;
        //    Session["BranchAddress"] = sessionBranchAddress;
        //    Session["Role"] = sessionRole;
        //    return true;
        //}


        [WebMethod(EnableSession = true)]
        public object logout()
        {
            Session.Clear();
            Session.Abandon();
            return true;
        }

        [WebMethod(EnableSession = true)]
        public object getCurrentEventByBranch(string sessionBranchID, string sessionRole)
        {

            //TODO get current branch from session
            int currBranchID = int.Parse(sessionBranchID);
            objevent = eventBIZ.ShowCurrentEventByBranch(currBranchID);
            int discountEventOfCurrentBranch = int.Parse(objevent != null ? objevent.Discount : "0");
            return new { discountEventOfCurrentBranch = discountEventOfCurrentBranch.ToString(), roleID = int.Parse(sessionRole) };
        }

        [WebMethod(EnableSession = true)]
        public object getBillToUpdate(string billID, string sessionRole)
        {
            objbill = billBIZ.GetBillByID(billID)[0];
            objcustomer = customerDAL.GetCustomerByID(objbill.CustomerID);
            listBillDetail = billBIZ.GetBillDetailByID(billID, objbill.BranchID);
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            object json = oSerializer.DeserializeObject(oSerializer.Serialize(listBillDetail));

           // return new { branchIDOfBill = objbill.BranchID, roleID = Session["Role"] != null ? (int)Session["Role"] : 0, codeCustomer = objcustomer.CodeCustomer, cusName = objcustomer.CustomerName, phone = objcustomer.Phone, email = objcustomer.Email, tc = objbill.TotalPrice, gg = objbill.Sale, tt = objbill.ActualTotalPrice, listBillDetail = json };
            return new { branchIDOfBill = objbill.BranchID, roleID = sessionRole, codeCustomer = objcustomer.CodeCustomer, cusName = objcustomer.CustomerName, phone = objcustomer.Phone, email = objcustomer.Email, tc = objbill.TotalPrice, gg = objbill.Sale, tt = objbill.ActualTotalPrice, listBillDetail = json };
        }

        [WebMethod(EnableSession = true)]
        public object getData(string barCode, string sl, string sessionBranchID)
        {
            //TODO get current branch from session
            //int currBranchID = int.Parse(Session["BranchID"].ToString());
            int currBranchID = int.Parse(sessionBranchID);
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

        [WebMethod(EnableSession = true)]
        public object getInfoCustomer(string codeCustomer, string sessionRole)
        {
            object customer = null;
            objcustomer = customerDAL.GetCustomerByCode(codeCustomer == null ? "" : codeCustomer);
            //JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            //object json = oSerializer.DeserializeObject(oSerializer.Serialize(objproduct));
            if (objcustomer != null)
            {
                //customer = new { id = objcustomer.CustomerID, code = objcustomer.CodeCustomer, name = objcustomer.CustomerName, phone = objcustomer.Phone, email = objcustomer.Email, discount = objcustomer.DisCount, roleID = Session["Role"] != null ? (int)Session["Role"] : 0 };
                customer = new { id = objcustomer.CustomerID, code = objcustomer.CodeCustomer, name = objcustomer.CustomerName, phone = objcustomer.Phone, email = objcustomer.Email, discount = objcustomer.DisCount, roleID = sessionRole };
            }
            return customer;
        }
        [WebMethod(EnableSession = true)]
        public string saveInfoCustomer(string codeCustomer, string cusName, string cusPhone,
            string cusEmail, string discount, string tc, string tt, string currOrder, string sessionEmpId, string sessionEmployeeName, string sessionBranchID)
        {
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();

            string flag = null;
            string nextId;
            objCustomer objcustomer = new objCustomer();
            objcustomer.CodeCustomer = codeCustomer;
            objcustomer.CustomerName = cusName;
            objcustomer.Phone = cusPhone;
            objcustomer.Email = cusEmail;
            objcustomer.DisCount = int.Parse(discount);
            objcustomer.CreateDate = DateTime.Now.ToString();
            objcustomer.Point = int.Parse(tt)/10000;
            int customerId = 0;
            string isInsertCus = "";
            var isExistCustomer = customerDAL.GetCustomerByCode(codeCustomer);
            if (isExistCustomer != null) // exist
            {
                isInsertCus = codeCustomer;
                customerId = isExistCustomer.CustomerID;
                if (codeCustomer != "FAL1234567")
                {
                    int isUpdatePoint = customerBIZ.UpdatePointWithExistCustomer(codeCustomer, int.Parse(tt) / 10000);
                }
            }
            else // not exist
            {
                //objcustomer.BranchID = int.Parse(Session["BranchID"].ToString());
                objcustomer.BranchID = int.Parse(sessionBranchID);
                objcustomer.DisCount = 0;
                isInsertCus = customerDAL.InsertCustomer(objcustomer); // return codeCustomer if exist
                customerId = customerDAL.GetCustomerByCode(isInsertCus).CustomerID;
            }

            if (isInsertCus != null)
            {
                objBill objbill = new objBill();
                nextId = billDAL.GetNextId().ToString();
                int lengthNextBillId = 10 - nextId.Length;
                string zeroString = "";
                for (int i = 0; i < lengthNextBillId; i++)
                {
                    zeroString = zeroString + "0";
                }
                nextId = zeroString + nextId;
                //TODO
                //int employeeId = int.Parse(Session["EmployeeID"].ToString());
                //int branchId = int.Parse(Session["BranchID"].ToString());
                //string createUser = Session["EmployeeName"].ToString();

                int employeeId = int.Parse(sessionEmpId);
                int branchId = int.Parse(sessionBranchID);
                string createUser = sessionEmployeeName;

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
                                flag = nextId;
                            }
                        }
                    }
                }
            }
            return flag;
        }
        [WebMethod(EnableSession = true)]
        public object updateRowInBillDetail(string barCode, string billID, string quantity, string amount, string oldQuantity, string branchID, string sessionEmployeeName)
        {
            Boolean flag = false;
            BillDetailBIZ billDetailBIZ = new BillDetailBIZ();
            objBillDetail = new objBillDetail();
            objBillDetail.BillID = billID;
            objBillDetail.BarCode = barCode;
            objBillDetail.Quantity = int.Parse(quantity);
            objBillDetail.Amount = float.Parse(amount);
            //objBillDetail.UpdateUser = Session["EmployeeName"].ToString();
            objBillDetail.UpdateUser = sessionEmployeeName;
            int isUpDate = billDetailBIZ.Update(objBillDetail);
            if (isUpDate == 1)
            {
                if (quantity != oldQuantity)
                {
                    objStore objstoreTemp = new objStore();
                    objstoreTemp.BarCode = new objBarCode();
                    objstoreTemp.BarCode.BarCode = barCode;
                    objstoreTemp.Branch = new objBranch();
                    objstoreTemp.Branch.BranchID = int.Parse(branchID);
                    objstoreTemp.Quantity = int.Parse(quantity);

                    if (int.Parse(quantity) < int.Parse(oldQuantity))
                    { // cong them
                        
                        int isUpdateStore = storeBIZ.UpdateSumQuantity(objstoreTemp);
                        if (isUpdateStore == 1)
                        {
                            flag = true;
                        }
                    }
                    else
                    { // tru di
                        int isUpdateStore = storeBIZ.UpdateQuantity(objstoreTemp);
                        if (isUpdateStore == 1)
                        {
                            flag = true;
                        }
                    }
                }
                flag = true;
            }
            return flag;
        }
        [WebMethod(EnableSession = true)]
        public object insertMoreRowInBillDetail(string billID, string branchID, string barCode, string quantity, string amount, string sessionEmployeeName)
        {
            Boolean flag = false;
            objBillDetail objbillDetail = new objBillDetail();

            objbillDetail.BillID = billID;
            objbillDetail.BranchID = int.Parse(branchID);
            objbillDetail.BarCode = barCode;
            objbillDetail.Quantity = int.Parse(quantity);
            objbillDetail.Amount = float.Parse(amount);
            objbillDetail.CreateDate = DateTime.Now;
            //objbillDetail.CreateUser = Session["EmployeeName"].ToString();
            objbillDetail.CreateUser = sessionEmployeeName;

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
            return flag;
        }

        [WebMethod(EnableSession = true)]
        public object deleteRowInBillDetail(string billID, string barCode, string sessionEmployeeName)
        {
            Boolean flag = false;
            objBillDetail objbillDetail = new objBillDetail();

            objbillDetail.BillID = billID;
            objbillDetail.BarCode = barCode;
            //objbillDetail.UpdateUser = Session["EmployeeName"].ToString();
            objbillDetail.UpdateUser = sessionEmployeeName;

            int isDeleteBillDetail = billDetailBIZ.Delete(objbillDetail);
            if (isDeleteBillDetail != 0)
            {
                flag = true;
            }
            return flag;
        }

        [WebMethod(EnableSession = true)]
        public object updateBill(string billID, string tc, string gg, string tt, string codeCus, string sessionEmployeeName)
        {
            Boolean flag = false;
            objBill objbill = new objBill();

            objbill.BillID = billID;
            objbill.TotalPrice = float.Parse(tc);
            objbill.Sale = float.Parse(gg);
            objbill.ActualTotalPrice = float.Parse(tt);
            //objbill.UpdateUser = Session["EmployeeName"].ToString();
            objbill.UpdateUser = sessionEmployeeName;

            int isUpdatePoint = customerBIZ.UpdatePointByCustomerCode(codeCus, int.Parse(tt) / 10000, billID);

            int isUpdateBill = billBIZ.Update(objbill);
            if (isUpdateBill != 0)
            {
                flag = true;
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