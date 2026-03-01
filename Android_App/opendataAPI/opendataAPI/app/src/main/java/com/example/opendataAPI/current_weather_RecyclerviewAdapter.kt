package com.example.opendataAPI

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class current_weather_RecyclerviewAdapter(
    private val mList:List<current_weather_Data>):
    RecyclerView.Adapter<current_weather_RecyclerviewAdapter.MyViewHolder>(){
    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int):MyViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.activity_current_weather_recyceler_view, parent, false)

        return  MyViewHolder(view)
    }
    class MyViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {
        val VH_CountyName:TextView=itemView.findViewById(R.id.items_CountyName)
        val VH_TownName:TextView=itemView.findViewById(R.id.item_TownName)
        val VH_NowTemperature:TextView=itemView.findViewById(R.id.item_NowTemperature)
        val VH_MaxTemperature:TextView=itemView.findViewById(R.id.item_MaxTemperature)
        val VH_MinTemperature:TextView=itemView.findViewById(R.id.item_MinTemperature)
        val VH_RelativeHumidity:TextView=itemView.findViewById(R.id.item_RelativeHumidity)
        val VH_item_distance:TextView=itemView.findViewById(R.id.item_distance)




    }

    override fun onBindViewHolder(holder: MyViewHolder, position: Int) {
        val currentItem=mList[position]
        holder.VH_CountyName.text=currentItem.CountyName
        holder.VH_TownName.text=currentItem.TownName
        holder.VH_NowTemperature.text=currentItem.NowTemperature.toString()
        holder.VH_MaxTemperature.text=currentItem.MaxTemperature.toString()
        holder.VH_MinTemperature.text=currentItem.MinTemperature.toString()
        holder.VH_RelativeHumidity.text=currentItem.RelativeHumidity.toString()
        holder.VH_item_distance.text="${currentItem.distance} 公里"
    }

    override fun getItemCount(): Int {
        return mList.size
    }
}