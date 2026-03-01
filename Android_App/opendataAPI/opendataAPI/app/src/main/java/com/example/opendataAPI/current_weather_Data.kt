package com.example.opendataAPI

data class current_weather_Data (
    var CountyName:String,//縣市名
    var TownName:String,//區名
    var Weather:String,//現在天氣狀況
    var NowTemperature:Long,//現在溫度
    var MaxTemperature:Long,//當日最高溫度
    var MinTemperature:Long,//當日最低溫度
    var RelativeHumidity:Int,//現在濕度
    var distance:Float//距離
)