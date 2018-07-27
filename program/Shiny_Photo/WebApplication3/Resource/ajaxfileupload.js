function ajaxFileUpLoad() {
    $.ajaxFileUpload(
        {
            url: 'Handlers/FileUpload.ashx?method=ajaxFileUpload',
            secureuri: false,
            fileElementId: 'fileToUpload',
            dataType: 'json',
            success: function (data, status) {
                $('#img1').attr("src", data.imgurl);
                if (typeof (data.error) !== 'undefined') {
                    if (data.error !== '') {
                        alert(data.error);
                    } else {
                        alert(data.msg);
                    }
                }
            },
            error: function (data, status, e) {
                alert(e);
            }
        }
    )
    return false;
}