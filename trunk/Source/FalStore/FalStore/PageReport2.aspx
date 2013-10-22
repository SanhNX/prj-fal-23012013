<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageReport2.aspx.cs" Inherits="FalStore.PageReport2" %>

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
    <script type="text/javascript" src="../Scripts/js/core/selectProduct.js"></script>
    <style type="text/css">
        .style1
        {
            width: 103px;
        }
        .style2
        {
            width: 203px;
        }
        .style3
        {
            width: 105px;
        }
        .style4
        {
            width: 489px;
        }
        .style5
        {
            width: 143px;
        }
        .style7
        {
            width: 251px;
        }
        .style8
        {
            width: 320px;
        }
    </style>
    <style type="text/css">
        table.gridtable 
        {
            width:100%; 
	        font-family: verdana,arial,sans-serif;
	        font-size:12px;
	        color:#333333;
	        border-width: 1px;
	        border-color: #666666;
	        border-collapse: collapse;
        }
        table.gridtable th {
	        border-width: 1px;
	        padding: 8px;
	        border-style: solid;
	        border-color: #666666;
	        background-color: #dedede;
        }
        table.gridtable td {
	        border-width: 1px;
	        padding: 8px;
	        border-style: solid;
	        border-color: #666666;
	        background-color: #ffffff;
        }
        .style9
        {
            width: 342px;
        }
        .style10
        {
            width: 432px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <div>
             <table style="width: 100%; height: 85px; margin-bottom: 0px;">
                 <tr>
                     <td class="style9" width="35%">
                         &nbsp;
                         <img alt="" src="Styles/Images/banner_Falshop_ex.png" /></td>
                     <td align="center" class="style10" style="font-size: 25px; font-weight: bold" 
                         width="30%">
                         PHIẾU XUẤT
                     </td>
                     <td width="35%">
                         &nbsp;
                     </td>
                 </tr>
             </table>
             
         </div>
         <div>
             <table style="width: 600px; margin-bottom: 30px;" align="center">
                 <tr>
                     <td class="style1">
                         &nbsp;&nbsp; Mã Phiếu</td>
                     <td class="style2">
                         <asp:Literal runat="server" ID="Literal0"></asp:Literal>
                      </td>
                     <td class="style3">
                         &nbsp;</td>
                     <td>
                          &nbsp;</td>
                 </tr>
                 <tr>
                     <td class="style1">
                         &nbsp;
                         Ngày Xuất:</td>
                     <td class="style2">
                          <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                     </td>
                     <td class="style3">
                         Nhân Viên Xuất:</td>
                     <td>
                          <asp:Literal runat="server" ID="Literal2"></asp:Literal>
                     </td>
                 </tr>
                 <tr>
                     <td class="style1">
                         &nbsp;
                         Xuất từ kho:</td>
                     <td class="style2">
                          <asp:Literal runat="server" ID="Literal3"></asp:Literal>
                     </td>
                     <td class="style3">
                         Nhập Vào Kho:</td>
                     <td>
                          <asp:Literal runat="server" ID="Literal4"></asp:Literal>
                     </td>
                 </tr>
            
             </table>
         </div>
          <div>
            <div class="mws-panel-body no-padding">
                <div>
                    <!-- serach -->
                    <!-- table -->
                    <table class="gridtable">
                        <thead>
                            <tr>
                                <th>
                                    STT
                                </th>
                                <th>
                                    Mã sản phẩm
                                </th>
                                <th>
                                    Tên sản phẩm
                                </th>
                                <th>
                                    Màu
                                </th>
                                 <th>
                                    Size
                                </th>
                                <th>
                                    Giá Bán
                                </th>
                                <th>
                                    Chiếc Khấu (%)
                                </th>
                                <th>
                                    SL
                                </th>
                                <th>
                                    Thánh Tiền
                                </th>
                            </tr>
                        </thead>


                         <tbody>
                            <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td align="center">
                                            <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrbarcode"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrColor"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Literal runat="server" ID="ltrSize"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Literal runat="server" ID="ltrCk"></asp:Literal>
                                        </td>
                                        <td align="center">
                                            <asp:Literal runat="server" ID="ltrSl"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrAmount"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>

                       <%-- <tr>
	                        <th>Info Header 1</th>
                            <th>Info Header 2</th>
                            <th>Info Header 3</th>
                        </tr>--%>
                      <%--  <tr>
	                        <td>Text 1A</td><td>Text 1B</td><td>Text 1C</td>
                        </tr>
                        <tr>
	                        <td>Text 2A</td><td>Text 2B</td><td>Text 2C</td>
                        </tr>--%>
                    </table>




                    <%--<table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" 
                        aria-describedby="DataTables_Table_1_info" align="center" border="0.5px" 
                        style="border: 0.5px groove #C0C0C0;">
                        <thead>
                            <tr>
                                <th align="center" 
                                    style="border-style: groove; border-width: thin; border-color: #000000">
                                    STT
                                </th>
                                <th style="border-style: groove; border-width: thin; border-color: #000000">
                                    Mã sản phẩm
                                </th>
                                <th style="border-style: groove; border-width: thin; border-color: #000000">
                                    Tên sản phẩm
                                </th>
                                <th style="border-style: groove; border-width: thin; border-color: #000000">
                                    Màu
                                </th>
                                 <th align="center" 
                                    style="border-style: groove; border-width: thin; border-color: #000000">
                                    Size
                                </th>
                                <th style="border-style: groove; border-width: thin; border-color: #000000">
                                    Giá Nhập
                                </th>
                                <th align="center" 
                                    style="border-style: groove; border-width: thin; border-color: #000000">
                                    Chiếc Khấu
                                </th>
                                <th style="border-style: groove; border-width: thin; border-color: #000000">
                                    SL
                                </th>
                                <th style="border-style: groove; border-width: thin; border-color: #000000">
                                    Thánh Tiền
                                </th>
                            </tr>
                        </thead>
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
                            <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrbarcode"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrColor"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrSize"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrCk"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrSl"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrAmount"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table--%>
                </div>
            </div>
         </div>
         <div>
             <table style="margin: 15px; width: 100%;">
                 <tr>
                     <td class="style4">
                         &nbsp;
                     </td>
                     <td style="font-size: 20px" align="left" class="style5">
                         Tổng Cộng :
                     </td>
                     <td class="style7" style="font-size: 20px">
                         <asp:Literal runat="server" ID="Literal5"></asp:Literal>
                     </td>
                 </tr>
                 
             </table>
         </div>
    </div>
    </form>
    <table align="center" style="width: 650px;">
        <tr>
            <td align="center" class="style8">
                <span style="color: rgb(0, 0, 0); font-family: Arial; font-size: 13px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 16px; orphans: auto; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">
                Người&nbsp;lập&nbsp;phiếu<br />
                <span style="color: rgb(0, 0, 0); font-family: Arial; font-size: 13px; font-style: italic; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: auto; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">
                (Ký,họ&nbsp;tên)</span></span></td>
            <td align="center">
                <span style="color: rgb(0, 0, 0); font-family: Arial; font-size: 13px; font-style: normal; font-variant: normal; font-weight: bold; letter-spacing: normal; line-height: 16px; orphans: auto; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">
                Người&nbsp;nhận&nbsp;hàng<br />
                <span style="color: rgb(0, 0, 0); font-family: Arial; font-size: 13px; font-style: italic; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 16px; orphans: auto; text-align: -webkit-center; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none;">
                (Ký,họ&nbsp;tên)</span></span></td>
        </tr>
        <tr>
            <td align="center" class="style8">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
    </table>
</body>
</html>
