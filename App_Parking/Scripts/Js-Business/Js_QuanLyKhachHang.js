var quanlyKhachHang = function () {
    var self = this;
    var rows_selected = [];
    var rowId = 0;
    self.initQuanlyKhachHang = function () {
        $('.datetimepicker').datepicker({
            locale: 'vi',
            format: 'DD/MM/YYYY'
        });
        self.KhachHangTable();
        self.KhachHangFunction();
    }
    var dTable;
    self.KhachHangTable = function () {
        //load bán vé        
        dTable = $('#tblKhachHang').DataTable({
            "bDestroy": true,
            "processing": true, // for show progress bar
            "serverSide": true, // for process server side
            "bProcessing": true,
            "iDisplayLength": 20,
            "sDom": 'it<pl>',
            "sPaginationType": "full_numbers",
            "sAjaxSource":'/QuanLyKhachHang/GetAll',
            "lengthMenu": [20, 40, 60, 100],
            "aoColumns": [
                {
                    mData: "USER_NAME"
                },
                {
                    mData: "USER_CODE"
                },
                { "mData": "IDENTITY_NUMBER" },
                { "mData": "strSEX", className: "text-center" },
                {
                    "mData": "strUSER_BIRTH",
                    className: "text-center"
                },
                {
                    "mData": "PHONE"
                },
                {
                    "mData": "EMAIL"
                },
                {
                    "mData": "strEM_STATUS",
                    className: "text-center"
                },
                {
                    mData: "USER_ID",
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
                var rowId = data["USER_ID"];
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
        $('#tblKhachHang tbody').on('click', '.fa-pencil', function (e) {
            var $row = $(this).closest('tr');
            var data = dTable.row($row).data();
            var rowId = data["USER_ID"];
            cur_id = rowId;
            $.ajax({
                url: 'QuanLyKhachHang/TimKiemKhachHang',
                async: false,
                data: { USER_ID: cur_id },
                dataType: 'json',
                type: "post",
                success: function (data) {
                    if (data == 'not permission') {
                        $.gritter.add({ title: "Ticket Manager", text: "Bạn không có quyền sửa thông tin khách hàng", image: "/uploads/error.png", class_name: "clean", time: "500" });
                        return;
                    }
                    $("#title").text("Sửa thông tin khách hàng");
                    cur_id = data.USER_ID;
                    $("#txtID").val(data.USER_ID);
                    $("#txtTenKhachHang").val(data.USER_NAME);
                    $("#txtMaKhachHang").val(data.USER_CODE);
                    $("#txtSoDienThoai").val(data.PHONE);
                    $("#txtSoCMND").val(data.IDENTITY_NUMBER);
                    $("#slGioiTinh").val(data.SEX);
                    $("#txtNgaySinh").val(data.strUSER_BIRTH);
                    $("#txtDiachi").val(data.ADDRESS);
                    $("#txtEmail").val(data.EMAIL);
                    $("#txtMoTa").val(data.NOTE);
                    $("#ckbHieuLuc").prop('checked', data.USER_STATUS);
                    $("#btnUpdate").show();
                    $("#modalKhachHang").modal("show");
                }
            });
            e.stopPropagation();
        });
        //khi người dùng click vào nút xóa
        $('#tblKhachHang tbody').on('click', '.fa-trash', function (e) {
            var $row = $(this).closest('tr');
            var data = dTable.row($row).data();
            var rowId = data["USER_ID"];
            cur_id = rowId;
            // Xác nhận người dùng muốn xóa
            bootbox.confirm("Bạn muốn xóa đối tượng vừa chọn?", function (result) {
                if (result == true) {
                    self.XoaKhachHang(cur_id);
                }
            })
            e.stopPropagation();
        });


    }
    self.KhachHangFunction = function () {
        $("#btnAdd").click(function () {
            self.SetDefault();
        });
    };
    self.SetDefault = function () {
        $("#txtTenKhachHang").val('');
        $("#txtMaKhachHang").val('');
        $("#txtSoDienThoai").val('');
        $("#txtSoCMND").val('');
        $("#txtNgaySinh").val('');
        $("#slGioiTinh").val(0);
        $("#txtDiachi").val('');
        $("#txtEmail").val('');
        $("#txtMoTa").val('');
        $("#ckbHieuLuc").prop("checked", true);
    };
    self.XoaKhachHang = function (id) {
        $.ajax({
            url:'QuanLyKhachHang/XoaKhachHang',
            async: false,
            type: "post",
            data: {
                USER_ID: id
            },
            success: function (data) {
                if (data == "success") {
                    self.RefreshTableUser('#tblKhachHang');
                    $.gritter.add({ title: "Ticket Manager", text: "Xóa khách hàng thành công", image: "/uploads/success.png", class_name: "clean", time: "500" });
                }
                else {
                    $.gritter.add({ title: "Ticket Manager", text: "Xóa khách hàng thất bại", image: "/uploads/error.png", class_name: "clean", time: "500" });
                }
            }
        });
    };
    // Phương thức tải lại dữ liệu lên table
    self.RefreshTableUser = function (tableId) {
        table = $(tableId).dataTable();
        oSettings = table.fnSettings();
        table.fnDraw();
    }
    // Textbox tìm kiếm
    $('input.ctrlsearch').on('keyup click', function () {
        self.searchKhachHang();
    });
    // Phương thức tìm kiếm trong Jquery datatble
    self.searchKhachHang = function () {
        $('#tblKhachHang').DataTable().search(
            $('.ctrlsearch').val()
        ).draw();
    }
    $('#btnAdd').click(function () {
        $('#modalKhachHang').modal('show');
    });
    $("#btnThemAnh").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $("#imgKhachHang").attr("src", "/" + url.substring(1));
            alert(url.substring(1));
            // console.log($("#imgAnhXe").attr("src", "/" + url.substring(1)));
            //linkImg = $("#imgKhachHang").prop('src').substring(21);           
        };
        finder.popup();
    });
    // Sự kiện khi người dùng click vào xóa ảnh
    $("#btnXoaAnh").click(function () {
        $("#imgKhachHang").attr("src", 'https://www.triaorkestrasi.com/resources/images/person.png');
    });
}
