<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Customer.ascx.cs" Inherits="FalStore.Control.Customer" %>

 <script type="text/javascript">

     $(document).ready(function () {

         $(".fancyboxDemo").fancybox({
             'type': 'iframe'
			, 'width': $(window).width() * 0.90
			, 'height': $(window).height() * 0.90
			, 'autoScale': false
			, 'hideOnOverlayClick': false
			, 'onClosed': function () { }
         });
     });
 
</script>

<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Thông tin khách hàng</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Số điểm tích lũy</label>
                            <div class="mws-form-item">
                                 <asp:TextBox ID="txtPoint" runat="server" style="width: 150px;" MaxLength="9"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="abc" ControlToValidate="txtPoint" ForeColor="Red" runat="server" ErrorMessage="Nhập số điểm "></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionQuantity" ControlToValidate="txtPoint" ForeColor="Red" runat="server" ErrorMessage="Phải là số" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Tìm Theo Số % giảm giá</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtDiscount" runat="server" style="width: 150px;" MaxLength="9"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtDiscount" ForeColor="Red" runat="server" ErrorMessage="Phải là số" ValidationExpression="\d+"></asp:RegularExpressionValidator>
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

                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Giảm Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="abc" ControlToValidate="txtStartDate" ForeColor="Red" runat="server" ErrorMessage="Chọn Ngày"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Giảm Đến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TxtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="abc" ControlToValidate="TxtEndDate" ForeColor="Red" runat="server" ErrorMessage="Chọn Ngày"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset class="mws-form-inline">
                        <div class="mws-button-row">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" class="btn btn-danger" />
                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" class="btn btn-danger"/>
                            <asp:Button ID="btnDiscount" runat="server" Text="Add Discount" ValidationGroup="abc" OnClick="btnDiscount_Click" class="btn btn-danger"/>
                            <asp:Button ID="btnDeleteDiscount" runat="server" Text="Delete Discount"  OnClick="btnDeleteDiscount_Click" class="btn btn-danger"/>
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
                                                Tên KH
                                            </th>
                                            <th>
                                                SĐT KH
                                            </th>
                                            <th>
                                                Email
                                            </th>
                                            <th>
                                                Chi Nhánh
                                            </th>
                                            <th>
                                                Mã Thành Viên
                                            </th>
                                            <th>
                                                Giảm Giá
                                            </th>
                                            <th>
                                                Giảm từ ngày
                                            </th>
                                            <th>
                                                Giảm đến ngày
                                            </th>
                                            <th>
                                                Điểm
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
                                                        <asp:Literal runat="server" ID="ltrCusName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrCusPhone"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrCusMail"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrBranchName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrCodeCus"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSale"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrStartDate"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrEndDate"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrPoint"></asp:Literal>
                                                    </td>
                                                 <%--   <td>
                                                        </i><a id="lnkFindProduct" class="fancyboxDemo" style="cursor: pointer" href="<asp:Literal runat="server" ID="ltrLink"></asp:Literal>"> Xem</a>
                                                        <i class="icon-pencil"><a id="lnkFindProduct"  style="cursor: pointer" href="<asp:Literal runat="server" ID="ltrLinkEdit"></asp:Literal>"> Edit</a>
                                                        <%-- <%-- <i class="icon-pencil"></i>
                                                        <asp:LinkButton ID="lnkView" runat="server" CausesValidation="false" CommandName="View"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Xem</asp:LinkButton>
                                                    </td>--%>
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
