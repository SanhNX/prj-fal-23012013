<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event.ascx.cs" Inherits="FalStore.Control.Event" %>
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
            <div>
                <asp:Label ID="lblMessage" ForeColor="Green" runat="server" Text=""></asp:Label>
            </div>
            <div class="mws-panel-header">
                <span>Thông tin kho</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">Tên Chương Trình</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtEventName" runat="server" class="large"  Visible="true"></asp:TextBox>
                                      <asp:RequiredFieldValidator ID="RequiredFieldEventName" runat="server" ErrorMessage="Nhập tên chương trình"
                                        ControlToValidate="txtEventName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="mws-form-row">
                            <label class="mws-form-label">Giảm Giá</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtDiscount" runat="server" class="" Visible="true"></asp:TextBox>
                                <asp:RangeValidator ID="RequiredFieldDiscount" runat="server" ControlToValidate="txtDiscount" Type="Integer" MinimumValue="0" MaximumValue="50" ErrorMessage="Nhập số từ 0 -> 50" ForeColor="Red"></asp:RangeValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mws-form-row">
                            <label class="mws-form-label">Đến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <%--<asp:CustomValidator ID="txtEndDateCustomValidator" OnServerValidate="CompareFromAndStartDate" ForeColor="Red" ControlToValidate="txtEndDate"
                                    ErrorMessage="Ngày kết thúc phải lớn hơn ngày bắt đầu" runat="server" ></asp:CustomValidator>--%>
                                <%--<asp:CompareValidator ID="CompareValidator1" Operator="LessThanEqual" Type="Date"
                                    ControlToValidate="txtStartDate" ControlToCompare="txtEndDate"
                                    ErrorMessage="Let's get started first!" runat="server" />--%>
                            </div>
                        </div>

                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Chọn chi nhánh</label>
                            <div class="mws-form-item">
                                <asp:DropDownList ID="drpBranch" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset class="mws-form-inline">
                        <div class="mws-button-row">
                            <asp:Button ID="btnAdd" runat="server" Text="Tạo mới" class="btn btn-success" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-success" OnClick="btnClear_Click" CausesValidation= "false" />
                            <asp:TextBox ID="txtTemp" runat="server" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtEventID" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Nhập thông tin khuyến mãi</span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
                                            <th>
                                                STT
                                            </th>
                                            <th>
                                                Chuong trình
                                            </th>
                                            <th>
                                                Giảm Giá (%)
                                            </th>
                                            <th>
                                                Chi Nhánh
                                            </th>
                                            <th>
                                                Ngày Bắt Đầu
                                            </th>
                                            <th>
                                                Ngày Kết Thúc
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
                                                        <asp:Literal runat="server" ID="ltrEventName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrDiscount"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrBranchName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrStartDate"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrEndDate"></asp:Literal>
                                                    <td>

                                                        <i class="icon-pencil"></i>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'>Chỉnh sửa</asp:LinkButton>
                                                        <%--<i class="icon-trash"></i>
                                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EventID") %>'>Xóa</asp:LinkButton>--%>
                                                    
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