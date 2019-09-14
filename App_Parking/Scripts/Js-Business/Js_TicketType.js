var rows_selected = [];
var cur_id = 0;
var Js_TicketType = function () {
    return {
        init: function () {
            Js_TicketType.dTable();
            this.update();
            this.delete();
        },
        dTable: function () {
            $("#tblTicketType").DataTable({
                "bDestroy": true,
                "processing": true, // for show progress bar
                "serverSide": true, // for process server side
                "bProcessing": true,
                "iDisplayLength": 10,
                "sDom": 'it<pl>',
                "sPaginationType": "full_numbers",
                "sAjaxSource": '/TicketTypeManager/GetAll',
                "lengthMenu": [10, 25, 50],
                "aoColumns": [
                    { "mData": "TYPENAME" },
                    { "mData": "TYPE_CODE", className: "text-center" },
                    { "mData": "TYPE_CHECK", className: "text-center" },
                    { "mData": "DESCRIPTIONS" },
                    {
                        mData: "TYPEID",
                        bSortable: false,
                        width: "80px",
                        mRender: function (o) {
                            return "<div class='text-center'>" +
                                "<span style='white-space: nowrap;'>" +
                                "<i class='fa fa-pencil fw btn btn-info btn-xs' title='Chỉnh sửa'></i>" + " " +
                                "<i class='fa fa-trash fw btn btn-danger btn-xs' title='Xóa'></i>" +
                                "</span></div>";
                        }
                    }
                ],
                "order": [0, 'asc'],
                "rowCallback": function (row, data, dataIndex) {
                    // Get row ID
                    var rowId = data["TYPEID"];
                    // If row ID is in the list of selected row IDs
                    //if ($.inArray(rowId, rows_selected) !== -1) {
                    //    $(row).find('input[type="checkbox"]').prop('checked', true);
                    //    $(row).addClass('selected');
                    //}
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
            
        },
        insert: function (ID) {
            jQuery.noConflict();
            $("#myModal").modal("show");

        },
        update: function () {
            $('#tblTicketType tbody').on('click', '.fa-pencil', function (e) {
                
                var table = $("#tblTicketType").DataTable();
                var $row = $(this).closest('tr');
                var data = table.row($row).data();
                var rowId = data["TYPEID"];
                //console.log(rowId);
                
                cur_id = rowId;
                $.ajax({
                    url: 'TicketTypeManager/TimKiemLoaiVe',
                    async: false,
                    data: JSON.stringify({ TYPEID: cur_id }),
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    type: "post",
                    success: function (data) {
                        if (data == 'not permission') {
                            //$.gritter.add({ title: "Ticket Manager", text: "Bạn không có quyền sửa thông tin khách hàng", image: "/uploads/error.png", class_name: "clean", time: "500" });
                            return;
                        }
                        $("#title").text("Sửa thông tin loại vé");
                        cur_id = data.TYPEID;
                        $("#txtID").val(data.TYPEID);
                        $("#txtMaLoaiVe").val(data.TYPE_CODE);
                        $("#txtTenLoaiVe").val(data.TYPENAME);
                        $("#txtMoTa").val(data.DESCRIPTIONS);
                        TYPE_CHECK: $("#slThuocLoai").prop("checked", data.TYPE_CHECK);
                        jQuery.noConflict();
                        $("#myModal").modal("show");
                    }
                });
                //e.stopPropagation();
                
               // $("#myModal").modal("show");
            });
        },
        delete: function (id) {
            $('#tblTicketType tbody').on('click', '.fa-trash', function (e) {
                var table = $("#tblTicketType").DataTable();
                var $row = $(this).closest('tr');
                var data = table.row($row).data();
                var rowId = data["TYPEID"];
                cur_id = rowId;
                // Xác nhận người dùng muốn xóa
                bootbox.confirm("Bạn muốn xóa đối tượng vừa chọn?", function (result) {
                    if (result == true) {
                        $.ajax({
                            url: '/TicketTypeManager/XoaLoaiVe',
                            async: false,
                            type: "post",
                            data: {
                                TYPEID: id
                            },
                            success: function (data) {
                                if (data == "success") {
                                    this.RefreshTableUser('#TicketTypeManager');
                                    //$.gritter.add({ title: "Ticket Manager", text: "Xóa khách hàng thành công", image: "/uploads/success.png", class_name: "clean", time: "500" });
                                    alert("Xóa thành công");
                                }
                                else {
                                    //$.gritter.add({ title: "Ticket Manager", text: "Xóa khách hàng thất bại", image: "/uploads/error.png", class_name: "clean", time: "500" });
                                    alert("Xóa thất bại")
                                }
                            }
                        });
                    }
                })
                e.stopPropagation();
            });
        },
        save: function () {
            var ticket = {
                TYPEID: $("#txtId").val(),
                TYPE_CODE: $("#txtMaLoaiVe").val(),
                TYPENAME: $("#txtTenLoaiVe").val(),
                DESCRIPTIONS: $("#txtMoTa").val(),
                TYPE_CHECK: $("#slThuocLoai option").filter(":selected").val()
            }
            if (this.validate) {
                $.ajax({
                    url: '/TicketTypeManager/CapNhatLoaiVe',
                    type: 'POST',
                    data: ticket,
                    success: function (data) {
                        if (data == 'Success') {
                            $('#myModal').modal('hide');
                            Js_TicketType.RefreshTableUser("#tblTicketType");
                            alertify.success("Cập nhật thành công!");

                        }
                        else
                            alertify.error("Cập nhật thất bại!");
                    }
                });
            }
        },
        RefreshTableUser : function (tableId) {
            table = $(tableId).dataTable();
            oSettings = table.fnSettings();
            table.fnDraw();
        },
        
        validate: function () {
            if ($("#txtTenLoaiVe").val() == '') {
                $("#txtTenLoaiVe").focus();
                return false;
            }
            if ($("#txtMaLoaiVe").val() == '') {
                $("#txtMaLoaiVe").focus();
                return false;
            }
            return true;
        }
    }
   
}();
