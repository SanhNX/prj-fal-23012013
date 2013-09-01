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
                                    <asp:TextBox ID="txtCategoryID" runat="server" class="small"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Tên danh mục</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtCategoryName" runat="server" class="small"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên danh mục"
                                        ControlToValidate="txtCategoryName" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <asp:Button ID="btnAdd" runat="server" Text="Tạo mới" class="btn btn-success" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-success" OnClick="btnClear_Click" />
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
                        <label>
                            Show
                            <select runat="server" id="count" size="1" name="DataTables_Table_1_length" aria-controls="DataTables_Table_1">
                                <option value="10" selected="selected">10</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="100">100</option>
                            </select>
                            entries
                        </label>
                        <asp:DropDownList ID="drpSelect" runat="server" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged">
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
                                    Số thứ tự
                                </th>
                                <th>
                                    Mã danh mục
                                </th>
                                <th>
                                    Tên danh mục
                                </th>
                                <th style="width: 150px;">
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
                                            <asp:Literal runat="server" ID="ltrCategoryID"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrCategoryName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:HyperLink ID="hypEdit" runat="server">
                                                <i class="icon-pencil"></i>
                                                <asp:Literal ID="ltrEdit" runat="server" Text="Chỉnh sửa"></asp:Literal>
                                            </asp:HyperLink>
                                            <asp:HyperLink ID="hypDelete" runat="server">
                                                <i class="icon-trash"></i>
                                                <asp:Literal ID="ltrDelete" runat="server" Text="Xóa"></asp:Literal>
                                            </asp:HyperLink>
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
                    <br />
                    <br />
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</div>
<p>
    &nbsp;</p>
