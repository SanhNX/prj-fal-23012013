<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Branch.ascx.cs" Inherits="FalStore.Control.Branch" %>
<%@ Register Namespace="Common.Helper" Assembly="Common" TagPrefix="cc" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div>
                <asp:Label ID="lblMessage" ForeColor="Green" runat="server" Text=""></asp:Label>
            </div>
            <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span>Chi nhánh</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <div class="mws-form">
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã chi nhánh</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtBranchID" runat="server" class="small" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Tên chi nhánh</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtBranchName" runat="server" class="small"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mô tả</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="large"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Địa chỉ</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtAddress" runat="server" class="small"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <asp:Button ID="btnAdd" runat="server" Text="Tạo mới" class="btn btn-success" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-success" OnClick="btnClear_Click" />
                        </div>
                        </form>
                    </div>
                </div>
            </div>
            <!-- table -->
            <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span><i class="icon-table"></i>Danh sách</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper" role="grid">
                        <!-- serach -->
                        <div id="DataTables_Table_1_length" class="dataTables_length">
                            Show
                            <asp:DropDownList ID="drpSelect" runat="server" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged"
                                AutoPostBack="true">
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
                        <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
                            <thead>
                                <tr>
                                    <th>
                                        Số thứ tự
                                    </th>
                                    <th>
                                        Mã chi nhánh
                                    </th>
                                    <th>
                                        Tên chi nhánh
                                    </th>
                                    <th>
                                        Mô tả
                                    </th>
                                    <th>
                                        Địa chỉ
                                    </th>
                                    <th style="width: 150px;">
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand"
                                    runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltrBranchID"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltrBranchName"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltrDescription"></asp:Literal>
                                            </td>
                                            <td>
                                                <asp:Literal runat="server" ID="ltrAddress"></asp:Literal>
                                            </td>
                                            <td>
                                                <i class="icon-pencil"></i>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>'>Chỉnh sửa</asp:LinkButton>
                                                <i class="icon-trash"></i>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BranchID") %>'>Xóa</asp:LinkButton>
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
    </div>
