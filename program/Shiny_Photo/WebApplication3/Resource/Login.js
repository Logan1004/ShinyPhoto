$(document).ready(function () {
    $.ajax({
        type: "post",　　　　　　　　　　//以POST的方式发送请求
        url: "/Home/TestAjax",　　　　　　　　　　　　//上面拼凑的链接及参数
        // contentType: "application/json",
        data: { "name": "wtj", "id": 1652791 },
        dataType: "json",
        success: function (data) {
            //成功获取一般处理程序响应后执行的代码
            alert(data.name);
        },
        error: function (err) {
            //收到一般处理程序响应失败后执行的代码
        }
    });
});

