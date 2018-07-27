$(document).ready(
    function () {
        if($.cookie("loveNum")!=null){
            $("#myLoveNum").text=$.cookie("loveNum");
        }
        myPagination("#picContainer1 li", "#type1 .pagination li");
        myPagination("#picContainer2 li", "#type2 .pagination li");
        myPagination("#picContainer3 li", "#type3 .pagination li");
        myPagination("#picContainer4 li", "#type4 .pagination li");
        myPagination("#picContainer5 li", "#type5 .pagination li");
        myPagination("#picContainer6 li", "#type6 .pagination li");
        myPagination("#picContainer7 li", "#type7 .pagination li");
        myPagination("#picContainer8 li", "#type8 .pagination li");
        myPagination("#picContainer9 li", "#type9 .pagination li");
        myPagination("#picContainer10 li", "#type10 .pagination li");
        myPagination("#picContainer11 li", "#type11 .pagination li");
        myPagination("#picContainer12 li", "#type12 .pagination li");
    }
);

function myPagination(str1, str2) {
    var len=$(str1).length;
    var pages=parseInt(len/16);
    if(len-pages*16>0){
        pages++;
    }
    for(var i=0; i<pages; ++i){
        var w1='<li><a href="#">';
        var w2=i+1;
        var w3='</a></li>';
        var par=w1+w2+w3;
        $(str2).eq(i).after(par);
    }
    var str3=str2+' a';
    for(var j=1; j<=pages; ++j){
        $(str3).on("click", function () {
            var curPage=this.text;
            $(str1).eq(curPage*16-16).siblings().hide();
            for(var k=curPage*16-16; k<curPage*16; k++){
                $(str1).eq(k).show();
            }
        })
    }
    if(len>16){
        $(str1).eq(0).siblings().hide();
        for(var i=0; i<16; ++i){
            $(str1).eq(i).show();
        }
    }
}

function saveLoveNum() {
    var tem=$("#myLoveNum").text;
    var newNum=parseInt(tem)+1;
    $.cookie("loveNum", newNum);
    $("#myLoveNum").text(newNum);
}