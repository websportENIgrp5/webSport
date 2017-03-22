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

responsiveSelect.text($('#' + url_parts[3]).text());

responsiveSelect.click(function () {
    if (accountMenuNav.parent().hasClass('active')) {
        accountMenuNav.slideUp();
        accountMenuNav.parent().removeClass('active');
    }
    else {
        accountMenuNav.slideDown();
        accountMenuNav.parent().addClass('active');
    }
});

$(window).resize(function () {
    if ($('#' + url_parts[3]) && ($(window).width() < 1001)) {
        accountMenuNav.css('display', 'none');
        $('.account-nav-item').parent().removeClass('active');
        responsiveSelect.text(url_parts[3]);
    }
    else {
        accountMenuNav.css('display', 'block');
        $('.account-nav-item').removeClass('active');
        $('#' + url_parts[3]).addClass('active');
    }
});

// Table responsive
var tableTitle = $('.table-title');

tableTitle.click(function () {
    var tableContent = $(this).find('.mobile-table-content');

    if ($(window).width() <= 670) {
        if (!tableContent.parent().hasClass('td-active')) {
            $('.mobile-table-content').slideUp();
            $('.mobile-table-content').parent().removeClass('td-active');

            tableContent.slideDown();
            tableContent.parent().addClass('td-active');
        }
        else {
            $('.mobile-table-content').slideUp();
            $('.mobile-table-content').parent().removeClass('td-active');
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