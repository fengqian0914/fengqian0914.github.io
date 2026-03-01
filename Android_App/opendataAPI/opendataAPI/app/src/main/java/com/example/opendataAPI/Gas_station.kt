package com.example.opendataAPI

import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.opendataAPI.databinding.ActivityGasStationBinding
import org.json.JSONArray

class Gas_station : AppCompatActivity() {
    private lateinit var binding: ActivityGasStationBinding
    private val viewModel: MyViewModel by viewModels()
    private var gasStationDataList = mutableListOf<Gas_station_Data>()
    private lateinit var recyclerViewAdapter: GasStationRecyclerViewAdapter
    private lateinit var recyclerView: RecyclerView

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityGasStationBinding.inflate(layoutInflater)
        setContentView(binding.root)

        // RecyclerView 設置
        recyclerView = binding.gasStation
        recyclerViewAdapter = GasStationRecyclerViewAdapter(gasStationDataList)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = recyclerViewAdapter

        // 觀察 API 返回資料
        viewModel.post.observe(this) { response ->
            try {
                val stations = JSONArray(response.pp) // 假設 API 回傳的是一個 JSON 陣列
                val mData: MutableList<Gas_station_Data> = ArrayList()

                for (i in 0 until stations.length()) {
                    val station = stations.getJSONObject(i)
                    val stationId = station.getString("站代號")
                    val stationName = station.getString("站名")
                    val zipCode = station.getString("郵遞區號")
                    val address = station.getString("地址")
                    val phone = station.getString("電話")
                    val serviceTime = station.getString("提供服務時段")

                    // 將資料加入列表
                    mData.add(
                        Gas_station_Data(
                            stationId = stationId,
                            stationName = stationName,
                            postalCode = zipCode,
                            address = address,
                            phone = phone,
                            serviceHours = serviceTime
                        )
                    )
                }

                // 更新列表
                gasStationDataList.clear()
                gasStationDataList.addAll(mData)
                recyclerViewAdapter.notifyDataSetChanged()
            } catch (e: Exception) {
                Log.e("API Error", "解析資料失敗: ${e.message}")
            }
        }

        // 使用你的 OpenData API URL
        viewModel.cwa_APICall("https://vipmbr.cpc.com.tw/openData/VarietyShopStn")
    }
}
