<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Employee.ascx.cs" Inherits="FalStore.Control.Employee" %>

<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Thông tin nhân viên</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            User name</label>
                        <div class="mws-form-item">
                            <asp:TextBox ID="TextUsername" runat="server" class="small" MaxLength="30" AutoPostBack="true" OnTextChanged="txtTextChanged"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập User Name"
                                        ControlToValidate="TextUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            PassWord</label>
                        <div class="mws-form-item">
                            <asp:TextBox ID="TextPassWord" runat="server" TextMode="Password" class="small" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Nhập PassWord"
                                        ControlToValidate="TextPassWord" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Tên nhân viên</label>
                        <div class="mws-form-item">
                            <asp:TextBox ID="textEmpName" runat="server" class="small" MaxLength="30"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredEmpName" runat="server" ErrorMessage="Nhập Tên Nhân Viên"
                                        ControlToValidate="textEmpName" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Giới tính</label>
                        <div class="mws-form-item clearfix">
                            <ul class="mws-form-list inline">
                                 <asp:DropDownList ID="drpGender" runat="server" class="small">
                            </asp:DropDownList>
                            </ul>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Địa chỉ</label>
                        <div class="mws-form-item">
                           <asp:TextBox ID="TextAdress" runat="server" class="small" MaxLength="50"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldAdress" runat="server" ErrorMessage="Nhập Địa chỉ"
                                        ControlToValidate="TextAdress" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Số điện thoại</label>
                        <div class="mws-form-item">
                              <asp:TextBox ID="TextPhone" runat="server" class="small" MaxLength="11"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldPhone" runat="server" ErrorMessage="Nhập số ĐT"
                                        ControlToValidate="TextPhone" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Chi Nhánh</label>
                        <div class="mws-form-item">
                            <asp:DropDownList ID="drpBranchTo" runat="server" class="small">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Chức vụ</label>
                        <div class="mws-form-item">
                                <asp:DropDownList ID="drpPermission" runat="server" class="small">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="mws-button-row">
                    <asp:Button ID="btnAdd" runat="server" Text="Tạo Nhân Viên" class="btn btn-success" OnClick="btnAdd_Click" />
                    <%--<input type="reset" value="Reset" class="btn ">--%>
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
                <table class="mws-table">
                    <thead>
                        <tr>
                            <th>
                                Tên NV
                            </th>
                            <th>
                                UserName
                            </th>
                            <th>
                                Chi Nhánh
                            </th>
                            <th>
                                Giới tính
                            </th>
                            <th>
                                Địa chỉ
                            </th>
                            <th>
                                Điện thoại
                            </th>
                            <th>
                                Cấp bật
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
                                            <asp:Literal runat="server" ID="ltrName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrUserName"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrChiNhanh"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrGioiTinh"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrDiaChi"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrDienThoai"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="ltrCapBat"></asp:Literal>
                                        </td>
                                        <td>
                                            <i class="icon-pencil"></i>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CausesValidation="false" CommandName="Edit"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmployeeID") %>'>Chỉnh sửa</asp:LinkButton>
                                            <i class="icon-trash"></i>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "EmployeeID") %>'>Xóa</asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                </table>
            </div>
        </div>
    </div>
</div>