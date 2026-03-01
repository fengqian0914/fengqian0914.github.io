package com.example.opendataAPI

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.opendataAPI.databinding.ActivityMainBinding

class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding=ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)
        binding.APIBtn1.setOnClickListener {
            val intent= Intent(this,current_weather::class.java).apply{
                startActivity(this)
            }
        }
        binding.APIBtn2.setOnClickListener {
            val intent= Intent(this,APOD_picture::class.java).apply{
                startActivity(this)
            }
        }

        binding.APIBtn3.setOnClickListener {

            val intent= Intent(this,CWA_week::class.java).apply{
                startActivity(this)
            }
        }
        binding.APIBtn4.setOnClickListener {

            val intent= Intent(this,earthquake::class.java).apply{
                startActivity(this)
            }
        }
        binding.APIBtn5.setOnClickListener {

            val intent = Intent(this,TodaySunMoon::class.java).apply {
                startActivity(this)
            }
        }
        binding.APIBtn6.setOnClickListener {
            val intent = Intent(this,rainfall_station::class.java).apply {
                startActivity(this)
            }
        }

        binding.APIBtn7.setOnClickListener {
            val intent = Intent(this,Gas_station::class.java).apply {
                startActivity(this)
            }
        }
        binding.APIBtn8.setOnClickListener {
            val intent= Intent(this,PM25Activity::class.java).apply{
                startActivity(this)
            }
        }
    }
}