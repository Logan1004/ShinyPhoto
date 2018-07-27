$(document).ready(function () {
    var picUrl=getUrlParam("picUrl");
    var price=getUrlParam("price");
    var name=getUrlParam("name");

    // alert(price);
    // alert(test);
    $(".typeInfo").eq(0).text(name);
    $(".eqptPic .wrap img").eq(0).attr("src", picUrl);
    $(".priceInfo").text(price+"/天");
});
function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]);
    return null; //返回参数值
}