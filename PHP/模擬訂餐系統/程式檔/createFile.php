<?php
include 'db_connect.php';

if (!isset($_POST['forms'])) {
    echo '請選擇送出類型，再前往';
    header("Refresh:3;Url=newfile.php");
    exit;
}

if ($_POST['forms'] == 'forms1') { // 店家類別
    $sql = "SELECT 類別編號 FROM 店家類型 ORDER BY CAST(SUBSTRING(類別編號, 12) AS UNSIGNED) DESC LIMIT 1";
    $result = $link->query($sql);
    $name = $_POST['Stypename'];
    echo $name;
    
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $current_id = $row['類別編號'];
        // 提取數字部分
        $current_number = intval(str_replace('Store_type_', '', $current_id));
        // 生成新的ID
        $Id = 'Store_type_' . ($current_number + 1);
        echo '建立成功';
    } else {
        // 如果沒有記錄，則從1開始
        echo '建立失敗';
        $Id = 'Store_type_1';
    }
    
    $sql = "INSERT INTO `店家類型`(`類別編號`, `類別名稱`) VALUES (?, ?)";
    $stmt = $link->prepare($sql);
    $stmt->bind_param("ss", $Id, $name);
    
    if ($stmt->execute()) {
        echo "插入成功: 編號 " . $Id . " 名稱 " . $name;
    } else {
        echo "執行失敗，錯誤訊息: " . $stmt->error;
    }

} else if ($_POST['forms'] == 'forms2') { // 餐點類別
    $sql = "SELECT 類別編號 FROM 餐點類型 ORDER BY  CAST(SUBSTRING(類別編號, 11) AS UNSIGNED)  DESC LIMIT 1";
    $result = $link->query($sql);
    $name = $_POST['Mtypename'];
    echo $name;
    
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $current_id = $row['類別編號'];
        // 提取數字部分
        $current_number = intval(str_replace('Meal_type_', '', $current_id));
        // 生成新的ID
        $Id = 'Meal_type_' . ($current_number + 1);
        echo '建立成功';
    } else {
        // 如果沒有記錄，則從1開始
        echo '建立失敗';
        $Id = 'Meal_type_1';
    }
    
    $sql = "INSERT INTO `餐點類型`(`類別編號`, `類別名稱`) VALUES (?, ?)";
    $stmt = $link->prepare($sql);
    $stmt->bind_param("ss", $Id, $name);
    
    if ($stmt->execute()) {
        echo "插入成功: 編號 " . $Id . " 名稱 " . $name;
    } else {
        echo "執行失敗，錯誤訊息: " . $stmt->error;
    }

} else if ($_POST['forms'] == 'forms3') { // 店家名稱
    $sql = "SELECT 店家編號 FROM 店家列表 ORDER BY CAST(SUBSTRING(店家編號, 7) AS UNSIGNED)  DESC LIMIT 1";
    $result = $link->query($sql);
    
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $current_id = $row['店家編號'];
        // 提取數字部分
        $current_number = intval(str_replace('Store_', '', $current_id));
        // 生成新的ID
        $Id = 'Store_' . ($current_number + 1);
    } else {
        // 如果沒有記錄，則從1開始
        $Id = 'Store_1';
    }

    $name = $_POST['Sname'];
    $phone = $_POST['phone'];
    $Address = $_POST['Address'];
    $Stype = $_POST['Stype'];

    $sql = "INSERT INTO `店家列表`(`店家編號`, `電話`, `地址`, `類別編號`, `店家名稱`) VALUES (?, ?, ?, ?, ?)";
    $stmt = $link->prepare($sql);
    $stmt->bind_param("sssss", $Id, $phone, $Address, $Stype, $name);
    
    if ($stmt->execute()) {
        echo "插入成功: 編號 " . $Id . " 名稱 " . $name;
    } else {
        echo "執行失敗，錯誤訊息: " . $stmt->error;
    }

} else { // 餐點
    $Stype = $_POST['Stype'];
    $sql = "SELECT 餐點編號 FROM 餐點 WHERE 店家編號= '$Stype' ORDER BY CAST(SUBSTRING(餐點編號, 6) AS UNSIGNED) DESC LIMIT 1";
    $result = $link->query($sql);
    
    if ($result->num_rows > 0) {
        $row = $result->fetch_assoc();
        $current_id = $row['餐點編號'];
        // 提取數字部分
        $current_number = intval(str_replace('Meal_', '', $current_id));
        // 生成新的ID
        $Id = 'Meal_' . ($current_number + 1);
    } else {
        // 如果沒有記錄，則從1開始
        $Id = 'Meal_1';
    }

    $Mtype = $_POST['Mtype'];
    $MealName = $_POST['MealName'];
    $Price = $_POST['Price'];
    $info = $_POST['info'];

    echo $Stype . $Mtype . $MealName . $Price . $info;
    echo "<br><br>";
    echo "id: " . $Id . "<br>名稱: " . $MealName . "<br>價格: " . $Price . "<br>介紹: " . $info . "<br>餐點類型編號: " . $Mtype . "<br>店家編號: " . $Stype;

    $sql = "INSERT INTO `餐點`(`餐點編號`, `餐點名稱`, `單價`, `說明`, `餐點類型編號`, `店家編號`) VALUES (?, ?, ?, ?, ?, ?)";
    $stmt = $link->prepare($sql);
    $stmt->bind_param("ssdsss", $Id, $MealName, $Price, $info, $Mtype, $Stype);
    
    if ($stmt->execute()) {
        echo "插入成功: 編號 " . $Id . " 名稱 " . $MealName;
    } else {
        echo "執行失敗，錯誤訊息: " . $stmt->error;
    }
}

echo '<br><a href="newfile.php">返回繼續添加</a>';
?>
