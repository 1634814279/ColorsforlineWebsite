
var restart = 'false';
//var highscore = 0;
//var highscoreForTheFirstTime = true;
var x1 = -1, x2, y1 = -1, y2;
var width;
const UID = localStorage.UID;
var x = -1, y = -1;//只在Change()函数中为确认上一个按钮的选择使用的临时变量
function Change(e) {
    /*alert($("p").css("visibility"));
    if ($("p").css("visibility") == "visible") { $("p").css("visibility", "hidden"); }
    else { $("p").css("visibility", "visible"); };*/
    //$("#00").css("background-color", intToColor(1));
    /*
    x1 = $("#x1")[0].value;
    y1 = $("#y1")[0].value;
    x2 = $("#x2")[0].value;
    y2 = $("#y2")[0].value;
    */
    if (!e) { var e = window.event; }
    //获取事件点击元素  
    var targ = e.target;
    //获取元素名称  
    var tname = targ.id;
    if (tname[0] == 'b') {
        //if ((x == -1 || y == -1) && (typeof (x) == 'undefined' || typeof (y) == 'undefined'))
        if (x == -1 || y == -1) {
            x = tname[1];
            y = tname[2];
        }
        else {
            x1 = x;
            y1 = y;
            x2 = tname[1];
            y2 = tname[2];
            x = -1;
            y = -1;
            CanMoveAjax();
        }
    }
}

function CanMoveAjax() {
    $.ajax({
        type: "POST",
        url: "Default.aspx/CanMove",
        data: '{"x1":"' + x1 + '","y1":"' + y1 + '","x2":"' + x2 + '","y2":"' + y2 + '","UID":"'+ UID +'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: CanMove,
        failure: function (response) {
            alert(response.d);
        }
    });
}
function RefreshAjax() {
    $.ajax({
        type: "POST",
        url: "Default.aspx/Refresh",
        data: '{"restart":"' + restart + '","UID":"' + UID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Refresh,
        failure: function (response) {
            alert(response.d);
        }
    });
    if (restart == 'true') restart = 'false';
}
function Restart() {
    restart = 'true';
    RefreshAjax();
}
//获取鼠标点击的元素
function show_element(e) {
    if (!e) {
        var e = window.event;
    }
    //获取事件点击元素  
    var targ = e.target;
    //获取元素名称  
    //var tname = targ.tagName;
    var tname = targ.id;
    alert(tname);
}
function CanMove(response) {
    var canmove = response.d;
    if (canmove == 'true' || canmove == 'false') {
        RefreshAjax();
    } else {
        alert('GameOver');
        Restart();
    }
}
function Refresh(response) {
    //$("#response").text(response.d)
    //alert(response.d);
    //return 0;
    var objline = JSON.parse(response.d);//提取返回的对象数据并将数据解析为json
    //width = $("#b00").css("width");
    var line = new Array(7);
    line[0] = objline.line0;
    line[1] = objline.line1;
    line[2] = objline.line2;
    line[3] = objline.line3;
    line[4] = objline.line4;
    line[5] = objline.line5;
    line[6] = objline.line6;
    line[7] = objline.line7;
    for (var i = 0; i <= 7; i++) {
        for (var j = 0; j <= 7; j++) {
            $("#b" + i + j).removeClass();
            $("#b" + i + j).addClass(intToColor(line[i][j]));
            //$("#b" + i + j).css("background-color", intToColor(line[i][j]));
            //$("#b" + i + j).css("height", width);
        }
    }
    //$("#c1").css("height", width);
    //$("#c2").css("height", width);
    //$("#c3").css("height", width);
    $("#c1").removeClass();
    $("#c2").removeClass();
    $("#c3").removeClass();
    $("#c1").addClass(intToColor(objline.color[0]));
    $("#c2").addClass(intToColor(objline.color[1]));
    $("#c3").addClass(intToColor(objline.color[2]));
    $("#score").text('当前分数为' + objline.score);
    $("#highscore").text('最高分数为' + objline.highscore);
    /*
    if (highscoreForTheFirstTime == true) {
        highscoreForTheFirstTime = false;
        highscore = objline.highscore;
    }
    */
    if (parseInt(objline.highscore) > parseInt(objline.score)) {
        $("#kingimg").css("background-position", "50% 0");
        $("#challengerimg").css("background-position", "50% " + (parseInt(objline.score) / parseInt(objline.highscore) * 100 - 85) + "%");
    } else if (parseInt(objline.highscore) < parseInt(objline.score)) {
        $("#challengerimg").css("background-position", "50% 0");
        $("#kingimg").css("background-position", "50% " + (parseInt(objline.highscore) / parseInt(objline.score) * 100 - 85) + "%");
    } else {
        $("#challengerimg").css("background-position", "50% 0");
        $("#kingimg").css("background-position", "50% 0");
    }

}
function intToColor(color) {
    color = parseInt(color);
    switch (color) {
        case 0: return "background"
        case 1: return "blue"
        case 2: return "green"
        case 3: return "grey"
        case 4: return "purple"
        case 5: return "red"
        case 6: return "yellow"
    }
}
window.onresize = function () {
    width = $("#b00").css("width");
    for (var i = 0; i <= 7; i++) {
        for (var j = 0; j <= 7; j++) {
            $("#b" + i + j).css("height", width);
        }
    }
    $("#c1").css("height", width);
    $("#c2").css("height", width);
    $("#c3").css("height", width);
}
function onload() {
    if (localStorage.UID == '' || localStorage.username == '' || localStorage.UID == undefined || localStorage.username == undefined) {
        window.location.href = "login.aspx";
        return 0;
    }
    $.ajax({
        type: "POST",
        url: "Default.aspx/firstLoad",
        data: '{"UID":"' + UID + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {},
        failure: function (response) {
            alert(response.d);
        }
    });
    $('#username').text(localStorage.username);
    width = $("#b00").css("width");
    //width='50px'
    for (var i = 0; i <= 7; i++) {
        for (var j = 0; j <= 7; j++) {
            $("#b" + i + j).css("height", width);
        }
    }
    $("#c1").css("height", width);
    $("#c2").css("height", width);
    $("#c3").css("height", width);
    $(".img").css("visibility", "visible");
    RefreshAjax();
}
function logout() {
    localStorage.UID = '';
    localStorage.username = '';
    window.location.href = "login.aspx";
}