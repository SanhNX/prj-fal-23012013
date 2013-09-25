<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="FalStore.Control.Category" %>
<%@ Register Namespace="Common.Helper" Assembly="Common" TagPrefix="cc" %>
<!-- Main Container Start -->
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div>
                <asp:Label ID="lblMessage" ForeColor="Green" runat="server" Text=""></asp:Label>
            </div>
            <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span>Thêm loại sản phẩm</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <div class="mws-form">
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã danh mục</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtCategoryID" runat="server" class="small" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Tên danh mục</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtCategoryName" runat="server" class="small" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên danh mục"
                                        ControlToValidate="txtCategoryName" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <asp:Button ID="btnAdd" runat="server" Text="Tạo mới" class="btn btn-success" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-success" OnClick="btnClear_Click" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- table -->
        <div class="mws-panel grid_8 mws-collapsible">
            <div class="mws-panel-header">
                <span><i class="icon-table"></i>Danh sách loại sản phẩm</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper" role="grid">
                    <!-- serach -->
                    <div id="DataTables_Table_1_length" class="dataTables_length">
                        Show
                        <asp:DropDownList ID="drpSelect" runat="server" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged"
                            AutoPostBack="true">
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
                                <th style="width: 100px;">
                                    Số thứ tự
                                </th>
                                <th>
                                    Tên danh mục
                                </th>
                                <th style="width: 150px;">
                                </th>
                            </tr>
                        </thead>
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
                            <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand"
                                runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrCategoryName"></asp:Literal>
                                        </td>
                                        <td>
                                            <i class="icon-pencil"></i>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>'>Chỉnh sửa</asp:LinkButton>
                                            <i class="icon-trash"></i>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>'>Xóa</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <!-- paging -->
                    <!-- end .container -->
                    <cc:Pager ID="pager" runat="server" EnableViewState="true" CompactModePageCount="10"
                        CssClass="dataTables_info" MaxSmartShortCutCount="0" RTL="False" PageSize="50"
                        OnCommand="pager_Command" />
                </div>
            </div>
        </div>
    </div>
</div>
<p>
    &nbsp;</p>
