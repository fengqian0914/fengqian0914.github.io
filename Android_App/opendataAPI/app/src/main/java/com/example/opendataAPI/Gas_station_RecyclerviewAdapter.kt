package com.example.opendataAPI

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class GasStationRecyclerViewAdapter(
    private var mList: List<Gas_station_Data>
) : RecyclerView.Adapter<GasStationRecyclerViewAdapter.MyViewHolder>() {

    class MyViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {
        val VH_StationName: TextView = itemView.findViewById(R.id.item_station_name)
        val VH_StationId: TextView = itemView.findViewById(R.id.item_station_id)
        val VH_ZipCode: TextView = itemView.findViewById(R.id.item_zip_code)
        val VH_Address: TextView = itemView.findViewById(R.id.item_address)
        val VH_Phone: TextView = itemView.findViewById(R.id.item_phone)
        val VH_ServiceTime: TextView = itemView.findViewById(R.id.item_service_time)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MyViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.gas_station_recycler_view, parent, false)
        return MyViewHolder(view)
    }

    override fun onBindViewHolder(holder: MyViewHolder, position: Int) {
        val currentItem = mList[position]
        holder.VH_StationName.text = currentItem.stationName
        holder.VH_StationId.text = currentItem.stationId
        holder.VH_ZipCode.text = currentItem.postalCode
        holder.VH_Address.text = currentItem.address
        holder.VH_Phone.text = currentItem.phone
        holder.VH_ServiceTime.text = currentItem.serviceHours
    }

    override fun getItemCount(): Int {
        return mList.size
    }

    fun updateData(newList: List<Gas_station_Data>) {
        mList = newList
        notifyDataSetChanged()
    }
}
