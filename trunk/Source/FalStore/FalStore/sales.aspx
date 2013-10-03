﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales.aspx.cs" Inherits="FalStore.Sales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <link rel="stylesheet" type="text/css" href="Styles/css/form.css"
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
    <!-- java script -->
    <script type="text/javascript" src="Scripts/js/libs/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="Scripts/js/libs/jquery-1.8.3.min.js"></script>
     <script type="text/javascript" src="Scripts/js/core/sales.js"></script>
      <script type="text/javascript" src="Scripts/jquery.formatCurrency-1.4.0.js"></script>
      <script type="text/javascript" src="Scripts/jquery.formatCurrency.vi-VN.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="mws-wrapper">
        <!-- Main Container Start -->
        <div id="mws-container-sale" class="clearfix">
            <div class="container-sale">
                <div class="mws-panel grid_8">
                    <div class="mws-panel-header">
                        <asp:Label ID="lblEmployeeName" runat="server" style="font-size: 22px;width: 40%;float: left;"></asp:Label>
                        <span style="font-size: 22px;width: 20%;float: left;text-align: center;">Bán Hàng</span>
                        <asp:Label ID="lblBranchName" runat="server" style="font-size: 22px;width: 40%;float: left;text-align: right;"></asp:Label>
                    </div>
                    <div class="mws-panel-body no-padding">
                        <div style="width: 70%;float: left;min-height: 560px;max-height: 100%;">
                            <!-- table -->
                            <div class="mws-panel grid_8 mws-collapsible">
                                <div class="mws-panel-body no-padding">
                                    <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper" role="grid">
                                        <!-- serach -->
                                        <div id="DataTables_Table_1_length" class="dataTables_length">
                                            <label>
                                                Thông tin sản phẩm
                                            </label>
                                        </div>
                                        <div class="dataTables_filter" id="DataTables_Table_1_filter">
                                            <label>
                                                Mã vạch:
                                                <input id="mavach" type="text" aria-controls="DataTables_Table_1">
                                                Số lượng:
                                                <input id="sl" type="text" style="width: 40px;" value="1" aria-controls="DataTables_Table_2">
                                                <button id="btn-newRow" type="button" class="btn btn-primary btn-small">Add</button>
                                            </label>
                                        </div>
                                        <!-- table -->
                                        <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
                                            <thead>
                                                <tr>
                                                    <th style="width: 20px;">
                                                        STT
                                                    </th>
                                                    <th style="width: 50px;">
                                                        Mã SP
                                                    </th>
                                                    <th>
                                                        Tên sản phẩm
                                                    </th>
                                                    <th style="width: 70px;">
                                                        Đơn giá
                                                    </th>
                                                    <th style="width: 20px;">
                                                        Số lượng
                                                    </th>
                                                    <th style="width: 70px;">
                                                        Thành tiền
                                                    </th>
                                                    <th style="width: 20px;">
                                                        xóa
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody role="alert" aria-live="polite" aria-relevant="all">
<%--                                                <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand"
                                                    runat="server">
                                                    <ItemTemplate>--%>
                                                        
                                             <%--       </ItemTemplate>
                                                </asp:Repeater>--%>
                                            </tbody>
                                        </table>
                                        <!-- paging -->
                                        <!-- end .container -->
                                       <%-- <cc:Pager ID="pager" runat="server" EnableViewState="true" CompactModePageCount="10"
                                            CssClass="dataTables_info" MaxSmartShortCutCount="0" RTL="False" PageSize="10"
                                            OnCommand="pager_Command" />--%>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div style="width: 30%;float: right;min-height: 560px;max-height: 100%;">
                            <div class="mws-panel grid_sale">
                                <div class="mws-panel-body no-padding">
                                    <div class="mws-form" action="">
                                        <fieldset class="mws-form-inline">
                                            <legend>Thông tin khach hàng</legend>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Mã Thành Viên</label>
                                                <div class="mws-form-item">
                                                    <input id="codeCustomer" type="text" value="" maxlength="10" class="large">
                                                </div>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Tên KH</label>
                                                <div class="mws-form-item">
                                                    <input id="cusName" type="text" value="" class="large">
                                                </div>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Số ĐT</label>
                                                <div class="mws-form-item">
                                                    <input id="cusPhone" type="text" value="" class="large">
                                                </div>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Email</label>
                                                <div class="mws-form-item">
                                                    <input id="cusEmail" type="text" value="" class="large">
                                                </div>
                                            </div>
                                        </fieldset>
                                        <fieldset class="mws-form-inline">
                                            <legend>Thông tin hóa đơn</legend>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Tổng Cộng</label>
                                                <label class="mws-form-label" style="font-size: 20px;font-family: fantasy;">
                                                    <input id="tc" type="text" disabled="disabled" value="0" class="large" style="width: 190px;">
                                                </label>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Giảm Giá</label>
                                                 <div class="mws-form-item">
                                                    <input id="gg" type="text" value="0" class="large" style="width: 50px;"><label style="font-size: x-large;margin-left: 5px;/* margin-top: 57px; */">%</label>
                                                </div>
                                                
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Thành Tiền</label>
                                                <label class="mws-form-label"  style="font-size: 25px;font-family: fantasy;">
                                                    <input id="tt" type="text" disabled="disabled" value="0" class="large" style="width: 190px;">
                                                </label>
                                            </div>
                                        </fieldset>
                                        <div class="mws-button-row">
                                            <input id="btn-saveOrderToDB" type="button" value="Xuất Hóa Đơn" class="btn btn-danger">
                                            <a href="http://fal.vn/Default.aspx" class="btn btn-primary">Trang Chủ</a>
                                        </div>
                                    </div>
                                </div>      
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            
        </div>
    </div>
    </form>
</body>
</html>
