$(document).ready(function () {
    var tem1='test1';
    var tem2='test2';
    var tem3='test3';
    var test='<tr><td>'+tem1+'</td><td>'+tem2+'</td><td>'+tem3+'</td></tr>';
    for(var i=1; i<20; ++i){
        $("#orderTable1").append(test);
    }
    myPagination("#orderTable1 tr", "#service1 .pagination li");
    myPagination("#orderTable2 tr", "#service2 .pagination li");
});

function myClear(str1, str2) {
    var len=$(str1).length;
    for(var i=0; i<len; ++i)
}
function myPagination(str1, str2) {
    var len=$(str1).length;
    var pages=parseInt(len/10);
    if(len-pages*10>0){
        pages++;
    }
    for(var i=0; i<pages; ++i){
        var w1='<li><a href="#">'
        var w2=i+1;
        var w3='</a></li>';
        var par=w1+w2+w3
        $(str2).eq(i).after(w1+w2+w3);
    }
    str3=str2+" a";
    for(var j=1; j<=pages; ++j){
        $(str3).eq(j).on("click", function () {
            var curPage=parseInt(this.text);
            $(str1).eq(curPage*10-10).siblings().hide();
            for(var k=curPage*10-10; k<curPage*10; k++){
                $(str1).eq(k).show();
            }
        });
    }
    if(len>10){
        $(str1).eq(0).siblings().hide();
        for(var i=0; i<10; ++i){
            $(str1).eq(i).show();
        }
    }
}