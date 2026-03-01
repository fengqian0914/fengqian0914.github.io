package com.example.opendataAPI

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class PM25_RecyclerviewAdapter (
    private val mList:List<PM25_Data>):
    RecyclerView.Adapter<PM25_RecyclerviewAdapter.MyViewHolder>(){

    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): PM25_RecyclerviewAdapter.MyViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.activity_pm25_recyclerview_adapter, parent, false)

        return  MyViewHolder(view)
    }
    class MyViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {
        val VH_sitename:TextView=itemView.findViewById(R.id.item_sitename)
        val VH_country:TextView=itemView.findViewById(R.id.item_country)
        val VH_aqi:TextView=itemView.findViewById(R.id.item_aqi)
        val VH_status:TextView=itemView.findViewById(R.id.item_status)
    }
    override fun onBindViewHolder(holder: MyViewHolder,position: Int){
        val currentItem = mList[position]
        holder.VH_sitename.text=currentItem.sitename
        holder.VH_country.text=currentItem.country
        holder.VH_aqi.text=currentItem.aqi.toString()
        holder.VH_status.text=currentItem.status
    }
    override fun getItemCount(): Int {
        return mList.size
    }

}