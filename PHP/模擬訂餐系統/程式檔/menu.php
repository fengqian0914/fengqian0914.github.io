<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>點餐系統</title>
    <link rel="stylesheet" href="css/style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-wEmeIV1mKuiNpC+IOBjI7aAzPcEZeedi5yW5f2yOq55WWLwNGmvvx4Um1vskeMj0" crossorigin="anonymous">

</head>

<body id="menu_body">
 
    <nav>
        <div class="logo">
        <a href="menu.php">
            <img src="img/outer/logo.png" alt="歷史訂單" class="icon">
        <span>訂餐網</span></a>
        </div>
        <div class="Account">
            <img src="img/outer/user.png" class="icon">
                <?php 
                    session_start();
                    if(isset($_SESSION['account']))
                        echo $_SESSION['account'];
                    else 
                    {
                        $_SESSION['Login_Msg']="請登入帳號";
                        header("Location: Loading.php");
                        exit;
                    }
                ?>
        </div>
        <div class="Historical_orders" >
            <a href="Historical_orders.php">
                <img src="img/outer/order.png" alt="歷史訂單" class="icon">
                歷史訂餐</a>
        </div>
        <div class="Sign_out">
            <a href="logout.php">
                <img src="img/outer/logout.png" alt="登出" class="icon"> 
                登出</a>
        </div>
    </nav>
    <div id="Menu">
        <div class="container">
            <div class="row">
                <?php
                    include 'db_connect.php';
                    $sql="SELECT 店家列表.店家編號, 店家列表.店家名稱, 店家列表.地址, 店家列表.電話, 店家類型.類別名稱
                    FROM 店家列表
                    JOIN 店家類型 ON 店家列表.類別編號 = 店家類型.類別編號
                    ORDER BY CAST(SUBSTR(店家編號, 7) AS INTEGER)";
                    // 執行查詢
                    $result = mysqli_query($link, $sql);
                    // 檢查查詢是否成功
                    if ($result) {
                        // 迴圈遍歷結果集中每一行
                        while ($row = mysqli_fetch_assoc($result)) {
                            // 將結果行中的值存儲為變數
                            $store_id = $row['店家編號'];
                            $store_name = $row['店家名稱'];
                            $address = $row['地址'];
                            $phone = $row['電話'];
                            $category_name = $row['類別名稱']; // 添加類別名稱
                            
                            // 輸出店家資訊
                            echo '<form action="gostore.php" method="post" class="col-lg-4 col-md-6 col-12">
                            <div class="store">
                                <div class="store_img">
                                    <img alt="'.$store_name.'" src="img/'. $store_id.'/banner.jpg" title="'.$store_name.'">
                                </div>
                                <div class="store_data" id="'.$store_id.'">
                                    <h2 class="store_name">
                                        '.$store_name.'
                                    </h2>
                                    <p class="store_address">
                                        '.$address.'
                                    </p>
                                    <p class="store_phone">
                                        '.$phone.'
                                    </p>
                                    <input type="hidden" value="'.$store_id.'" name="storeid"/>
                                    <input type="submit" class="btn btn-primary" value="前往該店家"  style="width:100%"/>
                                </div>
                            </div>
                            </form>';
                        }

                        // 釋放結果集
                        mysqli_free_result($result);
                    } else {
                        echo "查詢失敗: " . mysqli_error($link);
                    }

                    // 關閉資料庫連線
                    unset($_SESSION['storeId']);
                    mysqli_close($link);
                ?>
        <form action="gostore.php" method="post" class="col-lg-4 col-md-6 col-12" >
            <div class="store">
            <a href="newfile.php" >
                <div class="store_img">
                    <img src="img/outer/add.png" alt="增加餐廳資料"  title="增加餐廳資料" style="object-fit: contain;">
                </div>
                <div class="store_data"  id="addStoreText">
                    <p align="center">增加餐廳資料</p>
                </div>
                </a>
            </div>
        </form>

        </div>
    </div>
    </div>
    <!--  以下不要動 -->
    

    <script>
        let add=document.getElementById("addStoreText")
        let h=document.getElementById("Store_1").clientHeight
        add.style.cssText="height:"+h+"px";
    </script>

</body>
</html>