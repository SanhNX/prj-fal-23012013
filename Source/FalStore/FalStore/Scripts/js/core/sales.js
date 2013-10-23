var ORDER = "order";
var branchIDOfBill = null;
var oldBillDetail = [];
var oldListBillDetailID = [];
var oldSL = null;
var discountOfCurrBranch = 0;
$(document).ready(function () {

    // start add 20-10-2013 -Thanh
    //    setInterval(loadSession, 180000);
    //    function loadSession() {
    //        var var1 = $("#sessionEmpId").val();
    //        var var2 = $("#sessionEmployeeName").val();
    //        var var3 = $("#sessionBranchID").val();
    //        var var4 = $("#sessionBranchName").val();
    //        var var5 = $("#sessionBranchAddress").val();
    //        var var6 = $("#sessionRole").val();
    //        $.ajax({
    //            type: "POST",
    //            url: "Service/SaleService.asmx/loadSession",
    //            contentType: "application/json; charset=utf-8",
    //            data: JSON.stringify({ sessionEmpId: var1, sessionEmployeeName: var2, sessionBranchID: var3, sessionBranchName: var4, sessionBranchAddress: var5, sessionRole: var6}),
    //            dataType: "json",
    //            success: function (result) {
    //                //alert("Load session");
    //            }
    //        });
    //    }

    // End add 20-10-2013 -Thanh

    $('#btn-newRow').on('click', function (e) {

        // get value request
        var maVach = $("#mavach")[0].value;
        var sL = $("#sl")[0].value;

        if (maVach.length > 10 || maVach.length < 9) {
            alert("Mã vạch có độ dài 9-10 ký tự");

        } else if (isNaN(sL) == true) {
            alert("Số lượng phải là số !");
        } else {
            var barCode = $("#mavach").val();
            var sl = $("#sl").val();
            $.ajax({
                type: "POST",
                url: "Service/SaleService.asmx/getData",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ barCode: barCode, sl: sl, sessionBranchID: $("#sessionBranchID").val() }),
                dataType: "json",
                success: function (result) {
                    var item = result.d;
                    if (item.barCode) {
                        saveLocalStorage(item);
                        createTableOrder();
                        $("#mavach").val("");
                    } else {
                        alert(item.error);
                    }
                },
                error: function (mes) {
                    var responseText = JSON.parse(mes.responseText)
                    //alert(responseText.Message);
                }
            });
        }
    });

    $('#codeCustomer').on('focusout', function (e) {
        var codeCustomer = $("#codeCustomer").val();
        $.ajax({
            type: "POST",
            url: "Service/SaleService.asmx/getInfoCustomer",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ codeCustomer: codeCustomer, sessionRole: $("#sessionRole").val() }),
            dataType: "json",
            success: function (result) {
                var customer = result.d;

                if (customer) {
                    $("#cusName").val(customer.name);
                    $("#cusName")[0].disabled = true;
                    $("#cusPhone").val(customer.phone);
                    $("#cusPhone")[0].disabled = true;
                    $("#cusEmail").val(customer.email);
                    $("#cusEmail")[0].disabled = true;
                    if (customer.discount >= discountOfCurrBranch) {
                        $("#gg").val(customer.discount);
                    } else {
                        $("#gg").val(discountOfCurrBranch);
                    }
                    if (customer.roleID == "3") {
                        $("#gg")[0].disabled = false;
                    } else {
                        $("#gg")[0].disabled = true;
                    }
                } else {
                    $("#cusName").val("");
                    $("#cusPhone").val("");
                    $("#cusEmail").val("");
                    $("#cusName")[0].disabled = false;
                    $("#cusPhone")[0].disabled = false;
                    $("#cusEmail")[0].disabled = false;
                }

                loadInfomationInBill();
                loadPriceInBill();
            }
        });

    });

    $("#gg").on('focusout', function (e) {
        if ($("#gg")[0].value == "" || isNaN($("#gg")[0].value) || parseInt($("#gg")[0].value) > 100) {
            $("#gg")[0].value = 0;
        }
        var changeMoney = parseInt(formatMoneyToString($("#tc")[0].value));

        var gg = (changeMoney * parseInt(!isNaN($("#gg")[0].value) ? $("#gg")[0].value : 0)) / 100;

        $("#tt")[0].value = changeMoney - gg;
        $("#tt").formatCurrency({ region: 'vi-VN' });

        loadPriceInBill();
    });

    $('#btn-saveOrderToDB').on('click', function (e) {
        if (validateSalePage() == "") {
            loadInfomationInBill();
            var billID = getURLParameter("billID");
            if (billID) { // update bill 
                var currOrder = JSON.parse(getStorageItem(ORDER));
                if (currOrder && currOrder.length > 0) { // upadte or insert bill detail for current bill
                    for (var i = 0; i < currOrder.length; i++) {
                        var flagExist = false;
                        for (var j = 0; j < oldBillDetail.length; j++) {
                            if (currOrder[i].barCode == oldBillDetail[j].barCode) {
                                flagExist = true;
                                oldSL = oldBillDetail[j].sl;
                            }
                        }
                        if (flagExist) { // update bill detail and update bill
                            $.ajax({
                                type: "POST",
                                url: "Service/SaleService.asmx/updateRowInBillDetail",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify({ barCode: currOrder[i].barCode, billID: billID, quantity: currOrder[i].sl, amount: currOrder[i].amount, oldQuantity: oldSL, branchID: branchIDOfBill, sessionEmployeeName: $("#sessionEmployeeName").val() }),
                                dataType: "json",
                                success: function (result) {
                                    var resp = result.d;

                                },
                                error: function (mes) {
                                    var responseText = JSON.parse(mes.responseText)
                                    //alert(responseText.Message);
                                }
                            });
                        } else { // insert bill detail and update bill
                            $.ajax({
                                type: "POST",
                                url: "Service/SaleService.asmx/insertMoreRowInBillDetail",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify({ billID: billID, branchID: branchIDOfBill, barCode: currOrder[i].barCode, quantity: currOrder[i].sl, amount: currOrder[i].amount, sessionEmployeeName: $("#sessionEmployeeName").val() }),
                                dataType: "json",
                                success: function (result) {
                                    var resp = result.d;

                                },
                                error: function (mes) {
                                    var responseText = JSON.parse(mes.responseText)
                                    //alert(responseText.Message);
                                }
                            });
                        }
                    }
                    for (var i = 0; i < oldBillDetail.length; i++) {
                        var flagExist = false;
                        for (var j = 0; j < currOrder.length; j++) {
                            if (currOrder[j].barCode == oldBillDetail[i].barCode) {
                                flagExist = true;
                            }
                        }
                        if (!flagExist) {
                            $.ajax({
                                type: "POST",
                                url: "Service/SaleService.asmx/deleteRowInBillDetail",
                                contentType: "application/json; charset=utf-8",
                                data: JSON.stringify({ billID: billID, barCode: oldBillDetail[i].barCode, sessionEmployeeName: $("#sessionEmployeeName").val(), oldQuantity: oldBillDetail[i].sl, branchID: branchIDOfBill }),
                                dataType: "json",
                                success: function (result) {
                                    var resp = result.d;

                                },
                                error: function (mes) {
                                    var responseText = JSON.parse(mes.responseText)
                                    //alert(responseText.Message);
                                }
                            });
                        }
                    }
                    var gg = $("#gg").val();
                    var tc = parseInt(formatMoneyToString($("#tc")[0].value));
                    var tt = parseInt(formatMoneyToString($("#tt")[0].value));
                    $.ajax({
                        type: "POST",
                        url: "Service/SaleService.asmx/updateBill",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify({ billID: billID, tc: tc, gg: gg, tt: tt, codeCus: $("#codeCustomer").val(), sessionEmployeeName: $("#sessionEmployeeName").val() }),
                        dataType: "json",
                        success: function (result) {
                            var resp = result.d;

                            if (resp) {
                                alert("Đã hoàn tất chỉnh sửa");
                            } else {
                                alert("Đã xãy ra sự cố. vui lòng reload lại trang hiện tại.")
                            }
                        },
                        error: function (mes) {
                            var responseText = JSON.parse(mes.responseText)
                            //alert(responseText.Message);
                        }
                    });
                } else { // delete bill detail for current bill
                    for (var i = 0; i < oldBillDetail.length; i++) {
                        $.ajax({
                            type: "POST",
                            url: "Service/SaleService.asmx/deleteRowInBillDetail",
                            contentType: "application/json; charset=utf-8",
                            data: JSON.stringify({ billID: billID, barCode: oldBillDetail[i].barCode, sessionEmployeeName: $("#sessionEmployeeName").val() }),
                            dataType: "json",
                            success: function (result) {
                                var resp = result.d;
                                if (resp) {
                                    alert("Chi tiết hóa đơn đã được xóa trống");
                                } else {
                                    alert("Đã xãy ra sự cố. vui lòng reload lại trang hiện tại.")
                                }
                            },
                            error: function (mes) {
                                var responseText = JSON.parse(mes.responseText)
                                //alert(responseText.Message);
                            }
                        });
                    }
                }
            }
            else { // insert bill
                var codeCustomer = $("#codeCustomer").val();
                var cusName = $("#cusName").val();
                var cusPhone = $("#cusPhone").val();
                var cusEmail = $("#cusEmail").val();
                var gg = $("#gg").val();
                var tc = parseInt(formatMoneyToString($("#tc")[0].value));
                var tt = parseInt(formatMoneyToString($("#tt")[0].value));
                var currOrder = getStorageItem(ORDER);
                if (tc <= 0) {
                    alert("Vui lòng chọn sản phẩm cho đơn hàng");
                    return;
                }
                if (codeCustomer == "") {
                    alert("Vui lòng nhập mã thành viên");
                    return;
                }
                var isExist = $("#cusName")[0].disabled;
                //if (isExist) { // is exist

                //} else { // isn't exist
                $.ajax({
                    type: "POST",
                    url: "Service/SaleService.asmx/saveInfoCustomer",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({ codeCustomer: codeCustomer, cusName: cusName, cusPhone: cusPhone, cusEmail: cusEmail, discount: gg, tc: tc, tt: tt, currOrder: currOrder, sessionEmpId: $("#sessionEmpId").val(), sessionEmployeeName: $("#sessionEmployeeName").val(), sessionBranchID: $("#sessionBranchID").val() }),
                    dataType: "json",
                    success: function (result) {
                        var isSuccess = result.d;
                        if (isSuccess) {
                            $("#pb-codeBill")[0].innerHTML = isSuccess;
                            //alert("Thực thi thành công");
                            var r = confirm("Thực thi thành công. Bạn muốn in hóa đơn không ?")
                            if (r == true) {
                                PrintBill('printBill');
                                clearForm();
                            } else {
                                clearForm();
                            }
                        } else {
                            alert("Thực thi thất bại");
                        }
                    }
                });
                //}
            }
        } else {
            alert(validateSalePage());
        }
    });

});

