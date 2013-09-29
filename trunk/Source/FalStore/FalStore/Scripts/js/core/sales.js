var ORDER = "order";
$(document).ready(function () {
    $('#btn-newRow').on('click', function (e) {

        // get value request
        var maVach = $("#mavach")[0].value;
        var sL = $("#sl")[0].value;

        if (maVach.length > 7 || maVach.length < 7) {
            alert("Ma Vach phai 7 ky tu !!!!!");

        } else if (isNaN(sL) == true) {
            alert("So Luong phai la so !!!!!");
        } else {
            var productId = $("#mavach").val();
            var sl = $("#sl").val();
            $.ajax({
                type: "POST",
                url: "Service/test.asmx/getData",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ productId: productId, sl : sl }),
                dataType: "json",
                success: function (result) {
                    var item = result.d;
                    saveLocalStorage(item);
                    createTableOrder();
                    $("#mavach").val("");
                },
                error: function (mes) {
                    var responseText = JSON.parse(mes.responseText)
                    alert(responseText.Message);
                }
            });

            
        }

    });

    $('#codeCustomer').keyup(function (e) {
        var codeCustomer = $("#codeCustomer").val();
        $.ajax({
            type: "POST",
            url: "Service/test.asmx/getInfoCustomer",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({ codeCustomer: codeCustomer }),
            dataType: "json",
            success: function (result) {
                var customer = result.d;

                //TODO
                var discountOfCurrBranch = 20;
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
                    $("#gg")[0].disabled = true;
                } else {
                    $("#cusName").val("");
                    $("#cusName")[0].disabled = false;
                    $("#cusPhone").val("");
                    $("#cusPhone")[0].disabled = false;
                    $("#cusEmail").val("");
                    $("#cusEmail")[0].disabled = false;
                    $("#gg")[0].disabled = false;
                }
            }
        });

    });

    $("#gg").on('focusout', function (e) {
        if (parseInt($("#gg")[0].value) == 0) {
            $("#tt")[0].value = $("#tc")[0].value;
        } else {

            var changeMoney = parseInt(formatMoneyToString($("#tc")[0].value));

            var gg = (changeMoney * parseInt(isNaN($("#gg")[0].value) ? $("#gg")[0].value : 0)) / 100;

            $("#tt")[0].value = changeMoney - gg;
            $("#tt").formatCurrency({ region: 'vi-VN' });
        }
    });

    $('#btn-saveOrderToDB').on('click', function (e) {
        var codeCustomer = $("#codeCustomer").val();
        var cusName = $("#cusName").val();
        var cusPhone = $("#cusPhone").val();
        var cusEmail = $("#cusEmail").val();
        var gg = $("#gg").val();
        var tc = parseInt($("#tc")[0].value);
        var tt = parseInt($("#tt")[0].value);
        if (tc <= 0) {
            alert("Vui lòng chọn sản phẩm cho đơn hàng");
            return;
        }
        if (codeCustomer == "") {
            alert("Vui lòng nhập mã thành viên");
            return;
        }
        var isExist = $("#cusName")[0].disabled;
        if (isExist) { // is exist

        } else { // isn't exist
            //$.ajax({
            //    type: "POST",
            //    url: "Service/test.asmx/saveInfoCustomer",
            //    contentType: "application/json; charset=utf-8",
            //    data: JSON.stringify({ codeCustomer: codeCustomer, cusName: cusName, cusPhone: cusPhone, cusEmail: cusEmail, discount: gg, tc: tc, tt: tt}),
            //    dataType: "json",
            //    success: function (result) {
            //        var customer = result.d;

            //    }
            //});
        }
        alert("Thực thi thành công");
        
    });

});

window.onbeforeunload = closingCode;
function closingCode() {
    // do something...
    setStorageItem(ORDER, null);
    console.log("close or reload page");
    return "Please answer a question below :";
}

function createTableOrder() {
    $('tbody')[0].innerHTML = "";
    var currOrder = JSON.parse(getStorageItem(ORDER));
    if (currOrder && currOrder.length > 0) {
        for (var i = 0; i < currOrder.length; i++) {
            var item = currOrder[i];
            var moneyOfProduct = item.price;
            var sL = item.sl;
            var rowHtml = '<tr id="' + (i + 1) + '">' +
                        '<td>' + (i + 1) + '</td>' +
                        '<td>' + item.id + '</td>' +
                        '<td>' + item.name + '</td>' +
                        '<td>' + moneyOfProduct + '</td>' +
                        '<td>' + sL + '</td>' +
                        '<td>' + (moneyOfProduct * sL) + '</td>' +
                        "<td><a id='btn-deleteRow' href='javascript:deleteRow(" + '"' + item.id + '"' + ")' type='button' class='icol-cancel' ></a></td>" +
                    '</tr>';
            $('tbody')[0].innerHTML += rowHtml;

            //tổng cộng tiền
            var temp1 = parseInt(formatMoneyToString($("#tc")[0].value));
            var tc = temp1 + (moneyOfProduct * sL);
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
}

function deleteRow(id) {
    var currOrder = JSON.parse(getStorageItem(ORDER));
    var index = getProductInStorage(currOrder, id);
    currOrder.splice(index, 1);
    setStorageItem(ORDER, JSON.stringify(currOrder));
    createTableOrder();
}

function getProductInStorage(currOrder, id) {
    var index = null;
    if (currOrder) {
        for (var i = 0; i < currOrder.length; i++) {
            if (currOrder[i].id == id) {
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
            if(currOrder[i].id == item.id){
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