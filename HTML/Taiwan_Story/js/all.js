let data = 1949
$(document).ready(function () {
    $('.your-class').slick({
    });
    data = 1949
    roll()
});
let dom_data = [
    "#y1949", "#y1950", "#y1958", "#y1959",
    "#y1960", "#y1962", "#y1965", "#y1966", "#y1968",
    "#y1970", "#y1971", "#y1972", "#y1973", "#y1975", "#y1978", "#y1979",
    "#y1980", "#y1986", "#y1987", "#y1988", "#y1989",
    "#y1990", "#y1991", "#y1992", "#y1994", "#y1995", "#y1996", "#y1998", "#y1999",
    "#y2000", "#y2002", "#y2003", "#y2004", "#y2006", "#y2008",
    "#y2010", "#y2012", "#y2013", "#y2014", "#y2015", "#y2016", "#y2017", "#y2018", "#y2019",
    "#y2020", "#y2021", "#y2022", "#y2023",
    "#y2024"
]

let dom_height = []
for (var i = 0; i < dom_data.length; i++) {
    dom_height.push($(dom_data[i]).offset().top + $(dom_data[i]).height())
}
document.onscroll = () => {
    let height_ = document.documentElement.scrollTop || document.body.scrollTop
    for (var i = 0; i <= dom_height.length; i++) {
        if (height_ <= dom_height[i] - 50) {
            data = dom_data[i].substring(2, 6)
            roll()
            break;
        }
    }
}


var d2 = document.querySelector('.t2div')
$('.t2div').css("height", $('.t1div').height())


// 下方 滾動事件 
var ml = '';
var boxLi = document.querySelector('.box ul')
//放元素默认9个数字框
for (var g = 0; g < 4; g++) {
    ml += '<li><span>0123456789</span></li>'
}
boxLi.innerHTML = ml;

function roll() {
    var items = document.querySelectorAll('.box ul li span')
    for (var k = 0; k < 4; k++) {
        item = items[k]
        item.style.transform = `translate(-50%,-${data[k] + '0%'})`
    }
}

// 上方 滾動事件


// 下方時間倒數 


//創造變數，設定日期
const countDownTime = new Date(`January 13 2024 16:00:00`);
remainTime()
function remainTime() {
    const timeNow = new Date();
    const remain = countDownTime - timeNow;//得到的是毫秒
    if (remain <= 0) {
        document.getElementById('number_1').innerHTML = '';
        $('#number_2').text(('感謝參與投票'))
    } else {
        const sec = Math.floor(remain / 1000) % 60;
        const min = Math.floor(remain / 1000 / 60) % 60;
        const hour = Math.floor(remain / 1000 / 60 / 60) % 24;
        const day = Math.floor(remain / 1000 / 60 / 60 / 24);
        $('#days').html((day));
        $('#hours').text((hour));
        $('#minutes').text((min));
        $('#seconds').text((sec));
    }
}
const timeinterval = setInterval(function () {
    remainTime()
}, 1000);
// 上方時間倒數 

$("#y1973_10m_1 .y_w_c div").hover(function () {
    switch (this.id) {
        case "a1973_1": $(this).text("北起基隆，南至高雄，中以支線(現國道二號)連接桃園國際機場，全長373公里。1978年10月全線正式通車。")
            break;
        case "a1973_2": $(this).text("台灣對外貿易發達，為解決客貨運量的增加，因此在1973年起計畫電氣化工程，施行範圍以西部幹線縱貫線全線。")
            break;
        case "a1973_3": $(this).text("於1969年正式選定中華民國空軍桃園基地西側埤塘區域空地，以興建新的大型國際機場，並成為十大建設之一。")
            break;
        case "a1973_4": $(this).text("台灣進出口長期仰賴高雄港與基隆港兩港，兩港無法負荷，在淡水、台中、蘇澳選址後，決定於台中市梧棲區為新港港址")
            break;
        case "a1973_5": $(this).text("北部主要港口基隆港運量壅塞更加嚴峻，政府考量除台中港外仍須其他港口幫助其紓解交通量，於1972年核定將此港設定為基隆港的輔助港。")
            break;
        case "a1973_6": $(this).text("使東部鐵路幹線與西部接軌，將花蓮車站移至花蓮市豐川現址，興建花蓮車站至宜蘭線南聖湖車站之單線新線。")
            break;
        case "a1973_7": $(this).text("解除過去因鋼源不一，影響產品精度的缺點，遂決定興建一貫作業煉鋼場，位於高雄臨海第四工業區，濱臨高雄港第二港口。")
            break;
        case "a1973_8": $(this).text("為台灣最大的造船公司，位於高雄，提供商船、海軍艦艇等建造、大型鋼和機械製造、海上工程製造、組裝等。")
            break;
        case "a1973_9": $(this).text("今台灣中油股份有限公司，在高雄開發兩處石化工業區，中油公司煉油總廠的興建對於台灣的塑膠、合成橡膠、合成纖維及化學品工業之發展。")
            break;
        case "a1973_10": $(this).text("第一核能發電廠共有兩部機組，其裝置容量各為63.6萬瓩。核能一廠列入十大建設計畫優先興工，兩部機組分別於1977年與1978年完工。")
            break;
    }
}, function () {
    switch (this.id) {
        case "a1973_1": $(this).text("國道一號")
            break;
        case "a1973_2": $(this).text("鐵路電氣化")
            break;
        case "a1973_3": $(this).text("桃園國際機場")
            break;
        case "a1973_4": $(this).text("台中港")
            break;
        case "a1973_5": $(this).text("蘇澳港")
            break;
        case "a1973_6": $(this).text("北迴鐵路")
            break;
        case "a1973_7": $(this).text("大煉鋼廠")
            break;
        case "a1973_8": $(this).text("台灣造船")
            break;
        case "a1973_9": $(this).text("石油化學工業區")
            break;
        case "a1973_10": $(this).text("核能發電廠")
            break;
    }
});
