 function $(id){
   return getElementById(id);
 }
 window.onload = function(){
     var box = document.getElementById("box");
     //子元素
     var ul = document.getElementById("ad_ul");
     var ol = document.getElementById("ad_ol").getElementsByTagName("li");

     var timer = null;
     var index = 0;
     var target = 0;
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
         if (index >= ol.length){ // length 返回或设置窗口中的框架数量
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
         target = -curIndex * 500;
         index = curIndex;
     }

     //图片切换效果
     setInterval(function(){
        if (target >= 0){
            target = 0;
        }
        else if (target <= -2000){
            target = -2000;
        }
        
         leader = leader + (target - leader) / 10;
         ul.style.left = leader + "px";
     },20)

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
        $("arrow").style.display = "block";
    }
    //鼠标离开 播放下一张
    box.onmouseout = function(){
        timer = setInterval(autoPlay,2000);
        $("arrow").style.display = "none";
    }
    function $(id){
        return document.getElementById(id);
    }

        //点两只左箭头，left +500  right -500
        $('left').onclick = function (){
            target += 500;
            // 求出当前索引 
            index = -target /500;
            //把当前索引传到函数里面去
         
             if(index<=0)
             {
                 index =0;
             }
            changeImg(index);
        }
        $('right').onclick = function (){
            target -= 500; 
              // 求出当前索引 
            index = -target /500;
            if(index>=ol.length)
            {
                index =ol.length-1;
            }
            //把当前索引传到函数里面去
            changeImg(index);
           
        }

 }