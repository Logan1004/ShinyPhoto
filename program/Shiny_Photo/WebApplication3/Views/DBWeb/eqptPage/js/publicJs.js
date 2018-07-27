$(document).ready(function () {
    $(window).scrollTop(0);
    $(window).scroll(function () {
        if($(window).scrollTop()>0)
        {
            normalNav();
        }
        else {
            lgNav();
        }

        if($(window).scrollTop()+innerHeight>galPic0.offset().top)
        {
            showGalPic(0);
        }
    });
});

function normalNav() {
    $("#mainPageNav").css({height: 88});
    $("#mainPageNav").css("background-color", "rgba(255, 255, 255, 0.7)");
    $(".navLogo").css({height: 68, width: 160});
    $("#mainPageNav ul").css("margin-top", "10px");
    $("#mainPageNav ul a").css("font-size", "20px");
    $("#mainPageNav ul a").css("color", "black");

    //$("#mainPageNav .ul .li .a").css()
}

function lgNav() {
    $("#mainPageNav").css({height: 144});
    $("#mainPageNav").css("background-color", "rgba(255, 255, 255, 0)");
    $(".navLogo").css({height: 140, width: 280});
    $("#mainPageNav ul").css("margin-top", "35px");
    $("#mainPageNav ul a").css("font-size", "24px");
    $("#mainPageNav ul a").css("color", "white");
}