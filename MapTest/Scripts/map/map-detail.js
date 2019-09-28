function initDetail(image, bts_id, name) {//truyền các param link ảnh, id trạm, tên
    resetChart();//khởi tạo vùng biểu đồ
    $('#titBTS').text('bản đồ ' + name.replace(/,/g, ' '));//gán tên bản đồ trạm
    loadDetail(image, bts_id);//chi tiết thông tin đo được từ các thiết bị trạm
};
function loadChart(temp, humi, name) {
    resetChart();//khởi tạo vùng biểu đồ
    $("#titleChart").text('dữ liệu thiết bị ' + name);//thiết lập tiêu đề biểu đồ
    var g1 = new JustGage({//loại biểu đồ
        id: "modalBody1",
        value: temp,//giá trị nhiệt độ
        min: 0,
        max: 100,
        title: "Nhiệt độ",
        label: "độ C"
    });

    var g2 = new JustGage({//loại biểu đồ
        id: "modalBody2",
        value: humi,//giá trị độ ẩm
        min: 0,
        max: 100,
        title: "Độ ẩm",
        label: "%"
    });
};
function resetChart() {//khởi tạo vùng biểu đồ
    $("#titleChart").text('');//xóa tiêu đề biểu đồ
    $("#modalBody1").html("");//xóa nội dung biểu đồ
    $("#modalBody2").html("");//xóa nội dung biểu đồ
};
function loadDetail(value3, value4) {
    $('#image-wrapper img').attr('src', value3);//thiết lập hình ảnh bản đồ trạm cho marker
    $('#image-wrapper img').on('load', function () {//sau khi ảnh hoàn toàn load xong mới thực hiện chức năng bên trong
        $('#image-wrapper').find('span').remove();//xóa các thẻ span trong ảnh
        Markers.init(value4);//khởi tạo chi tiết Marker gồm map trạm, các thông tin đo đạc của các controller or thiết bị 
    });
};
var Markers = {
    fn: {
        addMarkers: function (BTS_ID) {
            var target = $('#image-wrapper');
            var data1 = $.ajax({
                async: false,
                url: '/BTSMap/DataControllers?BTS_ID=' + BTS_ID,//vị trí các controller trong 1 trạm có id = bts_id
                type: 'get',
                data: { 'GetConfig': 'YES' },
                dataType: "JSON"
            }).responseJSON;
            if (data1 == null) {
                return;
            };
            $('#myModal').show();//hiển thị popup
            var img = $('#image-wrapper img');//ảnh từ selector này
            var wClient = img[0].clientWidth;//chiều rộng ảnh theo kích thước trên từng thiết bị
            var hClient = img[0].clientHeight;//chiều cao ảnh theo kích thước trên từng thiết bị
            var wNatural = img[0].naturalWidth;//chiều rộng ảnh thật, ảnh tự nhiên, file
            var hNatural = img[0].naturalHeight;//chiều cao ảnh thật, ảnh tự nhiên, file
            for (var i = 0; i < data1.length; i++) {
                var obj = data1[i];
                var top = (obj.TOP * hClient) / hNatural - 16;//vị trí controller theo chiều từ trên xuống của ảnh, đơn vị pixel, 16 là do kích thước icon là 32x32, 16 để đưa trung tâm icon vào trung tâm vị trí
                var left = (obj.LEFT * wClient) / wNatural - 16;//vị trí controller theo chiều từ bên trái sang của ảnh, đơn vị pixel, 16 là do kích thước icon là 32x32, 16 để đưa trung tâm icon vào trung tâm vị trí
                var text = obj.TEMP + ',' + obj.HUMI + ',' + obj.NAME;//lấy 3 giá trị này vào 1 string để bên dưới dễ sử dụng
                $('<span class="marker"/>').css({//sau khi có thông tin từng controller, lại gắn thành điểm trên ảnh
                    top: top,
                    left: left
                }).html('<span class="caption">' + text + '</span>').
                    appendTo(target);//đẩy các thông tin vào selector #image-wrapper
            };
        },
        showCaptions: function () {
            $('span.marker').on('click', function () {//sự kiện khi click vào controller
                var data2 = $(this).text().split(",");//tách data thành 1 mảng gồm 3 giá trị nhiệt độ, độ ẩm, tên
                loadChart(data2[0], data2[1], data2[2]);//hiển thị các biểu đồ thông số
            });
        }
    },
    init: function (BTS_ID) {
        this.fn.addMarkers(BTS_ID);
        this.fn.showCaptions();
    }
};


