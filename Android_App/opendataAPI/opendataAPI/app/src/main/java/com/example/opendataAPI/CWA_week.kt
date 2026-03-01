package com.example.opendataAPI

import android.graphics.Color
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import android.widget.ArrayAdapter
import androidx.activity.viewModels
import androidx.appcompat.app.AppCompatActivity
import com.example.opendataAPI.databinding.ActivityCwaWeekBinding
import com.github.mikephil.charting.components.LimitLine
import com.github.mikephil.charting.components.XAxis
import com.github.mikephil.charting.data.Entry
import com.github.mikephil.charting.data.LineData
import com.github.mikephil.charting.data.LineDataSet
import com.github.mikephil.charting.formatter.ValueFormatter
import org.json.JSONObject
import java.text.SimpleDateFormat
import java.util.Locale


class CWA_week : AppCompatActivity() {
    private lateinit var binding: ActivityCwaWeekBinding
    private val viewModel: MyViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding= ActivityCwaWeekBinding.inflate(layoutInflater)
        setContentView(binding.root)
        val spinner = binding.spinner
        val adapter = ArrayAdapter.createFromResource(
            this,
            R.array.city_array,
            android.R.layout.simple_spinner_item)

        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

        spinner.adapter = adapter







        viewModel.post.observe(this) { response ->
            try {

                val mAll = JSONObject(response.pp)
                val mRecords = mAll.getJSONObject("records").getJSONArray("location")
                val mData: MutableList<Array<Any>> = ArrayList()
//
                for (i in 0 until mRecords.length()) {
                    val oneObject = mRecords.getJSONObject(i)
                    val locationName = oneObject.getString("locationName")
                    val weatherElement = oneObject.getJSONArray("weatherElement")

                    // Prepare lists to hold weather data for each elementg
                    val PoPData: MutableList<String> = ArrayList()
                    val MinData: MutableList<String> = ArrayList()
                    val MaxData: MutableList<String> = ArrayList()
                    val TimeData: MutableList<String> = ArrayList()

                    for (j in 0 until weatherElement.length()) {
                        val element = weatherElement.getJSONObject(j)
                        val elementName = element.getString("elementName")
                        val timeArray = element.getJSONArray("time")

                        when (elementName) {
                            "PoP" -> {
                                for (k in 0 until timeArray.length()) {
                                    val parameter = timeArray.getJSONObject(k).getJSONObject("parameter")
                                    val parameterName = parameter.getString("parameterName")
                                    val startTime=timeArray.getJSONObject(k).getString("startTime")
                                    PoPData.add(parameterName)
                                    TimeData.add(startTime)
                                }
                            }
                            "MinT" -> {
                                for (k in 0 until timeArray.length()) {
                                    val parameter = timeArray.getJSONObject(k).getJSONObject("parameter")
                                    val parameterName = parameter.getString("parameterName")
                                    MinData.add(parameterName)
                                }
                            }
                            "MaxT" -> {
                                for (k in 0 until timeArray.length()) {
                                    val parameter = timeArray.getJSONObject(k).getJSONObject("parameter")
                                    val parameterName = parameter.getString("parameterName")
                                    MaxData.add(parameterName)
                                }
                            }
                        }
                    }

                    mData.add(arrayOf(locationName, PoPData, MinData, MaxData,TimeData))

                }
                Log.d("title","mData${mData.toString()}")
                binding.textView14.text=mData[0][0] as String

                lineChart(mData)
            } catch (e: Exception) {
                Log.e("API Error", "解析天氣資料失敗: ${e.message}")

            }
        }
        spinner.setOnItemSelectedListener(spnOnItemSelected);



    }

    private fun lineChart(mData: MutableList<Array<Any>>) {
        val lineChart = binding.lineChart
        val lineChart2 = binding.lineChart2


        val entries1: MutableList<Entry> = ArrayList()
        val minData = mData[0][2] as List<String> // 取得 MinData

        Log.d("title","minData${minData}")

        entries1.add(Entry(0f, minData[0].toFloat()))
        entries1.add(Entry(18f, minData[1].toFloat()))
        entries1.add(Entry(36f, minData[2].toFloat()))

        val dataSet1 = LineDataSet(entries1, "最低溫")
        dataSet1.color = Color.BLUE
        dataSet1.lineWidth = 2f
        dataSet1.setDrawCircles(true)
        dataSet1.circleRadius = 5f
        dataSet1.setCircleColor(Color.BLUE)
        dataSet1.setDrawValues(true)
        dataSet1.valueTextSize=16f

        val entries2: MutableList<Entry> = ArrayList()
        val maxData = mData[0][3] as List<String>

        entries2.add(Entry(0f, maxData[0].toFloat()))
        entries2.add(Entry(18f, maxData[1].toFloat()))
        entries2.add(Entry(36f, maxData[2].toFloat()))


        val dataSet2 = LineDataSet(entries2, "最高溫")
        dataSet2.color = Color.RED
        dataSet2.lineWidth = 2f
        dataSet2.setDrawCircles(true)
        dataSet2.circleRadius = 5f
        dataSet2.setCircleColor(Color.RED)
        dataSet2.setDrawValues(true)
        dataSet2.valueTextSize=14f


        val lineData = LineData(dataSet1, dataSet2)
        lineChart.data = lineData


        // 設定 X 軸
        val xAxis1 = lineChart.xAxis
        xAxis1.setAxisMinimum(-4f)  // 設定 X 軸的最小值
        xAxis1.setAxisMaximum(40f) // 設定 X 軸的最大值
        xAxis1.setGranularity(18f)  // 設定刻度的間距
        lineChart.axisRight.isEnabled = true
        lineChart.axisRight.setDrawLabels(false)

        // 如果需要顯示右側的線條，確保以下設定：
        lineChart.axisRight.setDrawAxisLine(true)

        // 格式化 X 軸顯示的日期時間
        val TimeData = mData[0][4] as List<String> // 取得TimeData
        // 使用 valueFormatter 來設定顯示的日期
        xAxis1.valueFormatter = object : ValueFormatter() {
            override fun getFormattedValue(value: Float): String {
                val index = when (value) {
                    0f -> 0
                    18f -> 1
                    36f -> 2
                    else -> -1
                }
                return if (index != -1) TimeData[index] else ""
            }
        }

        xAxis1.position = XAxis.XAxisPosition.BOTTOM // 設定標籤顯示位置在底部
        lineChart.description.isEnabled = false


//
//
        val PoPData = mData[0][1] as List<String> // 取得 PoPData

        val entries3: MutableList<Entry> = ArrayList()

        Log.d("title","PoPData${PoPData}")

        entries3.add(Entry(0f, PoPData[0].toFloat()))
        entries3.add(Entry(18f, PoPData[1].toFloat()))
        entries3.add(Entry(36f, PoPData[2].toFloat()))

        val dataSet3 = LineDataSet(entries3, "降雨機率")
        dataSet3.color = Color.BLUE
        dataSet3.lineWidth = 2f
        dataSet3.setDrawCircles(true)
        dataSet3.circleRadius = 5f
        dataSet3.setCircleColor(Color.BLUE)
        dataSet3.setDrawValues(true)
        dataSet3.valueTextSize=16f

        val lineData2 = LineData(dataSet3)
        lineChart2.data = lineData2
        lineChart2.invalidate()



        // 設定 X 軸
        val xAxis2 = lineChart2.xAxis
        xAxis2.setAxisMinimum(-4f)
        xAxis2.setAxisMaximum(40f)
        xAxis2.setGranularity(18f)

        lineChart2.axisRight.isEnabled = true
        lineChart2.axisRight.setDrawLabels(false)
        lineChart2.axisRight.setDrawAxisLine(true) // 預設為 true，可省略
        // 使用 valueFormatter 來設定顯示的日期
        xAxis2.valueFormatter = object : ValueFormatter() {
            override fun getFormattedValue(value: Float): String {
                val index = when (value) {
                    0f -> 0
                    18f -> 1
                    36f -> 2
                    else -> -1
                }
                return if (index != -1) TimeData[index] else ""
            }
        }

        // 設定右側 Y 軸範圍
        val rightAxis2 = lineChart2.axisRight
        rightAxis2.axisMinimum = 0f
        rightAxis2.axisMaximum = 100f
        rightAxis2.granularity = 10f
        val leftAxis2 = lineChart2.axisLeft
        leftAxis2.axisMinimum = 0f
        leftAxis2.axisMaximum = 100f
        leftAxis2.granularity = 10f


        val max=Math.max(
            maxData[0].toFloat(),
            Math.max(maxData[1].toFloat(), maxData[2].toFloat())
        ) + 5
        val min=Math.min(
            minData[0].toFloat(),
            Math.min(minData[1].toFloat(), minData[2].toFloat())
        ) - 5

        val rightAxis = lineChart.axisRight
        rightAxis.axisMaximum =max
        rightAxis.axisMinimum =min
        rightAxis.granularity = 1f

        val leftAxis1 = lineChart.axisLeft
        leftAxis1.axisMaximum = max
        leftAxis1.axisMinimum = min
        leftAxis1.granularity = 1f

        xAxis2.position = XAxis.XAxisPosition.BOTTOM // 設定標籤顯示位置在底部
        lineChart2.description.isEnabled = false



        lineChart.invalidate()
    }

    private val spnOnItemSelected: AdapterView.OnItemSelectedListener =
        object : AdapterView.OnItemSelectedListener {
            override fun onItemSelected(
                parent: AdapterView<*>, view: View,
                pos: Int, id: Long
            ) {
                val sInfo = parent.getItemAtPosition(pos).toString()
                viewModel.cwa_APICall("https://opendata.cwa.gov.tw/api/v1/rest/datastore/F-C0032-001?Authorization=CWB-E276A43B-A362-40F5-B15E-9EF0C53D4D63&locationName=${sInfo}")
            }

            override fun onNothingSelected(parent: AdapterView<*>?) {
                //
            }
        }
}