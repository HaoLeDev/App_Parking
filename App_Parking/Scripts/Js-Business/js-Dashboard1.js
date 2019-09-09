var Js_Dashboard1 = function () {
    return {
        init: function () { },
        GetAll: function () {
            $.ajax({
                url: 'https://restcountries.eu/rest/v2/name/united',
                contentType: 'application/json',
                type: 'GET',
                dataType: 'json',
                success: function (res) {
                    console.log(res);
                },
                error: function (error, xhr) {
                    console.log(error);
                }
            });
        }
    }
}();
$(document).ready(function () {
    Js_Dashboard1.init();
});