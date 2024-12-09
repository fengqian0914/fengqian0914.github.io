<?php
 	session_start(); # 啟動SESSION
	 include 'db_connect.php'; # 引入資料庫連線


	if(!isset($_POST['Account'])||!isset($_POST['email'])){  # 是否取得值
		echo '請送出資訊後，再前往'; //顯示錯誤資訊
		header("Refresh:3;Url=forget.html");# 跳轉至 忘記密碼頁面
		exit; // 確保腳本在跳轉後終止
	}
	
    $account = mysqli_real_escape_string($link, $_POST['Account']);  # 防止 SQL 注入攻擊
    $email = mysqli_real_escape_string($link, $_POST['email']);  # 防止 SQL 注入攻擊
    session_start();
    // 檢查連接
    
    
	$sql = "SELECT * FROM 會員列表 WHERE 會員帳號 = '$account' and EMAIL = '$email '" ; # 搜尋帳號信箱相符的
	$result =  $link->query($sql);  #取得結果

	if ($result->num_rows > 0) {  #判定列數是否有超過0 有代表有此帳號且信箱正確
		$_SESSION['update_account']=$account; #將帳號名稱 傳入$_SESSION['update_account']
		header("Location: newpassword.html"); #跳轉至 更換密碼頁面
		exit(); // 確保腳本在跳轉後終止


	} else {
		echo "帳號或信箱有誤，請重新輸入，三秒後將重新導回"; #失敗則輸出 帳號或信箱有誤，請重新輸入，三秒後將重新導回
		header("Refresh: 3; URL=forget.html"); #等待3秒後 跳轉回 忘記密碼頁面
		exit(); // 確保腳本在跳轉後終止


	}
		// 關閉結果集
		$result->free();

		// 關閉資料庫連接
		$link->close();
?>
