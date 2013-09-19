
var indexSTT = 1;
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

            $.ajax({
                url: "sales.aspx/btnSave_Click",
                type: 'POST',
                data: { ID: "2" },
                cache: false,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    alert("thanh");
                }
            });






















            var moneyOfProduct = 100000;

            var rowHtml = '<tr id="' + indexSTT + '">' +
                        '<td>' + indexSTT + '</td>' +
                        '<td>' + maVach + '</td>' +
                        '<td>Ao thun ba lo</td>' +
                        '<td> ' + moneyOfProduct + '</td>' +
                        '<td> ' + sL + '</td>' +
                        '<td> ' + (moneyOfProduct * sL) + '</td>' +
                        '<td><button id="btn-deleteRow" type="button" class="icol-cancel"></button></td>' +
                    '</tr>';
            $('tbody')[0].innerHTML += rowHtml;
            indexSTT = indexSTT + 1;

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

    });

    $("#gg").on('focusout', function (e) {
        if (parseInt($("#gg")[0].value) == 0) {
            $("#tt")[0].value = $("#tc")[0].value;
        } else {

            var changeMoney = parseInt(formatMoneyToString($("#tc")[0].value));

            var gg = (changeMoney * parseInt($("#gg")[0].value)) / 100;

            $("#tt")[0].value = changeMoney - gg;
            $("#tt").formatCurrency({ region: 'vi-VN' });
        }
    });

    $('#btn-deleteRow').on('click', function (e) {
        var arrButton = $(this);
        var indexRow = arrButton.index('#btn-deleteRow') + 1;
        var indexTr = $(indexRow);
        alert(indexTr);
        // removeTR(indexRow);
        // indexSTT = indexSTT - 1;
    });


});

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