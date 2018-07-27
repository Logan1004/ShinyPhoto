function formDataUpload() {
    var fileupload = document.getElementById('fileToUpload').files;
    var formdata = new FormData();
    formdata.append('files', fileupload[0]);
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("post", 'Handlers/FileUpload.ashx?method=formDataUpload');
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState === 4 && xmlHttp.status === 200) {
            alert('上传成功');
        }
        else {
            alert('上传fail');
        }
    }
    xmlHttp.send(formdata);
}