<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Receipt.ascx.cs" Inherits="FalStore.Control.Receipt" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Nhập hàng</span>
            </div>
            <div class="mws-panel-body no-padding">
                <form class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mã phiếu</label>
                        <div class="mws-form-item">
                            <input type="text" class="small">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <div class=" mws-form-cols">
                            <div class="mws-form-col-4-8">
                                <label class="mws-form-label">
                                    Ngày lập phiếu</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </div>
                            <div class="mws-form-col-4-8">
                                <label class="mws-form-label">
                                    Người lập phiếu</label>
                                <div class="mws-form-item">
                                    <select class="large">
                                        <option>NGUYỄN VĂN A</option>
                                        <option>TRẦN THỊ B</option>
                                        <option>LÝ VĂN I</option>
                                        <option>NGUYỄN THỊ C</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <div class=" mws-form-cols">
                            <div class="mws-form-col-4-8">
                                <label class="mws-form-label">
                                    Kho nhập</label>
                                <div class="mws-form-item">
                                    <select class="large">
                                        <option>Kho chính</option>
                                        <option>Kho chi nhánh 1</option>
                                        <option>Kho chi nhánh 2</option>
                                        <option>Kho chi nhánh 3</option>
                                    </select>
                                </div>
                            </div>
                            <div class="mws-form-col-4-8">
                                <label class="mws-form-label">
                                    Nhà cung cấp</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Nội dung</label>
                        <div class="mws-form-item">
                            <textarea rows="" cols="" class="large"></textarea>
                        </div>
                    </div>
                    <%--<table class="mws-form-inline">
                        <tr  class="mws-form-row">
                            <td colspan="2">
                                <label class="mws-form-label">
                                    Mã phiếu</label>
                                <div class="mws-form-item">
                                    <input type="text" class="small"></div>
                            </td>
                        </tr>
                        <tr  class="mws-form-row">
                            <td>
                                <label class="mws-form-label">
                                    Ngày lập phiếu</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </td>
                            <td>
                                <label class="mws-form-label">
                                    Người lập phiếu</label>
                                <div class="mws-form-item">
                                    <select class="large">
                                        <option>NGUYỄN VĂN A</option>
                                        <option>TRẦN THỊ B</option>
                                        <option>LÝ VĂN I</option>
                                        <option>NGUYỄN THỊ C</option>
                                    </select>
                                </div>
                            </td>
                        </tr>
                        <tr  class="mws-form-row">
                            <td>
                                <label class="mws-form-label">
                                    Kho nhập</label>
                                <div class="mws-form-item">
                                    <select class="large">
                                        <option>Kho chính</option>
                                        <option>Kho chi nhánh 1</option>
                                        <option>Kho chi nhánh 2</option>
                                        <option>Kho chi nhánh 3</option>
                                    </select>
                                </div>
                            </td>
                            <td>
                                <label class="mws-form-label">
                                    Nhà cung cấp</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </td>
                        </tr >
                        <tr  class="mws-form-row">
                            <td colspan="2">
                                <label class="mws-form-label">
                                    Nội dung</label>
                                <div class="mws-form-item">
                                    <textarea rows="" cols="" class="large"></textarea>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr  class="mws-form-row">
                            <td colspan="2">
                                <label class="mws-form-label">
                                    Nhà cung cấp</label>
                                <div class="mws-form-item">
                                    <input type="text" class="large">
                                </div>
                            </td>
                        </tr>
                    </table>--%>
                </div>
                <div class="mws-button-row">
                    <input type="submit" value="Submit" class="btn btn-danger">
                    <input type="reset" value="Reset" class="btn ">
                    <input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Chọn sản phẩm">
                    <div id="mws-form-dialog">
                        <form id="mws-validate" class="mws-form">
                        <div id="mws-validate-error" class="mws-form-message error" style="display: none;">
                        </div>
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã phiếu</label>
                                <div class="mws-form-item">
                                    <input type="text" class="small">
                                </div>
                            </div>
                        </div>
                        </form>
                    </div>
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
                                Mã danh mục
                            </th>
                            <th>
                                Tên danh mục
                            </th>
                            <th>
                                Mô tả
                            </th>
                            <th>
                                Lựa chọn
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                1
                            </td>
                            <td>
                                001
                            </td>
                            <td>
                                ÁO VEST
                            </td>
                            <td>
                                Áo vest
                            </td>
                            <td>
                                X
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2
                            </td>
                            <td>
                                002
                            </td>
                            <td>
                                ÁO THUN NAM
                            </td>
                            <td>
                                Áo thun nam
                            </td>
                            <td>
                                X
                            </td>
                        </tr>
                        <tr>
                            <td>
                                3
                            </td>
                            <td>
                                003
                            </td>
                            <td>
                                SƠ MI NAM
                            </td>
                            <td>
                                Áo somi nam
                            </td>
                            <td>
                                A
                            </td>
                        </tr>
                        <tr>
                            <td>
                                4
                            </td>
                            <td>
                                004
                            </td>
                            <td>
                                QUẦN JEAN, KAKI
                            </td>
                            <td>
                                Quần jean, kaki
                            </td>
                            <td>
                                A
                            </td>
                        </tr>
                        <tr>
                            <td>
                                5
                            </td>
                            <td>
                                005
                            </td>
                            <td>
                                QUẦN SHORT
                            </td>
                            <td>
                                Quần short ngắn
                            </td>
                            <td>
                                A
                            </td>
                    </tbody>
                </table>
            </div>
        </div>
        <!--popup--->
        <%--<div class="mws-panel grid_4">
            <div class="mws-panel-body" style="text-align: center">
                <div class="mws-panel-content">
                    <input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Show Modal Form">
                    <div id="mws-form-dialog">
                        <form id="mws-validate" class="mws-form">
                        <div id="mws-validate-error" class="mws-form-message error" style="display: none;">
                        </div>
                        <div class="mws-form-inline">
                            <div class="mws-form-row">
                                <label class="mws-form-label">
                                    Mã phiếu</label>
                                <div class="mws-form-item">
                                    <input type="text" class="small">
                                </div>
                            </div>
                        </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
</div>