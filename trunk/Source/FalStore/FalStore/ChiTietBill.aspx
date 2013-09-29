<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietBill.aspx.cs" Inherits="FalStore.ChiTietBill" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Styles/plugins/colorpicker/colorpicker.css"
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

    <!-- fancybox --->
<script type="text/javascript" src="../Scripts/js/libs/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="../Scripts/jui/js/jquery-ui-1.9.2.min.js"></script>
<!-- fancybox --->
<link rel="stylesheet" type="text/css" href="../Styles/jquery.fancybox-1.3.4.css"
    media="screen" />
<script type="text/javascript" src="../Scripts/jquery.fancybox-1.3.4.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Thông Tin Hóa Dơn</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div id="mws-form" class="mws-form">
                    <div class="mws-form-inline">
                         <div class="mws-panel-body">
                            <ul>
                                <li>Tên Khách Hàng        :   <asp:Literal runat="server" ID="Literal0"></asp:Literal></li>
                                <li>Nhân Viên Bán Hàng    :    <asp:Literal runat="server" ID="Literal1"></asp:Literal></li>
                                <li>Ngày Giờ Bán          :    <asp:Literal runat="server" ID="Literal2"></asp:Literal></li>
                                <li>Chi Nhánh             :     <asp:Literal runat="server" ID="Literal3"></asp:Literal></li>
                                <label>
                                    -----------------------------------------
                                </label>
                                <li>Tổng Cộng             :     <asp:Literal runat="server" ID="Literal4"></asp:Literal></li>
                                <li>Gảm Giá               :     <asp:Literal runat="server" ID="Literal5"></asp:Literal></li>
                                 <label>
                                    -----------------------------------------
                                </label>
                                <li>Thành Tiền            :   <asp:Literal runat="server" ID="Literal6"></asp:Literal></li>
                            </ul>
                        </div>
                        
                     </div>

                      
                     <div class="mws-panel-body no-padding">
                             <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper" role="grid">
                            <!-- serach -->
                            <div id="DataTables_Table_1_length" class="dataTables_length">
                                <label>
                                    Thông Tin Chi Tiết Hóa Đơn
                                </label>
                            </div>
                            <div class="dataTables_filter" id="DataTables_Table_1_filter">
                                <label>
                                    :
                                    
                                </label>
                            </div>
                            <!-- table -->
                            <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
                                <thead>
                                    <tr>
                                        <th>
                                            STT
                                        </th>
                                        <th>
                                            Mã vạch
                                        </th>
                                        <th>
                                            Tên Sản Phẩm
                                        </th>
                                        <th>
                                            Giá Bán
                                        </th>
                                        <th>
                                            Số Lượng
                                        </th>
                                        <th>
                                            Thành Tiền
                                        </th>
                                        <th>
                                            Nhân Viên Bán
                                        </th>
                                        <th>
                                            Ngày Bán
                                        </th>
                                       <%-- <th>
                                            Ngày trả
                                        </th>--%>

                                    </tr>
                                </thead>
                                <tbody role="alert" aria-live="polite" aria-relevant="all">
                                    <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound" >
                                        <ItemTemplate>
                                            <tr <asp:Literal runat="server" ID="ltrCss"></asp:Literal> >
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrMaVach"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrTenSp"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrGiaBan"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrSoluong"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrThanhTien"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrNhanVien"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="ltrNgayBan"></asp:Literal>
                                                </td>
                                               <%-- <td>
                                                    <asp:Literal runat="server" ID="ltrNgayTra"></asp:Literal>
                                                </td>--%>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
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
                    </div>
                </div>
            </div>
    </form>
</body>
</html>
