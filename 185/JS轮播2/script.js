window.onload =function(){
   var scroll =document.getElementById('scroll');
   //取自元素;
   var ul = scroll.children[0];
   //控制左侧值
   var li_left =0;
   //计时器
   var timer =null;
   //用于控制动left的变量
   var leader =0;
   var target =0;

   //计时
    timer = setInterval(autoPlay,10);
    
    function autoPlay(){
       target--;
       target <= -1200? target =0: target;
       leader = leader +(target - leader)/10;
       console.log(leader);
       ul.style.left =leader+"px";
    }

    //鼠标悬停事件
    scroll.onmouseover =function(){
        clearInterval(timer);
    }
    scroll.onmouseover =function(){
       timer = setinterval(autopaly, 10);
    }
}