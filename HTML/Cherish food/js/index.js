window.onload = function () {
    if (document.body.scrollTop > 0) {
        console.log(1);
        window.scrollTo(0, -1);
        document.body.scrollTop = 0;
    }
    window.scrollTo(0, -1);
    document.body.scrollTop = 0;
}


var time_index = 0;
let time_line = document.getElementById("times");

$(document).ready(function () {
    //$("#times li:nth-child(1)").addClass("time_active");

    $("#times li").hover(function () {
        $(this).addClass("time_active");
        var t = $(this).children(".year_number").text();
        var y = $(this).children(".year_y").text();
        var h = $(this).children(".year_101h").text();
        $("#t101h").text(h);
        $("#title_y").text(y);
        if (h % 1 >= 0.5) {
            var hh = Math.trunc(h);
            $(".twicon-taipei101").slice(0, (h)).addClass("t101h_color");
            $(".twicon-taipei101").slice(hh, (hh + 1)).addClass("t101h_color_50");

        } else {
            $(".twicon-taipei101").slice(0, (h)).addClass("t101h_color");

        }

        $("#number_show").text(t);



    }, function () {
        $(this).removeClass("time_active");
        $(".twicon-taipei101").removeClass("t101h_color");
        $(".twicon-taipei101").removeClass("t101h_color_50");


    });
});

$("#time_btn div:nth-child(1)").click(function () {
    time_index--;
    $("#time_btn div:nth-child(2) span").css("display", "block");
    $("#time_btn div:nth-child(1) span").css("display", "none");

    $(".slide2:nth-of-type(1)").css("transform", "translateX(0%)");
    $(".slide2:nth-of-type(2)").css("transform", "translateX(0%)");

});
$("#time_btn div:nth-child(2)").click(function () {
    time_index++;

    $("#time_btn div:nth-child(2) span").css("display", "none");
    $("#time_btn div:nth-child(1) span").css("display", "block");

    $(".slide2:nth-of-type(1)").css("transform", "translateX(-100%)");
    $(".slide2:nth-of-type(2)").css("transform", "translateX(-100%)");

});
let main1 = document.getElementById("main1");
let main2 = document.getElementById("main2");

let earth = document.getElementById('earth');
let earth_bg = document.getElementById("earth_bg");
let text1 = document.getElementById("text1");
let text2 = document.getElementById("text2");
let text3 = document.getElementById("text3");



let title1_span1 = document.getElementById("title1_span1");
let title2_span1 = document.getElementById("title2_span1");
let title3_span1 = document.getElementById("title3_span1");

let main3_title = document.getElementById("main3_title");

