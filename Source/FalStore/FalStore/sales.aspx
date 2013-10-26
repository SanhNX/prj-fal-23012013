<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="FalStore.Sales" %>

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
    <link rel="stylesheet" type="text/css" href="Styles/css/print-bill.css" >
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
    <script type="text/javascript" src="../Scripts/js/libs/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="../Scripts/js/libs/jquery-1.8.3.min.js"></script>
     <script type="text/javascript" src="../Scripts/js/core/sales.js"></script>
      <script type="text/javascript" src="../Scripts/jquery.formatCurrency-1.4.0.js"></script>
      <script type="text/javascript" src="../Scripts/jquery.formatCurrency.vi-VN.js"></script>

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
                        <asp:Label ID="lblBranchAddress" runat="server" Visible="true" CssClass="undisplayed"></asp:Label>
                        <!--start thanh add  -->

                        <asp:Literal runat="server" ID="Literal0"></asp:Literal>
                        <asp:Literal runat="server" ID="Literal6"></asp:Literal>
                        <asp:Literal runat="server" ID="Literal7"></asp:Literal>
                        <asp:Literal runat="server" ID="Literal8"></asp:Literal>
                        <asp:Literal runat="server" ID="Literal9"></asp:Literal>
                        <asp:Literal runat="server" ID="Literal10"></asp:Literal>
                        <!--end thanh add  -->
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

                                        <div id="printBill" class="printBill undisplayed">
                                            <div class="pb-header">
                                                <div class="" align="center"><img src="../Styles/Images/banner_Falshop_ex.png" alt=""/>
                                                  </div>
                                                <div class=""><div id="pb-branchName" class="" align="center"> </div></div>
                                                <div class=""><div id="pb-branchAddress" class="" align="center"> </div></div>
                                                <div class="pb-title">Hóa Đơn</div>
                                              <%--  <div class="pb-branchDesc">
                                                    <div class="pb-branchName"><div class="pb-rowTitle">Chi Nhánh : </div></div>
                                                    <div class="pb-branchAddress"><div class="pb-rowTitle">Địa Chỉ   : </div></div>
                                                </div>--%>
                                                <div class="pb-billDesc">
                                                    <div class="pb-billID"><div class="pb-rowTitle">Mã hóa đơn : </div><div id="pb-codeBill" class="pb-rowValue"> </div></div>
                                                    <div class="pb-cutomerName"><div class="pb-rowTitle">Tên khách hàng   : </div><div id="pb-cusName" class="pb-rowValue"> </div></div>
                                                    <div class="pb-codeCustomer"><div class="pb-rowTitle">Mã KH thân thiết : </div><div id="pb-cusCode" class="pb-rowValue"> </div></div>
                                                    <div class="pb-dateCreateBill"><div class="pb-rowTitle">Ngày xuất  : </div><div id="pb-dateCreate" class="pb-rowValue"> </div></div>
                                                </div>

                                            </div>
                                            <div class="pb-content">
                                                <div class="pb-productDetailDesc">
                                                    Chi tiết đơn hàng : 
                                                    <table id="billDetail" class="table">
                                                        <tr class="tr">
                                                            <th class="pb-itemName th">Tên SP</th>
                                                            <th class="pb-itemPrice th">Đơn giá</th>
                                                            <th class="pb-itemAmount th">SL</th>
                                                            <th class="pb-itemTotalPrice th">Thành tiền</th>
                                                        </tr>
                                                        <%--<tr>
                                                            <td class="pb-itemName td">1. Quần Jean </td>
                                                            <td class="pb-itemPrice td">150,000</td>
                                                            <td class="pb-itemAmount td">2</td>
                                                            <td class="pb-itemTotalPrice td">300,000</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="pb-itemName td">2. Quần Jean </td>
                                                            <td class="pb-itemPrice td">150,000</td>
                                                            <td class="pb-itemAmount td">2</td>
                                                            <td class="pb-itemTotalPrice td">300,000</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="pb-itemName td">3. Quần Jean </td>
                                                            <td class="pb-itemPrice td">150,000</td>
                                                            <td class="pb-itemAmount td">2</td>
                                                            <td class="pb-itemTotalPrice td">300,000</td>
                                                        </tr>--%>
                                                    </table>
                                                    
                                                </div>
                                                <div class="pb-Price">
                                                    <div class="pb-priceTitle">Tổng tiền : </div><div id="pb-tc" class="pb-priceValue"> </div>
                                                </div>
                                                <div class="pb-Price">
                                                    <div class="pb-priceTitle">Giảm giá (%) : </div><div id="pb-gg" class="pb-priceValue"> </div>
                                                </div>
                                                <div class="pb-Price">
                                                    <div class="pb-priceTitle">Thành tiền: </div><div id="pb-tt" class="pb-priceValue"> </div>
                                                </div>
                                            </div>
                                            <div class="pb-footer">• Cảm ơn quý khách. Hẹn gặp lại ! •</div>
                                        </div>
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
                                                    <input id="codeCustomer" type="text" value="FAL1234567" maxlength="10" class="large">
                                                </div>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Tên KH</label>
                                                <div class="mws-form-item">
                                                    <input id="cusName" type="text" value="Khach Hang" class="large">
                                                </div>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Số ĐT</label>
                                                <div class="mws-form-item">
                                                    <input id="cusPhone" type="text" value="0937757753" class="large">
                                                </div>
                                            </div>
                                            <div class="mws-form-row bordered">
                                                <label class="mws-form-label">Email</label>
                                                <div class="mws-form-item">
                                                    <input id="cusEmail" type="text" value="fal@gmail.com" class="large">
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
                                            <input id="btn-printBill" type="button" value="In hóa đơn" class="btn btn-primary" onclick="PrintBill('printBill')">
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
