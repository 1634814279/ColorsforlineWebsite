<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<script src="js/jquery-3.1.1.min.js" type="text/javascript"></script>
<script src="js/main.js" type="text/javascript"></script>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="css/main.css" />
    <title>五彩连珠</title>
</head>
    <body style = "font-family:Arial; font-size:20pt" onmousedown="Change(event)" onload="onload()"">
        <q id="response" style="font-size:10pt/*;visivility:hidden;*/">lib 1.4</q>
        <q id="username" style="font-size:10pt;float:right/*;visivility:hidden;*/"></q>
    <!--<body style = "font-family:Arial; font-size:10pt">-->
    <!--<p id="00" style="visibility:visible"></p>-->
        <div id="topbar">
        <input id="refresh" type="button" value="重新开始游戏" onclick = "Restart()" />
        <input id="logout" type="button" value="退出登录" onclick = "logout()" />
        </div>
        <div id="king" class="top">
            <q id="highscore">最高分数为0</q>
            <div id="kingimg" class="img"></div>
            <div class="bottom"></div>
        </div>
<div id="chessboard">
    <div>
    <div id="nextcolor"></div>
        <p id="c1"></p><p id="c2"></p><p id="c3"></p>
    </div>
    <div id="margin"></div>
    <div id="chessboardcenter"></div>
<div id="line1" class="line">
    <p id="b00" style="clear:both"></p>
    <p id="b01"></p>
    <p id="b02"></p>
    <p id="b03"></p>
    <p id="b04"></p>
    <p id="b05"></p>
    <p id="b06"></p>
    <p id="b07"></p>
</div>
<div id="line2" class="line">
    <p id="b10" style="clear:both"></p>
    <p id="b11"></p>
    <p id="b12"></p>
    <p id="b13"></p>
    <p id="b14"></p>
    <p id="b15"></p>
    <p id="b16"></p>
    <p id="b17"></p>
</div>
<div id="line3" class="line">
    <p id="b20" style="clear:both"></p>
    <p id="b21"></p>
    <p id="b22"></p>
    <p id="b23"></p>
    <p id="b24"></p>
    <p id="b25"></p>
    <p id="b26"></p>
    <p id="b27"></p>
</div>
<div id="line4" class="line">
    <p id="b30" style="clear:both"></p>
    <p id="b31"></p>
    <p id="b32"></p>
    <p id="b33"></p>
    <p id="b34"></p>
    <p id="b35"></p>
    <p id="b36"></p>
    <p id="b37"></p>
</div>
<div id="line5" class="line">
    <p id="b40" style="clear:both"></p>
    <p id="b41"></p>
    <p id="b42"></p>
    <p id="b43"></p>
    <p id="b44"></p>
    <p id="b45"></p>
    <p id="b46"></p>
    <p id="b47"></p>
</div>
<div id="line6" class="line">
    <p id="b50" style="clear:both"></p>
    <p id="b51"></p>
    <p id="b52"></p>
    <p id="b53"></p>
    <p id="b54"></p>
    <p id="b55"></p>
    <p id="b56"></p>
    <p id="b57"></p>
</div>
<div id="line7" class="line">
    <p id="b60" style="clear:both"></p>
    <p id="b61"></p>
    <p id="b62"></p>
    <p id="b63"></p>
    <p id="b64"></p>
    <p id="b65"></p>
    <p id="b66"></p>
    <p id="b67"></p>
</div>
<div id="line8" class="line">
    <p id="b70" style="clear:both"></p>
    <p id="b71"></p>
    <p id="b72"></p>
    <p id="b73"></p>
    <p id="b74"></p>
    <p id="b75"></p>
    <p id="b76"></p>
    <p id="b77"></p>
</div>
</div>
        <div id="challenger" class="top">
            <q id="score">当前分数为0</q>
            <div id="challengerimg" class="img"></div>
            <div class="bottom"></div>
        </div>
            
<!--<form id="form1" runat="server">
<div>
    x1:
    <asp:TextBox ID="x1" runat="server"></asp:TextBox>
    y1:
    <asp:TextBox ID="y1" runat="server"></asp:TextBox>
    x2:
    <asp:TextBox ID="x2" runat="server"></asp:TextBox>
    y2:
    <asp:TextBox ID="y2" runat="server"></asp:TextBox>
    <input id="btnGo" type="button" value="Go!" onclick = "Change(event)" />
    <input id="refresh" type="button" value="Refresh" onclick = "RefreshAjax()" />
</div>
</form>-->

</body>
</html>