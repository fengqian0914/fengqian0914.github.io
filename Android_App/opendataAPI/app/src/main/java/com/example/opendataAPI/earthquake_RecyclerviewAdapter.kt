package com.example.opendataAPI

import android.content.Intent
import android.graphics.Color
import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.LinearLayout
import android.widget.TextView
import androidx.core.content.ContextCompat
import androidx.core.content.ContextCompat.startActivity
import androidx.recyclerview.widget.RecyclerView

class earthquake_RecyclerviewAdapter (
    private val mList:List<earthquakeData>):
    RecyclerView.Adapter<earthquake_RecyclerviewAdapter.MyViewHolder>(){
    class MyViewHolder(itemView: View):RecyclerView.ViewHolder(itemView) {

        val OriginTime:TextView=itemView.findViewById(R.id.VH_OriginTime)
        val FocalDepth:TextView=itemView.findViewById(R.id.VH_FocalDepth)
        val Location:TextView=itemView.findViewById(R.id.VH_Location)
        val EpicenterLatitude:TextView=itemView.findViewById(R.id.VH_EpicenterLatitude)
        val EpicenterLongitude:TextView=itemView.findViewById(R.id.VH_EpicenterLongitude)
        val MagnitudeValue:TextView=itemView.findViewById(R.id.VH_MagnitudeValue)
        val Maxvalue:TextView=itemView.findViewById(R.id.VH_Maxvalue)

        val MagnitudeValueLayout:LinearLayout=itemView.findViewById(R.id.VH_MagentiudeLayout)
        val MaxValueLayout:LinearLayout=itemView.findViewById(R.id.VH_MaxValueLayout)
        val DepthLayout:LinearLayout=itemView.findViewById(R.id.VH_DepthLayout)

        val imgbtn: Button =itemView.findViewById(R.id.VH_ImgBtn)
        val WebBtn:Button=itemView.findViewById(R.id.VH_WebBtn)

    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): MyViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.activity_earthquake_recyclerview_adapter, parent, false)


        return  MyViewHolder(view)
    }

    override fun getItemCount(): Int {
        return mList.size
    }

    override fun onBindViewHolder(holder: MyViewHolder, position: Int) {
        val currentItem=mList[position]
        val context=holder.itemView.context
        holder.MagnitudeValue.text=currentItem.MagnitudeValue.toString()
        holder.EpicenterLatitude.text=currentItem.EpicenterLatitude
        holder.EpicenterLongitude.text=currentItem.EpicenterLongitude
        holder.FocalDepth.text="${currentItem.FocalDepth} 公里"

        val content = currentItem.ReportContent
        val substring = content.substring(content.length - 3, content.length - 2)
        holder.Maxvalue.text=substring

        if(currentItem.MagnitudeValue>=5.0){
            holder.MagnitudeValueLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.MagnitudeValue_1))
        }else if(currentItem.MagnitudeValue>=4.0){
            holder.MagnitudeValueLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.MagnitudeValue_2))
        }else{
            holder.MagnitudeValueLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.MagnitudeValue_3))
        }


        if(substring.toInt()>=4.0){
            holder.MaxValueLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.MaxValue_1))
        }else if(substring.toInt()>=2.0){
            holder.MaxValueLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.MaxValue_2))
        }else{
            holder.MaxValueLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.MaxValue_3))
        }

        if( currentItem.FocalDepth >=70){
            holder.DepthLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.Depth_1))
        }else if(currentItem.FocalDepth>30){
            holder.DepthLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.Depth_2))
        }else{
            holder.DepthLayout.setBackgroundColor(ContextCompat.getColor(context, R.color.Depth_3))
        }
        holder.imgbtn.setOnClickListener {
            val intent = Intent(context, earthquake_Image::class.java).apply {
                putExtra("ImageUrl", currentItem.ReportImageURI)
            }
            context.startActivity(intent)
            Log.d("title","1 ImageUrl${currentItem.ReportImageURI}")
        }
        holder.WebBtn.setOnClickListener {
            val intent = Intent(Intent.ACTION_VIEW).apply {
                data = Uri.parse(currentItem.ReportWeb)
            }
            context.startActivity(intent)

        }



        holder.OriginTime.text=currentItem.OriginTime

        holder.Location.text=currentItem.Location
    }

}