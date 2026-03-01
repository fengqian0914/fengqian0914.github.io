package com.example.opendataAPI

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.example.opendataAPI.databinding.ActivityEarthquakeBinding
import org.json.JSONObject

class earthquake : AppCompatActivity() {
    private lateinit var binding:ActivityEarthquakeBinding
    private val viewModel: MyViewModel by viewModels()
    private var earthquakeDataList = mutableListOf<earthquakeData>()
    private lateinit var recyclerViewAdapter: earthquake_RecyclerviewAdapter
    private lateinit var recyclerView: RecyclerView
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding=ActivityEarthquakeBinding.inflate(layoutInflater)
        setContentView(binding.root)

        recyclerView = binding.earthquakeRecyclerview
        recyclerViewAdapter = earthquake_RecyclerviewAdapter(earthquakeDataList)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.adapter = recyclerViewAdapter

        viewModel.post.observe(this) { response ->
            try {
                val mAll = JSONObject(response.pp)
                val mRecords = mAll.getJSONObject("records").getJSONArray("Earthquake")
                val mData: MutableList<earthquakeData> = ArrayList()
                for (i in 0 until mRecords.length()) {
                    val oneObject = mRecords.getJSONObject(i)
                    val ReportContent=oneObject.getString("ReportContent")
                    val ReportImageURI =oneObject.getString("ReportImageURI")
                    val ReportWeb=oneObject.getString("Web")

                    val EarthquakeInfo=oneObject.getJSONObject("EarthquakeInfo")
                    val OriginTime=EarthquakeInfo.getString("OriginTime")
                    val FocalDepth=EarthquakeInfo.getLong("FocalDepth")

                    val Epicenter=EarthquakeInfo.getJSONObject("Epicenter")
                    val Location=Epicenter.getString("Location")
                    val EpicenterLatitude=Epicenter.getString("EpicenterLatitude")
                    val EpicenterLongitude=Epicenter.getString("EpicenterLongitude")

                    val MagnitudeValue =EarthquakeInfo.getJSONObject("EarthquakeMagnitude").getDouble("MagnitudeValue")


//                    val ShakingArea=oneObject.getJSONObject("Intensity").getJSONArray("ShakingArea")
                    Log.d("title","第${i}筆 ReportContent${ReportContent}_ReportImageURI${ReportImageURI}ReportWeb${ReportWeb}\n " +
                            "OriginTime${OriginTime} FocalDepth${FocalDepth} \n" +
                            "Location${Location} EpicenterLatitude${EpicenterLatitude} EpicenterLongitude${EpicenterLongitude} \n" +
                            "MagnitudeValue${MagnitudeValue}")
//                    for(i in 0 until ShakingArea.length()){
//                        val ShakingAreaObject=ShakingArea.getJSONObject(i)
//                        val CountyName=ShakingAreaObject.getString("CountyName")
//                        val AreaIntensity=ShakingAreaObject.getString("AreaIntensity")
//                        Log.d("title","第${i}筆 CountyName${CountyName} AreaIntensity${AreaIntensity}")
//                    }
                    Log.d("title","第${i}筆 結束")

                    mData.add(
                        earthquakeData(
                            ReportContent,
                            ReportImageURI,
                            ReportWeb,
                            OriginTime,
                            FocalDepth,
                            Location,
                            EpicenterLatitude,
                            EpicenterLongitude,
                            MagnitudeValue
                        )
                    )
                }

                // 更新列表
                earthquakeDataList.clear()
                earthquakeDataList.addAll(mData)
                recyclerViewAdapter.notifyDataSetChanged()
            } catch (e: Exception) {
                Log.e("API Error", "解析天氣資料失敗: ${e.message}")

            }
        }
        viewModel.cwa_APICall("https://opendata.cwa.gov.tw/api/v1/rest/datastore/E-A0016-001?Authorization=CWB-E276A43B-A362-40F5-B15E-9EF0C53D4D63")

    }
}