window.addEventListener('scroll', function () {
    let value = document.documentElement.scrollTop || document.body.scrollTop
    let value2 = document.body.scrollHeight

    if (value < 1200) {
        // text2.style.bottom = 50 - value3 + '%';

        //earth.style.transform = 'translateX(-' + (value * 0.00005) + "px)";
        let value3 = Math.round((value - 1200) / 1200 * 100, -2);

        title1_span1.style.fontSize = 30 + value * 0.025 + "px";

    }
    if (value > 1200 & value < 2400) {
        // text1.style.transform = "translateY(-" + (value3 * 2 - value3) + "%)";
        let value3 = Math.round((value - 1200) / 1200 * 100, -2);

        text1.style.transform = 'translate(0,-' + value3 + "vh)";
        text2.style.transform = 'translate(0,-' + value3 + "vh)";
        text2.style.opacity = (value3 * 2) / 100;
        title2_span1.style.fontSize = 30 + value3 * 1.15 + "px";


    }
    if (value > 2400 & value < 3600) {

        let value3 = Math.round((value - 2400) / 1200 * 100, -2);
        let color = (value - 2400) / 255 * 100;
        text3.style.transform = 'translate(0,-' + value3 + "vh)";
        title3_span1.style.fontSize = 30 + value3 + "px";
        title3_span1.style.color = "rgba(" + color + "," + (255 - color) + "," + (255 - color) + ", 1)";
        text3.style.opacity = (value3 / 100 * 1.03);
        earth.style.transform = 'translate(' + 0 + "vw," + 0 + "vh)";
        main1.style.transform = 'translate(' + 0 + "vw,0vh)"
        main2.style.transform = 'translate(' + 0 + "vw,0vh)";
    }
    if (value > 3600 & value < 6000) {

        let value3 = Math.round((value - 3600) / 1200 * 100, -2);
        // let value3 = (value - 3600) / 1200 * 100;
        // earth.style.transform = 'translate(' + value3 + "vw," + 0 + "vh)";

        earth.style.transform = 'translate(' + 100 + "vw," + 0 + "vh)";
        main1.style.transform = 'translate(' + 100 + "vw,0vh)"
        main2.style.transform = 'translate(' + 100 + "vw,0vh)";

    }
    if (value > 6000 & value < 6500) {
        main2.style.transform = 'translate(' + 0 + "vw,0vh)";
        $(".m3-1").css("transform", "rotate(" + 0 + "deg)");

    }
    if (value > 6500 & value < 7000) {

        let value3 = Math.round((value - 6500) / 500 * 100, -2);
        main2.style.transform = 'translate(' + 0 + "vw,0vh)";
        $(".m3-1").css("transform", "rotate(" + value3 * -1.8 + "deg)");
        $("#main3_title .row div:nth-child(4)").css("display", "flex");

        // $("#main3_title .row div:nth-child(2)").css("opacity", value3 * 0.05);
        //    $("#main3_title .row div:nth-child(3)").css("transform", "translate(" + -1 * value3 + "vw)");
        $("#main3_title .row div:nth-child(3) div:nth-child(1)").removeClass("main3_h50")
        $("#main3_title .row div:nth-child(3) div:nth-child(2)").removeClass("main3_h100")

    }
    if (value > 7000 & value < 7500) {

        let value3 = Math.round((value - 7000) / 500 * 100, -2);
        $("#main3_title .row div:nth-child(4)").css("display", "none");
        $("#main3_title .row div:nth-child(3) div:nth-child(1)").css("z-index", "6");
        $("#main3_title .row div:nth-child(3) div:nth-child(2)").css("z-index", "5");

        $("#main3_title .row div:nth-child(3) div:nth-child(1)").addClass("main3_h50")
        $("#main3_title .row div:nth-child(3) div:nth-child(2)").addClass("main3_h100")

        $("#main3_title .row .w-100:nth-child(2)").css("opacity", "0");
        $("#main3_title .row .w-100:nth-child(6)").css("opacity", "0");

        //       $("#main3_title .row div:nth-child(2)").css("opacity", value3 * 0.05);

    }
    if (value > 7500 & value < 8000) {

        $("#main3_title .row div:nth-child(3) div:nth-child(1)").css("z-index", "8");

        $("#main3_title .row div:nth-child(2)").css("opacity", "1");
        $("#main3_title .row div:nth-child(2)").css("z-index", "7");
        $("#main3_title .row .w-100:nth-child(1)").css("opacity", "0");


    }
    if (value > 8000 & value < 8500) {
        $("#main3_title .row div:nth-child(3) div:nth-child(1)").css("z-index", "6");

        $("#main3_title .row div:nth-child(3) div:nth-child(1)").removeClass("main3_h50")
        $("#main3_title .row div:nth-child(3) div:nth-child(2)").removeClass("main3_h100")
        $("#main3_title .row .w-100:nth-child(1)").css("opacity", "1");
        $("#main3_title .w-100:nth-child(1)").css("z-index", "7");
        $("#main3_title .row div:nth-child(2)").css("opacity", "0");
        $("#main3_title .w-100:nth-child(6) img").removeClass("main3_img_rotate ");
        $("#main3_title .w-100:nth-child(6)").css("opacity", "0")
        $("#main3_title .w-100:nth-child(1)").css("transform", "translate(0vw,0)");


    }
    if (value > 8500 & value < 9000) {
        $("#main3_title .row .w-100:nth-child(1)").css("opacity", "1");
        $("#main3_title .w-100:nth-child(1)").css("z-index", "7");
        $("#main3_title .row .w-100:nth-child(1)").css("opacity", "1");
        $("#main3_title .w-100:nth-child(1)").css("transform", "translate(-100vw,0)");
        $("#main3_title .w-100:nth-child(6)").css("opacity", "1");

        $("#main3_title .w-100:nth-child(6)").css("z-index", "99")
        $("#main3_title .w-100:nth-child(6) img").addClass("main3_img_rotate ");
        $("#main3_title .w-100:nth-child(6) img").removeClass("main3_img_rotate ");


    }

    if (value > 9000 & value < 9500) {

        $("#main3_title .w-100:nth-child(6) img").addClass("main3_img_rotate ");
        $("#main3_title .w-100:nth-child(7)").css("transform", "translate(-100vw,0)");

        $("#main3_title .w-100:nth-child(6)").css("transform", "translate(0vw,0)");

    }
    if (value > 9500 & value < 10000) {

        $("#main3_title .w-100:nth-child(6)").css("transform", "translate(-100vw,0)");
        $("#main3_title .w-100:nth-child(7)").css("transform", "translate(0vw,0)");
        $("#main3_title .w-100:nth-child(7)").css("opacity", "1");
        $("#main3_title .w-100:nth-child(7) ul li:nth-child(2) span").css("margin-right", "0px");
        $("#main3_title .w-100:nth-child(7) ul li:nth-child(4) span").css("opacity", "1");
        $("#main3_title .w-100:nth-child(7)  section").css("height", "0%");

    }
    if (value > 10000 & value < 10500) {

        $("#main3_title .w-100:nth-child(7) ul li:nth-child(2) span").css("margin-right", "80px");
        $("#main3_title .w-100:nth-child(7) ul li:nth-child(4) span").css("opacity", "0.5");
        $("#main3_title .w-100:nth-child(7) section").css("height", "50%");
        $("#main3_title .w-100:nth-child(7)").css("transform", "translateY(0vh)");
        $("#main3_title .w-100:nth-child(8)").css("opacity", "0");
        $("#main3_title .w-100:nth-child(8) ").css("z-index", "1");

    }
    if (value > 10500 & value < 11000) {
        $("#main3_title .w-100:nth-child(8)").css("opacity", "1");


        $("#main3_title .w-100:nth-child(7)").css("transform", "translateY(-100vh)");
        $("#main3_title .w-100:nth-child(8)").css("transform", "translateY(0vh)");
        $("#main3_title .w-100:nth-child(8) ").css("z-index", "9999");


    }
})