function clearForm() {
    setStorageItem(ORDER, null);
    createTableOrder();
    $("#gg").val(discountOfCurrBranch);
    $("#codeCustomer").val("FAL1234567");
    $("#cusName").val("Khach Hang");
    $("#cusPhone").val("0937757753");
    $("#cusEmail").val("fal@gmail.com");
    $("#cusName")[0].disabled = true;
    $("#cusPhone")[0].disabled = true;
    $("#cusEmail")[0].disabled = true;
}

function validateSalePage() {
    var codeCustomer = $("#codeCustomer").val();
    var cusName = $("#cusName").val();
    var cusPhone = $("#cusPhone").val();
    var cusEmail = $("#cusEmail").val();
    var error = "";
    var phone_regex = /^([0-9]{10,11})$/;
    var email_regex = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;

    if (codeCustomer.length != 10 || codeCustomer === "") {
        error += '• Mã thành viên không được để trống và phải đúng 10 ký tự \n\n';
    }
    if (cusName === "") {
        error += '• Tên khách hàng không được để trống \n\n';
    }
    if (!email_regex.test(cusEmail) || cusEmail === "") {
        error += '• Email không được để trống và phải hợp lệ \n\tVí dụ : "abc@abc.com" \n\n';
    }
    if (cusPhone.length < 10 || cusPhone.length > 11 || !phone_regex.test(cusPhone) || cusPhone === "") {
        error += '• Số điện thoại không được để trống, từ 10-11 ký tự và phải hợp lệ \n\tVí dụ : "09123456789" \n\n';
    }
    return error;
}

