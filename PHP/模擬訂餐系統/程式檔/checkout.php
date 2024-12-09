<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-wEmeIV1mKuiNpC+IOBjI7aAzPcEZeedi5yW5f2yOq55WWLwNGmvvx4Um1vskeMj0" crossorigin="anonymous">
    <title>Checkout</title>
    <style>
        body {
            background: #c9c3b3;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            background: white;
        }
        th, td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: center;
        }
        th {
            background-color: #a3a1a1;
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
                        
                    }
                ?>
        </div>
        
        <div class="Historical_orders" ><a href="Historical_orders.php"><img src="img/outer/order.png" alt="歷史訂單" class="icon">歷史訂餐</a></div>

        <div class="Sign_out"><a href="logout.php"><img src="img/outer/logout.png" alt="登出" class="icon"> 登出</a></div>

    </nav>
    <div class="container">
        <h1>訂單結帳</h1>
        <?php
        if(!isset($_POST['store_id'])){
            echo '請送出餐點後，再前往';
            header("Refresh:3;Url=menu.php");
            exit;
        }
        $_SESSION['store_id']=$_POST['store_id'];
        if (isset($_POST['cartItems'])) {
            $cartItems = json_decode($_POST['cartItems'], true);
            if (!empty($cartItems)) {
                echo '<table class="table">';
                echo '<thead><tr><th>品名</th><th>單價</th><th>數量</th><th>總價</th></tr></thead><tbody>';
                $total = 0;
                $index=0;
                unset($_SESSION['cartItem']);

                foreach ($cartItems as $item) {
                    $titleId = htmlspecialchars($item['titleId']);
                    $titleName = htmlspecialchars($item['titleName']);
                    $price = htmlspecialchars($item['price']);
                    $quantity = htmlspecialchars($item['quantity']);
                    $totalPrice = htmlspecialchars($item['totalPrice']);
                    $total += $totalPrice;
                    $_SESSION['cartItem'][$index][]=$titleId;
                    $_SESSION['cartItem'][$index][]=$titleName;
                    $_SESSION['cartItem'][$index][]=$price;
                    $_SESSION['cartItem'][$index][]=$quantity;
                    $_SESSION['cartItem'][$index][]=$totalPrice;
                    $index++;
                    echo "<tr><td>{$titleName}</td><td>\${$price}</td><td>{$quantity}</td><td>\${$totalPrice}</td></tr>";
                }
                echo '</tbody></table>';
                echo "<h2>總計: \${$total}</h2>";
            echo ' <hr>
            <div class="PayInfo">
                <h2>付款資訊</h2>
                <form action="Order_completed.php" method="post">
                    <label for="Username">姓名：</label><input type="text" name="Username" required>      <br>
                    <label for="UserNumber">電話：</label><input type="tel" name="UserNumber" required>  <br>
                    <label for="UserAddress">地址：</label><input type="text" name="UserAddress" required> <br>
                    <fieldset>
                        <div class="row">  <legend>付款方式</legend>
                            <div class="w-50">
                                <div>
                                    <input type="radio" id="cash" name="drone" value="現金" checked  onclick="showPaymentDetails()" />
                                    <label for="casj">現金</label>
                                </div>
                                <div>
                                    <input type="radio" id="credit_card" name="drone" value="信用卡/金融卡"  onclick="showPaymentDetails()"/>
                                    <label for="credit_card">信用卡/金融卡</label>
                                </div>
                                <div>
                                    <input type="radio" id="mobile_payment" name="drone" value="行動支付" onclick="showPaymentDetails()" />
                                    <label for="mobile_payment">行動支付</label>
                                </div>
                            </div>
                    
                            <div class="w-50">
                                    <div id="credit_card_details" style="display: none;">
                                    <label for="card_number">卡號：</label>
                                        <input type="text" id="card_number1" name="card_number1"  minlength="4" maxlength="4" size="4" >
                                        <input type="text" id="card_number2" name="card_number2"  minlength="4" maxlength="4" size="4">
                                        <input type="text" id="card_number3" name="card_number3"  minlength="4" maxlength="4" size="4">
                                        <input type="text" id="card_number4" name="card_number4"  minlength="4" maxlength="4" size="4">
                                    <br>   
                                    <label for="card_number_3n">後三碼：</label>
                                        <input type="text" id="card_number_3n" name="card_number_3n"  minlength="3" maxlength="3" size="3"> <br> 
                                    <label for="card_number_month">有效期限：</label>
                                        <input type="month" id="card_number_month" name="card_number_month" >
                                </div>
    
                                <div id="mobile_payment_qr" style="display: none;">
                                    <p>掃條碼付款</p>
                                    <img src="img/Qrcode.png" alt="QR Code for Mobile Payment" width="100px">
                                </div>
                            </div>
                        </div></fieldset>
                    <button class="btn btn-primary" type="submit">送出訂單</button>
                </form>
            </div>';
            } else {
                echo '<p>購物車內無商品。</p> <a href="products.php" >返回訂餐</a>';
            }

        } else {
            echo '<p>無有效的購物車資料。</p> <a href="products.php" >返回訂餐</a>';
        }

        ?>

    </div>
    <script>
        function showPaymentDetails() {
            var creditCardDetails = document.getElementById('credit_card_details');
            var mobilePaymentQR = document.getElementById('mobile_payment_qr');

            if (document.getElementById('credit_card').checked) {
                creditCardDetails.style.display = 'block';
                mobilePaymentQR.style.display = 'none';
            } else if (document.getElementById('mobile_payment').checked) {
                creditCardDetails.style.display = 'none';
                mobilePaymentQR.style.display = 'block';
            } else {
                creditCardDetails.style.display = 'none';
                mobilePaymentQR.style.display = 'none';
            }
        }
    </script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-p34f1UUtsS3wqzfto5wAAmdvj+osOnFyQFpp4Ua3gs/ZVWx6oOypYoCJhGGScy+8" crossorigin="anonymous"></script>
</body>
</html>
