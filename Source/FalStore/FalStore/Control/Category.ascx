<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="FalStore.Control.Category" %>
<!-- Main Container Start -->
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Danh mục sản phẩm</span>
            </div>
            <div class="mws-panel-body no-padding">
                <form class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mã danh mục</label>
                        <div class="mws-form-item">
                            <input type="text" class="small">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Tên danh mục</label>
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
                            Lựa chọn</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Option 1</option>
                                <option>Option 3</option>
                                <option>Option 4</option>
                                <option>Option 5</option>
                            </select>
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
                            <th></th>
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
                            <td>
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
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
                            <td>
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
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
                            <td>
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
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
                            <td>
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
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
                            <td>
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
                                    </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
