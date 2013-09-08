<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintBarCode.ascx.cs"
    Inherits="FalStore.Control.PrintBarCode" %>
<label>
    Nhap ma san pham</label>
<br />
<asp:Label ID="lblBarCode" runat="server" Text="Mã sản phẩm"></asp:Label>
<asp:TextBox ID="txtBarCode" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="lblProductName" runat="server" Text="Tên sản phẩm"></asp:Label>
<asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="lblPrice" runat="server" Text="Đơn giá"></asp:Label>
<asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
<br />
<asp:Button ID="Button1" runat="server" Text="Convert barcode" OnClick="ClickShow_Click" />
<input id="Button2" type="button" value="Print" onclick="PrintBarCode('barcode')" />

<div id="barcode">
    <asp:Table ID="Table1" runat="server">
    </asp:Table>
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
