$(document).ready(function () {
    var curType=getUrlParam("typeIndex");
    if(curType==null){
        curType=0;
    }
    $("#eqptTabs li").eq(curType).addClass("active");
    $("#eqptTabContent .tab-pane").eq(curType).addClass("active");
    $("#eqptTabs li").eq(curType).siblings().removeClass("active");
    $("#eqptTabContent .tab-pane").eq(curType).siblings().removeClass("active");
    myPagination("#container1 li", "#pagination1 li");
    myPagination("#container2 li", "#pagination2 li");
    myPagination("#container3 li", "#pagination3 li");
    myPagination("#container4 li", "#pagination4 li");
    myPagination("#container5 li", "#pagination5 li");
    myPagination("#container6 li", "#pagination6 li");
    myPagination("#container7 li", "#pagination7 li");
    myPagination("#container8 li", "#pagination8 li");
});

function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]);
    return null; //返回参数值
}

function myPagination(str1, str2) {
    // alert(str1);
    var len=$(str1).length;
    var pages=parseInt(len/8);
    if(len-pages*8>0){
         pages++;
     }
     // alert(pages);
    for(var i=0; i<pages; ++i){
        var w1='<li><a href="#">';
        var w2=i+1;
        var w3='</a></li>';
        var par=w1+w2+w3;
        $(str2).eq(i).after(par);
    }
    for(var j=1; j<=pages; ++j){
        str3=str2+" a";
        $(str3).eq(j).on("click", function () {
             var curPage=parseInt(this.text);
             $(str1).eq(curPage*8-8).siblings().hide();
             for(var k=curPage*8-8; k<curPage*8; ++k){
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