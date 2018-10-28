//为页面加载键盘事件
window.onload=function(){
    document.body.onkeyup=function(evt){
        //定义小球的步长
        var step = 10;
        //获取球台和小球的元素
        var box = document.getElementById('box');
        var ball = document.getElementById('ball');
        //获小球相对于球台div左侧和顶部的距离
        //var left = parseInt(ball.style.left);
        //var top = parseInt(ball.style.left);
        //offsetLeft = left + margin
        //offsetTop = left + margin
        var left = ball.offsetLeft;
        var top =ball.offsetTop;
        console.log(left+','+top)
    }
}