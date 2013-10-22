<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExportProduct.ascx.cs"
    Inherits="FalStore.Control.ExportProduct" %>

<script type="text/javascript">

    $(document).ready(function () {

        $(".fancyboxDemo").fancybox({
            'type': 'iframe'
   , 'width': $(window).width() * 0.80
   , 'height': $(window).height() * 0.90
   , 'autoScale': false
   , 'hideOnOverlayClick': true
   , 'onStart': function () {
       TranferData();
   }
   , 'onClosed': function () {
       var stt = 0;
       var temp = "";
       var arr = new Array();
       if (typeof popupRetVal != 'undefined' && popupRetVal != null) {
           if (popupRetVal.length > 0) {
               for (var i = 0; i < popupRetVal.length; i++) {
                   if (popupRetVal.charAt(i) == "=") {

                       arr[stt] = temp;

                       stt++;

                       temp = "";

                   } else {
                       temp = temp + popupRetVal.charAt(i);
                   }
               }
           }
       }
       if (arr.length > 0) {
           $("#ContentPlaceHolder1_ctl00_txtSize")[0].value = temp;
           for (var j = 0; j < arr.length; j++) {
               if (j == 0) {
                   $("#ContentPlaceHolder1_ctl00_txtBarCode")[0].value = arr[j];
               }

               if (j == 1) {
                   $("#ContentPlaceHolder1_ctl00_txtProductName")[0].value = arr[j];
               }

               if (j == 3) {
                   $("#ContentPlaceHolder1_ctl00_txtExportPrice")[0].value = arr[j];
               }

               if (j == 4) {
                   $("#ContentPlaceHolder1_ctl00_txtColor")[0].value = arr[j];
               }

           }
       }
       //window.location.href = '<%= Page.ResolveUrl("~/Default.aspx?pageName=ExportProduct") %>';
   }
        });
    });

</script>
<script type="text/jscript">
    function TranferData() {
        var ma = document.getElementById('<%= txtLogStoreID.ClientID %>').value;
        var ncc = '';
        var nd = document.getElementById('<%= txtDescription.ClientID %>').value;
        document.getElementById('lnkFindProduct').href = "FindProduct.aspx?ma=" + ma + "&&ncc=" + ncc + "&&nd=" + nd ;

    }
 
</script>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Xuất kho</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form">
                    <fieldset class="mws-form-inline">
                        <legend>Thông tin phiếu xuất</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mã phiếu xuất</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtLogStoreID" runat="server" class="small" Enabled="false"></asp:TextBox>
                                <asp:Button ID="btnCreate" runat="server" Text="Tạo phiếu" class="btn btn-success"
                                    CausesValidation="false" OnClick="btnCreate_Click" />
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Ngày lập phiếu</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtLogDate" runat="server" class="small" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Người lập phiếu</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtEmployee" runat="server" class="small" Enabled="false" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Kho xuất</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpBranchFrom" runat="server" class="small">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Kho nhập</label>
                                    <div class="mws-form-item">
                                        <asp:DropDownList ID="drpBranchTo" runat="server" class="small">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Nội dung</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="large"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                    <fieldset class="mws-form-inline">
                        <legend>Chọn sản phẩm</legend>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mã vạch</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtBarCode" runat="server" class="small" AutoPostBack="true" OnTextChanged="txtBarCode_TextChanged"></asp:TextBox>
                                  <a id="lnkFindProduct" class="fancyboxDemo" style="cursor: pointer" >Chọn sản phẩm
                                </a>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Tên sản phẩm</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtProductName" runat="server" class="small" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Giá bán</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtExportPrice" runat="server" class="small" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <div class=" mws-form-cols">
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Màu sắc</label>
                                    <div class="mws-form-item">
                                        <asp:TextBox ID="txtColor" runat="server" class="small" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="mws-form-col-4-8">
                                    <label class="mws-form-label">
                                        Size</label>
                                    <div class="mws-form-item">
                                         <asp:TextBox ID="txtSize" runat="server" class="small" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Chiết khấu</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtSale1" runat="server" class="small" MaxLength="2"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nhập Chiếc khấu , Và phải là số"
                                        ControlToValidate="txtSale1" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSale1" ForeColor="Red" runat="server" ErrorMessage="Nhập Chiếc khấu , Và phải là số" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Số lượng</label>
                            <div class="mws-form-item">
                                <asp:TextBox ID="txtQuantity1" runat="server" class="small" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldQuantity" ControlToValidate="txtQuantity1" runat="server" ForeColor="Red" ErrorMessage="Nhập Số lượng , Và phải là số"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionQuantity" ControlToValidate="txtQuantity1" ForeColor="Red" runat="server" ErrorMessage="Nhập Số lượng , Và phải là số" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="mws-button-row">
                            <asp:Button ID="btnAddProduct" runat="server" Text="Thêm sản phẩm" 
                                class="btn btn-success" OnClick="btnAddProduct_Click" />
                        </div>
                        <div class="mws-panel grid_8">
                            <div class="mws-panel-header">
                                <span><i class="icon-table"></i>Thông tin sản phẩm</span>
                            </div>
                            <div class="mws-panel-body no-padding">
                                <table class="mws-table">
                                    <thead>
                                        <tr>
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
                                                Giá tiền
                                            </th>
                                            <th>
                                                Số lượng
                                            </th>
                                            <th>
                                                Chiết khấu
                                            </th>
                                            <th>
                                                Thành tiền
                                            </th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody role="alert" aria-live="polite" aria-relevant="all">
                                        <asp:Repeater ID="rptResult" runat="server" OnItemDataBound="rptResult_ItemDataBound" OnItemCommand="rptResult_ItemCommand">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrProductID"></asp:Literal>
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
                                                        <asp:Literal runat="server" ID="ltrExportPrice"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrQuantity"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrSale"></asp:Literal>
                                                    </td>
                                                    <td>
                                                        <asp:Literal runat="server" ID="ltrAmount"></asp:Literal>
                                                    </td>
                                                      <td>
                                                     <i class="icon-trash"></i>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure?')" CommandName="Delete"
                                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "LogDetailID") %>'>Xóa</asp:LinkButton>
                                                </td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div align ="right">
                            Tổng tiền<asp:TextBox ID="txtTotal" runat="server" Enabled="false" Text="0"></asp:TextBox>
                        </div>
                    </fieldset>
                    <div class="mws-button-row">
                        <asp:Button ID="btnAdd" runat="server" Text="Lập phiếu" class="btn btn-success" OnClick="btnAdd_Click" />
                    </div>
                </div>
            </div>
        </div>
        <!-- table -->
        <!--popup--->
    </div>
</div>
