$(document).ready(function () {
    var memName1=$("#memName1");
    var memText1=$("#memText1");
    var wrap1=$("#wrap1");
    var memName2=$("#memName2");
    var memText2=$("#memText2");
    var wrap2=$("#wrap2");
    var memName3=$("#memName3");
    var memText3=$("#memText3");
    var wrap3=$("#wrap3");
    //四张一组
    var wrap4=$("#wrap4");
    var wrap5=$("#wrap5");
    var wrap6=$("#wrap6");
    var wrap7=$("#wrap7");
    //三张一组
    var wrap8=$("#wrap8");
    var wrap9=$("#wrap9");
    var wrap10=$("#wrap10");

    $(window).scroll(function () {
        if($(window).scrollTop()+innerHeight>memName1.offset().top)
        {
            memName1.css("top", "0px");
            memName1.css("opacity", "1");
        }

        if($(window).scrollTop()+innerHeight>memText1.offset().top)
        {
            memText1.css("left", "0px");
            memText1.css("opacity", "1");
        }

        if($(window).scrollTop()+innerHeight>wrap1.offset().top)
        {
            wrap1.css("opacity", "1");
            wrap1.css("left", "0px");
        }

        if($(window).scrollTop()+innerHeight>memName2.offset().top+100)
        {
            memName2.css("top", "0px");
            memName2.css("opacity", "1");
        }

        if($(window).scrollTop()+innerHeight>memText2.offset().top+100)
        {
            memText2.css("left", "0px");
            memText2.css("opacity", "1");
        }

        if($(window).scrollTop()+innerHeight>wrap2.offset().top+150)
        {
            wrap2.css("opacity", "1");
            wrap2.css("left", "0px");
        }

        if($(window).scrollTop()+innerHeight>memName3.offset().top+100)
        {
            memName3.css("top", "0px");
            memName3.css("opacity", "1");
        }

        if($(window).scrollTop()+innerHeight>memText3.offset().top+100)
        {
            memText3.css("left", "0px");
            memText3.css("opacity", "1");
        }

        if($(window).scrollTop()+innerHeight>wrap3.offset().top+150)
        {
            wrap3.css("opacity", "1");
            wrap3.css("left", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap4.offset().top+100)
        {
            wrap4.css("opacity", "1");
            wrap4.css("left", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap5.offset().top+50)
        {
            wrap5.css("opacity", "1");
            wrap5.css("top", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap6.offset().top+50)
        {
            wrap6.css("opacity", "1");
            wrap6.css("top", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap7.offset().top+100)
        {
            wrap7.css("opacity", "1");
            wrap7.css("left", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap8.offset().top+100)
        {
            wrap8.css("opacity", "1");
            wrap8.css("left", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap9.offset().top+100)
        {
            wrap9.css("opacity", "1");
            wrap9.css("top", "0px");
        }

        if($(window).scrollTop()+innerHeight>wrap10.offset().top+100)
        {
            wrap10.css("opacity", "1");
            wrap10.css("left", "0px");
        }
    });
});