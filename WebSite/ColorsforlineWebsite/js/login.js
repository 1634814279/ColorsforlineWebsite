function login() {
    if ($('#username').val() == '' || $('#password').val() == '') {
    } else {
        var username = $('#username').val();
        var password = hex_sha1($('#password').val());
        $.ajax({
        type: "POST",
        url: "login.aspx/login",
        data: '{"username":"' + username + '","userpw":"' + password + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var returnstring = JSON.parse(response.d);//提取返回的对象数据并将数据解析为json
            if (returnstring.login == 'true') {
                localStorage.UID = returnstring.UID;
                localStorage.username = username;
                window.location.href = "Default.aspx";
            } else {
                $("#warningsign").text('Invaild username or password');
                $(".warning").css("visibility", "visible");
            }
        },
        failure: function (response) {
            alert(response.d);
        }
        });
    }
}
function regsiter() {
    if ($('#username').val() == '' || $('#password').val() == '') {
    } else {
        var username = $('#username').val();
        var password = hex_sha1($('#password').val());
        $.ajax({
            type: "POST",
            url: "login.aspx/regsiter",
            data: '{"username":"' + username + '","userpw":"' + password + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var returnstring = JSON.parse(response.d);//提取返回的对象数据并将数据解析为json
                if (returnstring.regsiter == 'true') {
                    localStorage.UID = returnstring.UID;
                    localStorage.username = username;
                    window.location.href = "Default.aspx";
                } else if (returnstring.regsiter == 'false') {
                    $("#warningsign").text('This username had already been registered');
                    $(".warning").css("visibility", "visible");
                }
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

}
function load() {
    if (localStorage.UID != '' && localStorage.UID != undefined && localStorage.username != '' && localStorage.username != undefined) {
        window.location.href = "Default.aspx";
    }
    return 0;
}