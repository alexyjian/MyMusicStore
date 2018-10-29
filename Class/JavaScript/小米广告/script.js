function $(id) {
    return document.getElementById(id);
}

var time = null;
var pic_top = 0;

$("picDown").onmouseover = function() {
    clearInterval(time);
    timer = setInterval(function(){
        pic_top--;
        pic_top >= -1070 ? $("img").style.top = pic_top + "px" :clearInterval(timer);
    },5);
}

$("picUp").onmouseover = function() {
    clearInterval(time);
    timer = setInterval(function(){
        pic_top++;
        pic_top < 0 ? $("img").style.top = pic_top + "px" :clearInterval(timer);
    },5);
}

$("box").onmouseout = function() {
    clearInterval(timer);
    timer = setInterval(function(){
        pic_top++;
        pic_top < 0 ? $("img").style.top = pic_top + "px" :clearInterval(timer);
    },5);
}