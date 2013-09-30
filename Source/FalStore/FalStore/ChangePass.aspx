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
                        <form class="mws-form" action="form_layouts.html">
                            <div class="mws-form-inline">
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">User Name</label>
                                    <div class="mws-form-item">
                                        <input type="text" class="small" disabled="true">
                                    </div>
                                </div>
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">Mật Khẩu Cũ</label>
                                    <div class="mws-form-item">
                                        <input type="password" class="small">
                                    </div>
                                </div>
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">Mật Khẩu Mới</label>
                                    <div class="mws-form-item">
                                        <input type="password" class="small">
                                    </div>
                                </div>
                                <div class="mws-form-row bordered">
                                    <label class="mws-form-label">Xác Nhận Mật Khẩu</label>
                                    <div class="mws-form-item">
                                        <input type="password" class="small">
                                    </div>
                                </div>
                          
                            </div>
                            <div class="mws-button-row">
                                <input type="submit" value="Submit" class="btn btn-danger">
                                <input type="reset" value="Reset" class="btn ">
                            </div>
                        </form>
                    </div>      
                </div>
</body>
</html>
