window.onload = function () {
    function $(id) {
        return document.getElementById(id);
    }

    var pic_top = 0;      //控制图片的top
    var timer = null;     //定时器


    //up onmouseover
    //打开计数器 每秒修改top属性 图片顶部时停止
    $('picUp').onmouseover = function () {
        //打开定时器 每秒修改top属性 图片顶部停止
        clearInterval(timer);
        timer = setInterval(function () {
            pic_top--;
            pic_top >= -1070 ? $("pic").style.top = pic_top + "px" : clearInterval(timer);
        }, 1)
    }

    //down onmouseover
    //打开计时器 每秒修改top属性 图片底部时停止
    $('picDown').onmouseover = function () {
        //打开定时器 每秒修改top属性 图片顶部停止
        clearInterval(timer);
        timer = setInterval(function () {
            pic_top++;
            pic_top < 0 ? $('pic').style.top = pic_top + "px" : clearInterval(timer);
        }, 1)
    }


    //onmouseout 计时器停止
    $("xiaomi").onmouseout = function () {
        clearInterval(timer);
    }
}