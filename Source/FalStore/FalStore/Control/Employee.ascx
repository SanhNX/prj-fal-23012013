<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Employee.ascx.cs" Inherits="FalStore.Control.Employee" %>
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Thông tin nhân viên</span>
            </div>
            <div class="mws-panel-body no-padding">
                <form class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mã nhân viên</label>
                        <div class="mws-form-item">
                            <input type="text" class="small">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Tên nhân viên</label>
                        <div class="mws-form-item">
                            <input type="text" class="large">
                        </div>
                    </div>
                     <div class="mws-form-row">
                    				<label class="mws-form-label">Giới tính</label>
                    				<div class="mws-form-item clearfix">
                    					<ul class="mws-form-list inline">
                    						<li><input type="radio"> <label>Nam</label></li>
                    						<li><input type="radio"> <label>Nữ</label></li>
                    							</ul>
                    				</div>
                    			</div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Địa chỉ</label>
                        <div class="mws-form-item">
                            <textarea rows="" cols="" class="large"></textarea>
                        </div>
                    </div>
                      <div class="mws-form-row">
                        <label class="mws-form-label">
                            Số điện thoại</label>
                        <div class="mws-form-item">
                            <input type="text" class="large">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Ghi chú</label>
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
                                Mã nhân viên
                            </th>
                            <th>
                                Tên nhân viên
                            </th>
                            <th>
                                Giới tính
                            </th>
                            <th>
                                Địa chỉ
                            </th>
                            <th>
                                Điện thoại
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                1
                            </td>
                            <td>
                                NV001
                            </td>
                            <td>
                                NGUYỄN VĂN A
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                HCM
                            </td>
                            <td>
                                090.000.000.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                2
                            </td>
                            <td>
                                NV002
                            </td>
                            <td>
                                TRẦN VĂN B
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                Đồng Nai
                            </td>
                            <td>
                                090.111.000.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                3
                            </td>
                            <td>
                                NV003
                            </td>
                            <td>
                                NGUYỄN THỊ C
                            </td>
                            <td>
                                Nữ
                            </td>
                            <td>
                                Tiền Giang
                            </td>
                            <td>
                                090.000.222.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                4
                            </td>
                            <td>
                                NV004
                            </td>
                            <td>
                                TRẦN THỊ D
                            </td>
                            <td>
                                Nữ
                            </td>
                            <td>
                                Bình Thuận
                            </td>
                            <td>
                                090.000.333.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                5
                            </td>
                            <td>
                                NV005
                            </td>
                            <td>
                                NGUYỄN VĂN E
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                Bến Tre
                            </td>
                            <td>
                                090.000.000.444
                            </td>
                        </tr>
                         <tr>
                            <td>
                                6
                            </td>
                            <td>
                                NV006
                            </td>
                            <td>
                                LÝ VĂN F
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                Bình Dương
                            </td>
                            <td>
                                090.000.555.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                7
                            </td>
                            <td>
                                NV007
                            </td>
                            <td>
                                NGUYỄN VĂN G
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                Tây Ninh
                            </td>
                            <td>
                                090.000.000.666
                            </td>
                        </tr>
                         <tr>
                            <td>
                                8
                            </td>
                            <td>
                                NV008
                            </td>
                            <td>
                                NGUYỄN THỊ H
                            </td>
                            <td>
                                Nữ
                            </td>
                            <td>
                                Hà Nội
                            </td>
                            <td>
                                090.777.000.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                9
                            </td>
                            <td>
                                NV009
                            </td>
                            <td>
                                NGUYỄN VĂN I
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                Long An
                            </td>
                            <td>
                                090.888.000.000
                            </td>
                        </tr>
                         <tr>
                            <td>
                                10
                            </td>
                            <td>
                                NV010
                            </td>
                            <td>
                                LÝ VĂN J
                            </td>
                            <td>
                                Nam
                            </td>
                            <td>
                                Bình Phước
                            </td>
                            <td>
                                090.000.999.000
                            </td>
                        </tr>
          
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>