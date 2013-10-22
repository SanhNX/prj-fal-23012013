<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoiNhuan.ascx.cs" Inherits="FalStore.Control.LoiNhuan" %>
<!-- JavaScript Plugins -->
    <script src="Scripts/js/libs/jquery-1.8.3.min.js"></script>
    <script src="Scripts/js/libs/jquery.mousewheel.min.js"></script>
    <script src="Scripts/js/libs/jquery.placeholder.min.js"></script>
    <script src="Scripts/custom-plugins/fileinput.js"></script>
    <!-- jQuery-UI Dependent Scripts -->
    <script src="Scripts/jui/js/jquery-ui-1.9.2.min.js"></script>
    <script src="Scripts/jui/jquery-ui.custom.min.js"></script>
    <script src="Scripts/jui/js/jquery.ui.touch-punch.js"></script>
    <script src="Scripts/jui/js/timepicker/jquery-ui-timepicker.min.js"></script>
    <!-- Plugin Scripts -->
    <script src="Scripts/plugins/imgareaselect/jquery.imgareaselect.min.js"></script>
    <script src="Scripts/plugins/jgrowl/jquery.jgrowl-min.js"></script>
    <script src="Scripts/plugins/validate/jquery.validate-min.js"></script>
    <script src="Scripts/plugins/colorpicker/colorpicker-min.js"></script>
    <!-- Core Script -->
    <script src="Styles/bootstrap/js/bootstrap.min.js"></script>
    <script src="Scripts/js/core/mws.js"></script>
    <!-- Themer Script (Remove if not needed) -->
    <script src="Scripts/js/core/themer.js"></script>
    <!-- Demo Scripts (remove if not needed) -->
    <script src="Scripts/js/demo/demo.widget.js"></script>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Lợi Nhuận</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtStartDate" ForeColor="Red" runat="server" ErrorMessage="Chọn Ngày"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Đến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TxtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TxtEndDate" ForeColor="Red" runat="server" ErrorMessage="Chọn Ngày"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Chọn chi nhánh</label>
                            <div class="mws-form-item">
                                <asp:DropDownList ID="drpBranch" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset class="mws-form-inline">
                        <div class="mws-button-row">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" class="btn btn-danger" />
                            <asp:Button ID="Button1" runat="server" Text="Export Phiếu Nhập" OnClick="btnPn_Click" class="btn btn-danger" />
                            <asp:Button ID="Button2" runat="server" Text="Export CT Phiếu Nhập" OnClick="btnCtPn_Click" class="btn btn-danger" />
                            <asp:Button ID="Button3" runat="server" Text="Export Doanh Thu" OnClick="btnDt_Click" class="btn btn-danger" />
                             <asp:Button ID="Button4" runat="server" Text="Export Chi Phí kD" OnClick="btnCpKd_Click" class="btn btn-danger" />
                              <asp:Button ID="Button5" runat="server" Text="Export Phiếu Xuất" OnClick="btnPx_Click" class="btn btn-danger" />
                            <asp:Button ID="Button6" runat="server" Text="Export CT Phiếu Xuất" OnClick="btnCtPx_Click" class="btn btn-danger" />
                     <%--       <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" class="btn btn-danger"/>--%>
               <%--             <div class="">
                                <label class="mws-form-label" style="font-size: medium;width: 200px;">
                                    Tổng Cộng </label>
                                <div class="mws-form-item" style="font-size: medium;">
                                    <asp:Literal runat="server" ID="ltrDoanhThu" ></asp:Literal>
                                </div>
                            </div>--%>
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Danh sách thông tin tìm kiếm || <asp:Literal runat="server" ID="ltrDoanhThu" ></asp:Literal></span>
                            </div>
                            <div class="mws-panel-body no-padding">
                               <!-- Statistics Button Container -->
            	            <div class="mws-stat-container clearfix">
                	
                                <!-- Statistic Item -->
                	            <a class="mws-stat" href="#">
                    	            <!-- Statistic Icon (edit to change icon) -->
                    	            <span class="mws-stat-icon icol32-building"></span>
                        
                                    <!-- Statistic Content -->
                                    <span class="mws-stat-content">
                        	            <span class="mws-stat-title">Tổng Cộng Chi Phí Nhập Hàng Từ <asp:Literal runat="server" ID="sDate" ></asp:Literal> Đến <asp:Literal runat="server" ID="eDate" ></asp:Literal></span>
                                        <span class="mws-stat-value"><asp:Literal runat="server" ID="cpNhaphang" ></asp:Literal></span>
                                    </span>
                                </a>

                	            <a class="mws-stat" href="#">
                    	            <!-- Statistic Icon (edit to change icon) -->
                    	            <span class="mws-stat-icon icol32-chart-bar-add"></span>
                        
                                    <!-- Statistic Content -->
                                    <span class="mws-stat-content">
                        	            <span class="mws-stat-title"> <asp:Literal runat="server" ID="nameTc" ></asp:Literal> <asp:Literal runat="server" ID="sDate1" ></asp:Literal> Đến <asp:Literal runat="server" ID="eDate1" ></asp:Literal></span>
                                        <span class="mws-stat-value"><asp:Literal runat="server" ID="doanhthu" ></asp:Literal></span>
                                    </span>
                                </a>

                	            <a class="mws-stat" href="#">
                    	            <!-- Statistic Icon (edit to change icon) -->
                    	            <span class="mws-stat-icon icol32-chart-bar-delete"></span>
                        
                                    <!-- Statistic Content -->
                                    <span class="mws-stat-content">
                        	            <span class="mws-stat-title">Tổng Cộng Chí Phí Kinh Doanh Từ <asp:Literal runat="server" ID="sDate2" ></asp:Literal> Đến <asp:Literal runat="server" ID="eDate2" ></asp:Literal></span>
                                        <span class="mws-stat-value"><asp:Literal runat="server" ID="cpKinhDoanh" ></asp:Literal></span>
                                    </span>
                                </a>
                    
                	            <a class="mws-stat" href="#">
                    	            <!-- Statistic Icon (edit to change icon) -->
                    	            <span class="mws-stat-icon icol32-chart-pie"></span>
                        
                                    <!-- Statistic Content -->
                                    <span class="mws-stat-content">
                        	            <span class="mws-stat-title">Tổng Cộng lợi Nhuận Từ <asp:Literal runat="server" ID="sDate3" ></asp:Literal> Đến <asp:Literal runat="server" ID="eDate3" ></asp:Literal></span>
                                        <span class="mws-stat-value"><asp:Literal runat="server" ID="tongln" ></asp:Literal></span>
                                    </span>
                                </a>
                  
                            </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <!-- table -->
        <!--popup--->
    </div>
</div>