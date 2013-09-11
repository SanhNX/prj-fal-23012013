<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FalStore.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!--<![endif]-->
<head>
    <meta charset="utf-8">
    <!-- Viewport Metata -->
    <meta name="viewport" content="width=device-width,initial-scale=1.0">
    <!-- Required Stylesheets -->
    <link rel="stylesheet" type="text/css" href="Styles/bootstrap/css/bootstrap.min.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/fonts/ptsans/stylesheet.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/fonts/icomoon/style.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/login.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/mws-theme.css" media="screen">
    <!-- JavaScript Plugins -->
    <script src="Scripts/js/libs/jquery-1.8.3.min.js"></script>
    <script src="Scripts/js/libs/jquery.placeholder.min.js"></script>
    <script src="Scripts/custom-plugins/fileinput.js"></script>
    <!-- jQuery-UI Dependent Scripts -->
    <script src="Scripts/jui/js/jquery-ui-effects.min.js"></script>
    <!-- Plugin Scripts -->
    <script src="Scripts/plugins/validate/jquery.validate-min.js"></script>
    <!-- Login Script -->
    <script src="Scripts/js/core/login.js"></script>
    <title>MWS Admin - Login Page - (shared on themelock.com)</title>
</head>
<body>
    <div id="mws-login-wrapper">
        <div id="mws-login">
            <h1>
                Đăng nhập</h1>
            <div class="mws-login-lock">
                <i class="icon-lock"></i>
            </div>
            <div id="mws-login-form">
                <form class="mws-form" runat="server">
                <div class="mws-form-row">
                    <div class="mws-form-item">
                        <asp:TextBox ID="txtUser" runat="server" class="mws-login-username required" placeholder="Tên đăng nhập"></asp:TextBox>
                    </div>
                </div>
                <div class="mws-form-row">
                    <div class="mws-form-item">
                        <asp:TextBox ID="txtPass" runat="server" class="mws-login-password required" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div id="mws-login-remember" class="mws-form-row mws-inset">
                    <ul class="mws-form-list inline">
                        <li>
                            <input id="remember" type="checkbox">
                            <label for="remember">
                                Remember me</label>
                        </li>
                    </ul>
                </div>
                <div class="mws-form-row">
                    <asp:Button class="btn btn-success mws-login-button" Text="Login" runat="server"
                        OnClick="btnLogin_Click" ID="btnLogin" />
                </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
