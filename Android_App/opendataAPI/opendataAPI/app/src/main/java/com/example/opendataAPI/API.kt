package com.example.opendataAPI

import android.util.Log
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import okhttp3.Call
import okhttp3.Callback
import okhttp3.FormBody
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.Response
import okio.IOException
import org.json.JSONObject

class MyViewModel:ViewModel() {
    private var _post= MutableLiveData<Post>()
    val post:MutableLiveData<Post> get()=_post
    private val client=OkHttpClient()
    fun cwa_APICall(url: String){
        val request=Request.Builder()
            .url(url)
            .build()
        client.newCall(request).enqueue(object :okhttp3.Callback{
            override fun onFailure(call: Call, e: IOException) {
            }

            override fun onResponse(call: Call, response: Response) {
                if(response.isSuccessful){
                    response.body.string().let{
                        getBackString->
                        val post=Post(pp=getBackString)
                        _post.postValue(post)

                    }
                }else{

                }
            }

        })
    }



}