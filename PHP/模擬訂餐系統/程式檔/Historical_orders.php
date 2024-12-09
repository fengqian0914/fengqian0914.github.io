<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link rel="stylesheet" href="css/style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-wEmeIV1mKuiNpC+IOBjI7aAzPcEZeedi5yW5f2yOq55WWLwNGmvvx4Um1vskeMj0" crossorigin="anonymous">
    <style>
        .Order_container img{
            width:100%;
            height: 200px;
            object-fit: cover;
            border-radius: 30px;
        }
   
        .Order_container{
            background:#eeeeee;
            padding-top: 20px;
        }
        .orderNumber, h1{
            font-weight: bold;
        }
        .rows{
            padding: 20px;
        }
        .w-30{
            width: 30%;
        }
        .w-70{
            width: 70%;
        }
        .order_Left,h1{
            text-align: center;

        }
        .order_Left p{
            margin-top: 10px;
        }
        .TotalPrice, .Price,.buyagain{
            text-align: right;
        }
        .order_Right,h1{
            font-weight: bold;
        }
        .StoreName{
            font-size: 28px;
        }
        .grayColor{
            color: gray;
        }
     
    </style>
</head>
<body>
<nav>
        <div class="logo">
        <a href="menu.php"><img src="img/outer/logo.png" alt="歷史訂單" class="icon">
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
       
        <div class="Historical_orders" ><a href="Historical_orders.php"><img src="img/outer/order.png" alt="歷史訂單" class="icon">歷史訂餐</a></div>

        <div class="Sign_out"><a href="logout.php"><img src="img/outer/logout.png" alt="登出" class="icon"> 登出</a></div>

    </nav>
<div class="container Order_container">
        <h1>歷史訂單</h1>
            <?php
                    include 'db_connect.php';
                    $account = $_SESSION['account'];
                    
                    $sql = "SELECT * 
                    FROM `訂單總價` os
                    LEFT JOIN `訂單小計` o on os.訂單編號=o.訂單編號 
                    LEFT JOIN `付款資訊` p on os.付款編號=p.付款編號
                    LEFT JOIN `店家列表` s on o.店家編號=s.店家編號
                    WHERE os.會員帳號= '$account'
                    GROUP BY os.訂單編號
                    ORDER BY CAST(SUBSTRING(os.訂單編號,7) AS UNSIGNED)
                    ";
                    $result =  $link->query($sql);
                    // echo "<h1>歷史訂單</h1><table border=1><tr><td>訂單編號</td><td>店家名稱</td><td>訂單日期</td><td>總價</td><td>付款方式</td></table>";
               
                    $str="";

                    if ($result->num_rows > 0) {
                        // 輸出數據
                        while($row = $result->fetch_assoc()) {

                            $date = new DateTime($row['訂單時間']);
                            $formattedDate = $date->format('Y年m月d日 H時m分s秒');
                            $orderIdIndex=$row['訂單編號'];
                            $str.=' <div class="row rows" >
                                        <div class="orderNumber">
                                            <h2>#'.$row['訂單編號'].'</h2>
                                        </div>
                                        <div class="w-30 order_Left">
                                            <img src="img/'.$row['店家編號'].'/'.$row['餐點編號'].'.jpg">
                                            <p class="grayColor">'. $formattedDate .'</p>
                                        </div>
                                        <div class="w-70 order_Right">
                                            <div class="row Order_Title">
                                                <div class="w-30 StoreName">'.$row['店家名稱'].'</div>
                                                <div class="w-70 TotalPrice">$'.$row['總價'].'元</div>
                                            
                                            </div>  
                                            <div class="row Order_Meal">

                            ';

                                            $sql_Queantity_Price = "SELECT * 
                                            FROM `店家列表` s 
                                            inner JOIN `訂單小計` os ON s.店家編號 = os.店家編號  
                                            inner JOIN `餐點` M ON os.餐點編號 = M.餐點編號
                                            WHERE os.訂單編號 IS NOT NULL AND os.訂單編號 = '$orderIdIndex' and M.店家編號=s.店家編號 ";
                                            
                                            $result_Queantity_Price = $link->query($sql_Queantity_Price);
                                            
                                            if ($result_Queantity_Price) {
                                                // 輸出數據
                                                while ($row_Queantity_Price = $result_Queantity_Price->fetch_assoc()) {
                                                    $str .= '<div class="w-70 Meal">
                                                                <div class="quantity grayColor">' .
                                                         $row_Queantity_Price['數量'] . 'X  
                                                                    <span class="MealName grayColor">' . $row_Queantity_Price['餐點名稱'] . '</span>
                                                                </div>
                                                            </div>
                                                            <div class="w-30 Price grayColor">$' . $row_Queantity_Price['小計'] . '元</div>';
                                                }
                                            }
    
                                            $str.='</div><br>
                                            <div class="payInfo row" >
                                                <div class="w-70">
                                                    <div>
                                                    訂購者：'.$row['訂購者'].'</span>
                                                    </div>
                                                    <div>
                                                    付款方式：'.$row['付款方式'].'</span>
                                                    </div>
                                                    <div>
                                                    取餐地址：'.$row['取餐位置'].'</span>
                                                    </div>
                                                  
                                                </div>

                                                <div class="buyagain w-30">
                                                    <a class="btn btn-primary" type="submit" href="menu.php">再次購買</a>
                                                </div>
                                            </div>
                                            <br>
                                        </div>
                                    </div>
                                    <hr> 
                            ';
                            $str.="<div></div>";
                        }
                    } else {
                        echo "<h1>此帳號尚未有訂餐紀錄</h1>";
                    }

            echo $str;
            unset($_SESSION['cartItem']);
            unset($_SESSION['storeId']);

            ?>
            
    


    </div>
</body>
</html>