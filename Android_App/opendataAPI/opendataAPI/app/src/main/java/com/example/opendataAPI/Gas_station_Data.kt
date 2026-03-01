package com.example.opendataAPI

data class Gas_station_Data(
    val stationId: String,          // 站代號
    val stationName: String,        // 站名
    val postalCode: String,         // 郵遞區號
    val address: String,            // 地址
    val phone: String,              // 電話
    val serviceHours: String        // 提供服務時段
)
