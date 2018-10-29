window.onload = function () {
    //通用函数 少写document.getElementById(id);
    function $(id) {
        return document.getElementById(id);
    }
    var pic_top = 0;
    var timer = null;
    $("picup").mouseover = function () {
        clearInterval(timer);//停止计时器
        timer = setInterval(function () {//setInterval打开计时器
            pic_top--;
            pic_top >= -1070 ? $("pic").style.top = pic_top + 'px' : clearInterval(timer);
        }, 20);
    };

    $("picup").mouseover = function () {
        clearInterval(timer);//停止计时器
        timer = setInterval(function () {//setInterval打开计时器
            pic_top++;
            pic_top < 0 ? $("pic").style.top = pic_top + 'px' : clearInterval(timer);
        }, 20);
    };

    $("xiaomi").onmouseout = function () {
        clearInterval(timer);
    }
}
