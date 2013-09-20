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
            <li><a href="#"><i class="icon-list"></i>Quản lý kho</a>
                <ul>
                    <li><a href="" runat="server" id="hypCategory">Loại sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypProduct">Sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypReceipt">Nhập kho</a></li>
                    <li><a href="" runat="server" id="hypExportProduct">Xuất kho</a></li>
                    <li><a href="" runat="server" id="hypStore">Thông tin kho</a></li>
                    <li><a href="" runat="server" id="hypPrintBarcode">Xuất mã vạch</a></li>
                </ul>
            </li>
            <li><a href="#"><i class="icon-list"></i>Quản lý chi nhánh</a>
                <ul>
                    <li><a href="" runat="server" id="hypBranch">Thông tin chi nhánh</a></li>
                    <li><a href="" runat="server" id="hypDoanhThu">Doanh thu</a></li>
                    <li><a href="" runat="server" id="A1">Thông kê theo Sản Phẩm</a></li>
                    <li><a href="" runat="server" id="A3">Chi phí kinh doanh</a></li>
                    <li><a href="" runat="server" id="A4">Lợi nhuận</a></li>
                </ul>
            </li>
            <li><a href="#"><i class="icon-list"></i>Quản lý nhân viên</a>
                <ul>
                    <li><a href="" runat="server" id="hypEmployee">Thông tin nhân viên</a></li>
                    <li><a href="" runat="server" id="hypUser">Tài khoản đăng nhập</a></li>
                </ul>
            </li>
             <li><a href="../sales.aspx"><i class="icon-list"></i>Bán hàng</a>
            </li>
        </ul>
    </div>
</div>
