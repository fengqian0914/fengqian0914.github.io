<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="css/style.css">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-wEmeIV1mKuiNpC+IOBjI7aAzPcEZeedi5yW5f2yOq55WWLwNGmvvx4Um1vskeMj0" crossorigin="anonymous">
    <title>Document</title>
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
        #cartTable{
            overflow: auto;
            max-height: 80%;
        }

        .cart-container {
            margin:100px 0px 30px 0px;
            max-height: 80vh;
            overflow-y: auto;
            display: flex;
            flex-direction: column;
        }
        .cart-content {
            flex-grow: 1;
            overflow-y: auto;
        }
        .cart-footer {
            background: white;
        }
        .cartfooter{
            max-height: 20%;
        }
        #cartTable img {
            max-width: 100px;
            max-height: 100px;
        }
        #total-price {
            margin: 10px;
        }
        #orderdatas{
            width: 700px;
            height: 100vh;
            position: fixed;
            top: 0px;
            right: -100%;
            background: white;
            transition: right 0.3s ease;
        }
        #orderdatas.open {
            right: 0;
        }
    </style>
</head>
<body>
<?php
    session_start();
    if(!isset($_SESSION['storeId'])){
        echo '請選擇店家後，再前往';
        header("Refresh:3;Url=menu.php");
        exit;
    }
    $store_id = $_SESSION['storeId'];

    include 'db_connect.php';

    $sql = "SELECT * FROM 店家列表 WHERE 店家列表.店家編號 = '$store_id'";

    $result = mysqli_query($link, $sql);
    $name = '';
    $phone = '';
    $address = '';
    while ($row = mysqli_fetch_assoc($result)) {
        $name = $row['店家名稱'];
        $phone = $row['電話'];
        $address = $row['地址'];
    }

    $sql_data = "SELECT * FROM 餐點 WHERE 店家編號 = '$store_id'";
    $result_data = mysqli_query($link, $sql_data);
    $result_data_print = '<div class="container"><div class="row">';
    $result_data_id = 1;

    while ($row = mysqli_fetch_assoc($result_data)) {
        $result_data_print .= '
        <div class="col-lg-4 col-md-6 col-12 cards">
            <div class="card">
                <div class="cardimg">
                    <img src="img/'.$store_id.'/Meal_'.$result_data_id.'.jpg" class="card-img-top" 
                    alt="'.$row['餐點名稱'].'"  title="'.$row['餐點名稱'].'">
                </div>
                <div class="card-body">
                    <h5 class="card-title">'.$row['餐點名稱'].'</h5>
                    <p class="card-text">'.$row['說明'].'</p>
                    <p class="card-money">$'.$row['單價'].'元</p>
                    <div class="form-group">
                        <label for="quantity_'.$result_data_id.'">數量:</label>
                        <select class="form-control quantity" id="quantity_'.$result_data_id.'" 
                            name="quantity_'.$result_data_id.'">
                                <option value="1">1</option>
                                <option value="2">2</option>
                                <option value="3">3</option>
                                <option value="4">4</option>
                                <option value="5">5</option>
                                <option value="6">6</option>
                                <option value="7">7</option>
                                <option value="8">8</option>
                                <option value="9">9</option>
                                <option value="10">10</option>
                        </select>
                    </div>
                    <a class="btn btn-primary" onclick="addToCart(this)" name="Meal_'.$result_data_id.'">訂購</a>
                </div>
            </div>
        </div>';
        $result_data_id++;
    }
    $result_data_print .= '</div></div>';
    ?>

<nav>
        <div class="logo">
        <a href="menu.php"><img src="img/outer/logo.png" alt="歷史訂單" class="icon">
        <span>訂餐網</span></a>
        
        </div>
        <div class="Account">
            <img src="img/outer/user.png" class="icon">
                <?php 
                    if(isset($_SESSION['account']))
                        echo $_SESSION['account'];
                    else 
                    {
                                $_SESSION['Login_Msg']="請登入帳號";
                                header("Location: Loading.php");
                        
                    }
                ?>
        </div>
       
        <div class="Historical_orders" ><a href="Historical_orders.php"><img src="img/outer/order.png" alt="歷史訂單" class="icon"> 歷史訂餐</a></div>

        <div class="Sign_out"><a href="logout.php"><img src="img/outer/logout.png" alt="登出" class="icon"> 登出</a></div>
        <div class="Shopping_cart"><div  onclick="toggleCart()"><img src="img/burger-bar.png" id="toggleCarts" alt="click"  class="icon"> 購物車</div></div>
