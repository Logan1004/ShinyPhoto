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

        // if($(window).scrollTop()+innerHeight>$("#memName1").offset().top)
        // {
        //     $("#memName1").css("top", "0px");
        //     $("#memName1").css("opacity", "1");
        // }
        //
        // if($(window).scrollTop()+innerHeight>$("#memText1").offset().top)
        // {
        //     $("#memText1").css("left", "0px");
        //     $("#memText1").css("opacity", "1");
        // }
        //
        // if($(window).scrollTop()+innerHeight>$("#wrap1").offset().top)
        // {
        //     var tem=$("#wrap1");
        //     tem.css("opacity", "1");
        //     tem.css("left", "0px");
        // }
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