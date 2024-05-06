Vue.createApp({
    data: function () {
        return {
            times: [
                {
                    number: "721,472",
                    year: "2009",
                    t101_h: "16.5",
                },
                {
                    number: "769,164",
                    year: "2010",
                    t101_h: "17.5",
                },
                {
                    number: "811,199",
                    year: "2011",
                    t101_h: "18.5",
                },
                {
                    number: "834,541",
                    year: "2012",
                    t101_h: "19",
                },
                {
                    number: "795,213",
                    year: "2013",
                    t101_h: "18",
                },
                {
                    number: "720,373",
                    year: "2014",
                    t101_h: "16.5",
                },


            ],
            times2: [
                {
                    number: "609,706",
                    year: "2015",
                    t101_h: "14",
                },
                {
                    number: "575,932",
                    year: "2016",
                    t101_h: "13",
                },
                {
                    number: "551,332",
                    year: "2017",
                    t101_h: "12.5",
                },
                {
                    number: "594,992",
                    year: "2018",
                    t101_h: "13.5",
                },
                {
                    number: "498,045",
                    year: "2019",
                    t101_h: "11.5",
                },
                {
                    number: "529,567",
                    year: "2020",
                    t101_h: "12",
                },
            ],
        }
    },
    methods: {

    },
    mounted() {

    },
}).mount("#contain1_index")
Vue.createApp({
    data: function () {
        return {
            nav_li: [
                {
                    name: "首頁",
                    URL: "index.html",
                },
                {
                    name: "源頭",
                    URL: "page1.html",
                },
                {
                    name: "加工",
                    URL: "page2.html",
                },
                {
                    name: "餐廳",
                    URL: "page3.html",
                },
                {
                    name: "廚餘",
                    URL: "page4.html",
                },
                {
                    name: "基因改造",
                    URL: "page5.html",
                },
                {
                    name: "關於我們",
                    URL: "page6.html",
                },
            ],
        }
    },
    methods: {

    },
    mounted() {

    },
}).mount("#nav")
Vue.createApp({
    data: function () {
        return {
            page1_1: [
                {
                    title: "虱目魚",
                    text: "冬季天氣冷，加上強冷鋒來襲，讓水溫更快速流失，雲嘉南沿海養殖漁民特別擔心虱目魚的「安危」，展開防寒大作戰，包括增設擋風牆、抽取水溫較高的地下水注入魚塭，但溫度還是太低了，虱目魚還是冷得受不了，大量死亡。",
                    src: "img/page1/圖片4.jpg",
                    href: "https://www.ftvnews.com.tw/news/detail/2021101C11M1",
                },
                {
                    title: "蔬菜與瓜果類",
                    text: "因為寒害的影響，蔬菜和瓜果，在低溫期容易出現抽苔現象，抽苔現象是指花芽分化後，從菜心中開始長出花莖結構的過程，在一般情況下植物會依其生命週期開花、結果，但遇到惡劣的氣候環境，植物就會提早抽苔，這樣會使得產品的品質降低，就有可能被農夫丟棄。",
                    src: "img/page1/圖片5.jpg",
                    href: "https://fae.coa.gov.tw/theme_data.php?theme=kids_edu_topics&id=37",
                },
                {
                    title: "果樹",
                    text: "果樹方面，結果期的蓮霧、棗子、草莓和開花期的芒果、荔枝，容易發生落果落花、著果不良的情形，結果後的品質也會不佳。對嫁接後的高接梨，會使得癒合組織不形成或形成不良，使得接穗無法成活。已經結成的果實，則會導致裂果。",
                    src: "img/page1/圖片6.jpg",
                    href: "https://fae.coa.gov.tw/theme_data.php?theme=kids_edu_topics&id=37",
                },
                {
                    title: "水稻",
                    text: "在台灣，水稻受寒害影響有兩個時期，第一個時期為中南部地區水稻的生育初期，強烈冷氣團入侵在一、二月間，秧苗較容易遭受寒害影響，第二個時期為北部地區水稻的抽穗期，如果遇到冷氣團，水稻則會在九月下旬或十月上旬開始抽穗，如果受到冷氣團的影響較為嚴重的話，則會導致水稻的結實率降低。",
                    src: "img/page1/圖片7.jpg",
                    href: "https://fae.coa.gov.tw/theme_data.php?theme=kids_edu_topics&id=37",
                },

            ],
            page4_1: [
                {
                    section_title: "全球食物浪費翻倍 聯合國報告：每年被丟棄糧食逼近10億!",
                    src: "img/page1/圖片7.jpg",
                    img_text: "若食物浪費是一個國家，其碳排放量將僅次於美國和中國，排世界第三  ",
                    article_title: "報告指出：全球每年浪費近10億噸食物，<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;糧食浪費造成10％碳排",
                    article_text: "根據聯合國環境( UNEP )發表的糧食浪費指數報告，全球每年浪費近10億噸食物，約為過去最佳估計值的兩倍。<br><br>衛報報導，這份報告是截至目前最全面性的報告。其中指出，全球光是家庭食物浪費就高達每人每年74公斤。<br><br>數十億飢餓或無力負擔健康飲食的人口，因食物浪費而無法溫飽，環境也受到影響。糧食浪費和損失造成約10％的排放量，助長氣候危機，加速全球暖化。",
                },
                {
                    section_title: "台灣廚餘現況",
                    src: "img/page1/圖片8.jpg",
                    img_text: "2020南投縣草屯掩埋場堆置大量廢棄物",
                    article_title: "2020全台廚餘產生量高 焚化量能減、掩埋量增!",
                    article_text: "根據聯合國環境( UNEP )發表的糧食浪費指數報告，全球每年浪費近10億噸食物，約為過去最佳估計值的兩倍。衛報報導，這份報告是截至目前最全面性的報告。其中指出，全球光是家庭食物浪費就高達每人每年74公斤。數十億飢餓或無力負擔健康飲食的人口，因食物浪費而無法溫飽，環境也受到影響。糧食浪費和損失造成約10％的排放量，助長氣候危機，加速全球暖化。",
                },
                {
                    src: "img/page1/圖片9.png",
                    img_text: "自2018年有統計以來，未處理的暫存廢棄物量連年上升，而2021年衛生掩埋量也呈現上漲趨勢。 ",
                    article_title: "2021年全國廢棄量突破千萬噸 暫存垃圾連年飆升",
                    article_text: "根據聯合國環境( UNEP )發表的糧食浪費指數報告，全球每年浪費近10億噸食物，約為過去最佳估計值的兩倍。衛報報導，這份報告是截至目前最全面性的報告。其中指出，全球光是家庭食物浪費就高達每人每年74公斤。數十億飢餓或無力負擔健康飲食的人口，因食物浪費而無法溫飽，環境也受到影響。糧食浪費和損失造成約10％的排放量，助長氣候危機，加速全球暖化。",
                },

            ],

        }
    },
    methods: {

    },
    mounted() {

    },
}).mount("#main_data")

