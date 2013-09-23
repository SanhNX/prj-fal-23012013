<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event.ascx.cs" Inherits="FalStore.Control.Event" %>
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
                <span>Thông tin kho</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin tìm kiếm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">Tên Chương Trình</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TextBox1" runat="server" class="large" Visible="true" ></asp:TextBox>
                            </div>
                        </div>
                         <div class="mws-form-row">
                            <label class="mws-form-label">Giảm Giá</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TextBox2" runat="server" class="" Visible="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">Từ ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtStartDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="mws-form-row">
                            <label class="mws-form-label">Dến ngày</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="TxtEndDate" runat="server" class="mws-dtpicker" Visible="true"></asp:TextBox>
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
                                onclick="btnSearch_Click" />

                            <asp:Button class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update" 
                                onclick="btnUpdate_Click" />
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Nhập thông tin khuyến mãi</span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
                                            <th>
                                                STT
                                            </th>
                                            <th>
                                                Chuong trình
                                            </th>
                                            <th>
                                                Giảm Giá (%)
                                            </th>
                                            <th>
                                                Chi Nhánh
                                            </th>
                                            <th>
                                                Ngày Bắt Đầu
                                            </th>
                                            <th>
                                                Ngày Kết Thúc
                                            </th>
                                            <th>
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">

                                        <tr>
                                            <td>1</td>
                                            <td>Khai trương</td>
                                            <td>10</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>2</td>
                                            <td>Khai trương</td>
                                            <td>10</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>3</td>
                                            <td>Khai trương</td>
                                            <td>10</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>4</td>
                                            <td>Khai trương</td>
                                            <td>10</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td>Khai trương</td>
                                            <td>20</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>5</td>
                                            <td>Khai trương</td>
                                            <td>20</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>7</td>
                                            <td>Khai trương</td>
                                            <td>10</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>8</td>
                                            <td>Khai trương</td>
                                            <td>10</td>
                                            <td>Phú Nhuận</td>
                                            <td>2013-09-20</td>
                                            <td>2013-11-20</td>
                                            <td>
                                                <span class="btn-group">
                                                    <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                                    <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                                </span>
                                            </td>
                                        </tr>
                                        <%--<asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand"
                                            runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrBillId"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrEmpName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrCusName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrBranchName"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrPrice1"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSale"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrPrice2"></asp:Literal>
                                                    </td>
                                                    <td>
                                                      <%-- <%-- <i class="icon-pencil"></i>
                                                        <asp:LinkButton ID="lnkView" runat="server" CausesValidation="false" CommandName="View"
                                                            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ProductID") %>'>Xem</asp:LinkButton>
                                       
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>--%>
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