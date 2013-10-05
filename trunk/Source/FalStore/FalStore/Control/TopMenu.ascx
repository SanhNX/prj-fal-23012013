<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TopMenu.ascx.cs" Inherits="FalStore.Control.topmenu" %>
 <!-- JavaScript Plugins -->
    <script type="text/javascript" src="../Scripts/js/libs/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Scripts/js/libs/jquery.mousewheel.min.js"></script>
    <script type="text/javascript" src="../Scripts/js/libs/jquery.placeholder.min.js"></script>
    <script type="text/javascript" src="../Scripts/custom-plugins/fileinput.js"></script>
    <!-- jQuery-UI Dependent Scripts -->
    <script type="text/javascript" src="../Scripts/jui/js/jquery-ui-1.9.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/jui/jquery-ui.custom.min.js"></script>
    <script type="text/javascript" src="../Scripts/jui/js/jquery.ui.touch-punch.js"></script>
    <script type="text/javascript" src="../Scripts/jui/js/timepicker/jquery-ui-timepicker.min.js"></script>
    <!-- Plugin Scripts -->
    <script type="text/javascript" src="../Scripts/plugins/imgareaselect/jquery.imgareaselect.min.js"></script>
    <script type="text/javascript" src="../Scripts/plugins/jgrowl/jquery.jgrowl-min.js"></script>
    <script type="text/javascript" src="../Scripts/plugins/validate/jquery.validate-min.js"></script>
    <script type="text/javascript" src="../Scripts/plugins/colorpicker/colorpicker-min.js"></script>
    <!-- Core Script -->
    <script type="text/javascript" src="../Styles/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../Scripts/js/core/mws.js"></script>
    <!-- Themer Script (Remove if not needed) -->
    <script type="text/javascript" src="../Scripts/js/core/themer.js"></script>
    <!-- Demo Scripts (remove if not needed) -->
    <script type="text/javascript" src="../Scripts/js/demo/demo.widget.js"></script>

    <!-- fancybox --->
    <link rel="stylesheet" type="text/css" href="../Styles/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript" src="../Scripts/jquery.fancybox-1.3.4.js"></script>

    <script type="text/javascript">

        $(document).ready(function () {

            $(".fancyboxDemo").fancybox({
                'type': 'iframe'
			, 'width': $(window).width() * 0.40
			, 'height': $(window).height() * 0.80
			, 'autoScale': false
			, 'hideOnOverlayClick': false
			, 'onClosed': function () { }
            });
        });
 
</script>
<!-- Header -->
<div id="mws-header" class="clearfix">
    <!-- Logo Container -->
    <div id="mws-logo-container">
        <!-- Logo Wrapper, images put within this wrapper will always be vertically centered -->
        <div id="mws-logo-wrap">
            <img src="../Styles/Images/banner_Falshop.png" alt="mws admin">
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
                    <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                </div>
                <ul>
                    <li><a href="ChangePass.aspx" class="fancyboxDemo" >Change Password</a></li>
                    <li><a href="#">Logout</a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
