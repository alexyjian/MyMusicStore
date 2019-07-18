//页面加载完成时启动
window.onload = function () {
    //获取ul标签
    var scroll_lis = document.getElementById('ul').getElementsByTagName('li');
    //用于控制left的变量
    var left = 0;
    //用于判断li的编号
    var li = 0;
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
        scroll_lis[li].style.left = left + 'px';
        // //判断过度方向
        // if (s == 0) {
        //     left--;
        // }
        // else {
        //     left++;
        // }
        
        if (li < scroll_lis.length) {
            li++;
        }
        console.log(li);

    }
}