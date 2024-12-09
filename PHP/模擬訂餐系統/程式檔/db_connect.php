<?php
// db_connect.php

$host = 'localhost';
$db = 'order_phps';
$user = 'root';
$pass = '';

// 建立資料庫連線
$link = mysqli_connect($host, $user, $pass, $db);

// 檢查資料庫連線
if (!$link) {
    die('資料庫連線失敗: ' . mysqli_connect_error());
}
?>
