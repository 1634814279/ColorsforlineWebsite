<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" %>

<!DOCTYPE html>
<script src="js/jquery-3.1.1.min.js" type="text/javascript"></script>
<script src="js/login.js" type="text/javascript"></script>
<script src="js/sha1.js" type="text/javascript"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Colorsforline Login</title>
    <link rel="stylesheet" type="text/css" href="css/login.css" />
</head>
<body onload="load()">
<div class="container">
	<section id="content">
		<form action="">
			<h1>Colorsforline</h1>
			<div>
				<input type="text" placeholder="Username" required="" id="username" />
			</div>
			<div>
				<input type="password" placeholder="Password" required="" id="password" />
			</div>
            <div class="warning">
                <p id="warningsign"></p>
            </div>
			<div>
				<input type="button" value="Log in" onclick="login()"/>
				<input type="button" value="Register" onclick="regsiter()"/>
                <!--
				<a href="#">Lost your password?</a>
				<a href="#">Register</a
                -->
			</div>
		</form><!-- form -->
        <!--
		<div class="button">
			<a href="#">Download source file</a>
		</div>
        -->
        <!-- button -->
	</section><!-- content -->
</div><!-- container -->
</body>
</html>
