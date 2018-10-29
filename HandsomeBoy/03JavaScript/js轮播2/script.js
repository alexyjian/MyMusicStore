window.onload = function () {

    function $(id) {
        return document.getElementById(id);
    }
    var pic_right = 0;
    var pic_left = 0; //控制图片left
    var timer = null; //定时器
    var leader = 0;

    function autoplay() {
        pic_left--;
        pic_left <=-610?pic_left = 0 : pic_left;
        leader = leader +(pic_left - leader) / 10;
        $('pic').style.left = leader +"px";

        // 我自己写的   到尾没有过渡效果
        // pic_left >= -610 ? $('pic').style.left = pic_left + "px" : pic_left =leader;
        console.log(pic_left);
    }
    $("box").onmouseout = function () {
        timer = setInterval(autoplay, 10);

    }
    $("box").onmouseover = function () {
        clearInterval(timer);
    }
    timer = setInterval(autoplay, 10);
}