function getscroll() {
    var scrollY = document.documentElement.scrollTop || document.body.scrollTop
    scrollY += window.innerHeight
    docHeight = document.body.scrollHeight
    scrollnum = Math.round(scrollY / docHeight * 10000) / 100
    console.log(docHeight);
    $(".navscroll div").css("width", scrollnum + "%");
};

// $(window).load(function () { // 確認整個頁面讀取完畢再將這三個div隱藏起來
//     $("#status").delay(2000).fadeOut(1000); //delay --> 延遲幾秒才fadeOut
//     $("#preloader").delay(3000).fadeOut(1000);
// })


var icon = document.getElementById("icon");
var logo = document.getElementById("logo");
var iconcontain = document.getElementById("iconcontain");
icon.onclick = function () {
    document.body.classList.toggle("dark");
    if (document.body.classList.contains("dark")) {
        $(this).addClass('fa-sun');
        logo.src = "img/logo2.ico";


        iconcontain.textContent = "白天模式";
    } else {
        $(this).removeClass('fa-sun');
        $(this).addClass('fa-moon');


        icon.src = "img/moon.svg";
        logo.src = "img/icon.ico";

        iconcontain.textContent = "夜晚模式";
    }
};
$(document).ready(function () {
    $("#icon").hover(function () {
        $("#icon").css("color", "#f9ba48");
    }, function () {
        $("#icon").css("color", "var(--secondary-color)");
    });
    $("#hamburger").toggle(
        function () {
            $('html').css("overflow", "hidden");
        },
        function () {
            $('html').css("overflow", "scroll");

        },
    );
    $(".slides").hover(function () {
        $(".scr").removeClass("scr");
    }, function () {
        $(".slide").addClass("scr");
    });

});




const navMenu = document.querySelector(".nav_toggle");
const hamburger = document.querySelector("#hamburger");
const html_toggle = document.querySelector("html");

hamburger.addEventListener('click', function () {
    this.classList.toggle('ham_active');
    navMenu.classList.toggle('nav_active');

});
document.querySelectorAll(".nav-link").forEach(n => n.
    addEventListener("click", () => {
        hamburger.classList.remove('nav-active');

    }));

