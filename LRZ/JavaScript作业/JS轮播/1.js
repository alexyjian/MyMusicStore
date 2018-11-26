window.onload = function () {
    function $(id) {
        return document.getElementById(id);
    }

    var pic_top = 0;
    var timer = null;

    $("picUp").onmouseover = function () {
        clearInterval(timer);
        timer = setInterval(function () {
            pic_top--;
            pic_top >= -1070 ? $('pic').style.top = pic_top + "px" : clearInterval(timer);
        }, 20);
    }

    $("picDown").onmouseover = function () {
        clearInterval(timer);
        timer = setInterval(function () {
            pic_top++;
            pic_top < 0 ? $('pic').style.top = pic_top + "px" : clearInterval(timer);
        }, 20);
    }

    $("xiaomi").onmouseout = function () {
        clearInterval(timer);
    }
}