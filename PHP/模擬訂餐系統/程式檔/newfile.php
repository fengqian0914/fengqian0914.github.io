<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>

<body>
    <?php
        include 'db_connect.php';
    ?>
    <form action="createFile.php" method="post" style="background: #aeaeae;" id="form1">
        <h1>新增店家類別</h1>
       類別名稱：<input type="text" name="Stypename"><br>
        <input type="submit" value="送出">
        <input type="text" value="forms1" name="forms" style="display: none;">
    </form>
    <form action="createFile.php" method="post" style="background: #aeaeae;" id="form1">
        <h1>新增餐點類別</h1>
        類別名稱：<input type="text" name="Mtypename"><br>
        <input type="submit" value="送出">
        <input type="text" value="forms2"  name="forms" style="display: none;">
    </form>
    <form action="createFile.php" method="post" style="background: #aeaeae;" id="form1">
        <h1>新增店家</h1>
        店家名稱：<input type="text" name="Sname"><br>
        電話：<input type="text" name="phone"><br>
        地址：<input type="text" name="Address"><br>
        類別：<select name="Stype" id="Stype">
            <?php
                $sql="SELECT * FROM `店家類型` ";
                $result=mysqli_query($link, $sql);
                // 檢查查詢是否成功
                if ($result) {
                    // 迴圈遍歷結果集中每一行
                    while ($row = mysqli_fetch_assoc($result)) {
                        $type=$row["類別編號"];
                        $typeName=$row['類別名稱'];
                            echo ' <option value="'.$type.'">'. $typeName. '</option>';
                    }
                }
              
            ?>
        </select><br>
        <input type="text" value="forms3"  name="forms" style="display: none;">
        <input type="submit" value="送出">
    </form>
    <form action="createFile.php" method="post" style="background: #aeaeae;" id="form1">
        <h1>新增餐點</h1>
        餐點類別：<select name="Mtype" id="Mtype">
            <?php
                $sql="SELECT * FROM `餐點類型` ";
                $result=mysqli_query($link, $sql);
                // 檢查查詢是否成功
                if ($result) {
                    // 迴圈遍歷結果集中每一行
                    while ($row = mysqli_fetch_assoc($result)) {
                        $type=$row["類別編號"];
                        $typeName=$row['類別名稱'];
                            echo ' <option value="'.$type.'">'. $typeName. '</option>';
                    }
                }
              
            ?>
        </select><br>


        店家名稱：<select name="Stype" id="Stype">
            <?php
                $sql="SELECT * FROM `店家列表` ";
                $result=mysqli_query($link, $sql);
                // 檢查查詢是否成功
                if ($result) {
                    // 迴圈遍歷結果集中每一行
                    while ($row = mysqli_fetch_assoc($result)) {
                        $type=$row["店家編號"];
                        $typeName=$row['店家名稱'];
                            echo ' <option value="'.$type.'">'. $typeName. '</option>';
                    }
                }
              
            ?>
        </select><br>
        餐點名稱：<input type="text" name="MealName" id="MealName"><br>
        價格：<input type="text" name="Price" id="Price"><br>
        說明：<input type="text" name="info" id="info"><br>
        <input type="hidden" value="forms4"  name="forms" style="display: none;">

        <input type="submit" value="送出">
    </form>
</body>

</html>