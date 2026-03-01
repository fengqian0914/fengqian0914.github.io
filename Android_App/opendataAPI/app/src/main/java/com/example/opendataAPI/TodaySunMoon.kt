package com.example.opendataAPI

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.opendataAPI.databinding.ActivityTodaySunMoonBinding
import org.json.JSONObject
import java.util.Calendar

class TodaySunMoon : AppCompatActivity() {
    private lateinit var binding:ActivityTodaySunMoonBinding
    private val viewModel: MyViewModel by viewModels()
    private var TodaySunMoonDataList = mutableListOf<TodaySunMoonData>()
    private lateinit var recyclerViewAdapter: TodaySunMoon_RecyclerviewAdapter
    private lateinit var recyclerView: RecyclerView
    override fun onCreate(savedInstanceState: Bundle?) {

        super.onCreate(savedInstanceState)
        binding=ActivityTodaySunMoonBinding.inflate(layoutInflater)
        setContentView(binding.root)


        // 獲取目前時間
        val calendar = Calendar.getInstance()
        val currentToDay="${calendar.get(Calendar.YEAR)}-${calendar.get(Calendar.MONTH)+1}-${calendar.get(Calendar.DATE)}"

        Log.d("日期","currentDay${currentToDay}")
        val currentHour = calendar.get(Calendar.HOUR_OF_DAY) // 小時 (24小時制)
        val currentMinute = calendar.get(Calendar.MINUTE)   // 分鐘

        // 使用 String.format 來確保小於 10 時，顯示兩位數
        val formattedHour = String.format("%02d", currentHour)
        val formattedMinute = String.format("%02d", currentMinute)

        // 顯示格式化過的時間
        binding.NowTime.text = "$formattedHour:$formattedMinute"

        // RecyclerView 設置
        recyclerView = binding.SunMoonRecyclerview
        recyclerViewAdapter = TodaySunMoon_RecyclerviewAdapter(TodaySunMoonDataList,calendar)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = recyclerViewAdapter
        viewModel.post.observe(this) { response ->
            try {
                val mAll = JSONObject(response.pp)
                val mRecords = mAll.getJSONObject("records").getJSONObject("locations").getJSONArray("location")
                val mData: MutableList<TodaySunMoonData> = ArrayList()
                for (i in 0 until mRecords.length()) {
                    val oneObject = mRecords.getJSONObject(i)
                    val CountyName=oneObject.getString("CountyName")
                    val timeObejct=oneObject.getJSONArray("time").getJSONObject(0)
                    val SunRiseTime=timeObejct.getString("SunRiseTime")
                    val SunSetTime=timeObejct.getString("SunSetTime")

//                    Log.d("title","第${i}筆 CountyName${CountyName} SunRiseTime${SunRiseTime} SunSetTime${SunSetTime}")
//
//                    Log.d("title","第${i}筆 結束")

                    mData.add(
                        TodaySunMoonData(
                            CountyName,
                            SunRiseTime,
                            SunSetTime
                        )
                    )
                }

                // 更新列表
                TodaySunMoonDataList.clear()
                TodaySunMoonDataList.addAll(mData)
                recyclerViewAdapter.notifyDataSetChanged()
            } catch (e: Exception) {
                Log.e("API Error", "解析天氣資料失敗: ${e.message}")

            }
        }
        viewModel.cwa_APICall("https://opendata.cwa.gov.tw/api/v1/rest/datastore/A-B0062-001?Authorization=CWB-E276A43B-A362-40F5-B15E-9EF0C53D4D63&CountyName=&Date=${currentToDay}")

    }
}