<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Branch.ascx.cs" Inherits="FalStore.Control.Branch" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Chi nhánh</span>
            </div>
            <div class="mws-panel-body no-padding">
                <form class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mã chi nhánh</label>
                        <div class="mws-form-item">
                            <input type="text" class="small">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Tên chi nhánh</label>
                        <div class="mws-form-item">
                            <input type="text" class="large">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mô tả</label>
                        <div class="mws-form-item">
                            <textarea rows="" cols="" class="large"></textarea>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Địa chỉ</label>
                        <div class="mws-form-item">
                            <textarea rows="" cols="" class="large"></textarea>
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
        <!-- table -->
        <div class="mws-panel grid_8 mws-collapsible">
            <div class="mws-panel-header">
                <span><i class="icon-table"></i>Danh sách</span>
            </div>
            <div class="mws-panel-body no-padding">
                <table class="mws-table">
                    <thead>
                        <tr>
                            <th>
                                Số thứ tự
                            </th>
                            <th>
                                Mã chi nhánh
                            </th>
                            <th>
                                Tên chi nhánh
                            </th>
                            <th>
                                Mô tả
                            </th>
                            <th>
                                Địa chỉ
                            </th>
                            <th>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptResult" OnItemDataBound="rptResult_ItemDataBound" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrStt"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrBranchID"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrBranchName"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrDescription"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Literal runat="server" ID="ltrAddress"></asp:Literal>
                                    </td>
                                    <td>
                                        <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                        </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                            class="btn btn-small"><i class="icon-trash"></i></a></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
