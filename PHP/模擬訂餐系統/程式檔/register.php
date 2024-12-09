<?php

include 'db_connect.php';


if(!isset($_POST['account'])||!isset($_POST['name'])||!isset($_POST['phone'])||
!isset($_POST['email'])||!isset($_POST['password1'])||!isset($_POST['password2'])){//檢查傳值
	echo '請輸入資料';#錯誤資訊
	header("Refresh:3;Url=register.html");#跳轉頁面
	exit;#跳離
}

// 接收表單數據
$account = $_POST['account']; // 接收表單中 'account' 欄位的值
$name = $_POST['name']; // 接收表單中 'name' 欄位的值
$phone = $_POST['phone']; // 接收表單中 'phone' 欄位的值
$email = $_POST['email']; // 接收表單中 'email' 欄位的值
$password1 = $_POST['password1']; // 接收表單中 'password1' 欄位的值
$password2 = $_POST['password2']; // 接收表單中 'password2' 欄位的值

// 確認兩次密碼輸入一致
if ($password1 !== $password2) {
    // 如果兩次密碼不一致
    echo '兩次密碼輸入不一致'; // 顯示錯誤信息
    header("Refresh:3;Url=register.html"); // 3秒後跳轉至註冊頁面
	exit(); // 確保腳本在跳轉後終止

} else {
    // 如果兩次密碼一致

    // 準備 SQL 語句並綁定參數
    $sql = "INSERT INTO `會員列表` (`會員帳號`, `姓名`, `電話`, `EMAIL`, `密碼`) VALUES (?, ?, ?, ?, ?)";
    // 準備 SQL 語句
    $stmt = $link->prepare($sql);
    // 綁定參數 (會員帳號、姓名、電話、EMAIL、密碼)
    $stmt->bind_param("sssss", $account, $name, $phone, $email, $password1);

    // 執行 SQL 語句
    if ($stmt->execute()) {
        // 如果執行成功

        // 啟動會話
        session_start();
        // 設置會話變量
        $_SESSION['account'] = $account;

        // 顯示成功信息
        echo '<h1>'.$account.'您好，恭喜您註冊成功</h1>';
        // 跳轉到 Loading.php
        header('Location: Loading.php');
    } else {
        // 如果執行失敗

        // 顯示錯誤信息
        echo '註冊失敗，請重新註冊';
        // 3秒後跳轉至註冊頁面
        header("Refresh:3;Url=register.html");
    }

// 關閉預處理語句
$stmt->close();

// 關閉資料庫連接
$link->close();
}

?>