window.onload = getCurrentEventByBranch;

function getCurrentEventByBranch() {
    setStorageItem(ORDER, null);
    var billID = getURLParameter("billID");
    if (billID) {
        $.ajax({
            type: "POST",
            url: "Service/SaleService.asmx/getBillToUpdate",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ billID: billID, sessionRole: $("#sessionRole").val()}),
            dataType: "json",
            success: function (result) {
                var resp = result.d;
                branchIDOfBill = resp.branchIDOfBill;

                $("#codeCustomer").val(resp.codeCustomer);
                $("#cusName").val(resp.cusName);
                $("#cusPhone").val(resp.phone);
                $("#cusEmail").val(resp.email);
                $("#tc")[0].value = resp.tc;
                $("#tc").formatCurrency({ region: 'vi-VN' });
                $("#tt")[0].value = resp.tt;
                $("#tt").formatCurrency({ region: 'vi-VN' });
                
                $("#gg").val(resp.gg ? resp.gg : 0);

                $("#codeCustomer")[0].disabled = true;
                $("#cusName")[0].disabled = true;
                $("#cusPhone")[0].disabled = true;
                $("#cusEmail")[0].disabled = true;
                $("#btn-saveOrderToDB")[0].value = "Hoàn tất chỉnh sửa";
                $("#btn-printBill").removeClass("undisplayed");
                if (resp.roleID == "3") {
                    $("#gg")[0].disabled = false;
                } else {
                    $("#gg")[0].disabled = true;
                }

                // save order to local storage

                currOrder = [];
                
                for (var i = 0; i < resp.listBillDetail.length; i++)
                {
                    var item = {};
                    item.amount = resp.listBillDetail[i].Amount;
                    item.barCode = resp.listBillDetail[i].BarCode;
                    item.name = resp.listBillDetail[i].ProductName;
                    item.price = resp.listBillDetail[i].ExportPrice;
                    item.sl = resp.listBillDetail[i].Quantity;
                    oldListBillDetailID.push(item.barCode);
                    oldBillDetail.push(item);
                    currOrder.push(item);
                }
                
                setStorageItem(ORDER, JSON.stringify(currOrder));

                $('tbody')[0].innerHTML = "";
                var currOrder = JSON.parse(getStorageItem(ORDER));
                if (currOrder && currOrder.length > 0) {
                    for (var i = 0; i < currOrder.length; i++) {
                        var item = currOrder[i];
                        var sL = item.sl;
                        var rowHtml = '<tr id="' + (i + 1) + '">' +
                                    '<td>' + (i + 1) + '</td>' +
                                    '<td>' + item.barCode + '</td>' +
                                    '<td>' + item.name + '</td>' +
                                    '<td>' + addCommas(item.price) + '</td>' +
                                    '<td>' + sL + '</td>' +
                                    '<td>' + addCommas(item.price * sL) + '</td>' +
                                    "<td><a id='btn-deleteRow' href='javascript:deleteRow(" + '"' + item.barCode + '"' + ")' type='button' class='icol-cancel' ></a></td>" +
                                '</tr>';
                        var rowBillHTML = '<tr>' +
                                '<td class="pb-itemName td">' + (i + 1) + '.' + (item.name.length > 13 ? item.name.substr(0, 10) + '...' : item.name) + '</td>' +
                                '<td class="pb-itemPrice td">' + addCommas(item.price) + '</td>' +
                                '<td class="pb-itemAmount td">' + sL + '</td>' +
                                '<td class="pb-itemTotalPrice td">' + addCommas(item.price * sL) + '</td>' +
                              '</tr>';
                        $('tbody')[0].innerHTML += rowHtml;
                        $("#billDetail")[0].innerHTML += rowBillHTML;
                    }
                }
                loadInfomationInBill();
                loadPriceInBill();
                $("#pb-dateCreate")[0].innerHTML = resp.dateCreate;
            }
        });
    }
    else {
        $.ajax({
            type: "POST",
            url: "Service/SaleService.asmx/getCurrentEventByBranch",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ sessionBranchID: $("#sessionBranchID").val(), sessionRole: $("#sessionRole").val()}),
            dataType: "json",
            success: function (result) {
                var resp = result.d;
                if (resp.discountEventOfCurrentBranch != "") {
                    discountOfCurrBranch = resp.discountEventOfCurrentBranch;
                    $("#gg").val(resp.discountEventOfCurrentBranch);
                }
                if (resp.roleID == "3") {
                    $("#gg")[0].disabled = false;
                } else {
                    $("#gg")[0].disabled = true;
                }
            }
        });
        $("#codeCustomer").val("FAL1234567");
        $("#cusName").val("Khach Hang");
        $("#cusPhone").val("0937757753");
        $("#cusEmail").val("fal@gmail.com");
        $("#cusName")[0].disabled = true;
        $("#cusPhone")[0].disabled = true;
        $("#cusEmail")[0].disabled = true;
        $("#btn-saveOrderToDB")[0].value = "Xuất hóa đơn";
        $("#btn-printBill").addClass("undisplayed");
        loadInfomationInBill();
        loadPriceInBill();
    }
    
    
}

