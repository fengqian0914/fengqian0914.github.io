<?php
    session_start();
    if(!isset($_SESSION['account'])){
        echo '請登入帳號';
        header("Refresh:3;Url=login.html");
        exit;
    }
    if(!isset($_POST['Username']) || !isset($_POST['UserAddress']) || !isset($_POST['drone'])){
        echo '請輸入資訊，再前往';
        header("Refresh:3;Url=checkout.php");
        exit;
    }
    if(!isset($_SESSION['cartItem'])){
        echo '請輸入資訊，再前往';
        header("Refresh:3;Url=menu.php");
        exit;
    } else {
        include 'db_connect.php';
        $cartItems = $_SESSION['cartItem'];
        date_default_timezone_set('Asia/Taipei');
        
        // 獲取當前日期並格式化為 YYYYMMDD
        $currentDate = date("Ymd");
        // 獲取當前時間的時分秒
        $currentTime = date("His");
        
        $account = $_SESSION['account'];
        $username = $_POST['Username'];
        $store_id = $_SESSION['store_id'];
        $address = $_POST['UserAddress'];
        $drone = $_POST['drone'];
        $Times = $currentDate . $currentTime;
        
        // 使用 DateTime 解析時間字串
        $dateTime = DateTime::createFromFormat('YmdHis', $Times);
        // 格式化為您想要的格式
        $outputTime = $dateTime->format('Y-m-d H:i:s');
        
        // 使用 DateTime 解析時間字串
        $dateTimeNew = DateTime::createFromFormat('YmdHis', $Times);
        // 增加 30 分鐘
        $dateTimeNew->modify('+30 minutes');
        // 格式化為您想要的格式
        $outputTimeNew = $dateTimeNew->format('Y-m-d H:i:s');

        $total = 0;
        $sql = "SELECT 訂單編號 FROM 訂單小計
        ORDER BY CAST(SUBSTRING(訂單編號, 7) AS UNSIGNED) DESC LIMIT 1";
        $result = $link->query($sql);

        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc();
            $current_id = $row['訂單編號'];
            // 提取數字部分
            $current_number = intval(str_replace('Order_', '', $current_id));
            // 生成新的ID
            $orderId = 'Order_' . ($current_number + 1);
        } else {
            // 如果沒有記錄，則從Order_1開始
            $orderId = 'Order_1';
        }

        $sql = "SELECT 團購編號 FROM 團購 
        ORDER BY CAST(SUBSTRING(團購編號, 10) AS UNSIGNED) DESC LIMIT 1";
        $result = $link->query($sql);

        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc();
            $current_id = $row['團購編號'];
            // 提取數字部分
            $current_number = intval(str_replace('GroupBuy_', '', $current_id));
            // 生成新的ID
            $GroupBuyId = 'GroupBuy_' . ($current_number + 1);
        } else {
            // 如果沒有記錄，則從GroupBuy_1開始
            $GroupBuyId = 'GroupBuy_1';
        }

        $sql = "SELECT 付款編號 FROM 付款資訊 
        ORDER BY CAST(SUBSTRING(付款編號, 5) AS UNSIGNED) DESC LIMIT 1";
        $result = $link->query($sql);
        if ($result->num_rows > 0) {
            $row = $result->fetch_assoc();
            $current_id = $row['付款編號'];
            // 提取數字部分
            $current_number = intval(str_replace('pay_', '', $current_id));
            // 生成新的ID
            $payId = 'pay_' . ($current_number + 1);
        } else {
            // 如果沒有記錄，則從pay_1開始
            $payId = 'pay_1';
        }

        echo '<br><br>訂單: ' . $orderId . "<br>付款編號: " . $payId . "<br>團購編號: " . $GroupBuyId . "<br><br>";

        foreach($cartItems as $item){
            $mealID = $item[0];
            $quantity = $item[3];
            $subtotal = $item[4];
            $total += $subtotal;
            echo "<br>";
            
            $sql = "INSERT INTO `訂單小計` (`訂單編號`, `餐點編號`, `數量`, `小計`, `訂購者`, `店家編號`) VALUES (?, ?, ?, ?, ?, ?)";
            $stmt = $link->prepare($sql);
            $stmt->bind_param("ssidss", $orderId, $mealID, $quantity, $subtotal, $username, $store_id);

            if ($stmt->execute()) {
                echo "訂單小計：訂單插入成功: 訂單編號 " . $orderId;
            } else {
                echo "訂單小計：語法執行失敗，錯誤訊息: " . $stmt->error;
            }
        }

        echo "<br>";

        $sqlPay = "INSERT INTO `付款資訊`(`付款編號`, `付款方式`) VALUES (?, ?)";
        $stmtPay = $link->prepare($sqlPay);
        $stmtPay->bind_param("ss", $payId, $drone);

        if ($stmtPay->execute()) {
            echo "付款資訊表：訂單插入成功: 付款編號 " . $payId;
        } else {
            echo "付款資訊表：語法執行失敗，錯誤訊息: " . $stmtPay->error;
        }

        echo "<br>";

        $sqlGroupBuy = "INSERT INTO `團購`(`團購編號`, `開啟時間`) VALUES (?, ?)";
        $stmtGroupBuy = $link->prepare($sqlGroupBuy);
        $stmtGroupBuy->bind_param("ss", $GroupBuyId, $outputTime);

        if ($stmtGroupBuy->execute()) {
            echo "團購表：訂單插入成功: 團購編號 " . $GroupBuyId;
        } else {
            echo "團購表：語法執行失敗，錯誤訊息: " . $stmtGroupBuy->error;
        }

        echo "<br>";

        $sql = "INSERT INTO `訂單總價`(`訂單編號`, `會員帳號`, `付款編號`, `訂單時間`, `取餐位置`, `總價`, `取單時間`, `團購編號`) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
        $stmt = $link->prepare($sql);
        $stmt->bind_param("sssssdss", $orderId, $account, $payId, $outputTime, $address, $total, $outputTimeNew, $GroupBuyId);

        if ($stmt->execute()) {
            echo "訂單總價表：訂單插入成功: 訂單編號 " . $orderId;
        } else {
            echo "訂單總價表：語法執行失敗，錯誤訊息: " . $stmt->error;
        }

        echo '<br>完成訂單送出<br><a href="menu.php">回到店家選單</a>';

        unset($_SESSION['cartItem']);
        unset($_SESSION['storeId']);
    }
?>
