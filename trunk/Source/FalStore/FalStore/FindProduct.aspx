<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindProduct.aspx.cs" Inherits="FalStore.FindProduct" %>

<%@ Register Namespace="Common.Helper" Assembly="Common" TagPrefix="cc" %>
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
    <form id="form1" runat="server">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Chọn sản phẩm</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div id="mws-form" class="mws-form">
                    <div class="mws-form-inline">
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Danh mục</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpCategory" runat="server" class="small">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Tên sản phẩm</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtProductName" runat="server" class="large"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mws-button-row">
                        <asp:Button ID="btnFind" runat="server" Text="Tìm kiếm" class="btn btn-danger" OnClick="btnFind_Click" />
                        <asp:Button ID="btnAddNew" runat="server" Text="Tạo mới" class="btn btn-danger" OnClick="btnAddNew_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="mws-panel grid_8 mws-collapsible">
            <div class="mws-panel-header">
                <span><i class="icon-table"></i>Danh sách</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper" role="grid">
                    <!-- serach -->
                    <div id="DataTables_Table_1_length" class="dataTables_length">
                        <label>
                            Show
                        </label>
                        <asp:DropDownList ID="drpSelect" runat="server">
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="dataTables_filter" id="DataTables_Table_1_filter">
                        <label>
                            Search:
                            <input type="text" aria-controls="DataTables_Table_1">
                        </label>
                    </div>
                    <!-- table -->
                    <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
                        <thead>
                            <tr>
                                <th>
                                </th>
                                <th>
                                    Loại sản phẩm
                                </th>
                                <th>
                                    Mã sản phẩm
                                </th>
                                <th>
                                    Tên sản phẩm
                                </th>
                                <th>
                                    Giá bán
                                </th>
                            </tr>
                        </thead>
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
                            <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lnkSelect" runat="server" CausesValidation="false" CommandName="Select"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Chọn</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrCategoryName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrProductID"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <!-- paging -->
                    <!-- end .container -->
                    <cc:Pager ID="pager" runat="server" EnableViewState="true" CompactModePageCount="10"
                        CssClass="dataTables_info" MaxSmartShortCutCount="0" RTL="False" PageSize="10"
                        OnCommand="pager_Command" />
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
