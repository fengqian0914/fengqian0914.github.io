package com.example.opendataAPI

data class earthquakeData(

    var ReportContent:String,
    var ReportImageURI:String,
    var ReportWeb:String,
    var OriginTime:String,
    var FocalDepth:Long,
    var Location:String,
    var EpicenterLatitude:String,
    var EpicenterLongitude:String,
    var MagnitudeValue:Double

)
