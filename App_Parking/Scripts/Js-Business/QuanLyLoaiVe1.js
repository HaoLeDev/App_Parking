// Mảng lưu trữ bản ghi lựa chọn để xóa
var rows_selected = [];
var cur_id = 0;
// Quản lý Loại vé
var LoaiVe = function () {
    var self = this;
    // Thiết lập thuộc tính disabled khi người dùng chưa check vào ô checkbox để xóa
    $('#barbtnLoaiVe_btnDelete').attr("disabled", "disabled");
    // Hàm khởi tạo
    self.initLoaiVe = function () {
        self.LoaiVeTable();
        self.LoaiVeFunction();
    }

    // Hàm chức năng loại vé
    self.LoaiVeFunction = function () {
        // Thêm loại vé.
        $("#btnAdd").click(function () {
            self.SetDefault();
            $("#title").text("Thêm loại vé");
            $("#txtID").val(0);
            cur_id = 0;
            jQuery.noConflict();
            $("#myModal").modal("show");
        });
        //sự kiện khi người dùng click vào xuất file excel
        $('#barbtnLoaiVe_btnExport').click(function (e) {
            bootbox.confirm("Bạn có chắc chắn muốn xuất dữ liệu ra file Excel ?", function (result) {
                if (result == true) {
                    Busy.Block();

                    $.ajax({
                        url:  'tblTicketType/ExportToExcel',
                        data: {},
                        type: "post",
                        dataType: 'json',
                        success: function (data) {
                            var _dataResult = data.data;
                            if (data.result == "success") {
                                if (_dataResult != null) {
                                    window.location.href = Config.AppUrl + data.data;
                                }
                            }
                            else {
                                if (data.result == "error") {
                                    $.gritter.add({ title: "Ticket Manager", text: "Chưa xuất được file", image: "/uploads/error.png", class_name: "clean", time: "500" });
                                }
                            }

                            $.unblockUI();
                        }
                    });
                };
            });
        });

        // Sự kiện khi người dùng click vào button cập nhật loại vé
        $("#btnUpdate").click(function () {
            if (self.ValidateData() == true) {
                self.CapNhatLoaiVe(cur_id);
            }
        });
    }

    // Hàm load dữ liệu lên bảng sử dụng datatable 
    self.LoaiVeTable = function () {
        //Load loại vé: lấy dữ liệu từ controller và đẩy dữ liệu vào bảng
        var dTable = $('#tblTicketType').DataTable({
            "bDestroy": true,
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "bProcessing": true,
            "iDisplayLength": 10,
            "sDom": 'it<pl>',
            "sPaginationType": "full_numbers",
            "sAjaxSource": 'TicketTypeManager/GetAll',
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
        //khi người dùng click vào nút sửa
        $('#tblTicketType tbody').on('click', '.fa-pencil', function (e) {
            //self.RemoveToolTip();
            var $row = $(this).closest('tr');
            var data = dTable.row($row).data();
            var rowId = data["TYPEID"];
            cur_id = rowId;
            $.ajax({
                url: '/TicketTypeManager/TimKiemLoaiVe',
                async: false,
                data: { TYPEID: cur_id },
                dataType: 'json',
                type: "post",
                success: function (data) {
                    $("#title").text("Sửa loại vé");
                    $("#txtID").val(data.TYPEID);
                    cur_id = data.TYPEID;
                    $("#txtTenLoaiVe").val(data.TYPENAME);
                    $("#txtMaLoaiVe").val(data.TYPE_CODE);
                    $("#txaMoTa").val(data.DESCRIPTIONS);
                    $("#slThuocLoai").val(data.TYPE_CHECK);
                    $("#myModal").modal("show");
                }
            });
            e.stopPropagation();
        });
        //khi người dùng click vào nút xóa
        $('#tblTicketType tbody').on('click', '.fa-trash', function (e) {
            var $row = $(this).closest('tr');
            var data = dTable.row($row).data();
            var rowId = data["TYPEID"];
            cur_id = rowId;
            // Xác nhận người dùng muốn xóa
            bootbox.confirm("Bạn muốn xóa đối tượng vừa chọn?", function (result) {
                if (result == true) {
                    self.XoaLoaiVe(cur_id);
                }
            })
            e.stopPropagation();
        });
    }

    // Thiết lập các giá trị về mặc định
    self.SetDefault = function () {
       // self.RemoveToolTip();
        $("#txtTenLoaiVe").val("");
        $("#txtMaLoaiVe").val("");
        $("#slThuocLoai").val("0");
        $("#txaMoTa").val("");
    }

    // Kiểm tra tính hợp lệ của dũ liệu
    self.ValidateData = function () {
        var flag = true;

        // Validate data txtTenLoaiVe: Kiểm tra tính hợp lệ textboxt Tên loại vé
        var title = $('#txtTenLoaiVe').val();
        if ($.trim(title) == '') {
            //$($('#txtTenLoaiVe')).tooltip('hide').attr('data-original-title', 'Vui lòng nhập tên loại vé').tooltip('fixTitle').addClass('errorClass');
            flag = false;
        } else {
            //$('#txtTenLoaiVe').data("title", "").removeClass("errorClass").tooltip("destroy");
        }

        var maloaive = $('#txtMaLoaiVe').val();
        if ($.trim(maloaive) == '') {
            //$($('#txtMaLoaiVe')).tooltip('hide').attr('data-original-title', 'Vui lòng nhập mã loại vé').tooltip('fixTitle').addClass('errorClass');
            flag = false;
        } else {
            //$('#txtMaLoaiVe').data("title", "").removeClass("errorClass").tooltip("destroy");
        }

        //if (flag == false) {
        //    $('#thongbao span').text('* Dữ liệu trên form thiếu hoặc là không hợp lệ');
        //    $('#thongbao').show();
        //}
        return flag;
    }

    // Loại bỏ tooltip
    //self.RemoveToolTip = function () {
    //    $('#txtTenLoaiVe').data("title", "").removeClass("errorClass").tooltip("destroy");
    //    $('#txtMaLoaiVe').data("title", "").removeClass("errorClass").tooltip("destroy");
    //    //$('#thongbao').hide();
    //}

    // Cập nhật loại vé
    self.CapNhatLoaiVe = function (ID) {
        var tenLoaiVe = $("#txtTenLoaiVe").val();
        var maLoaiVe = $("#txtMaLoaiVe").val();
        var thuocLoai = $("#slThuocLoai option").filter(":selected").val();
        var moTa = $("#txaMoTa").val();
        $.ajax({
            url:'TicketTypeManager/CapNhatLoaiVe',
            async: false,
            type: "post",
            data: {
                TYPEID: ID, TYPENAME: tenLoaiVe, DESCRIPTIONS: moTa, TYPE_CHECK: thuocLoai, TYPE_CODE: maLoaiVe
            },
            success: function (data) {
                if (data == "success") {
                    $('#myModal').modal('hide');
                    Js_TicketType.RefreshTableUser("#tblTicketType");
                    alertify.success("Cập nhật thành công!");

                    //$.gritter.add({ title: "Ticket Manager", text: "Cập nhật loại vé thành công", image: "/uploads/success.png", class_name: "clean", time: "500" });
                }
                else {
                    //$.gritter.add({ title: "Ticket Manager", text: data, image: "/uploads/error.png", class_name: "clean", time: "500" });
                }

            }
        });
    }

    // Xóa nhiều loại vé
    self.XoaLoaiVe = function (id) {
        $.ajax({
            url:'TicketTypeManager/XoaLoaiVe',
            async: false,
            type: "GET",
            data: {
                TYPEID: id
            },
            success: function (data) {
                if (data == "success") {
                    self.RefreshTableUser('#tblTicketType');
                    //$.gritter.add({ title: "Ticket Manager", text: "Xóa loại vé thành công", image: "/uploads/success.png", class_name: "clean", time: "500" });
                    alertify.success("Xóa thành công!");
                }
                else {
                    //$.gritter.add({ title: "Ticket Manager", text: "Xóa loại vé thất bại", image: "/uploads/error.png", class_name: "clean", time: "500" });
                    alertify.error("Xóa thất bại!");
                }
            },
            error: function (data) {
                //$.gritter.add({ title: "Ticket Manager", text: "Xóa loại vé thất bại", image: "/uploads/error.png", class_name: "clean", time: "500" });
                alertify.error("Lỗi khi xóa bản ghi!");
            }
        });
    }

    // Phương thức tải lại dữ liệu lên table
    self.RefreshTableUser = function (tableId) {
        table = $(tableId).dataTable();
        oSettings = table.fnSettings();
        table.fnDraw();
    }

    // Textbox tìm kiếm
    $('input.ctrlsearch').on('keyup click', function () {
        self.searchKeHoachCongViec();
    });

    // Phương thức tìm kiếm trong Jquery datatble
    self.searchKeHoachCongViec = function () {
        $('#tblTicketType').DataTable().search(
            $('.ctrlsearch').val()
        ).draw();
    }
}

// In nội dung
function printDiv(divID) {
    var divIDPrint = "#" + divID;
    var urlCss = '<link href="' + Config.AppUrl + 'Assets/admin/css/admin-print-browser.css" rel="stylesheet" />';
    var contents = $(divIDPrint).html();
    var frame1 = $('<iframe />');
    frame1[0].name = "frame1";
    frame1.css({ "position": "absolute", "top": "-1000000px" });
    $("body").append(frame1);
    var frameDoc = frame1[0].contentWindow ? frame1[0].contentWindow : frame1[0].contentDocument.document ? frame1[0].contentDocument.document : frame1[0].contentDocument;
    frameDoc.document.open();
    //Create a new HTML document.
    frameDoc.document.write('<html><head><title></title>');
    frameDoc.document.write('</head><body>');
    //Append the external CSS file.
    frameDoc.document.write(urlCss);
    //Append the DIV contents.
    frameDoc.document.write(contents);
    frameDoc.document.write('</body></html>');
    frameDoc.document.close();
    setTimeout(function () {
        window.frames["frame1"].focus();
        window.frames["frame1"].print();
        frame1.remove();
    }, 200);
}