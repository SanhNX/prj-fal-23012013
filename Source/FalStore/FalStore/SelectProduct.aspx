<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectProduct.aspx.cs"
    Inherits="FalStore.SelectProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Plugin Stylesheets first to ease overrides -->
    <link rel="stylesheet" type="text/css" href="Styles/plugins/colorpicker/colorpicker.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/custom-plugins/wizard/wizard.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/plugins/imgareaselect/css/imgareaselect-default.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/plugins/jgrowl/jquery.jgrowl.css"
        media="screen">
    <!-- Required Stylesheets -->
    <link rel="stylesheet" type="text/css" href="Styles/bootstrap/css/bootstrap.min.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/fonts/ptsans/stylesheet.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/fonts/icomoon/style.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/mws-style.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/icons/icol16.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/icons/icol32.css" media="screen">
    <!-- Demo Stylesheet -->
    <link rel="stylesheet" type="text/css" href="Styles/css/demo.css" media="screen">
    <!-- jQuery-UI Stylesheet -->
    <link rel="stylesheet" type="text/css" href="Styles/jui/css/jquery.ui.all.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/jui/jquery-ui.custom.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Scripts/jui/css/jquery.ui.timepicker.css"
        media="screen">
    <!-- Theme Stylesheet -->
    <link rel="stylesheet" type="text/css" href="Styles/css/mws-theme.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/themer.css" media="screen">
</head>
<body>
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Chọn sản phẩm</span>
            </div>
            <div class="mws-panel-body no-padding">
                <form class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <div class=" mws-form-cols">
                            <div class="mws-form-col-4-8">
                                <label class="mws-form-label">
                                    Mã sản phẩm</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </div>
                            <div class="mws-form-col-4-8">
                                <label class="mws-form-label">
                                    Tên sản phẩm</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mws-button-row" >
                    <input type="submit" value="Tìm kiếm" class="btn btn-danger">
                    <input type="reset" value="Tạo mới" class="btn btn-danger">
                </div>
                <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span><i class="icon-table"></i>Danh sách</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <table class="mws-table">
                        <thead>
                            <tr>
                                <th>
                                    Số thứ tự
                                </th>
                                <th>
                                    Mã sản phẩm
                                </th>
                                <th>
                                    Tên sản phẩm
                                </th>
                                <th>
                                    Mô tả
                                </th>
                                <th>
                                    Dach mục
                                </th>
                                <th>
                                    Màu sắc
                                </th>
                                <th>
                                    Kích cỡ
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    AV 01b
                                </td>
                                <td>
                                    Vest nam màu xanh
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO VEST
                                </td>
                                <td>
                                    Màu xanh
                                </td>
                                <td>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    AV 01a
                                </td>
                                <td>
                                    Vest nam màu kem
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO VEST
                                </td>
                                <td>
                                    Màu kem
                                </td>
                                <td>
                                    XL
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    AV 01
                                </td>
                                <td>
                                    Vest nam màu kaki
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO VEST
                                </td>
                                <td>
                                    Màu kaki
                                </td>
                                <td>
                                    M
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4
                                </td>
                                <td>
                                    BL 01a
                                </td>
                                <td>
                                    Balo màu đô in chữ
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO THUN NAM
                                </td>
                                <td>
                                    Màu đỏ đô
                                </td>
                                <td>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5
                                </td>
                                <td>
                                    BL 01
                                </td>
                                <td>
                                    Balo in chữ màu kem
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO THUN NAM
                                </td>
                                <td>
                                    Màu kem
                                </td>
                                <td>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    6
                                </td>
                                <td>
                                    TP 07
                                </td>
                                <td>
                                    Polo sooc ngang xanh đen
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO THUN NAM
                                </td>
                                <td>
                                    Màu xanh đen
                                </td>
                                <td>
                                    M
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    7
                                </td>
                                <td>
                                    TP 02
                                </td>
                                <td>
                                    Polo chấm bi xanh
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO THUN NAM
                                </td>
                                <td>
                                    Chấm bi xanh
                                </td>
                                <td>
                                    XL
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    8
                                </td>
                                <td>
                                    TT 01
                                </td>
                                <td>
                                    Áo thun nâu chỉ nổi túi caro
                                </td>
                                <td>
                                </td>
                                <td>
                                    ÁO THUN NAM
                                </td>
                                <td>
                                    Màu nâu
                                </td>
                                <td>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    9
                                </td>
                                <td>
                                    SN 19
                                </td>
                                <td>
                                    Tay ngắn caro nâu
                                </td>
                                <td>
                                </td>
                                <td>
                                    SƠ MI NAM
                                </td>
                                <td>
                                    Màu nâu
                                </td>
                                <td>
                                    M
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    10
                                </td>
                                <td>
                                    SN 17
                                </td>
                                <td>
                                    Tay ngắn đen trơn phối túi
                                </td>
                                <td>
                                </td>
                                <td>
                                    SƠ MI NAM
                                </td>
                                <td>
                                    Màu đen
                                </td>
                                <td>
                                    L
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    11
                                </td>
                                <td>
                                    1036b
                                </td>
                                <td>
                                    Sơ mi tay dài caro xám
                                </td>
                                <td>
                                </td>
                                <td>
                                    SƠ MI NAM
                                </td>
                                <td>
                                    Màu xám
                                </td>
                                <td>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    12
                                </td>
                                <td>
                                    QKD 01c
                                </td>
                                <td>
                                    Quần kaki màu xanh đen
                                </td>
                                <td>
                                </td>
                                <td>
                                    QUẦN JEAN, KAKI
                                </td>
                                <td>
                                    Màu xanh đen
                                </td>
                                <td>
                                    M
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    13
                                </td>
                                <td>
                                    QKD 01
                                </td>
                                <td>
                                    Quần kaki màu đô
                                </td>
                                <td>
                                </td>
                                <td>
                                    QUẦN JEAN, KAKI
                                </td>
                                <td>
                                    Màu xanh
                                </td>
                                <td>
                                    S
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    14
                                </td>
                                <td>
                                    0004
                                </td>
                                <td>
                                    Quần jean thái
                                </td>
                                <td>
                                </td>
                                <td>
                                    QUẦN JEAN, KAKI
                                </td>
                                <td>
                                    Màu xanh
                                </td>
                                <td>
                                    XL
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    15
                                </td>
                                <td>
                                    QSK 01
                                </td>
                                <td>
                                    Quần short màu xám
                                </td>
                                <td>
                                </td>
                                <td>
                                    QUẦN SHORT
                                </td>
                                <td>
                                    Màu xám
                                </td>
                                <td>
                                    L
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            </div>
            
        </div>
</body>
</html>
