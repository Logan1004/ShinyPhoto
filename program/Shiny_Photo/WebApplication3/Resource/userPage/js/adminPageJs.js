$(document).ready(function () {
    myPagination("#orderTable1 tr", "#pagination1 li");
    myPagination("#orderTable2 tr", "#pagination2 li");
    myPagination("#empTable tr", "#pagination3 li");
    myPagination("#userTable tr", "#pagination4 li");
 
});


function myPagination(str1, str2) {
    var len=$(str1).length;
    var pages=parseInt(len/10);
    if(len-pages*10>0){
        pages++;
    }
    for(var i=0; i<pages; ++i){
        var w1='<li><a href="#">';
        var w2=i+1;
        var w3='</a></li>';
        var par=w1+w2+w3;
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

function clearTest(str1, str2) {
    var len=$(str1).length;
    var i=$(str1).eq(0).nextAll().remove();
    var pages=parseInt(len/10);
    if(len-pages>10){
        pages++;
    }
    for(var i=0; i<pages; ++i){
        $(str2).eq(1).remove();
    }
}



