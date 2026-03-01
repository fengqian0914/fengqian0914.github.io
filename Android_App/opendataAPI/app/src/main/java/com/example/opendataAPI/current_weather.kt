package com.example.opendataAPI

import android.Manifest
import android.content.pm.PackageManager
import android.location.Location
import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.opendataAPI.databinding.ActivityCurrentWeatherBinding
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationServices
import org.json.JSONObject
import kotlin.math.atan2
import kotlin.math.cos
import kotlin.math.sin
import kotlin.math.pow
import kotlin.math.sqrt

class current_weather : AppCompatActivity() {
    private lateinit var binding: ActivityCurrentWeatherBinding
    private val viewModel: MyViewModel by viewModels()
    private var currentWeatherDataList = mutableListOf<current_weather_Data>()
    private lateinit var recyclerViewAdapter: current_weather_RecyclerviewAdapter
    private lateinit var recyclerView: RecyclerView
    private val REQUEST_LOCATION_PERMISSION = 1001

    private lateinit var fusedLocationClient: FusedLocationProviderClient

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityCurrentWeatherBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // 初始化 FusedLocationProviderClient
        fusedLocationClient = LocationServices.getFusedLocationProviderClient(this)

        // RecyclerView 設置
        recyclerView = binding.currentWeatherRecyclerview
        recyclerViewAdapter = current_weather_RecyclerviewAdapter(currentWeatherDataList)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = recyclerViewAdapter

        // 觀察 API 返回資料
        viewModel.post.observe(this) { response ->
            try {
                Log.d("API Response", "Response: $response")
                val mAll = JSONObject(response.pp)
                val mRecords = mAll.getJSONObject("records").getJSONArray("Station")
                val mData: MutableList<current_weather_Data> = ArrayList()

                for (i in 0 until mRecords.length()) {
                    val oneObject = mRecords.getJSONObject(i)
                    val geoInfo = oneObject.getJSONObject("GeoInfo")
                    val weatherElement = oneObject.getJSONObject("WeatherElement")
                    val countyName = geoInfo.getString("CountyName")
                    val townName = geoInfo.getString("TownName")
                    val weather = weatherElement.getString("Weather")
                    val airTemperature = weatherElement.getLong("AirTemperature")

                    val dailyExtreme = weatherElement.getJSONObject("DailyExtreme")
                    val maxTemperature = dailyExtreme.getJSONObject("DailyHigh").getJSONObject("TemperatureInfo").getLong("AirTemperature")
                    val minTemperature = dailyExtreme.getJSONObject("DailyLow").getJSONObject("TemperatureInfo").getLong("AirTemperature")

                    val relativeHumidity = weatherElement.getInt("RelativeHumidity")

                    val StationLatitude = geoInfo.getJSONArray("Coordinates").getJSONObject(0).getDouble("StationLatitude")
                    val StationLongitude = geoInfo.getJSONArray("Coordinates").getJSONObject(0).getDouble("StationLongitude")

                    // 使用回調來處理距離結果
                    getLocation(StationLatitude, StationLongitude) { calculateDistance_Result ->
                        Log.d("Distance Calculated", "距離: ${"%.2f".format(calculateDistance_Result)} 公里")
                        val roundedResult = String.format("%.2f", calculateDistance_Result).toFloat()
                        // 更新資料後加入到 mData
                        mData.add(
                            current_weather_Data(
                                countyName,
                                townName,
                                weather,
                                airTemperature,
                                maxTemperature,
                                minTemperature,
                                relativeHumidity,
                                roundedResult
                            )
                        )

                        // 當所有資料都處理完畢，排序並刷新 RecyclerView
                        if (mData.size == mRecords.length()) {
                            // 根據距離從近到遠排序（最近的放前面）
                            mData.sortBy { it.distance }  // 假設 `distance` 是 `current_weather_Data` 中存儲距離的字段

                            // 更新列表資料並刷新 RecyclerView
                            currentWeatherDataList.clear()
                            currentWeatherDataList.addAll(mData)
                            recyclerViewAdapter.notifyDataSetChanged()
                            Log.d("Data Update", "更新並排序列表資料")
                        }
                    }
                }

            } catch (e: Exception) {
                Log.e("API Error", "解析天氣資料失敗: ${e.message}")
            }
        }


        // 呼叫 API 獲取天氣資料
        viewModel.cwa_APICall("https://opendata.cwa.gov.tw/api/v1/rest/datastore/O-A0003-001?Authorization=CWB-E276A43B-A362-40F5-B15E-9EF0C53D4D63")
    }

    private fun getLocation(
        StationLatitude: Double,
        StationLongitude: Double,
        onDistanceCalculated: (Double) -> Unit
    ) {
        Log.d("getLocation", "getLocation")

        // 檢查權限
        if (ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(this, Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            // 如果權限未被授予，請求權限
            ActivityCompat.requestPermissions(
                this,
                arrayOf(
                    Manifest.permission.ACCESS_FINE_LOCATION,
                    Manifest.permission.ACCESS_COARSE_LOCATION
                ),
                REQUEST_LOCATION_PERMISSION
            )
            viewModel.cwa_APICall("https://opendata.cwa.gov.tw/api/v1/rest/datastore/O-A0003-001?Authorization=CWB-E276A43B-A362-40F5-B15E-9EF0C53D4D63")

            return
        }else{

        }

        // 獲取位置
        fusedLocationClient.lastLocation.addOnSuccessListener { location: Location? ->
            location?.let {
                val latitude = it.latitude
                val longitude = it.longitude
                Log.d("title", "目前位置：緯度: $latitude 經度: $longitude")

                // 計算距離
                val distance = calculateDistance(latitude, longitude, StationLatitude, StationLongitude)

                onDistanceCalculated(distance)
            } ?: run {
                Log.d("title", "無法取得位置資訊")
                onDistanceCalculated(0.0)
            }
        }
    }



    // 計算兩個經緯度之間的距離（單位：公里）
    private fun calculateDistance(
        lat1: Double, lon1: Double,
        lat2: Double, lon2: Double
    ): Double {
        val earthRadius = 6371.0 // 地球半徑（單位：公里）

        val dLat = Math.toRadians(lat2 - lat1)
        val dLon = Math.toRadians(lon2 - lon1)

        val a = sin(dLat / 2).pow(2) + cos(Math.toRadians(lat1)) * cos(Math.toRadians(lat2)) * sin(dLon / 2).pow(2)
        val c = 2 * atan2(sqrt(a), sqrt(1 - a))

        return earthRadius * c
    }
}
