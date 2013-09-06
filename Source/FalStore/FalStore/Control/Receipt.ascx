﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Receipt.ascx.cs" Inherits="FalStore.Control.Receipt" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div>
                <asp:Label ID="lblMessage" ForeColor="Green" runat="server" Text=""></asp:Label>
            </div>
            <div class="mws-panel-header">
                <span>Nhập kho</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin phiếu nhập</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mã phiếu nhập</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtLogStoreID" runat="server" class="small" Enabled="false"></asp:TextBox>
                                   <asp:Button ID="btnCreate" runat="server" Text="Tạo phiếu" class="btn btn-success" CausesValidation = "false" OnClick="btnCreate_Click" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Ngày lập phiếu</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtLogDate" runat="server" class="small" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Người lập phiếu</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpEmployee" runat="server" class="small">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Kho nhập</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpBranchTo" runat="server" class="small">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Nhà cung cấp</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtNcc" runat="server" class="small"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldNCC" runat="server" ErrorMessage="Nhập nhà cung cấp"
                                        ControlToValidate="txtNcc" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Nội dung</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="large"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset class="mws-form-inline">
                        <legend>Chọn sản phẩm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mã sản phẩm/ Mã vạch</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtProductID" runat="server" class="small" AutoPostBack="true" OnTextChanged="txtProductID_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Tên sản phẩm</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtProductName" runat="server" class="small" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Giá bán</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtExportPrice" runat="server" class="small" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Màu sắc</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpColor" runat="server" class="small" Enabled="False">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Size</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpSize" runat="server" class="small">
                                            <asp:ListItem>S</asp:ListItem>
                                            <asp:ListItem>M</asp:ListItem>
                                            <asp:ListItem>L</asp:ListItem>
                                            <asp:ListItem>XL</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Chiết khấu</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtSale" runat="server" class="small" Text = "0"  ></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Số lượng</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtQuantity" runat="server" class="small" Text = "1"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Chọn sản phẩm"
                                class="fancyboxDemo" />
                            <asp:Button ID="btnAddProduct" runat="server" Text="Thêm sản phẩm" CausesValidation="false" class="btn btn-success" OnClick="btnAddProduct_Click" />
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Thông tin sản phẩm</span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
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
                                                Giá tiền
                                            </th>
                                            <th>
                                                Số lượng
                                            </th>
                                            <th>
                                                Chiết khấu
                                            </th>
                                            <th>
                                                Thành tiền
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                                        <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrProductID"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrColor"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSize"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrQuantity"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSale"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrAmount"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </fieldset>
                    <div class="mws-button-row">
                        <asp:Button ID="btnAdd" runat="server" Text="Lập phiếu" class="btn btn-success" OnClick="btnAdd_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>