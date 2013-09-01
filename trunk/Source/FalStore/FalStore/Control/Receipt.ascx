<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Receipt.ascx.cs" Inherits="FalStore.Control.Receipt" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
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
                                <asp:TextBox ID="txtLogStore" runat="server" class="small"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Ngày lập phiếu</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtLogDate" runat="server" class="small"></asp:TextBox>
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
                                <asp:TextBox ID="txtProductID" runat="server" class="small"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Màu sắc</label>
                            <div class="mws-form-item">
                                <asp:DropDownList ID="drpColor" runat="server" class="small">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="mws-form-row">
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
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Số lượng</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtQuantity" runat="server" class="small"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Chọn sản phẩm"
                                class="fancyboxDemo" />
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
                                                Số thứ tự
                                            </th>
                                            <th>
                                                Mã sản phẩm
                                            </th>
                                            <th>
                                                Tên sản phẩm
                                            </th>
                                            <th>
                                                Giá tiền
                                            </th>
                                            <th>
                                                Số lượng
                                            </th>
                                            <th>
                                                Thành tiền
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                            <asp:Repeater ID="rptResult" runat="server">
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
                                            <asp:Literal runat="server" ID="ltrPrice"></asp:Literal>
                                        </td>
                                         <td>
                                            <asp:Literal runat="server" ID="ltrQuantity"></asp:Literal>
                                        </td>
                                         <td>
                                            <asp:Literal runat="server" ID="ltrAmount"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:HyperLink ID="hypEdit" runat="server">
                                                <i class="icon-pencil"></i>
                                                <asp:Literal ID="ltrEdit" runat="server" Text="Chỉnh sửa"></asp:Literal>
                                            </asp:HyperLink>
                                            <asp:HyperLink ID="hypDelete" runat="server">
                                                <i class="icon-trash"></i>
                                                <asp:Literal ID="ltrDelete" runat="server" Text="Xóa"></asp:Literal>
                                            </asp:HyperLink>
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
                        <asp:Button ID="btnAdd" runat="server" Text="Lập phiếu" class="btn btn-success"  />
                    </div>
                </div>
                <div id="mws-form-dialog">
                    <div class="mws-panel grid_8">
                        <div class="mws-panel-header">
                            <span>Chọn sản phẩm</span>
                        </div>
                        <div class="mws-panel-body no-padding">
                            <form class="mws-form" action="form_layouts.html">
                            <div class="mws-form-inline">
                                <div class="mws-form-row">
                                    <div class=" mws-form-cols">
                                        <div class="mws-form-col-4-8">
                                            <label class="mws-form-label">
                                                Mã sản phẩm</label>
                                            <div class="mws-form-item">
                                                <input type="text" class="large">
                                            </div>
                                        </div>
                                        <div class="mws-form-col-4-8">
                                            <label class="mws-form-label">
                                                Tên sản phẩm</label>
                                            <div class="mws-form-item">
                                                <input type="text" class="large">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mws-button-row">
                                <input type="submit" value="Tìm kiếm" class="btn btn-danger">
                                <input type="reset" value="Tạo mới" class="btn btn-danger">
                            </div>
                            <div class="mws-panel grid_8 mws-collapsible">
                                <div class="mws-panel-header">
                                    <span><i class="icon-table"></i>Danh sách</span>
                                </div>
                                <div class="mws-panel-body no-padding">
                                    <table class="mws-table">
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
                                                    Mô tả
                                                </th>
                                                <th>
                                                    Dach mục
                                                </th>
                                                <th>
                                                    Màu sắc
                                                </th>
                                                <th>
                                                    Kích cỡ
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    1
                                                </td>
                                                <td>
                                                    AV 01b
                                                </td>
                                                <td>
                                                    Vest nam màu xanh
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO VEST
                                                </td>
                                                <td>
                                                    Màu xanh
                                                </td>
                                                <td>
                                                    S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    2
                                                </td>
                                                <td>
                                                    AV 01a
                                                </td>
                                                <td>
                                                    Vest nam màu kem
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO VEST
                                                </td>
                                                <td>
                                                    Màu kem
                                                </td>
                                                <td>
                                                    XL
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    3
                                                </td>
                                                <td>
                                                    AV 01
                                                </td>
                                                <td>
                                                    Vest nam màu kaki
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO VEST
                                                </td>
                                                <td>
                                                    Màu kaki
                                                </td>
                                                <td>
                                                    M
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    4
                                                </td>
                                                <td>
                                                    BL 01a
                                                </td>
                                                <td>
                                                    Balo màu đô in chữ
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO THUN NAM
                                                </td>
                                                <td>
                                                    Màu đỏ đô
                                                </td>
                                                <td>
                                                    S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    5
                                                </td>
                                                <td>
                                                    BL 01
                                                </td>
                                                <td>
                                                    Balo in chữ màu kem
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO THUN NAM
                                                </td>
                                                <td>
                                                    Màu kem
                                                </td>
                                                <td>
                                                    S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    6
                                                </td>
                                                <td>
                                                    TP 07
                                                </td>
                                                <td>
                                                    Polo sooc ngang xanh đen
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO THUN NAM
                                                </td>
                                                <td>
                                                    Màu xanh đen
                                                </td>
                                                <td>
                                                    M
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    7
                                                </td>
                                                <td>
                                                    TP 02
                                                </td>
                                                <td>
                                                    Polo chấm bi xanh
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO THUN NAM
                                                </td>
                                                <td>
                                                    Chấm bi xanh
                                                </td>
                                                <td>
                                                    XL
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    8
                                                </td>
                                                <td>
                                                    TT 01
                                                </td>
                                                <td>
                                                    Áo thun nâu chỉ nổi túi caro
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    ÁO THUN NAM
                                                </td>
                                                <td>
                                                    Màu nâu
                                                </td>
                                                <td>
                                                    S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    9
                                                </td>
                                                <td>
                                                    SN 19
                                                </td>
                                                <td>
                                                    Tay ngắn caro nâu
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    SƠ MI NAM
                                                </td>
                                                <td>
                                                    Màu nâu
                                                </td>
                                                <td>
                                                    M
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    10
                                                </td>
                                                <td>
                                                    SN 17
                                                </td>
                                                <td>
                                                    Tay ngắn đen trơn phối túi
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    SƠ MI NAM
                                                </td>
                                                <td>
                                                    Màu đen
                                                </td>
                                                <td>
                                                    L
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    11
                                                </td>
                                                <td>
                                                    1036b
                                                </td>
                                                <td>
                                                    Sơ mi tay dài caro xám
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    SƠ MI NAM
                                                </td>
                                                <td>
                                                    Màu xám
                                                </td>
                                                <td>
                                                    S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    12
                                                </td>
                                                <td>
                                                    QKD 01c
                                                </td>
                                                <td>
                                                    Quần kaki màu xanh đen
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    QUẦN JEAN, KAKI
                                                </td>
                                                <td>
                                                    Màu xanh đen
                                                </td>
                                                <td>
                                                    M
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    13
                                                </td>
                                                <td>
                                                    QKD 01
                                                </td>
                                                <td>
                                                    Quần kaki màu đô
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    QUẦN JEAN, KAKI
                                                </td>
                                                <td>
                                                    Màu xanh
                                                </td>
                                                <td>
                                                    S
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    14
                                                </td>
                                                <td>
                                                    0004
                                                </td>
                                                <td>
                                                    Quần jean thái
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    QUẦN JEAN, KAKI
                                                </td>
                                                <td>
                                                    Màu xanh
                                                </td>
                                                <td>
                                                    XL
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    15
                                                </td>
                                                <td>
                                                    QSK 01
                                                </td>
                                                <td>
                                                    Quần short màu xám
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    QUẦN SHORT
                                                </td>
                                                <td>
                                                    Màu xám
                                                </td>
                                                <td>
                                                    L
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- table -->
        <!--popup--->
        <%--<div class="mws-panel grid_4">
        <div class="mws-panel-body" style="text-align: center">
            <div class="mws-panel-content">
                <input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Show Modal Form">
                <div id="mws-form-dialog">
                    <form id="mws-validate" class="mws-form">
                    <div id="mws-validate-error" class="mws-form-message error" style="display: none;">
                    </div>
                    <div class="mws-form-inline">
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mã phiếu</label>
                            <div class="mws-form-item">
                                <input type="text" class="small">
                            </div>
                        </div>
                    </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
        --%>
    </div>