function getURLParameter(name) {
    return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null;
}

//function getURLParameter(name) {
//    return decodeURI(
//        (RegExp(name + '=' + '(.+?)(&|$)').exec(location.search) || [, null])[1]
//    );
//}

window.onbeforeunload = closingCode;
function closingCode() {
    // do something...
    setStorageItem(ORDER, null);
    console.log("close or reload page");
    return "Please answer a question below :";
}

function createTableOrder() {
    $('tbody')[0].innerHTML = "";
    $("#billDetail")[0].innerHTML = '<tr class="tr"><th class="pb-itemName th">Tên SP</th><th class="pb-itemPrice th">Đơn giá</th><th class="pb-itemAmount th">SL</th><th class="pb-itemTotalPrice th">Thành tiền</th></tr>';
    var tc = 0;
    var currOrder = JSON.parse(getStorageItem(ORDER));
    if (currOrder && currOrder.length > 0) {
        for (var i = 0; i < currOrder.length; i++) {
            var item = currOrder[i];
            var moneyOfProduct = item.price;
            var sL = item.sl;
            var rowHtml = '<tr id="' + (i + 1) + '">' +
                        '<td>' + (i + 1) + '</td>' +
                        '<td>' + item.barCode + '</td>' +
                        '<td>' + item.name + '</td>' +
                        '<td>' + addCommas(moneyOfProduct) + '</td>' +
                        '<td>' + sL + '</td>' +
                        '<td>' + addCommas(moneyOfProduct * sL) + '</td>' +
                        "<td><a id='btn-deleteRow' href='javascript:deleteRow(" + '"' + item.barCode + '"' + ")' type='button' class='icol-cancel' ></a></td>" +
                    '</tr>';
            var rowBillHTML = '<tr>' +
                                '<td class="pb-itemName td">' + (i + 1) + '.' + (item.name.length > 13 ? item.name.substr(0, 10) + '...' : item.name) + '</td>' +
                                '<td class="pb-itemPrice td">' + addCommas(moneyOfProduct) + '</td>' +
                                '<td class="pb-itemAmount td">' + sL + '</td>' +
                                '<td class="pb-itemTotalPrice td">' + addCommas(moneyOfProduct * sL) + '</td>' +
                              '</tr>';
            $('tbody')[0].innerHTML += rowHtml;
            $("#billDetail")[0].innerHTML += rowBillHTML;
            //tổng cộng tiền
            tc = tc + (moneyOfProduct * sL);
            $("#tc")[0].value = tc;
            $("#tc").formatCurrency({ region: 'vi-VN' });

            
            // Tính thành tien
            if (parseInt($("#gg")[0].value) == 0) {
                $("#tt")[0].value = $("#tc")[0].value;
            } else {
                var changeMoney = parseInt(formatMoneyToString($("#tc")[0].value));

                var gg = (changeMoney * parseInt($("#gg")[0].value)) / 100;

                $("#tt")[0].value = changeMoney - gg;
                $("#tt").formatCurrency({ region: 'vi-VN' });
            }
        }
    } else {
        $("#tc").val(0);
        $("#tc").formatCurrency({ region: 'vi-VN' });
        $("#tt").val(0);
        $("#tt").formatCurrency({ region: 'vi-VN' });
    }
    loadPriceInBill();
}

