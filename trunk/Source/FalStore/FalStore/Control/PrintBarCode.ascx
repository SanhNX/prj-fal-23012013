<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintBarCode.ascx.cs"
    Inherits="FalStore.Control.PrintBarCode" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
            <thead>
                <tr>
                    <th>
                        STT
                    </th>
                    <th>
                        BarCode
                    </th>
                    <th>
                        Mã sản phẩm
                    </th>
                    <th>
                        Tên sản phẩm
                    </th>
                    <th>
                        Màu sắc
                    </th>
                    <th>
                        Size
                    </th>
                    <th>
                        Giá Nhập
                    </th>
                     <th>
                        Giá Bán
                    </th>
                    <th>
                    </th>
                </tr>
            </thead>
            <tbody role="alert" aria-live="polite" aria-relevant="all">
                <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand"
                    runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrBarCode"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrProducID"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrProductName"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrColor"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrSize"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrImportPrice"></asp:Literal>
                            </td>
                            <td>
                                <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                            </td>
                            <td>
                                <i class="icon-barcode"></i>
                               <%-- <a onclick="ShowInfo(<asp:Literal runat="server" ID="priBarCode"></asp:Literal>)">In mã vạch</a>--%>
                               <%-- <input id="Button2" type="button" value="In mã vạch" class="btn btn-success" onclick="ShowInfo()" />--%>
                                <asp:LinkButton ID="lnkBarcode" runat="server" CausesValidation="false" CommandName="Barcode"
                                    CommandArgument='<%# DataBinder.Eval(Container.DataItem, "BarCode")%>'>Chọn mã vạch</asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div>
                <asp:Label ID="lblMessage" ForeColor="Green" runat="server" Text=""></asp:Label>
            </div>
            <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span>Thêm loại mã vạch</span>
                </div> 
                <div class="mws-panel-body no-padding">
                    <div class="mws-form">
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã Vạch</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtBarCode" runat="server" class="small"  Enabled="false"
                                        AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập tên sản phẩm"
                                        ControlToValidate="txtBarCode" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Tên sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtProductName" runat="server" class="small" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Giá bán</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtPrice" runat="server" class="small" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <asp:Button ID="Button1" runat="server" Text="Xem mã vạch" class="btn btn-success"
                                OnClick="ClickShow_Click" />
                            <input id="Button2" type="button" value="In mã vạch" class="btn btn-success" onclick="PrintBarCode('barcode')" />
                        </div>
                        <div id="barcode" class="ExampleFont">
                            <asp:Table ID="Table1" runat="server">
                            </asp:Table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">

    function PrintBarCode(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=0,top=0,width=1,height=1,toolbar=0,scrollbars=0,status=0');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();

    }

    function ShowInfo(strid) {
        alert("thanh" + strid);

    }
      
</script>
