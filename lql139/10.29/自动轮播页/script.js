
var scroll = document.getElementById('scroll');
var timer = null;
var img_left = 0;
var leader = 0;
var scroll_uls = document.getElementById('scroll_uls');
    timer = setInterval(autoplay, 20);
    function autoplay() {
        img_left--;
        img_left <= -600 ? img_left = 0 : img_left;
        leader = leader + (img_left - leader) / 10;
        scroll_uls.style.left = leader + 'px';
    }

    scroll.onmouseover = function () {
        clearInterval(timer);
    }

    scroll.onmouseout = function () {
        timer = setInterval(autoplay, 20);
        /* timer = setInterval(function() {
             img_left--;
             img_left >= -600 ? scroll_uls.style.left=img_left+'px':clearInterval(timer);
         }, 5);*/
    }