<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="User.ascx.cs" Inherits="FalStore.Control.User" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Quản lý người dùng</span>
            </div>
            <div class="mws-panel-body no-padding">
                <div class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Tên đăng nhập</label>
                        <div class="mws-form-item">
                            <input type="text" class="small">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mật khẩu</label>
                        <div class="mws-form-item">
                            <input type="text" class="large">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Nhân viên</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>NGUYỄN VĂN A</option>
                                <option>TRẦN THỊ B</option>
                                <option>NGUYỄN THỊ C</option>
                                <option>TRẦN THỊ D</option>
                                <option>NGUYỄN VĂN E</option>
                                <option>LÝ VĂN F</option>
                                <option>NGUYỄN VĂN G</option>
                                <option>NGUYỄN THỊ H</option>
                                <option>NGUYỄN VĂN I</option>
                                <option>LÝ VĂN J</option>
                            </select>
                        </div>
                    </div>
                    
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Chức vụ</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Quản lý</option>
                                <option>Nhân viên</option>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="mws-button-row">
                    <input type="submit" value="Submit" class="btn btn-danger">
                    <input type="reset" value="Reset" class="btn ">
                </div>
                </div>
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
                                Tên đăng nhập
                            </th>
                            <th>
                                Mật khẩu
                            </th>
                            <th>
                                Nhân viên
                            </th>
                            <th>
                                Chức vụ
                            </th>
                              <th>
                                Chi nhánh
                            </th>
                            <th>
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                1
                            </td>
                            <td>
                                U0001
                            </td>
                            <td>
                                ********
                            </td>
                            <td>
                                NGUYỄN VĂN A
                            </td>
                            <td>
                                Quản lý
                            </td>
                            <td>
                                Chi nhanh A
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2
                            </td>
                            <td>
                                U0002
                            </td>
                            <td>
                                ********
                            </td>
                            <td>
                                TRẦN VĂN B
                            </td>
                            <td>
                                Quản lý
                            </td>
                            <td>
                                Chi nhanh B
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                3
                            </td>
                            <td>
                                U0003
                            </td>
                            <td>
                                ********
                            </td>
                            <td>
                                NGUYỄN THỊ C
                            </td>
                            <td>
                                Nhân viên
                            </td>
                            <td>
                                Chi nhanh B
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                4
                            </td>
                            <td>
                                U0004
                            </td>
                            <td>
                                ********
                            </td>
                            <td>
                                TRẦN THỊ D
                            </td>
                            <td>
                                Nhân viên
                            </td>
                            <td>
                                Chi nhanh D
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                5
                            </td>
                            <td>
                                U0005
                            </td>
                            <td>
                                ********
                            </td>
                            <td>
                                NGUYỄN VĂN I
                            </td>
                            <td>
                                Nhân viên
                            </td>
                            <td>
                                Chi nhanh E
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                6
                            </td>
                            <td>
                                U0006
                            </td>
                            <td>
                                ********
                            </td>
                            <td>
                                LÝ VĂN J
                            </td>
                            <td>
                                Nhân viên
                            </td>
                            <td>
                                Chi nhanh A
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>