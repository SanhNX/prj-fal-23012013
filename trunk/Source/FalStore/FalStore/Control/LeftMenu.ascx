<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftMenu.ascx.cs" Inherits="FalStore.Control.leftmenu" %>
<%--THIS LEFT MENU--%>
<!-- Necessary markup, do not remove -->
<div id="mws-sidebar-stitch">
</div>
<div id="mws-sidebar-bg">
</div>
<!-- Sidebar Wrapper -->
<div id="mws-sidebar">
    <!-- Hidden Nav Collapse Button -->
    <div id="mws-nav-collapse">
        <span></span><span></span><span></span>
    </div>
    <!-- Main Navigation -->
    <div id="mws-navigation">
         <ul>
            <li class="active"><a href="../Default.aspx?pageName=Home"><i class="icon-home"></i>Home</a></li>
            <li><a href="" runat="server" id="hypCustomer"><i class="icon-list"></i> Quản lý Khách Hàng</a></li>
            <li><a href="#"><i class="icon-list"></i>Quản lý kho</a>
                <ul>
                    <li><a href="" runat="server" id="hypCategory">Loại sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypProduct">Sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypSearchProduct">Tìm Sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypReceipt">Nhập kho</a></li>
                    <li><a href="" runat="server" id="hypExportProduct">Xuất kho</a></li>
                    <li><a href="" runat="server" id="hypStore">Thông tin kho</a></li>
                    <li><a href="" runat="server" id="hypNhapXuat">Quản lý nhập xuất</a></li>
                    <li><a href="" runat="server" id="hypNhapXuatDetail">Chi Tiết nhập xuất</a></li>
                </ul>
            </li>
            <li><a href="#"><i class="icon-list"></i>Quản lý chi nhánh</a>
                <ul>
                    <li><a href="" runat="server" id="hypBranch">Thông tin chi nhánh</a></li>
                    <li><a href="" runat="server" id="hypEvent">Thông Tin khuyến mãi</a></li>
                    <li><a href="" runat="server" id="hypDoanhThu">Doanh thu</a></li>
                    <li><a href="" runat="server" id="hypThongKe">Thông kê theo Sản Phẩm</a></li>
                    <li><a href="" runat="server" id="hypChiPhi">Chi phí kinh doanh</a></li>
                    <li><a href="" runat="server" id="hypLoiNhuan">Lợi nhuận</a></li>
                </ul>
            </li>
            <li><a href="#"><i class="icon-list"></i>Quản lý nhân viên</a>
                <ul>
                    <li><a href="" runat="server" id="hypEmployee">Thông tin nhân viên</a></li>
                   <%-- <li><a href="" runat="server" id="hypUser">Tài khoản đăng nhập</a></li>--%>
                </ul>
            </li>
             <li><a href="../sales.aspx"><i class="icon-list"></i>Bán hàng</a>
            </li>
        </ul>
    </div>
</div>
