<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongKe.ascx.cs" Inherits="FalStore.Control.ThongKe" %>
  <!-- JavaScript Plugins -->
    <script src="Scripts/js/libs/jquery-1.8.3.min.js"></script>
    <script src="Scripts/js/libs/jquery.mousewheel.min.js"></script>
    <script src="Scripts/js/libs/jquery.placeholder.min.js"></script>
    <script src="Scripts/custom-plugins/fileinput.js"></script>
    <!-- jQuery-UI Dependent Scripts -->
    <script src="Scripts/jui/js/jquery-ui-1.9.2.min.js"></script>
    <script src="Scripts/jui/jquery-ui.custom.min.js"></script>
    <script src="Scripts/jui/js/jquery.ui.touch-punch.js"></script>
    <script src="Scripts/jui/js/timepicker/jquery-ui-timepicker.min.js"></script>
    <!-- Plugin Scripts -->
    <script src="Scripts/plugins/imgareaselect/jquery.imgareaselect.min.js"></script>
    <script src="Scripts/plugins/jgrowl/jquery.jgrowl-min.js"></script>
    <script src="Scripts/plugins/validate/jquery.validate-min.js"></script>
    <script src="Scripts/plugins/colorpicker/colorpicker-min.js"></script>
    <!-- Core Script -->
    <script src="Styles/bootstrap/js/bootstrap.min.js"></script>
    <script src="Scripts/js/core/mws.js"></script>
    <!-- Themer Script (Remove if not needed) -->
    <script src="Scripts/js/core/themer.js"></script>
    <!-- Demo Scripts (remove if not needed) -->
    <script src="Scripts/js/demo/demo.widget.js"></script>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Thống Kê Sản Phẩm</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtProductID" runat="server" class="small" MaxLength="7"></asp:TextBox>
                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldProductID" runat="server" ErrorMessage="Nhập mã sản phẩm"
                                        ControlToValidate="txtProductID" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    <asp:RegularExpressionValidator ID="regExTextBox1" runat="server" ErrorMessage="Nhập đủ 7 ký tự"
                                        ControlToValidate="txtProductID" ForeColor="Red" ValidationExpression=".{7}.*"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Tên sản phẩm</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtTenSanPham" runat="server" class="" Visible="true" MaxLength="30"></asp:TextBox>

                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldStartDate" runat="server" ErrorMessage="Chọn ngày"
                                        ControlToValidate="txtStartDate" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Dến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TxtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Chọn ngày"
                                        ControlToValidate="TxtEndDate" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                Chọn chi nhánh</label>
                            <div class="mws-form-item">
                                <asp:DropDownList ID="drpBranch" runat="server"  class="small">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset class="mws-form-inline">
                        <div class="mws-button-row">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" class="btn btn-danger" />
                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" class="btn btn-danger"/>
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Danh sách thông tin tìm kiếm</span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
                                             <th>
                                                STT
                                            </th>
                                            <th>
                                                Bar Code
                                            </th>
                                            <th>
                                                Mã SP
                                            </th>
                                            <th>
                                                Tên SP
                                            </th>
                                            <th>
                                                Màu SP
                                            </th>
                                            <th>
                                                Size
                                            </th>
                                            <th>
                                                Số Lượng Bán
                                            </th>
                                            <th>
                                                Loại SP
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                                        <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" 
                                            runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
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
                                                        <asp:Literal runat="server" ID="ltrQuantity"></asp:Literal>
                                                    </td>
                                                     <td>
                                                        <asp:Literal runat="server" ID="ltrCategoryName"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <!-- table -->
        <!--popup--->
    </div>
</div>