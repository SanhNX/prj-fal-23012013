<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="FalStore.Control.Category" %>
<!-- Main Container Start -->
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
             <div class="mws-panel grid_8 mws-collapsible">
                <div class="mws-panel-header">
                    <span>Thêm loại sản phẩm</span>
                </div>
                <div class="mws-panel-body no-padding">
                    <form class="mws-form" action="form_layouts.html">
                    <div class="mws-form-inline">
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mã danh mục</label>
                            <div class="mws-form-item">
                                <input type="text" class="small" value="011" disabled="true"></input>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Tên danh mục</label>
                            <div class="mws-form-item">
                                <input type="text" class="large" value="Quần Jean"></input>
                            </div>
                        </div>
                        <div class="mws-form-row">
                            <label class="mws-form-label">
                                Mô tả</label>
                            <div class="mws-form-item">
                                <textarea rows="" cols="" class="large" ></textarea>
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
        </div>
        <!-- table -->
        <div class="mws-panel grid_8 mws-collapsible">

            <div class="mws-panel-header">
                <span><i class="icon-table"></i>Danh sách loại sản phẩm</span>
            </div>

            <div class="mws-panel-body no-padding">
                <div id="DataTables_Table_1_wrapper" class="dataTables_wrapper" role="grid">
                    <!-- serach -->
                    <div id="DataTables_Table_1_length" class="dataTables_length">
			            <label>Show 
				            <select size="1" name="DataTables_Table_1_length" aria-controls="DataTables_Table_1">
					            <option value="10" selected="selected">10</option>
					            <option value="25">25</option>
					            <option value="50">50</option>
					            <option value="100">100</option>
					            </select> entries
			            </label>
		            </div>
		            <div class="dataTables_filter" id="DataTables_Table_1_filter">
			            <label>Search: 
				            <input type="text" aria-controls="DataTables_Table_1">
			            </label>
		            </div>
                    <!-- table -->
                    <table class="mws-datatable-fn mws-table dataTable" id="DataTables_Table_1" aria-describedby="DataTables_Table_1_info">
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
                                <th style="width: 100px;"></th>
                            </tr>
                        </thead>
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
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
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
                                    </td>
                        </tr>
                        <tr>
                            <td>
                                6
                            </td>
                            <td>
                                006
                            </td>
                            <td>
                                QUẦN SHORT
                            </td>
                            <td>
                                Quần short ngắn
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
                                        <span class="btn-group">
                                            <a href="#" class="btn btn-small"><i class="icon-search"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-pencil"></i></a>
                                            <a href="#" class="btn btn-small"><i class="icon-trash"></i></a>
                                        </span>
                                    </td>
                        </tr>
                        </tbody>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                    </table>
                    <!-- paging -->
                    <div class="dataTables_info" id="DataTables_Table_1_info">Showing 1 to 10 of 57 entries</div>
	                <div class="dataTables_paginate paging_full_numbers" id="DataTables_Table_1_paginate">
                        <a tabindex="0" class="first paginate_button paginate_button_disabled" id="DataTables_Table_1_first">First</a>
                        <a tabindex="0" class="previous paginate_button paginate_button_disabled" id="DataTables_Table_1_previous">Previous</a>
                        <span>
                            <a tabindex="0" class="paginate_active">1</a>
                            <a tabindex="0" class="paginate_button">2</a>
                            <a tabindex="0" class="paginate_button">3</a>
                            <a tabindex="0" class="paginate_button">4</a>
                            <a tabindex="0" class="paginate_button">5</a>
                        </span>
                        <a tabindex="0" class="next paginate_button" id="DataTables_Table_1_next">Next</a>
                        <a tabindex="0" class="last paginate_button" id="DataTables_Table_1_last">Last</a>
                     </div>
                </div>
            </div>
        </div>
    </div>
</div>
