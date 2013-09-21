<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DoanhThu.ascx.cs" Inherits="FalStore.Control.DoanhThu" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Thông tin kho</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Dến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TxtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
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
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" />
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
                                                Mã HĐ
                                            </th>
                                            <th>
                                                Nhân Viên BH
                                            </th>
                                            <th>
                                                Kháck Hàng
                                            </th>
                                            <th>
                                                Chi Nhánh
                                            </th>
                                            <th>
                                                Ngày Lập HĐ
                                            </th>
                                            <th>
                                                Thành Tiền
                                            </th>
                                            <th>
                                                Giảm Giá
                                            </th>
                                            <th>
                                                Tổng Tiền
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
                                                        <asp:Literal runat="server" ID="ltrBillId"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrEmpName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrCusName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrBranchName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrPrice1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSale"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrPrice2"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <%-- <%-- <i class="icon-pencil"></i>
                                                        <asp:LinkButton ID="lnkView" runat="server" CausesValidation="false" CommandName="View"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Xem</asp:LinkButton>--%>
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
