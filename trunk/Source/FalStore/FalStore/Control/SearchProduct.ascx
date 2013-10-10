<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchProduct.ascx.cs" Inherits="FalStore.Control.SearchProduct" %>
<%@ Register Namespace="Common.Helper" Assembly="Common" TagPrefix="cc" %>
<div id="mws-container" class="clearfix">
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

                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                        Tìm Theo</label>
                                <div class="mws-form-item">
                                    <asp:DropDownList ID="drpDelete" runat="server" class="small">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtProductID" runat="server" class="small" MaxLength="7"></asp:TextBox>
                                </div>
                            </div>

                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                        Danh mục</label>
                                <div class="mws-form-item">
                                    <asp:DropDownList ID="drpCategory" runat="server" class="small">
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="mws-form-row">
                                 <label class="mws-form-label">
                                        Tên sản phẩm</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtProductName" runat="server" class="small"></asp:TextBox>
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
           
                    <!-- table -->
                    <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
                        <thead>
                            <tr>
                                <th>
                                    Loại sản phẩm
                                </th>
                                <th>
                                    Mã vạch
                                </th>
                                <th>
                                    Mã sản phẩm
                                </th>
                                <th>
                                    Tên sản phẩm
                                </th>
                                <th>
                                    Màu sắc
                                </th>
                                <th>
                                    Size
                                </th>
                                <th>
                                    Giá nhập
                                </th>
                                <th>
                                    Giá bán
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
                            <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound"
                                OnItemCommand="rptResult_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrCategoryName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrBarCode"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrProductID"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrColorName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrSizeName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrImportPrice"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                        </td>
                                        <td>
                                            <i class="icon-trash"></i>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" 
                                                OnClientClick="return confirm('Are you sure?')"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Product.ProductID") %>'> <asp:Literal runat="server" ID="deleteName"></asp:Literal> </asp:LinkButton>
                                            <i class="icon-barcode"></i>
                                            <asp:LinkButton ID="lnkBarcode" runat="server" CausesValidation="false" CommandName="Barcode"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Product.ProductID") %>'>In mã vạch</asp:LinkButton>
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