</nav>

<div class="container">
    <div class="row">
        <div class="w-100">
            <?php echo '<img src="img/'.$store_id.'/banner.jpg">'; ?>
        </div>
        <div class="col-lg-6 col-12">
            <div class="storeName">
                <?php echo '<h1>' . $name . '</h1>'; ?>
            </div>
            <div class="storePhone">
                <?php echo '<h3>' . $phone . '</h3>'; ?>
            </div>
            <div class="storeAddress">
                <?php echo '<h3>' . $address . '</h3>'; ?>
            </div>
        </div>
     
    </div>
</div>
<div class="data">
    <?php echo $result_data_print; ?>
</div>
<div id="orderdatas">
    <div class="cart-container">
        <div class="cart-content">
            <form action="checkout.php" method="post" id="form1">
            <input type="hidden" name="store_id" value="<?php echo $store_id; ?>">

                <table id="cartTable">
                    <tr>
                        <th colspan="2">品名</th>
                        <th>單價</th>
                        <th>數量</th>
                        <th>總價</th>
                        <th>操作</th>
                    </tr>
                </table>
                <div class="cartfooter">
                    <h1 id="total-price">小計: <span>$0.00</span></h1>
                    <button type="button" class="btn btn-dark w-100" style="height: 3rem;"
                     onclick="CheckOut()">前往結帳
                    </button>
                </div>
            </form>
        </div>
    </div>
</div>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-p34f1UUtsS3wqzfto5wAAmdvj+osOnFyQFpp4Ua3gs/ZVWx6oOypYoCJhGGScy+8" crossorigin="anonymous"></script>

