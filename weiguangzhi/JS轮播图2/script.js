window.onload = function () {
    var scroll=document.getElementById('scroll');
    //取子元素
    var ul=scroll.children[0];
    var li_left=0;//控制左侧值
    var timer = null;  //定时器
    // 用于控制动画left的变量
    var leader=0;
    var target=0;
 
    // 计时器
    timer = setInterval(autoplay,10);
    

    function autoplay(){
        target--;

        target <= -4096 ? target = 0 : target;
        leader = leader + (target - leader) / 10;
        ul.style.left = leader + "px";
    }

    //鼠标悬停事件
    scroll.onmouseover = function(){
        clearInterval(timer);
    }
    scroll.onmouseover = function(){
        timer = setInterval(autoplay,10);
    }
   
    
}