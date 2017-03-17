// Account menu
var url = window.location.pathname;
var url_parts = url.replace(/\/\s*$/, '').split('/');

if ($('#' + url_parts[3])) {
    $('.account-nav-item').removeClass('active');
    $('#' + url_parts[3]).addClass('active');
}