var alertmsg = {}
alertmsg.error = function (content) {
    $.Notification.notify('error', 'top right', 'Thông báo!', content);
    setTimeout(function () {
        $(".notifyjs-wrapper").hide();
    }, 3000);
    return false;
};
alertmsg.success = function (content) {
    $.Notification.notify('success', 'top right', 'Thông báo', content);
    setTimeout(function () {
        $(".notifyjs-wrapper").fadeOut();
    }, 3000);
    return true;
};
alertmsg.NotificationBootbox = function (content, isReload) {
    bootbox.alert({ title: "Thông báo", message: content, buttons: { ok: { label: '<i class="fa fa-times-circle-o"></i> Đóng', className: 'btn btn-default btnAlertBootbox' } } });
    if (isReload) {
        setTimeout(function () {
            location.reload();
        }, 3000);
    }
};
alertmsg.init = function () { };
$(document).ready(function () {
    alertmsg.init();
})