//页面加载完成时启动
window.onload = function () {
    //获取ul标签
    var scroll_ul = document.getElementById('ul');
    //用于控制left的变量
    var left = 0;
    //用于改变过度方向
    var s = 0;
    //定义计时器
    var timer = null;
    //启动定时器
    timer = setInterval(aucoke, 10);
    //添加鼠标悬停事件
    var scroll = document.getElementById('scroll');  //获取div
    scroll.onmouseover = function () {
        //清除计时器
        clearInterval(timer);
    }
    scroll.onmouseout = function () {
        //重新启动计时器
        timer = setInterval(aucoke, 10);
    }
    function aucoke() {
        scroll_ul.style.left = left + 'px';
        //判断过度方向
        if (s == 0) {
            left--;
        }
        else {
            left++;
        }
        //判断是否到达最后一张图
        if (left <= -600) {
            s++;
        }
        if (left >= 0) {
            s--;
        }
    }
}