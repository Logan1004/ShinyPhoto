$(document).ready(function () {
    // for(var i=0; i<20; i++) {
    //     var tem1 = 'test1';
    //     var tem2 = 'test2';
    //     var tem3 = 'test3';
    //     var test = '<tr><td>' + tem1 + '</td><td>' + tem2 + '</td><td>' + tem3 + '</td></tr>';
    //     $("#orderTable1").append(test);
    // }
    $("#testBtn").click(function () {
        alert("meibug");
        ajaxFileUpload();
    })
});

function ajaxFileUpload() {
    $.ajaxFileUpload
    (
        {
            url: '/Test/Upload', //用于文件上传的服务器端请求地址
            secureuri: false, //是否需要安全协议，一般设置为false
            fileElementId: 'file1', //文件上传域的ID
            dataType: 'json', //返回值类型 一般设置为json
            success: function (data, status)  //服务器成功响应处理函数
            {
                alert("OJBK");
                $("#img1").attr("src", data.imgurl);
                if (typeof (data.error) != 'undefined') {
                    if (data.error != '') {
                        alert(data.error);
                    } else {
                        alert(data.msg);
                    }
                }
            },
            error: function (data, status, e)//服务器响应失败处理函数
            {
                
            }
        }
    )
    return false;
}

