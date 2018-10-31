 window.onload = function(){
     var box = document.getElementById("box");
     var ul = document.getElementById("ad_ul");
     var ol = document.getElementById("ad_ol").getElementsByTagName("li");

     var timer = null;
     var index = 0;
     var target =0;
     var leader = 0;

     //若有在等待的定时器，则清掉
     if (timer){
         clearInterval(timer);
         timer = null;
     }
     //自动切换
     timer = setInterval(autoPlay,2000);

     //定义并调用自动播放函数
     function autoPlay (){
         index ++;
         if (index >= ol.length){
             index = 0;
         }
         changeImg(index);
     }

     //定义图片切换函数
     function changeImg(curIndex){
         for (var j = 0; j <ol.length;j++){
             ol[j].className = "";
         }
         //改变当前显示索引
         ol[curIndex].className = "on";
         ul.style.marginTop = -440 *curIndex + "px";
         index = curIndex;
     }


     //遍历所有数字导航实现划过切换对应的图片
     for (var i = 0; i < ol.length;i++){
         //每个li的索引号
         ol[i].id = i;
         ol[i].onmouseover= function(){
            clearInterval(timer);
            changeImg(this.id);
         }
     }

     //鼠标划过停止自动播放
    box.onmouseover = function(){
        clearInterval(timer);
    }
    //鼠标离开 播放下一张
    box.onmouseout = function(){
        timer = setInterval(autoPlay,2000);
    }
 }