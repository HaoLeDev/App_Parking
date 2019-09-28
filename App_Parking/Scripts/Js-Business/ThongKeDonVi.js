var status = 0;
var ThongKeDonVi = function () {
    $('#btnInNoiDung').attr("disabled", "disabled");
    $('#btnExportToExcel').attr("disabled", "disabled");
    this.init = function () {
        this.SetDefaultValue();
        this.DuLieuThongKeDonVi();
        this.ChucNangThongKeDonVi();
    }
    this.ChucNangThongKeDonVi=function(){
        $("btnThongKe").click(function () {
            status = $("#slStatus option").filter(":selected").val();
            if (status == 0) status = null;
            if (status == 1) status = true;
            if (status == 2) status = false;
            this.DuLieuThongKeDonVi();
        });
        //$.unblockUI();
    }
    $("#btnInNoiDung").click(function () {
        printDiv("printDiv"); $("#btnInNoiDung").attr("disabled", true);
    });
    this.DuLieuThongKeDonVi = function () {
        $.ajax({
            url:'ThongKeDonVi/GetAll',
            data: { STATUS: status },
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (data, result) {
                var _dataResult = data.data;
                if (data.result == "success") {
                    if (_dataResult != null) {
                        $("#content").html("");
                        loadData(_dataResult);
                    }
                }
            },
            error: function (xhr, status, error) {
                //$.gritter.add({ title: "Car Parking", text: error, image: "/uploads/error.png", class_name: "clean", time: "1500" });
            }
        });
    }
    this.SetDefaultValue = function () {
        $("#slStatus").val(0);
        status = 0;
    }
    $('#btnExportToExcel').click(function (e) {
        bootbox.confirm("Bạn có chắc chắn muốn xuất dữ liệu ra file Excel ?", function (result) {
            if (result == true) {
                //Busy.Block();
                status = $("#slStatus option").filter(":selected").val();
                if (status == 0) status = null;
                if (status == 1) status = true;
                if (status == 2) status = false;
                $.ajax({
                    url:'ThongKeDonVi/ExportToExcel',
                    data: { UNIT_STATUS: status },
                    type: "post",
                    dataType: 'json',
                    success: function (data) {
                        if (data.result == "success") {
                            //$.gritter.add({ title: "CarParking", text: "Xuất dữ liệu ra file Excel thành công", image: "/uploads/success.png", class_name: "clean", time: "1500" });
                            window.location.href = data.data;
                        } else {
                            //$.gritter.add({ title: "CarParking", text: "Xuất dữ liệu ra file Excel thất bại", image: "/uploads/error.png", class_name: "clean", time: "1500" });
                        }
                    }

                });
                //$.unblockUI();
            }
        });
    });
}
function loadData(data) {
    var tab = $("<table class='table table-bordered table-striped '></table>")
    var thead = $('<thead></thead>');
    thead.append('<th class="p5" style="text-align:center">STT</th>');
    thead.append('<th class="p5">Tên đơn vị</th>');
    thead.append('<th class="p5">Mã đơn vị</th>');
    //thead.append('<th class="p5 hidden-xs">Mô tả</th>');
    if ($("#slStatus").val() == 0) {
        thead.append('<th class="p5 hidden-xs text-center">Trạng thái</th>');
    }
    tab.append(thead);
    if (data != null && data.length > 0) {
        var pb = "";
        $.each(data, function (i, val) {
            var trow = $('<tr></tr>');
            trow.append('<td style="text-align:center">' + (i + 1) + '</td>');
            trow.append('<td>' + val.UNIT_NAME + '</td>');
            trow.append('<td>' + val.UNIT_CODE + '</td>');
            //trow.append('<td class="hidden-xs">' + val.UNIT_DES + '</td>');
            if ($("#slStatus").val() == 0) {
                trow.append('<td class="hidden-xs text-center">' + val.strUNIT_STATUS+ '</td>');
            }
            tab.append(trow);
        });
        // Loại bỏ thuộc thuộc disabled button In nội dung
        $('#btnInNoiDung').removeAttr("disabled");
        $('#btnExportToExcel').removeAttr("disabled");
    }
    else {
        var trow = $('<tr></tr>');
        trow.append('<td colspan="7" style="text-align:center; color:red">Chưa có dữ liệu thống kê. Vui lòng chọn các điều kiện thống kê</td>');
        tab.append(trow);
    }
    $("#content").html(tab);
}
function printDiv(divID) {
    var divIDPrint = "#" + divID;
    var urlCss = '<link href="Assets/content-admin/css/admin-print-browser.min.css" rel="stylesheet" media="print" />';
    var contents = document.getElementById(divID).innerHTML;
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
    }, 200)
}
$(document).ready(function () {
    var thongke = new ThongKeDonVi();
    thongke.init();
})