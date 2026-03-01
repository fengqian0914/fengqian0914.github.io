package com.example.opendataAPI

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class rainfall_station_RecyclerviewAdapter(
    private val mList: List<rainfall_station_Data>
) : RecyclerView.Adapter<rainfall_station_RecyclerviewAdapter.MyViewHolder>() {

    // 建立 ViewHolder
    class MyViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val VH_StationName: TextView = itemView.findViewById(R.id.item_station_name)
        val VH_StationId: TextView = itemView.findViewById(R.id.item_station_id)
        val VH_CurrentPrecipitation: TextView = itemView.findViewById(R.id.item_current_precipitation)
        val VH_Past24hrPrecipitation: TextView = itemView.findViewById(R.id.item_past24hr_precipitation)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MyViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.activity_rainfall_station_recycler_view, parent, false)
        return MyViewHolder(view)
    }

    override fun onBindViewHolder(holder: MyViewHolder, position: Int) {
        val currentItem = mList[position]
        holder.VH_StationName.text = currentItem.stationName
        holder.VH_StationId.text = currentItem.stationId
        holder.VH_CurrentPrecipitation.text = "Current: ${currentItem.currentPrecipitation} mm"
        holder.VH_Past24hrPrecipitation.text = "24hr: ${currentItem.past24hrPrecipitation} mm"
    }

    override fun getItemCount(): Int {
        return mList.size
    }
}
