<?php
	header("Content-Type:text/html; charset=utf-8");
	$id= $_POST['id'];
	$pwd = $_POST['password'];
	
	echo "中文： $id, 密碼為： $pwd <br>";
?>