<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintBarCode.ascx.cs"
    Inherits="FalStore.Control.PrintBarCode" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div>
                <asp:Label ID="lblMessage" ForeColor="Green" runat="server" Text=""></asp:Label>
            </div>
            <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span>Thêm loại sản phẩm</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <div class="mws-form">
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã sản phẩm</label>
                                <div class="mws-form-item">
                                    <asp:TextBox ID="txtBarCode" runat="server" class="small" OnTextChanged="txtBarCode_TextChanged"
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
      
</script>
