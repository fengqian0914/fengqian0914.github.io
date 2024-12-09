<?php
	header("Content-Type:text/html; charset=utf-8");
	$Account= $_POST['Account'];
	$password = $_POST['password'];
	
	echo "帳號(員工編號)： $Account <br> 密碼： $password <br>";
?>