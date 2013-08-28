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
    <!-- Searchbox -->
    <div id="mws-searchbox" class="mws-inset">
        <form action="typography.html">
        <input type="text" class="mws-search-input" placeholder="Search...">
        <button type="submit" class="mws-search-submit">
            <i class="icon-search"></i>
        </button>
        </form>
    </div>
    <!-- Main Navigation -->
    <div id="mws-navigation">
         <ul>
            <li class="active"><a href="../Default.aspx"><i class="icon-home"></i>Home</a></li>
            <li><a href="#"><i class="icon-list"></i>Quản lý kho</a>
                <ul>
                    <li><a href="" runat="server" id="hypCategory">Danh mục sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypProduct">Thông tin sản phẩm</a></li>
                    <li><a href="" runat="server" id="hypReceipt">Nhập hàng vào kho</a></li>
                    <li><a href="" runat="server" id="A1">Xuất cho các chi nhánh</a></li>
                </ul>
            </li>
            <li><a href="#"><i class="icon-list"></i>Quản lý chi nhánh</a>
                <ul>
                    <li><a href="" runat="server" id="hypBranch">Thông tin chi nhánh</a></li>
                    <li><a href="" runat="server" id="A2">Doanh thu</a></li>
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
        </ul>
    </div>
</div>
