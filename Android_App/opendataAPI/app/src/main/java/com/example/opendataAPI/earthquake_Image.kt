package com.example.opendataAPI

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import com.bumptech.glide.Glide
import com.example.opendataAPI.databinding.ActivityEarthquakeImageBinding

class earthquake_Image : AppCompatActivity() {
    private lateinit var binding:ActivityEarthquakeImageBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding= ActivityEarthquakeImageBinding.inflate(layoutInflater)
        setContentView(binding.root)
        val url=intent.getStringExtra("ImageUrl")
        Log.d("title","2 ImageUrl${url}")

        Glide.with(this)
            .load(url)
            .into(binding.earthquakeImage)
    }
}