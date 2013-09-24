<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChiPhi.ascx.cs" Inherits="FalStore.Control.ChiPhi" %>
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
                <span>Chi Phí kinh Doanh</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Nhập Thông tin</legend>
                        <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mô tả</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" 
                                        class="small" MaxLength="200"></asp:TextBox>
                                </div>
                            </div>
                         <div class="mws-form-row">
                            <label class="mws-form-label">Tổng số Tiền</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtTien" runat="server" class="" Visible="true"></asp:TextBox>
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
                            <asp:Button class="btn btn-primary" ID="btnSearch" runat="server" Text="Tạo mới" 
                                onclick="btnInsert_Click" />

                            <asp:Button class="btn btn-primary" ID="btnUpdate" runat="server" Text="Search Theo chi Nhánh" 
                                onclick="btnSearch_Click" />
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Nhập thông tin chi phí kinh doanh</span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
                                            <th>
                                                STT
                                            </th>
                                            <th>
                                                Chi Nhánh
                                            </th>
                                            <th>
                                                Mô Tả
                                            </th>
                                            <th>
                                                Tổng Tiền
                                            </th>
                                            <th>
                                                Ngày Chi Tiền
                                            </th>
                                            <th>
                                                Người Lập Phiếu
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                                        <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" 
                                            runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltr1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltr2"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltr3"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltr4"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltr5"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltr6"></asp:Literal>
                                                    </td>
                                                    
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
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