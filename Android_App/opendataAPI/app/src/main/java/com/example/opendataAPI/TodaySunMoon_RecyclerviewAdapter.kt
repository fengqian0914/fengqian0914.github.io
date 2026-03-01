package com.example.opendataAPI

import android.graphics.Color
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ProgressBar
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.github.mikephil.charting.charts.PieChart
import com.github.mikephil.charting.data.PieData
import com.github.mikephil.charting.data.PieDataSet
import com.github.mikephil.charting.data.PieEntry
import java.util.Calendar

class TodaySunMoon_RecyclerviewAdapter(
    private val mList:List<TodaySunMoonData>,private val nowTime: Calendar
):
RecyclerView.Adapter<TodaySunMoon_RecyclerviewAdapter.MyViewHolder>(){
    class MyViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {

        val VHCountyName:TextView=itemView.findViewById(R.id.items_CountyName)
        val VHSunRiseTime:TextView=itemView.findViewById(R.id.item_SunRiseTime)
        val VHSunSetTime:TextView=itemView.findViewById(R.id.item_sunSet)
        val VHprogressBar:ProgressBar=itemView.findViewById(R.id.progressBar2)



    }
    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): TodaySunMoon_RecyclerviewAdapter.MyViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.activity_today_sun_moon_recyclerview_adapter, parent, false)

        return MyViewHolder(view)
    }

    override fun onBindViewHolder(
        holder: TodaySunMoon_RecyclerviewAdapter.MyViewHolder,
        position: Int
    ) {
        val item=mList[position]

        val nowHour = nowTime.get(Calendar.HOUR_OF_DAY) // 小時 (24小時制)
        val nowMinute = nowTime.get(Calendar.MINUTE)   // 分鐘
        var nowallMinute=nowHour*60+nowMinute

        holder.VHCountyName.text=item.CountyName
        holder.VHSunRiseTime.text=item.SunRiseTime
        holder.VHSunSetTime.text=item.SunSetTime

        var sunrise_time=item.SunRiseTime.substring(0,2).toInt()*60+ item.SunRiseTime.substring(3,5).toInt()
        var sunset_time=item.SunSetTime.substring(0,2).toInt()*60+item.SunSetTime.substring(3,5).toInt()



        if(nowallMinute>sunset_time){
            holder.VHprogressBar.progress = 100
        }else if(nowallMinute<sunset_time &&nowallMinute>sunrise_time){
            val counttime=nowallMinute-sunrise_time
            val counttimes=counttime*100/(sunset_time-sunrise_time)
            holder.VHprogressBar.progress=counttimes
        }else{
            holder.VHprogressBar.progress = 0
        }


    }

    override fun getItemCount(): Int {
        return mList.size
    }

}