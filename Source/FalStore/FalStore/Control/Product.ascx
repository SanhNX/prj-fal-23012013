<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Product.ascx.cs" Inherits="FalStore.Control.Product" %>
<!-- Main Container Start -->
<div id="mws-container" class="clearfix">
    <div class="container">
        <!-- From category --->
        <div class="mws-panel grid_8">
            <div class="mws-panel-header">
                <span>Sản phẩm</span>
            </div>
            <div class="mws-panel-body no-padding">
                <form class="mws-form" action="form_layouts.html">
                <div class="mws-form-inline">
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Mã sản phẩm</label>
                        <div class="mws-form-item">
                            <input type="text" class="small">
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Tên sản phẩm</label>
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
                            Danh mục sản phẩm</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>ÁO VEST VN</option>
                                <option>ÁO THUN TQ</option>
                                <option>ÁO SOMI NAM TA</option>
                                <option>QUẦN JEAN USA</option>
                                <option>QUẦN KAKI VN</option>
                                <option>QUẦN SORT VN</option>
                            </select>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Màu sắc</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Màu xanh</option>
                                <option>Màu kem</option>
                                <option>Màu kaki</option>
                                <option>Màu đỏ đô</option>
                                <option>Màu trắng</option>
                                <option>Chấm bi xanh</option>
                            </select>
                        </div>
                    </div>
                    <div class="mws-form-row">
                        <label class="mws-form-label">
                            Kích cỡ</label>
                        <div class="mws-form-item">
                            <select class="large">
                                <option>Size S</option>
                                <option>Size M</option>
                                <option>Size L</option>
                                <option>Size XL</option>
                                <option>Big size</option>
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
                                Mã sản phẩm
                            </th>
                            <th>
                                Tên sản phẩm
                            </th>
                            <th>
                                Mô tả
                            </th>
                            <th>
                                Dach mục
                            </th>
                            <th>
                                Màu sắc
                            </th>
                            <th>
                                Kích cỡ
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
                                AV 01b
                            </td>
                            <td>
                                Vest nam màu xanh
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO VEST
                            </td>
                            <td>
                                Màu xanh
                            </td>
                            <td>
                                S
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
                                AV 01a
                            </td>
                            <td>
                                Vest nam màu kem
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO VEST
                            </td>
                            <td>
                                Màu kem
                            </td>
                            <td>
                                XL
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
                                AV 01
                            </td>
                            <td>
                                Vest nam màu kaki
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO VEST
                            </td>
                            <td>
                                Màu kaki
                            </td>
                            <td>
                                M
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
                                BL 01a
                            </td>
                            <td>
                                Balo màu đô in chữ
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO THUN NAM
                            </td>
                            <td>
                                Màu đỏ đô
                            </td>
                            <td>
                                S
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
                                BL 01
                            </td>
                            <td>
                                Balo in chữ màu kem
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO THUN NAM
                            </td>
                            <td>
                                Màu kem
                            </td>
                            <td>
                                S
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
                                TP 07
                            </td>
                            <td>
                                Polo sooc ngang xanh đen
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO THUN NAM
                            </td>
                            <td>
                                Màu xanh đen
                            </td>
                            <td>
                                M
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                7
                            </td>
                            <td>
                                TP 02
                            </td>
                            <td>
                                Polo chấm bi xanh
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO THUN NAM
                            </td>
                            <td>
                                Chấm bi xanh
                            </td>
                            <td>
                                XL
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                8
                            </td>
                            <td>
                                TT 01
                            </td>
                            <td>
                                Áo thun nâu chỉ nổi túi caro
                            </td>
                            <td>
                            </td>
                            <td>
                                ÁO THUN NAM
                            </td>
                            <td>
                                Màu nâu
                            </td>
                            <td>
                                S
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                9
                            </td>
                            <td>
                                SN 19
                            </td>
                            <td>
                                Tay ngắn caro nâu
                            </td>
                            <td>
                            </td>
                            <td>
                                SƠ MI NAM
                            </td>
                            <td>
                                Màu nâu
                            </td>
                            <td>
                                M
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                10
                            </td>
                            <td>
                                SN 17
                            </td>
                            <td>
                                Tay ngắn đen trơn phối túi
                            </td>
                            <td>
                            </td>
                            <td>
                                SƠ MI NAM
                            </td>
                            <td>
                                Màu đen
                            </td>
                            <td>
                                L
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                11
                            </td>
                            <td>
                                1036b
                            </td>
                            <td>
                                Sơ mi tay dài caro xám
                            </td>
                            <td>
                            </td>
                            <td>
                                SƠ MI NAM
                            </td>
                            <td>
                                Màu xám
                            </td>
                            <td>
                                S
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                12
                            </td>
                            <td>
                                QKD 01c
                            </td>
                            <td>
                                Quần kaki màu xanh đen
                            </td>
                            <td>
                            </td>
                            <td>
                                QUẦN JEAN, KAKI
                            </td>
                            <td>
                                Màu xanh đen
                            </td>
                            <td>
                                M
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                13
                            </td>
                            <td>
                                QKD 01
                            </td>
                            <td>
                                Quần kaki màu đô
                            </td>
                            <td>
                            </td>
                            <td>
                                QUẦN JEAN, KAKI
                            </td>
                            <td>
                                Màu xanh
                            </td>
                            <td>
                                S
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                14
                            </td>
                            <td>
                                0004
                            </td>
                            <td>
                                Quần jean thái
                            </td>
                            <td>
                            </td>
                            <td>
                                QUẦN JEAN, KAKI
                            </td>
                            <td>
                                Màu xanh
                            </td>
                            <td>
                                XL
                            </td>
                            <td>
                                <span class="btn-group"><a href="#" class="btn btn-small"><i class="icon-search"></i>
                                </a><a href="#" class="btn btn-small"><i class="icon-pencil"></i></a><a href="#"
                                    class="btn btn-small"><i class="icon-trash"></i></a></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                15
                            </td>
                            <td>
                                QSK 01
                            </td>
                            <td>
                                Quần short màu xám
                            </td>
                            <td>
                            </td>
                            <td>
                                QUẦN SHORT
                            </td>
                            <td>
                                Màu xám
                            </td>
                            <td>
                                L
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