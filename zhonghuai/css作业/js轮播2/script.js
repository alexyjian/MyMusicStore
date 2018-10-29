window.onload = function () {
    var scroll = document.getElementById('scroll');
    //取子元素
    var ul = scroll.children[0];

    //计时器
    var timer = null;

    //用于控制动left的变量
    var leader = 0;
    var target = 0;
    //计时器
    timer = setInterval(autoplay, 10);

    function autoplay() {
        target--;
        target <= -1200 ? target = 0 : target;
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + "px";
    }
    //鼠标悬停事件
   

}