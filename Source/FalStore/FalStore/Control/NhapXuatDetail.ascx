﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NhapXuatDetail.ascx.cs" Inherits="FalStore.Control.NhapXuatDetail" %>

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
                <span>Thông tin chi tiết nhập xuất</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class ="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Chọn loại phiếu</label>
                            <div class="mws-form-item">
                                <asp:DropDownList ID="drpPhieu" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtStartDate" ForeColor="Red" runat="server" ErrorMessage="Chọn Ngày"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Dến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TxtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtEndDate" ForeColor="Red" runat="server" ErrorMessage="Chọn Ngày"></asp:RequiredFieldValidator>
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
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" class="btn btn-danger" />
                            <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" class="btn btn-danger"/>
               <%--             <div class="">
                                <label class="mws-form-label" style="font-size: medium;width: 200px;">
                                    Tổng Cộng </label>
                                <div class="mws-form-item" style="font-size: medium;">
                                    <asp:Literal runat="server" ID="ltrDoanhThu" ></asp:Literal>
                                </div>
                            </div>--%>
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Danh sách thông tin tìm kiếm || <asp:Literal runat="server" ID="ltrDoanhThu" ></asp:Literal></span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
                                            <th>
                                                STT
                                            </th>
         <%--                                   <th>
                                                Ngày
                                            </th>--%>
                                            <th>
                                                Mã Phiếu
                                            </th>
                                            <th>
                                                Bar Code
                                            </th>
                                            <th>
                                                Mã SP
                                            </th>
                                             <th style="width: 80px;">
                                                Tên SP
                                            </th>
                                            <th>
                                                Màu
                                            </th>
                                            <th>
                                                Size
                                            </th>
                                            <th>
                                                Giá
                                            </th>
                                            <th>
                                                Sale
                                            </th>
                                            <th>
                                                SL
                                            </th>
                                            <th>
                                                Thành Tiền
                                            </th>
                                            
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                                         <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound" >
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrstt"></asp:Literal>
                                                    </td>
                                       <%--             <td>
                                                        <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
                                                    </td>--%>
                                                     <td>
                                                        <asp:Literal runat="server" ID="ltrLogID"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrBarCode"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrProID"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrProName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrColor"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSize"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrPrice"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSale"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="LitSl"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="LitTotalAmount"></asp:Literal>
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
