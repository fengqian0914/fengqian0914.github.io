package com.example.opendataAPI

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import androidx.activity.viewModels
import com.bumptech.glide.Glide
import com.example.opendataAPI.databinding.ActivityApodPictureBinding
import org.json.JSONArray
import org.json.JSONObject

class APOD_picture : AppCompatActivity() {
    private lateinit var binding:ActivityApodPictureBinding
    private val viewModel:MyViewModel by viewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding= ActivityApodPictureBinding.inflate(layoutInflater)
        setContentView(binding.root)
        viewModel.post.observe(this,{
            val mAll = if (it.pp.trim().startsWith("[")) {
                JSONArray(it.pp).getJSONObject(0)
            } else {
                JSONObject(it.pp)
            }

            val date=mAll.getString("date")
            val hdurl=mAll.getString("url")
            val title=mAll.getString("title")
            val explanation=mAll.getString("explanation")
            binding.apodDate.text=date
            binding.APODTitle.text=title
            binding.APODExplanation.text=explanation
            Glide.with(this)
                .load(hdurl)
                .placeholder(R.drawable.baseline_downloading_24)
                .into(binding.APODImage)

        })

        viewModel.cwa_APICall("https://api.nasa.gov/planetary/apod?api_key=MOdmQm3rah6iG58jnMhzvuS1pOBw3Iqaahx2doTm")
        binding.APODTodayBtn.setOnClickListener {
            viewModel.cwa_APICall("https://api.nasa.gov/planetary/apod?api_key=MOdmQm3rah6iG58jnMhzvuS1pOBw3Iqaahx2doTm")
        }
        binding.APODRandomBtn.setOnClickListener {
            viewModel.cwa_APICall("https://api.nasa.gov/planetary/apod?api_key=MOdmQm3rah6iG58jnMhzvuS1pOBw3Iqaahx2doTm&count=1")
        }
    }
}