<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectColor.aspx.cs" Inherits="FalStore.SelectColor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/plugins/colorpicker/colorpicker.css"
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

    <script type="text/javascript" src="../Scripts/js/libs/jquery-1.8.3.min.js"></script>
<script type="text/javascript" src="../Scripts/jui/js/jquery-ui-1.9.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#saveColor').on('click', function (e) {


                var abc = $("#TextBox1")[0].value + " " + $("#TextBox2")[0].value;
                alert(abc);
                parent.popupRetVal = [abc];
                parent.$.fancybox.close();
                // removeTR(indexRow);
                // indexSTT = indexSTT - 1;
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mws-wrapper">
        <!-- Main Container Start -->
        <div id="mws-container" class="clearfix">
            <!-- Inner Container Start -->
            <div class="container">
                <div class="mws-panel grid_8">
                    <div class="mws-panel-header">
                        <span>Chọn màu</span>
                        <asp:Label ID="lab" runat="server"></asp:Label>
                    </div>
                    <div class="mws-panel-body no-padding">
                        <div class="mws-form">
                            <div class="mws-form-row">
                                <div class="mws-form-cols">
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <div class="mws-form-cols">
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <div class="mws-form-cols">
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <div class="mws-form-cols">
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <div class="mws-form-cols">
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="mws-form-col-4-8">
                                        <label class="mws-form-label">
                                            Màu</label>
                                        <div class="mws-form-item">
                                            <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="mws-button-row">
                                <asp:Button ID="btnSave" runat="server" Text="Lưu màu" class="btn btn-danger"  OnClick="btnSave_Click"/>
                                <input type="button" id="saveColor" class="btn btn-danger" value="Show Dialog">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
