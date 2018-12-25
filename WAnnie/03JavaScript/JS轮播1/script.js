window.onload = function(){
    //
    function $(id){
    return document.getElementById(id);
}

var pic_top = 0;  //控制图片的top
var timer = null;  //定时器

//查询 up 元素 定义onmouseover事件时执行的方法
 $("picUP").onmouseover = function(){
    //打开计时器 每秒修改top 属性  图片顶部时停止
    clearInterval(timer);
    timer = setInterval(function(){
        pic_top -- ;
        pic_top >= -1070 ? $('pic').style.top = pic_top + "px":clearInterval(timer);
    },20)
 }

//查询 down 元素  定义onmouseover事件时执行的方法
$("picDown").onmouseover = function(){
    //打开计时器 每秒修改top 属性  图片底部时停止
    clearInterval(timer);
    timer = setInterval(function(){
        pic_top ++ ;
        pic_top < 0 ? $('pic').style.top = pic_top + "px":clearInterval(timer);
    },20)
 }

 //onmouseout 计时器停止
 $("xiaomi").onmouseout = function(){
     clearInterval(timer);
 }
}