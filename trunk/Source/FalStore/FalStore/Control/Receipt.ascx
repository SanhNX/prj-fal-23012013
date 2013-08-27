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
                        <label class="mws-form-label">
                            Ngày lập phiếu</label>
                        <div class="mws-form-item">
                            <input type="text" class="large">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Người lập phiếu</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Option 1</option>
                                <option>Option 3</option>
                                <option>Option 4</option>
                                <option>Option 5</option>
                            </select>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Kho nhập</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Option 1</option>
                                <option>Option 3</option>
                                <option>Option 4</option>
                                <option>Option 5</option>
                            </select>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Kho xuất</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Option 1</option>
                                <option>Option 3</option>
                                <option>Option 4</option>
                                <option>Option 5</option>
                            </select>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Nội dung</label>
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
        <div class="mws-panel grid_4">
                	<div class="mws-panel-header">
                    	<span><i class="icon-warning-sign"></i> jQuery-UI Dialog</span>
                    </div>
                    <div class="mws-panel-body" style="text-align: center">
                    	<div class="mws-panel-content">
                        	<input type="button" id="mws-jui-dialog-btn" class="btn btn-danger" value="Show Dialog">
                        	<input type="button" id="mws-jui-dialog-mdl-btn" class="btn btn-primary" value="Show Modal Dialog">
                        	<input type="button" id="mws-form-dialog-mdl-btn" class="btn btn-success" value="Show Modal Form">
                            
                            <div id="mws-jui-dialog">
                        		<div class="mws-dialog-inner">
                            		<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nisi tellus, faucibus tristique faucibus sit amet, lacinia at velit. Proin pretium vulputate orci, nec luctus odio volutpat ac. Curabitur semper adipiscing tellus sed venenatis. Integer vitae diam dui. Ut ut quam ac ante eleifend aliquam. Cras tincidunt pulvinar sollicitudin. Nullam mattis justo nec nisl adipiscing ullamcorper. Curabitur fermentum egestas massa, eu dictum ligula accumsan id. Duis elit arcu, adipiscing vel consectetur ac, fermentum ac nisl. Quisque varius ipsum vitae mauris cursus eu tristique velit dapibus. Cras eu viverra neque.</p>
                                </div>
                            </div>
                            
                            <div id="mws-form-dialog">
                                <form id="mws-validate" class="mws-form" action="form_elements.html">
                                    <div id="mws-validate-error" class="mws-form-message error" style="display:none;"></div>
                                    <div class="mws-form-inline">
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">Required Validation</label>
                                            <div class="mws-form-item">
                                                <input type="text" name="reqField" class="required">
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">Email Validation</label>
                                            <div class="mws-form-item">
                                                <input type="text" name="emailField" class="required email">
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">URL Validation</label>
                                            <div class="mws-form-item">
                                                <input type="text" name="urlField" class="required url">
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">Date Validation</label>
                                            <div class="mws-form-item">
                                                <input type="text" class="mws-datepicker required date" readonly="readonly">
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">Select Box Validation</label>
                                            <div class="mws-form-item">
                                                <select class="required" name="selectBox">
                                                    <option></option>
                                                    <option>Option 1</option>
                                                    <option>Option 3</option>
                                                    <option>Option 4</option>
                                                    <option>Option 5</option>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">File Input Validation</label>
                                            <div class="mws-form-item">
                                                <input type="file" name="picture" class="required">
                                                <label for="picture" class="error" generated="true" style="display:none"></label>
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">Spinner Validation</label>
                                            <div class="mws-form-item">
                                                <input type="text" id="s1" name="spinner" class="required mws-spinner" value="10.5">
                                                <label for="s1" class="error" generated="true" style="display:none"></label>
                                            </div>
                                        </div>
                                        <div class="mws-form-row">
                                            <label class="mws-form-label">Radiobutton Validation</label>
                                            <div class="mws-form-item">
                                                <ul class="mws-form-list">
                                                    <li><input id="gender_male" type="radio" name="gender" class="required"> <label for="gender_male">Male</label></li>
                                                    <li><input id="gender_female" type="radio" name="gender"> <label for="gender_female">Female</label></li>
                                                </ul>
                                                <label for="gender" class="error plain" generated="true" style="display:none"></label>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>    	
                </div>
    </div>
</div>