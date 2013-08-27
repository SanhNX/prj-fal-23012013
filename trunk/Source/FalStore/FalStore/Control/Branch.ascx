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
        <div class="mws-panel grid_8">
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
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                1
                            </td>
                            <td>
                                CN001
                            </td>
                            <td>
                                Chi nhánh Tân Bình
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                100, Lý Thường Kiệt, Tân Bình
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2
                            </td>
                            <td>
                                CN002
                            </td>
                            <td>
                                Chi nhánh Gò Vấp
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                200, Nguyễn Oanh, Gò Vấp
                            </td>
                        </tr>
                        <tr>
                            <td>
                                3
                            </td>
                            <td>
                                CN003
                            </td>
                            <td>
                                Chi nhánh Phú Nhuận
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                300, Hồ Văn Huê, Phú Nhuận
                            </td>
                        </tr>
                        <tr>
                            <td>
                                4
                            </td>
                            <td>
                                CN004
                            </td>
                            <td>
                                Chi nhánh Thủ Đức
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                400, Võ Văn Ngân, Thủ Đức
                            </td>
                        </tr>
                        <tr>
                            <td>
                                5
                            </td>
                            <td>
                                CN005
                            </td>
                            <td>
                                Chi nhánh Bình Tân
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                500, Lạc Long Quân, Bình Tân
                            </td>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>