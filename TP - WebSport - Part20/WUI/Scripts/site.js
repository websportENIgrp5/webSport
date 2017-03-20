// Menu responsive
var btnMenu = $('.moblie-menu-button');
var menu = $('.nav-menu');

btnMenu.click(function () {
    if (menu.hasClass('active')) {
        menu.slideUp();
        menu.removeClass('active');
    }
    else {
        menu.slideDown();
        menu.addClass('active');
    }
});

// Account menu
var url = window.location.pathname;
var url_parts = url.replace(/\/\s*$/, '').split('/');
var responsiveSelect = $('.account-menu-responsive');
var accountMenuNav = $('.account-menu-nav');

if ($('#' + url_parts[3]) && $(window).width() > 1001) {
        $('.account-nav-item').removeClass('active');
        $('#' + url_parts[3]).addClass('active');
}
else {
    responsiveSelect.text($('#' + url_parts[3]).text());

    responsiveSelect.click(function () {
        if (accountMenuNav.hasClass('active')) {
            accountMenuNav.slideUp();
            accountMenuNav.removeClass('active');
        }
        else {
            accountMenuNav.slideDown();
            accountMenuNav.addClass('active');
        }
    });
}

$(window).resize(function () {
    if ($('#' + url_parts[3]) && ($(window).width() < 1001)) {
        $('.account-nav-item').removeClass('active');
        responsiveSelect.text(url_parts[3]);
    }
    else {
        $('.account-nav-item').removeClass('active');
        $('#' + url_parts[3]).addClass('active');
    }
});

// Table responsive
var tableTitle = $('.table-title');

tableTitle.click(function () {
    var tableContent = $(this).find('.mobile-table-content');

    if ($(window).width() <= 670) {
        if (!tableContent.hasClass('td-active')) {
            $('.mobile-table-content').slideUp();
            $('.mobile-table-content').removeClass('td-active');

            tableContent.slideDown();
            tableContent.addClass('td-active');
        }
        else {
            $('.mobile-table-content').slideUp();
            $('.mobile-table-content').removeClass('td-active');
        }
    }

    $(window).resize(function () {
        if ($(window).width() > 670) {
            $('.mobile-table-content').css('display', 'block');
        }
        else {
            $('.mobile-table-content').css('display', 'none');
        }
    });
});