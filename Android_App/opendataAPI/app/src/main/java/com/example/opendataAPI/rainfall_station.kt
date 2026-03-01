package com.example.opendataAPI

import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.opendataAPI.databinding.ActivityRainfallStationBinding
import org.json.JSONObject

class rainfall_station : AppCompatActivity() {
    private lateinit var binding: ActivityRainfallStationBinding
    private val viewModel: MyViewModel by viewModels()
    private var rainfallStationDataList = mutableListOf<rainfall_station_Data>()
    private lateinit var recyclerViewAdapter: rainfall_station_RecyclerviewAdapter
    private lateinit var recyclerView: RecyclerView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityRainfallStationBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // RecyclerView 設置
        recyclerView = binding.rainfallStation
        recyclerViewAdapter = rainfall_station_RecyclerviewAdapter(rainfallStationDataList)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = recyclerViewAdapter

        // 觀察 API 返回資料
        viewModel.post.observe(this) { response ->
            try {
                val mAll = JSONObject(response.pp)
                val mData: MutableList<rainfall_station_Data> = ArrayList()
                val stations = mAll.getJSONObject("cwaopendata").getJSONObject("dataset").getJSONArray("Station")

                for (i in 0 until stations.length()) {
                    val station = stations.getJSONObject(i)
                    val stationName = station.getString("StationName")
                    val stationId = station.getString("StationId")
                    val countyName = station.getJSONObject("GeoInfo").getString("CountyName")
                    val townName = station.getJSONObject("GeoInfo").getString("TownName")
                    val currentPrecipitation =
                        station.getJSONObject("RainfallElement").getJSONObject("Now").getString("Precipitation")
                    val past24hrPrecipitation =
                        station.getJSONObject("RainfallElement").getJSONObject("Past24hr").getString("Precipitation")

                    // 將資料加入列表
                    mData.add(
                        rainfall_station_Data(
                            stationName = stationName,
                            stationId = stationId,
                            countyName = countyName,
                            townName = townName,
                            currentPrecipitation = currentPrecipitation,
                            past24hrPrecipitation = past24hrPrecipitation
                        )
                    )
                }

                // 更新列表
                rainfallStationDataList.clear()
                rainfallStationDataList.addAll(mData)
                recyclerViewAdapter.notifyDataSetChanged()
            } catch (e: Exception) {
                Log.e("API Error", "解析資料失敗: ${e.message}")
            }
        }

        // 使用你的 OpenData API URL
        viewModel.cwa_APICall("https://opendata.cwa.gov.tw/fileapi/v1/opendataapi/O-A0002-001?Authorization=rdec-key-123-45678-011121314&format=JSON")
    }
}
