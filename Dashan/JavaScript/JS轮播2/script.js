//页面加载时
window.onload = function () {
    var scri = document.getElementById('scri');
    //取子元素
    var ul = scri.children[0];
    //计时器 初始值
    var timer = null;
    //用于控制 left 的变量 初始值
    var leader = 0;
    var target = 0;

    //计时器 
    timer = setInterval(autoPlay, 10);
    function autoPlay() {
        target--;

        target <= -1200 ? target = 0 : target;
        leader = leader + (target - leader) / 10;

        ul.style.right= leader + "px";
    }
    //鼠标悬停事件
    scri.onmouseover = function () {
        clearInterval(timer);

    }
    scri.onmouseout = function () {
        timer = setInterval(autoPlay, 10);
    }
}