<script>
    let total = 0;
    let cartarray = [];
    function addToCart(button) {
        var card = button.closest('.card');
        var imgSrc = card.querySelector('.card-img-top').src;
        var title = card.querySelector('.card-title').innerText;
        var price = parseFloat(card.querySelector('.card-money').innerText.replace('$', '').replace('元', ''));
        var quantity = parseInt(card.querySelector('.quantity').value);
        var totalPrice = price * quantity;
        var cart_to_product = card.querySelector('.btn-primary').name;
        var cart_to_product_index = 0;

        var tables = document.getElementById('cartTable');
        var rows = tables.getElementsByTagName('tr');
        var product_exist = false;

        for (var i = 1; i < rows.length; i++) {
            var row = rows[i];
            if (row.dataset.title.toString() == cart_to_product.toString()) {
                cart_to_product_index = i;
                product_exist = true;
            }
        }

        if (product_exist == true) {

            var change_quantity_tr = parseInt(document.querySelector("#cartTable > tbody > tr:nth-child(" +
             (cart_to_product_index + 1) + ") > td:nth-child(4) > div").innerHTML);

            document.querySelector("#cartTable > tbody > tr:nth-child(" + (cart_to_product_index + 1) +
             ") > td:nth-child(4) > div").innerHTML = parseInt(change_quantity_tr + quantity);

            var change_price_tr = parseFloat(document.querySelector("#cartTable > tbody > tr:nth-child(" +
             (cart_to_product_index + 1) + ") > td:nth-child(5) > span").innerHTML);

            document.querySelector("#cartTable > tbody > tr:nth-child(" + (cart_to_product_index + 1) + 
            ") > td:nth-child(5) > span").innerHTML = parseFloat(change_price_tr + (price * quantity));

            calculateTotalPrice(totalPrice);
        } else {
            cartarray.push(cart_to_product);
            var table = document.getElementById('cartTable');
            var row = table.insertRow(-1);
            var imgCell = row.insertCell(0);
            var titleCell = row.insertCell(1);
            var priceCell = row.insertCell(2);
            var quantityCell = row.insertCell(3);
            var totalPriceCell = row.insertCell(4);
            var actionCell = row.insertCell(5);

            row.setAttribute('data-title', cart_to_product);
            imgCell.innerHTML = '<img src="' + imgSrc + '" alt="' + title + '">';
            titleCell.textContent = title;
            priceCell.textContent = '$' + price.toFixed(2);
            quantityCell.innerHTML = '<button class="btn btn-sm btn-secondary" onclick="updateQuantity(this, -1)">-</button> <div class="count">' 
            + quantity +
             ' </div><button class="btn btn-sm btn-secondary" onclick="updateQuantity(this, 1)">+</button>';
            totalPriceCell.innerHTML = '$<span class="card_total">' + totalPrice.toFixed(2) + '</span>';
            actionCell.innerHTML = '<button class="btn btn-sm btn-danger" onclick="removeFromCart(this)">刪除</button>';
            calculateTotalPrice(totalPrice);
        }
    }

    function calculateTotalPrice(price) {
        total += price;
        document.getElementById('total-price').innerHTML = '小計: <span>$' + total.toFixed(2) + '</span>';
    }

    function updateQuantity(button, change) {
        var row = button.closest('tr');
        var quantityCell = row.cells[3];
        var currentQuantity = parseInt(quantityCell.textContent.split('-')[1].split('+')[0]);
        var newQuantity = currentQuantity + change;
        if (newQuantity == 0) {
            removeFromCart(button);
        } else {
            var priceCell = row.cells[2];
            var totalPriceCell = row.cells[4];
            var price = parseFloat(priceCell.textContent.replace('$', ''));
            var currentTotalPrice = parseFloat(totalPriceCell.querySelector('.card_total').textContent);
            var newTotalPrice = price * newQuantity;
            total -= currentTotalPrice;
            total += newTotalPrice;
            quantityCell.innerHTML = 
            '<button class="btn btn-sm btn-secondary" onclick="updateQuantity(this, -1)">-</button> ' 
            + newQuantity + 
            ' <button class="btn btn-sm btn-secondary" onclick="updateQuantity(this, 1)">+</button>';
            totalPriceCell.innerHTML = '$<span class="card_total">' + newTotalPrice.toFixed(2) + '</span>';
            document.getElementById('total-price').innerHTML = '小計: <span>$' + total.toFixed(2) + '</span>';
        }
    }

    function removeFromCart(button) {
        var row = button.closest('tr');
        var totalPriceCell = row.cells[4];
        var currentTotalPrice = parseFloat(totalPriceCell.querySelector('.card_total').textContent);
        total -= currentTotalPrice;
        document.getElementById('total-price').innerHTML = '小計: <span>$' + total.toFixed(2) + '</span>';
        row.remove();
    }

    function toggleCart() {
        var orderdatas = document.getElementById('orderdatas');
        if (orderdatas.classList.contains('open')) {
            orderdatas.classList.remove('open');
        } else {
            orderdatas.classList.add('open');
        }
    }

    function CheckOut() {
        var table = document.getElementById('cartTable');
        var rows = table.getElementsByTagName('tr');
        var cartItems = [];
        for (var i = 1; i < rows.length; i++) {
            var row = rows[i];
            var item = {
                titleId: row.dataset.title,

                titleName: row.cells[1].textContent,

                price: parseFloat(row.cells[2].textContent.replace('$', '')),
                quantity: parseInt(row.cells[3].querySelector('.count').textContent),
                totalPrice: parseFloat(row.cells[4].querySelector('.card_total').textContent)
            };
            cartItems.push(item);
        }
        var hiddenField = document.createElement('input');
        hiddenField.type = 'hidden';
        hiddenField.name = 'cartItems';
        hiddenField.value = JSON.stringify(cartItems);
        document.getElementById('form1').appendChild(hiddenField);
        document.getElementById('form1').submit();
    }
</script>
</body>
</html>
