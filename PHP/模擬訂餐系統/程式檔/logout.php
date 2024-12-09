<?php 
session_start();    #開啟session
if(!isset($_SESSION['account'])){ #檢查是否有傳值
    echo '尚未登入'; #錯誤資訊
    header("Refresh:3;Url=login.html"); #跳轉頁面
    exit; #跳離
}
unset($_SESSION['account']); #清除資訊
unset($_SESSION['storeId']);#清除資訊

header("Location: login.html"); #跳轉頁面
exit;#跳離
?>