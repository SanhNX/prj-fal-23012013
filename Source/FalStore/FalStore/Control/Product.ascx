<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="FalStore.Control.Product" %>
<%@ Register Namespace="Common.Helper" Assembly="Common" TagPrefix="cc" %>
<script type="text/javascript">
    function CreateTextbox() {
        createTextbox.innerHTML = createTextbox.innerHTML + "<div>Màu: <input type=text class='small' name='mytext' /></div>";
    }
    function RemoveTextbox() {
        createTextbox.innerHTML = '';
    } 
</script>
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
                    <span>Sản phẩm</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <div class="mws-form">
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtProductID" runat="server" class="small"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldProductID" runat="server" ErrorMessage="Nhập mã sản phẩm"
                                        ControlToValidate="txtProductID" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Tên sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtProductName" runat="server" class="small"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldProductName" runat="server" ErrorMessage="Nhập tên sản phẩm"
                                        ControlToValidate="txtProductName" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Danh mục sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:DropDownList ID="drpCategory" runat="server" class="small">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Thêm màu</label>
                                <div class="mws-form-item">
                                    <input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Chọn màu">
                                </div>
                            </div>
                            <div id="mws-form-dialog">
                                <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor1" runat="server" class="small"></asp:TextBox>
                                </div>
                                <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor2" runat="server" class="small"></asp:TextBox>
                                </div>
                                <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor3" runat="server" class="small"></asp:TextBox>
                                </div>
                                <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor4" runat="server" class="small"></asp:TextBox>
                                </div>
                                <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor5" runat="server" class="small"></asp:TextBox>
                                </div>
                                <%--  <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor6" runat="server" class="large"></asp:TextBox>
                                </div>
                                <div class="mws-form-row">
                                    <label class="mws-form-label">
                                        Màu</label>
                                    <asp:TextBox ID="txtColor7" runat="server" class="small"></asp:TextBox>
                                --%>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Giá nhập</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtImportPrice" runat="server" class="small"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldImportPrice" runat="server" ErrorMessage="Nhập giá nhập"
                                    ControlToValidate="txtImportPrice" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtImportPrice"
                                    ValidationExpression="([0-9])*" ErrorMessage="Nhập số" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Giá bán</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtExportPrice" runat="server" class="small"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldExportPrice" runat="server" ErrorMessage="Nhập giá bán"
                                    ControlToValidate="txtExportPrice" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtExportPrice"
                                    ValidationExpression="([0-9])*" ErrorMessage="Nhập số" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <asp:Button ID="btnAdd" runat="server" Text="Tạo mới" class="btn btn-success" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnEdit" runat="server" Text="Tạo mới" class="btn btn-success" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-success" />
                            <asp:TextBox ID="txtTemp" runat="server" Visible = "false"></asp:TextBox>
                        </div>
                    </div>
                </div>
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
                                Số thứ tự
                            </th>
                            <th>
                                Mã sản phẩm
                            </th>
                            <th>
                                Tên sản phẩm
                            </th>
                            <th>
                                Dach mục
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
                        <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand"
                            runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrProductID"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrCategoryName"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrImportPrice"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                    </td>
                                    <td>
                                        <i class="icon-pencil"></i>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Chỉnh sửa</asp:LinkButton>
                                        <i class="icon-trash"></i>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Xóa</asp:LinkButton>
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