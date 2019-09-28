var Js_Login = function () {
    return {
        init: function () {
        },
        Login: function () {
            if ($("#UserName").val() == "") {
                alertmsg.error("Bạn chưa nhập tên đăng nhập!");
                //alertmsg.success("Đăng nhập thành công");
                $("#UserName").focus();
                return false;
            }
            if ($("#Password").val() == "") {
                alertmsg.error("Bạn chưa nhập mật khẩu!");
                $("#Password").focus();
                return false;
            }
        },
        LogOut: function () {
            bootbox.confirm("Bạn muốn đăng xuất?", function () {
                $.ajax({
                    url: 'Login/LogOut',
                    type: 'Post',
                    dataType: 'json',
                    success: function () {     
                    }
                });
                
            })
            
        }
    }
}();
$(document).ready(function () {
    Js_Login.init();
});