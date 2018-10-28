window.onload=function(){
    function$(id)
        return document.getElementById(id);
    }

function $(id){
    return document.getElementById(id);

}

var  pic_top=0;//控制图片的top
var timer=null;//定时器

//查询up元素 定义   onmouseenter  事件时执行的方法
$("picUP").onmouseenter =function(){
    clearInterval(timer);
    timer =setInterval(function(){
        pic_top--;
        pic_top >= -1070 ? $('pic').style.top = pic_top:clearInterval(timer);
    },20);
}

$("picDown").onmouseenter =function(){
    //打开计时器 每秒修改top 属性 图片底部时停止
    clearInterval(timer);
    timer =setInterval(function(){
        pic_top++;
        pic_top < 0 ? $('pic').style.top = pic_top:clearInterval(timer);
    },20);
}

$("XM").onmouseout = function () {
    clearInterval(timer);
}