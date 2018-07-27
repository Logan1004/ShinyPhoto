$(document).ready(function () {
    var galPics=$(".galPic");
    var galPic0=galPics.eq(0);
    var galPic1=galPics.eq(4);
    var galPic2=galPics.eq(8);
    $(window).scroll(function () {
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


function showGalPic(i) {
    for(var j=0; j<4; ++j) {
        var tem=$(".galPic").eq(i*4+j);
        tem.css("top", "0px");
        tem.css("opacity", "1");
    }
}