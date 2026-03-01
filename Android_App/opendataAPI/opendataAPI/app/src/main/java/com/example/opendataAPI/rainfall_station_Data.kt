package com.example.opendataAPI

data class rainfall_station_Data(
    val stationName: String,            // 測站名稱
    val stationId: String,              // 測站代號
    val countyName: String,             // 縣市名稱
    val townName: String,               // 鄉鎮名稱
    val currentPrecipitation: String,   // 即時降雨量
    val past24hrPrecipitation: String   // 過去24小時降雨量
)
