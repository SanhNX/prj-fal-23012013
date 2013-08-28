<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="FalStore.Control.topmenu" %>
<!-- Header -->
THIS IS TOP MENU
<div id="mws-header" class="clearfix">
    <!-- Logo Container -->
    <div id="mws-logo-container">
        <!-- Logo Wrapper, images put within this wrapper will always be vertically centered -->
        <div id="mws-logo-wrap">
            <img src="../Styles/Images/logo.png" alt="mws admin">
        </div>
    </div>
    <!-- User Tools (notifications, logout, profile, change password) -->
    <div id="mws-user-tools" class="clearfix">
        <!-- User Information and functions section -->
        <div id="mws-user-info" class="mws-inset">
            <!-- User Photo -->
            <div id="mws-user-photo">
                <img src="../Styles/Images/profile.jpg" alt="User Photo">
            </div>
            <!-- Username and Functions -->
            <div id="mws-user-functions">
                <div id="mws-username">
                    Hello, John Doe
                </div>
                <ul>
                    <li><a href="#">Profile</a></li>
                    <li><a href="#">Change Password</a></li>
                    <li><a href="index.html">Logout</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