function loadPriceInBill() {
    $("#pb-tc")[0].innerHTML = $("#tc")[0].value.substr(0, $("#tc")[0].value.length - 2);
    $("#pb-gg")[0].innerHTML = $("#gg")[0].value;
    $("#pb-tt")[0].innerHTML = $("#tt")[0].value.substr(0, $("#tt")[0].value.length - 2);;
}
function loadInfomationInBill() {
    $("#pb-branchName")[0].innerHTML = $("#lblBranchName")[0].innerHTML.substr(11, $("#lblBranchName")[0].innerHTML.length);
    //    $("#pb-branchAddress")[0].innerHTML = $("#lblBranchAddress")[0].innerHTML.length > 18 ? ($("#lblBranchAddress")[0].innerHTML.substr(0, 60) + "...") : $("#lblBranchAddress")[0].innerHTML;
    $("#pb-branchAddress")[0].innerHTML = $("#lblBranchAddress")[0].innerHTML;
    $("#pb-codeBill")[0].innerHTML = getURLParameter("billID") == "" ? "" : getURLParameter("billID");

    if ($("#codeCustomer")[0].value != "FAL1234567") {
        $(".pb-cutomerName").removeClass("undisplayed");
        $(".pb-codeCustomer").removeClass("undisplayed");
        $("#pb-cusName")[0].innerHTML = $("#cusName")[0].value;
        $("#pb-cusCode")[0].innerHTML = $("#codeCustomer")[0].value;
    } else {
        $(".pb-cutomerName").addClass("undisplayed");
        $(".pb-codeCustomer").addClass("undisplayed");
    }

    if (!getURLParameter("billID")) {
        var d = new Date();
        var curr_date = d.getDate();
        var curr_month = d.getMonth() + 1; //Months are zero based
        var curr_year = d.getFullYear();
        $("#pb-dateCreate")[0].innerHTML = curr_date + "/" + curr_month + "/" + curr_year;
    }
}
function deleteRow(barCode) {
    var currOrder = JSON.parse(getStorageItem(ORDER));
    var index = getProductInStorage(currOrder, barCode);
    currOrder.splice(index, 1);
    setStorageItem(ORDER, JSON.stringify(currOrder));
    createTableOrder();
}

