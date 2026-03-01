package com.example.opendataAPI

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import androidx.recyclerview.widget.GridLayoutManager
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.opendataAPI.databinding.ActivityCurrentWeatherBinding
import com.example.opendataAPI.databinding.ActivityPm25Binding
import org.json.JSONObject

class PM25Activity : AppCompatActivity() {
    private lateinit var binding: ActivityPm25Binding
    private val viewModel: MyViewModel by viewModels()
    private var PM25DataList = mutableListOf<PM25_Data>()
    private lateinit var recyclerviewAdapter: PM25_RecyclerviewAdapter
    private lateinit var recyclerView: RecyclerView


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityPm25Binding.inflate(layoutInflater)
        setContentView(binding.root)

        // RecyclerView 設置
        recyclerView = binding.PM25Recyclerview
        recyclerviewAdapter = PM25_RecyclerviewAdapter(PM25DataList)
        val gridLayoutManager = GridLayoutManager(this,2)
        recyclerView.layoutManager = gridLayoutManager
        recyclerView.adapter = recyclerviewAdapter



        // 觀察 API 返回資料
        viewModel.post.observe(this) { response ->
            try {
                val mAll = JSONObject(response.pp)
                val mRecords = mAll.getJSONArray("records")
                val mData: MutableList<PM25_Data> = ArrayList()
                for (i in 0 until mRecords.length()) {
                    val oneObject = mRecords.getJSONObject(i)
                    val sitename = oneObject.getString("sitename")
                    val country = oneObject.getString("county")
                    val aqi = oneObject.getString("aqi")
                    val status = oneObject.getString("status")
                    mData.add(
                        PM25_Data(
                            sitename,
                            country,
                            aqi,
                            status,
                        )
                    )
                }

                //更新列表
                PM25DataList.clear()
                PM25DataList.addAll(mData)
                recyclerviewAdapter.notifyDataSetChanged()

            }catch (e:Exception){
                Log.e("API Error", "解析空氣品質資料失敗: ${e.message}")
            }

        }
        viewModel.cwa_APICall("https://data.moenv.gov.tw/api/v2/aqx_p_432?api_key=e8dd42e6-9b8b-43f8-991e-b3dee723a52d&limit=1000&sort=ImportDate%20desc&format=JSON")
    }
}