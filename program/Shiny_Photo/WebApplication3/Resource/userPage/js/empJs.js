$(document).ready(
    function () {
        myPagination("#picContainer li", "#myPagination li");
    }
);
function myPagination(str1, str2) {
    var len=$(str1).length;
    var pages=parseInt(len/8);
    if(len-pages*8>0){
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
            $(str1).eq(curPage*8-8).siblings().hide();
            for(var k=curPage*8-8; k<curPage*8; k++){
                $(str1).eq(k).show();
            }
        })
    }
    if(len>8){
        $(str1).eq(0).siblings().hide();
        for(var i=0; i<8; ++i){
            $(str1).eq(i).show();
        }
    }
}