function getProductInStorage(currOrder, barCode) {
    var index = null;
    if (currOrder) {
        for (var i = 0; i < currOrder.length; i++) {
            if (currOrder[i].barCode == barCode) {
                index = i;
            }
        }
    }
    return index;

}

function saveLocalStorage(item) {
    var currOrder = JSON.parse(getStorageItem(ORDER));
    if (currOrder) {
        var isExist = checkExistProductInCurrentOrder(item, currOrder);
        if (isNaN(isExist)) { // product is not exist in current order
            currOrder.push(item);
        } else { // product exist in current order
            currOrder[isExist].sl = parseInt(currOrder[isExist].sl, 10) +  parseInt(item.sl, 10);
        }
    } else {
        currOrder = [];
        currOrder.push(item);
    }
    setStorageItem(ORDER, JSON.stringify(currOrder));
}

function checkExistProductInCurrentOrder(item, currOrder) {
    var index = null;
    if(item){
        for(var i = 0; i < currOrder.length; i++){
            if(currOrder[i].barCode == item.barCode){
                index = i;
                return index;
            }
        }
    }else{
        return index;
    }
}

function setStorageItem(key, value) {
    localStorage.setItem(key, value);
}

function getStorageItem(key) {
    return localStorage.getItem(key);
}

function removeStorageItem(key) {
    localStorage.removeItem(key);
}

function formatMoneyToString(pagam) {
    var toString = '';
    if (parseInt(pagam) != 0) {
        for (var i = 1; i <= (pagam.length - 5); i++) {
            if (pagam.charAt(i - 1) != ".") {
                toString = toString + pagam.charAt(i - 1);
            }

        }
    } else {
        toString = 0;
    }
    return toString;
}

function addCommas(str) {
    var amount = new String(str);
    amount = amount.split("").reverse();

    var output = "";
    for (var i = 0; i <= amount.length - 1; i++) {
        output = amount[i] + output;
        if ((i + 1) % 3 == 0 && (amount.length - 1) !== i) output = ',' + output;
    }
    return output;
}

function PrintBill(strid) {
    var prtContent = document.getElementById(strid);
    //var WinPrint = window.open('', '', 'letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
    //WinPrint.document.write('<HTML><HEAD><META http-equiv="Content-type" content="text/html; charset=iso-8859-2"><LINK rel="stylesheet" type="text/css" href="Styles/css/print-bill.css"></HEAD></HTML>');
    //WinPrint.document.write(prtContent.innerHTML);




    var WinPrint = open('', '', 'letf=0,top=0,width=1000,height=800,toolbar=0,scrollbars=0,status=0');
    WinPrint.document.open();
    WinPrint.document.write('<HTML><HEAD><META http-equiv="Content-type" content="text/html; charset=iso-8859-2"><LINK rel="stylesheet" type="text/css" href="Styles/css/print-bill.css">');
    WinPrint.document.write('<scr' + 'ipt language="javascript" type="text/javascript" src="/js/JSFILE.js"></scr' + 'ipt>');
    WinPrint.document.write('</HEAD><BODY>');
    WinPrint.document.write(prtContent.innerHTML);
    WinPrint.document.write('</BODY></HTML>');
    
    setTimeout(function () {
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
    }, 300);
    

}