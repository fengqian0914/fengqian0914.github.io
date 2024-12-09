<?php


// 開啟 Session
session_start();
if(!isset($_SESSION['update_account'])||!isset($_POST['password1'])){ // 檢查是否取得值
         echo '請送出資料後，再前往';#錯誤資訊

        header("Refresh:3;Url=login.html");#跳轉頁面
        exit;#跳離
}
include 'db_connect.php'; // 引入資料庫連線




// 從 Session 中獲取帳號，從 POST 請求中獲取新密碼
$account = $_SESSION['update_account'];
$new_password = $_POST['password1'];
// 準備一個參數化的 SQL 查詢
$sql = "UPDATE 會員列表 SET 密碼=? WHERE 會員帳號=?";

// 初始化一個預處理語句
$stmt = mysqli_prepare($link, $sql);

// 檢查初始化是否成功
if ($stmt) {
    // 綁定參數
    mysqli_stmt_bind_param($stmt, "ss", $new_password, $account);

    // 執行 SQL 查詢
    $result = mysqli_stmt_execute($stmt);

    // 檢查執行結果
    if ($result) {
       		  echo "密碼更新成功。";
		      // 清空 Session
			  session_unset();
			  session_destroy();
			  header("Refresh:3 ;Url=login.html");
    } else {
        echo "更新密碼時出錯: " . mysqli_stmt_error($stmt);
    }

    // 關閉預處理語句
    mysqli_stmt_close($stmt);
} else {
    // 如果初始化失敗，顯示錯誤信息
    echo "初始化 SQL 語句失敗: " . mysqli_error($link);
}

// 關閉資料庫連線
mysqli_close($link);
?>
