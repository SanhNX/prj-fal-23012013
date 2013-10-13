<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePass.aspx.cs" Inherits="FalStore.ChangePass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="Styles/plugins/colorpicker/colorpicker.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/custom-plugins/wizard/wizard.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/plugins/imgareaselect/css/imgareaselect-default.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/plugins/jgrowl/jquery.jgrowl.css"
        media="screen">
    <!-- Required Stylesheets -->
    <link rel="stylesheet" type="text/css" href="Styles/bootstrap/css/bootstrap.min.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/fonts/ptsans/stylesheet.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/fonts/icomoon/style.css"
        media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/mws-style.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/icons/icol16.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/icons/icol32.css" media="screen">
    <!-- Demo Stylesheet -->
    <link rel="stylesheet" type="text/css" href="Styles/css/demo.css" media="screen">
    <!-- jQuery-UI Stylesheet -->
    <link rel="stylesheet" type="text/css" href="Styles/jui/css/jquery.ui.all.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/jui/jquery-ui.custom.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Scripts/jui/css/jquery.ui.timepicker.css"
        media="screen">
    <!-- Theme Stylesheet -->
    <link rel="stylesheet" type="text/css" href="Styles/css/mws-theme.css" media="screen">
    <link rel="stylesheet" type="text/css" href="Styles/css/themer.css" media="screen">

    <!-- fancybox --->
<script type="text/javascript" src="../Scripts/js/libs/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="../Scripts/jui/js/jquery-ui-1.9.2.min.js"></script>
<!-- fancybox --->
<link rel="stylesheet" type="text/css" href="../Styles/jquery.fancybox-1.3.4.css"
    media="screen" />
<script type="text/javascript" src="../Scripts/jquery.fancybox-1.3.4.js"></script>

</head>
<body>
    <div class="mws-panel grid_4">
                    <div class="mws-panel-header">
                        <span>Thay Đổi Mật Khẩu</span>
                    </div>
                    <div class="mws-panel-body no-padding">
                        <form class="mws-form" runat="server" >
                            <div class="mws-form-inline">
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">User Name</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtUserName" runat="server" CssClass="large"  Visible="true" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">Mật Khẩu Cũ</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtOldPass" TextMode="Password" runat="server" class="large"  Visible="true"></asp:TextBox>
                                        <asp:Label id="lblMessage" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                                        <asp:RequiredFieldValidator ID="txtOldPassRequiredFieldValidator" runat="server" ErrorMessage="Không được để trống"
                                        ControlToValidate="txtOldPass" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">Mật Khẩu Mới</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtNewPass" TextMode="Password" runat="server" class="large"  Visible="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtNewPassRequiredFieldValidator" runat="server"  Display="Dynamic" ErrorMessage="Không được để trống"
                                        ControlToValidate="txtNewPass" ForeColor="Red"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="txtNewPassCustomValidator" runat="server"  Display="Dynamic" ControlToValidate="txtNewPass" ValidationExpression="[A-Za-z0-9]{8,16}" ErrorMessage="Mật khẩu phải từ 8-16 ký tự" ForeColor="Red"/>
                                    </div>
                                </div>
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">Xác Nhận Mật Khẩu</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtNewPassConfirm" TextMode="Password" runat="server" class="large"  Visible="true"></asp:TextBox>
                                        <asp:CompareValidator ID="txtNewPassConfirmCompareValidator" ControlToValidate="txtNewPass" ControlToCompare="txtNewPassConfirm" ForeColor="Red"  ErrorMessage="Xác nhận mật khẩu chưa đúng" runat="server" class="large" Visible="true" ></asp:CompareValidator>
                                    </div>
                                </div>
                          
                            </div>
                            <div class="mws-button-row">
                                <asp:Button ID="btnChangePass" runat="server" Text="Submit" class="btn btn-danger" OnClick="btnChangePass_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset" class="btn" OnClick="btnReset_Click" />
                            </div>
                        </form>
                    </div>      
                </div>
</body>
</html>
