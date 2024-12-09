<?php
	session_start(); # 啟動SESSION
	include 'db_connect.php'; # 引入資料庫連線
	
	if(!isset($_POST['Account'])||!isset($_POST['password'])){ # 是否取得值
		echo '請輸入資料後，再前往'; #顯示錯誤資訊
		header("Refresh:3;Url=login.html");# 跳轉至 登入 頁面
		exit;
	}

	$account = mysqli_real_escape_string($link, $_POST['Account']);
    $password = mysqli_real_escape_string($link, $_POST['password']);
  
	$sql = "SELECT * FROM 會員列表 WHERE 會員帳號 = '$account' AND 密碼='$password'"; # 搜尋帳號密碼相符的
	$result =  $link->query($sql); #取得結果

	if ($result->num_rows > 0) { #判定列數是否有超過0 有代表有此帳號且密碼正確
		echo "成功登入，將為你跳轉至下訂頁面。"; #成功則輸出 成功登入
		$_SESSION['account']=$account;  #將帳號名稱 傳入$_SESSION['account']
		header("Refresh:3;Url=menu.php"); #等待3秒後 跳轉至 店家選單頁面
		exit(); // 確保腳本在跳轉後終止


	} else {
		echo "帳號或密碼錯誤，請重新輸入。"; #失敗則輸出 帳號或密碼錯誤，請重新輸入
		header("Refresh:3;Url=login.html");#等待3秒後 跳轉回 登入頁面
		exit(); // 確保腳本在跳轉後終止


	}
	// 關閉結果集
	$result->free();

	// 關閉資料庫連接
	$link->close();


?>
