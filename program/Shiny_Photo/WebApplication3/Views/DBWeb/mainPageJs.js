$(document).ready(function () {
    $(window).scrollTop(0);
    var galPics=$(".galPic");
    var galPic0=galPics.eq(0);
    var galPic1=galPics.eq(4);
    var galPic2=galPics.eq(8);
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

        if($(window).scrollTop()+innerHeight>galPic1.offset().top)
        {
            showGalPic(1);
        }

        if($(window).scrollTop()+innerHeight>galPic2.offset().top)
        {
            showGalPic(2);
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
    $(".navLogo").css({height: 120, width: 240});
    $("#mainPageNav ul").css("margin-top", "35px");
    $("#mainPageNav ul a").css("font-size", "24px");
    $("#mainPageNav ul a").css("color", "white");
}

function showGalPic(i) {
    for(var j=0; j<4; ++j) {
        var tem=$(".galPic").eq(i*4+j);
        tem.css("top", "0px");
        tem.css("opacity", "1");
    }
}