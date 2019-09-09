var Login = function () {
    return {
        init: function () {
        },
        checkLogin: function () {
            $(document).ready(function () {
                $("#linkClose").click(function () {
                    $("divError").hide('fade');
                });
                $("btnLogin").click(function () {
                    $.ajax({
                        url: '/Index',
                        method: 'POST',
                        contentType:'applicattion/json',
                        data: {
                            UserName: $("UserName").val(),
                            Password: $("Password").val()
                        },
                        success: function (response) {

                            $("divError").show('fade');
                        }
                    })
                })
            })
        }
    }
}