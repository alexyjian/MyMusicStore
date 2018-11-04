window.onload=function(){
    var scroll = document.getElementById('scroll');
    //取子元素
    var ul = scroll.children[0];
    //计时器
    var timer =null;
    //用于控制动left的变量
    var leader = 0;
    var terget=0;

    //计时器
    timer = setInterval(autoPlay,10)

    function autoPlay(){
        terget--;
        terget <= -600?terget = location.reload():terget;
        // terget <= -900?terget = 0:terget;
        leader = leader+(terget-leader)/10;
        ul.style.left=leader+"px";
    };

    //鼠标悬停事件
    scroll.onmouseover=function(){
        clearInterval(timer);
    }  
    scroll.onmouseout =function(){
        timer=setInterval(autoPlay,10)     
    }
}