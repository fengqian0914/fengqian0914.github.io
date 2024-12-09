<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php
    session_start();
    if(isset($_SESSION["account"])){
	    echo '<h1>'.$_SESSION['account'].'您好，恭喜您註冊成功</h1>';
        header("Refresh: 3; URL=menu.php");
        exit;

    }
    else if(isset($_SESSION['Login_Msg'])){
        echo '<h1>'.$_SESSION['Login_Msg'].'</h1>';
        header("Refresh: 3; URL=Login.html");
        exit;

    }else{
        echo '請選擇送出類型，再前往';
        header("Refresh:3;Url=login.html");
        exit;
    }
    ?>
</body>
<script>

</script>
</html>