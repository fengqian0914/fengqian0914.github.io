<?php
    session_start();
    if(!isset($_POST['storeid'])){
		echo '請送出資訊後，再前往';
		header("Refresh:3;Url=menu.php");
		exit;
	}
    $_SESSION['storeId']=$_POST['storeid'];
    header('Location: products.php');
?>