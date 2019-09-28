var locations = [];//mảng các tọa độ trên google map (gồm kinh độ, vĩ độ)
var infoWindowContent = [];//mảng lưu thông tin, khi click vào 1 điểm trên google map, hiện ra thông tin gồm tên, ...
var monitoring = $.ajax({
    async: false,
    url: '/BTSMap/DataMonitoringByAccount',//đọc dữ liệu từ action này BtsMapController, method DataMonitoringByAccount
    type: 'get',
    data: { 'GetConfig': 'YES' },
    dataType: "JSON"//lấy dữ liệu dạng json
}).responseJSON;//monitoring thu dc là 1 mảng các vị trí trạm bts trên google map, kèm thông tin như ảnh bản đồ của trạm và tên trạm
for (i = 0; i < monitoring.length; i++) {//đọc data và đưa vào từng mảng
    locations.push({ lat: parseFloat(monitoring[i].LAT), lng: parseFloat(monitoring[i].LNG) });
    infoWindowContent.push('<div class=\'info_content\'><h5>' + monitoring[i].NAME + '</h5><button type=\'button\' id=\'btnDetail\' class=\'btn btn-link btn-sm\' data-toggle=\'modal\' data-target=\'#myModal\' onclick=initDetail(\''
        + monitoring[i].IMAGE + '\',' + monitoring[i].ID + ',\'' + monitoring[i].NAME.replace(/ /g, ',') + '\')> Xem chi tiết</button ></div >');
};
function initMap() {
    var infoWindow = new google.maps.InfoWindow();//khởi tạo cửa sổ thông tin nhỏ của các điểm khi click vào
    var map = new google.maps.Map(document.getElementById('map'), {//khởi tạo bản đồ
        zoom: 16,//zoom càng lớn thì càng gần, các điểm càng hiện to lên
        center: { lat: 21.0333895, lng: 105.8395289 },//trung tâm bản đồ, lấy điểm này làm giữa màn hình
        disableDefaultUI: true//vô hiệu bản đồ mặc định (bản đồ mặc định có các nút zoom, chọn loại bản đồ hiển thị, view 360, giao thông, ...)
    });
    var markers = locations.map(function (location, i) {//khởi tạo các điểm từ duyệt các vị trí bts
        new google.maps.Circle({ //khởi tạo 1 hình tròn có trung tâm là vị trí bts                                     
            strokeColor: '#00c851', //màu                                                   
            strokeOpacity: 0.8, //độ trong suốt đường tròn, 1 là cao nhất, 0 thấp nhất                                                      
            strokeWeight: 2, //độ dày đường tròn                                                         
            fillColor: '#00c851', //màu bên trong hình tròn                                                     
            fillOpacity: 0.7, //độ trong suốt hình tròn, 1 là cao nhất, 0 thấp nhất                                                       
            map: map, //điểm này gán cho map đã khởi tạo ở trên                                                                
            center: location,//vị trí bts                                                         
            radius: Math.sqrt(10) * 50 //bán kính hình tròn                                          
        });
        return new google.maps.Marker({//custom lại marker (marker chính là 1 trong các điểm ở trên)
            position: location,//vị trí
            icon: '/Content/Images/icon/icon/btsOrange32.png'//icon hiển thị, mặc định là flag
        });
    });
    for (i = 0; i < markers.length; i++) {//duyệt các marker vừa gán cho map ở trên
        google.maps.event.addListener(markers[i], 'click', (function (marker, i) {//bắt dự kiện khi click vào marker
            return function () {
                //map.setCenter(markers[i].getPosition());//dòng này đưa điểm này về giữa màn hình
                infoWindow.setContent(infoWindowContent[i]);//gán nội dung cho marker
                infoWindow.open(map, marker);//mở cửa sổ thông tin của marker
            }
        })(markers[i], i));
    }

    var markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });//khi độ zoom của bản đồ nhỏ, các điểm chồng lên nhau sẽ có icon khác, là số lượng marker khu vực này
};
//function showNotice() { //(đã ko còn dùng)
//    var monitoring2 = $.ajax({//đọc dữ liệu từ server
//        async: false,
//        url: '/BTSMap/DataMonitoringByAccount',
//        type: 'get',
//        data: { 'GetConfig': 'YES' },
//        dataType: "JSON"
//    }).responseJSON;
//    if (equals(monitoring, monitoring2) == false) {//so sánh có sự thay đổi hay ko
//        location.reload();//tải lại trang
//    }
//};
//function equals(x, y) {
//    // If both x and y are null or undefined and exactly the same
//    if (x === y) {
//        return true;
//    }
//    // If they are not strictly equal, they both need to be Objects
//    if (!(x instanceof Object) || !(y instanceof Object)) {
//        return false;
//    }
//    // They must have the exact same prototype chain, the closest we can do is
//    // test the constructor.
//    if (x.constructor !== y.constructor) {
//        return false;
//    }
//    for (var p in x) {
//        // Inherited properties were tested using x.constructor === y.constructor
//        if (x.hasOwnProperty(p)) {
//            // Allows comparing x[ p ] and y[ p ] when set to undefined
//            if (!y.hasOwnProperty(p)) {
//                return false;
//            }
//            // If they have the same strict value or identity then they are equal
//            if (x[p] === y[p]) {
//                continue;
//            }

//            // Numbers, Strings, Functions, Booleans must be strictly equal
//            if (typeof (x[p]) !== "object") {
//                return false;
//            }
//            // Objects and Arrays must be tested recursively
//            if (!equals(x[p], y[p])) {
//                return false;
//            }
//        }
//    }
//    for (p in y) {
//        // allows x[ p ] to be set to undefined
//        if (y.hasOwnProperty(p) && !x.hasOwnProperty(p)) {
//            return false;
//        }
//    }
//    return true;
//}//hàm so sánh 2 mảng json, hình như chưa đúng lắm