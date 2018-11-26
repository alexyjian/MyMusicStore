//页面加载完成时
window.onload = function () {
    var scroll = document.getElementById('scroll');

    //取子元素；
    var ul = scroll.children[0];

    //计时器
    var timer = null;

    //用于控制动left的变量 
    var leader = 0;
    var target = 0;
    
    // 启动定时器
    timer = setInterval(autoPaly, 20);

    //鼠标悬停事件
    scroll.onmouseover = function () {
        clearInterval(timer);
    }
    scroll.onmouseout = function () {
        timer = setInterval(autoPaly, 20);
    }

    function autoPaly() {
        target--;
        target <= -1200 ? target = 0 : target;
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + 'px';
    }

}