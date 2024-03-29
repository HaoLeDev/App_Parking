﻿var rows_selected = [];
var cur_id = 0;
var donvi = function () {
    var self = this;
    self.init = function () {
       
        self.UnitFunction();
        self.UnitTable();
    }
    self.UnitFunction = function () {
        $("#btnAdd").click(function () {
            self.SetDefault();
            $("#title").text("Thêm đơn vị tính");
            $("#txtID").val(0);
            cur_id = 0;
        });
        
       // var table = $('#tblUnit').DataTable();
        
        $('#tblUnit tbody').on('click', '.fa-edit', function () {
            $("#title").text("Sửa vị tính");
            //Lấy data theo dòng
            var obj = dTable.row($(this).closest('tr')).data();
            //var currentRow = $(this).closest('tr');
            //var maDonVi = currentRow.find('td:eq(0)').text();
            //var tenDonVi = currentRow.find('td:eq(1)').text();
            //var mota = currentRow.find('td:eq(2)').text();
            //var trangThai = currentRow.find('td:eq(3)').val();
            $('#txtId').val(obj.UNIT_ID);
            $('#txtMaDonVi').val(obj.UNIT_CODE);
            $('#txtTenDonVi').val(obj.UNIT_NAME);
            $('#txtMoTa').val(obj.UNIT_DES);
            $('#ckTrangThai').prop('checked', obj.UNIT_STATUS);
            cur_id = $('#txtId').val();
            
            //alert(result);
        });
        $("#btnAdd").click(function () {
            self.SetDefault();
        });
        $("#btnUpdate").click(function () {
            if (self.ValidateData() == true) {
                self.Insert(cur_id);
            }
        });
        $('#tblUnit tbody').on('click', '.fa-trash', function (e) {
            var $row = $(this).closest('tr');
            var data = dTable.row($row).data();
            var rowId = data["UNIT_ID"];
            cur_id = rowId;
            // Xác nhận người dùng muốn xóa
            bootbox.confirm("Bạn muốn xóa đối tượng vừa chọn?", function (result) {
                if (result == true) {
                    self.Delete(cur_id);
                }
            });
            e.stopPropagation();
        });
        $('input.ctrlsearch').on('keyup click', function () {
            self.searchDonVi();
        });
        // Phương thức tìm kiếm trong Jquery datatble
        self.searchDonVi = function () {
            $('#tblUnit').DataTable().search(
                $('.ctrlsearch').val()
            ).draw();
        };
        $('#barbtnNhanVien_btnExport').click(function (e) {
            bootbox.confirm("Bạn có chắc chắn muốn xuất dữ liệu ra file Excel ?", function (result) {
                if (result == true) {
                    Busy.Block();
                    $.ajax({
                        url:'QuanLyDonViTinh/ExportToExcel',
                        data: {},
                        type: "post",
                        dataType: 'json',
                        success: function (data) {
                            var _dataResult = data.data;
                            if (data.result == "success") {
                                if (_dataResult != null) {
                                    alertify.success("Xuất file Excel thành công!");
                                    window.location.href = data.data;
                                }
                            }
                            else {
                                //if (data.result == "error") {
                                //    $.gritter.add({ title: "Ticket Manager", text: "Chưa xuất được file", image: "/uploads/error.png", class_name: "clean", time: "1500" });
                                //}
                                //if (data == 'not permission') {
                                //    $.gritter.add({ title: "Ticket Manager", text: "Bạn không được quyền xuất file", image: "/uploads/error.png", class_name: "clean", time: "1500" });
                                //}
                            }

                            $.unblockUI();
                        }
                    });
                };
            });
        });

    };
    self.UnitTable = function () {
        dTable = $('#tblUnit').DataTable({
            "bDestroy": true,
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "bProcessing": true,
            "iDisplayLength": 20,
            "sDom": 'it<pl>',
            "sPaginationType": "full_numbers",
            "sAjaxSource":'QuanLyDonViTinh/GetAll',
            "lengthMenu": [20, 40, 60, 100],
            "aoColumns": [
                {
                    mData: "UNIT_CODE"
                },
                {
                    mData: "UNIT_NAME"
                },
                { "mData": "UNIT_DES" },
                { "mData": "strUNIT_STATUS", className: "text-center" }, 
                {
                    mData: "UNIT_ID",
                    bSortable: false,
                    width: "80px",
                    mRender: function (o) {
                        return "<div class='text-center'>" +
                            "<span style='white-space: nowrap;'>" +
                            "<i class='fa fa-edit fw btn btn-info btn-xs' data-target='#myModal' data-toggle='modal' title='Chỉnh sửa'></i>" + " " +
                            "<i class='fa fa-trash fw btn btn-danger btn-xs' title='Xóa'></i>" +
                            "</span></div>";
                    }
                }
            ],
            "order": [0, 'asc'],
            "rowCallback": function (row, data, dataIndex) {
                // Get row ID
                var rowId = data["UNIT_ID"];
            },
            "oLanguage": {
                "sProcessing": "Đang xử lý",
                "sLengthMenu": "Hiển thị _MENU_ Bản ghi",
                "sZeroRecords": "Không tìm thấy bản ghi nào !",
                "sInfo": "Hiển thị _START_ tới _END_ của ( _TOTAL_ bản ghi )",
                "sInfoEmpty": "Không tìm thấy bản ghi nào !",
                "oPaginate": {
                    "sFirst": "Đầu",
                    "sPrevious": "Trước",
                    "sNext": "Sau",
                    "sLast": "Cuối"
                }
            }
        });  
    };
    self.Insert = function (Id) {
        
        var unit1 = {
            UNIT_ID:$("#txtId").val(),
            UNIT_CODE: $("#txtMaDonVi").val(),
            UNIT_NAME: $("#txtTenDonVi").val(),
            UNIT_DES: $("#txtMoTa").val(),
            //UNIT_STATUS: $("#ckTrangThai").cheked(),
            UNIT_STATUS:$('#ckTrangThai').is(':checked')
        }
        $.ajax({
            url: 'QuanLyDonViTinh/Insert',
            async: false,
            type: 'post',
            data: unit1 ,
            success: function (data) {
                if (data == 'success') {
                    $(".close").click();
                   // document.getElementById("myModal").classList.remove("show");
                    self.RefreshTable('#tblUnit');
                    alertify.success('Cập nhật thành công!'); 
                }
                else
                    alertify.error("Cập nhật thất bại");
            },
            error: function (error) {
                alertify.error(error);
            }
        });
    };
    self.Delete = function (id) {
        $.ajax({
            url:'QuanLyDonViTinh/Delete',
            async: false,
            type: "post",
            data: {
                UNIT_ID: id
            },
            success: function (data) {
                if (data == "success") {
                    self.RefreshTable('#tblUnit');
                    alertify.success('Xóa thành công!');
                    //$.gritter.add({ title: "Ticket Manager", text: "Xóa khách hàng thành công", image: "/uploads/success.png", class_name: "clean", time: "500" });
                }
                else {
                    alertify.error("Xóa thất bại");
                    //$.gritter.add({ title: "Ticket Manager", text: "Xóa khách hàng thất bại", image: "/uploads/error.png", class_name: "clean", time: "500" });
                }
            }
        });
    };
    self.RefreshTable = function (tableId) {
        table = $(tableId).dataTable();
        osetting = table.fnSettings();
        table.fnDraw();
    };
    self.SetDefault = function () {
        // self.RemoveToolTip();
        $("#txtMaDonVi").val("");
        $("#txtTenDonVi").val("");
        $("#ckTrangThai").prop('checked',true);
        $("#txtMoTa").val("");
    };
    self.ValidateData = function () {
        var flag = true;

        // Validate data txtTenLoaiVe: Kiểm tra tính hợp lệ textboxt Tên loại vé
        var title = $('#txtMaDonVi').val();
        if ($.trim(title) == '') {
            $('#txtMaDonVi').focus();
            alertify.error("Mã đơn vị không được bỏ trống!");
            flag = false;
        }
        else if ($('#txtTenDonVi').val() == '') {
            $('#txtTenDonVi').focus();
            alertify.error("Tên đơn vị không được bỏ trống!");
            flag = false;
        }
        return flag;
    };
}
$(document).ready(function () {
    var DonVi = new donvi();
    DonVi.init();
});