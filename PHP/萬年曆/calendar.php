<?php
	header("Content-Type:text/html; charset=utf-8");
	// 抓html post
	$selectedYear = $_POST["selectedYear"];
	$monthedYear = $_POST["selectedMonth"];
	
	$today = getdate();//抓今日 日期



	$calendar=array();



	//建表+標題列
	echo '<table border=1 align=center style="text-align: center;">';
	echo '<tr style="background:#b0aaaa;color:white;font-weight:bold"><td style="color:red">日</td><td>一</td><td>二</td><td>三</td><td>四</td><td>五</td><td style="color:red">六</td><tr>';
	
	$daySkip_W=date('w', mktime(0, 0, 0, $monthedYear,  1, $selectedYear)); //補星期 數字格式
	echo "<h1 align=center>$selectedYear 年 $monthedYear 月</h1>"; // 標題

	for($daySkip=0;$daySkip<=$daySkip_W;$daySkip++){ //留空數量
		$calendar[0][$daySkip]=null;
	}

	$day=1;  //天數值
	$days=$daySkip_W; //周次 

	do{
		$calendar[floor($days/7)][$days%7]=$day;
		$days++;
		$day++;
	}while(checkdate($monthedYear,$day,$selectedYear));
	
	for($n=date('w', mktime(0, 0, 0, $monthedYear,$day, $selectedYear));$n<7;$n++){  //尾巴留下
			$calendar[count($calendar)-1][$n]=null;
	}
	for( $n= 0; $n<count($calendar); $n++ ) {
		echo '<tr>';
		for( $j= 0; $j<7; $j++ ){
			if($j==0 ||$j==6){ //六日 給個紅色字體
				if($today['year']==$selectedYear && $today['mon']==$monthedYear&&$calendar[$n][$j]==$today['mday']) // 是六日 但看是否為今日 是給個藍背景+白字
					echo '<td style="width: 50px; height: 50px;background:#6f8cda;color:white">'.$calendar[$n][$j].'<br>今天</td>';	
				else  //非今日 且為六日給紅字體
					echo '<td style="width: 50px; height: 50px;color:red">'.$calendar[$n][$j].'</td>';	 //六日 給個紅色字體
			}else{
				if($today['year']==$selectedYear && $today['mon']==$monthedYear&&$calendar[$n][$j]==$today['mday']) //非六日 但看是否為今日 是給個藍背景+白字
					echo '<td style="width: 50px; height: 50px;background:#6f8cda;color:white">'.$calendar[$n][$j].'<br>今天</td>';	
				else //非今日 且非六日 一般樣式
					echo '<td style="width: 50px; height: 50px;">'.$calendar[$n][$j].'</td>';	
			}

		}
	}
    echo '</tr>';
	echo '</table>';
	
?>
