$(function() {

    $("#goTop").click(function() {

        $("html,body").animate({
            scrollTop: 0
        }, 800);

        //$("html,body").animate({scrollTop:0},900,"easeOutBounce");

        return false;

    });

    $(window).scroll(function() {
        if ($(this).scrollTop() > 150) {
            $('#gotop').fadeIn("fast");
        } else {
            $('#gotop').stop().fadeOut("fast");
        }
    });
});
$(window).scroll(function() {
    if ($(this).scrollTop() > 4100) {
        $('#handna').fadeOut("fast");
    } else if ($(this).scrollTop() > 791) {
        $('#handna').stop().fadeIn("fast");
    } else {
        $('#handna').stop().fadeOut("fast");
    }
});

$(window).scroll(function() {
    if ($(this).scrollTop() > 655) {
        $('#nav').fadeIn("fast");
    } else {
        $('#nav').stop().fadeOut("fast");
    }
});;
$(function() {
    //control display of goTop button and motion
    $("#go1").click(function() {
        jQuery("html,body").animate({
            scrollTop: 120
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#go2").click(function() {
        jQuery("html,body").animate({
            scrollTop: 850
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#go3").click(function() {
        jQuery("html,body").animate({
            scrollTop: 2750
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#go4").click(function() {
        jQuery("html,body").animate({
            scrollTop: 5050
        }, 800);
    });
}, )

//以下領養頁
$(function() {
    //control display of goTop button and motion
    $("#s1").click(function() {
        jQuery("html,body").animate({
            scrollTop: 1030
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#s2").click(function() {
        jQuery("html,body").animate({
            scrollTop: 1500
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#s3").click(function() {
        jQuery("html,body").animate({
            scrollTop: 2050
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#s4").click(function() {
        jQuery("html,body").animate({
            scrollTop: 2550
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#s5").click(function() {
        jQuery("html,body").animate({
            scrollTop: 3100
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#s6").click(function() {
        jQuery("html,body").animate({
            scrollTop: 3650
        }, 800);
    });
}, )

//page1
$(function() {
    //control display of goTop button and motion
    $("#p1g1").click(function() {
        jQuery("html,body").animate({
            scrollTop: 100
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#p1g2").click(function() {
        jQuery("html,body").animate({
            scrollTop: 1100
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#p1g3").click(function() {
        jQuery("html,body").animate({
            scrollTop: 1700
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#p1g4").click(function() {
        jQuery("html,body").animate({
            scrollTop: 2100
        }, 800);
    });
}, )

//page2
$(function() {
    //control display of goTop button and motion
    $("#p2g1").click(function() {
        jQuery("html,body").animate({
            scrollTop: 80
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#p2g2").click(function() {
        jQuery("html,body").animate({
            scrollTop: 2365
        }, 800);
    });
}, )

$(function() {
    //control display of goTop button and motion
    $("#p2g3").click(function() {
        jQuery("html,body").animate({
            scrollTop: 3535
        }, 800);
    });
}, )

$(function() {
        //control display of goTop button and motion
        $("#p2g4").click(function() {
            jQuery("html,body").animate({
                scrollTop: 5300
            }, 800);
        });
    }, )
    //page3
$(function() {
    //control display of goTop button and motion
    $("#p3g1").click(function() {
        jQuery("html,body").animate({
            scrollTop: 50
        }, 800);
    });
}, )
$(function() {
        //control display of goTop button and motion
        $("#p3g2").click(function() {
            jQuery("html,body").animate({
                scrollTop: 6660
            }, 800);
        });
    }, )
    //page4
$(function() {
    //control display of goTop button and motion
    $("#p4g1").click(function() {
        jQuery("html,body").animate({
            scrollTop: 50
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#p4g2").click(function() {
        jQuery("html,body").animate({
            scrollTop: 790
        }, 800);
    });
}, )
$(function() {
    //control display of goTop button and motion
    $("#p4g3").click(function() {
        jQuery("html,body").animate({
            scrollTop: 4780
        }, 800);
    });
}, )