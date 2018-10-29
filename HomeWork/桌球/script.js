<<<<<<< HEAD
window.onload = function() {
    document.body.onkeydown = function(evt) {
        var e = evt ? evt : window.event;
        var ball = document.getElementById("img");
        var x = ball.offsetLeft;
        var y = ball.offsetTop;
        //left
        if(e.keyCode == 37) {
            ball.style.left = x - 10 + "px"
        }
        
        //up
        if(e.keyCode == 38){
            ball.style.top = y - 10 + "px"
        }

        //right
        if(e.keyCode == 39){
            ball.style.left = x + 10 + "px"
        }

        //down
        if(e.keyCode == 40) {
            ball.style.top = y + 10 + "px"
=======
window.onload = function () {
    document.body.onkeydown = function (evt) {
        var e = evt ? evt : window.event;
        var step = 10;
        //获取
        var ball = document.getElementById("img");
        var box = document.getElementById("box");
        //获取球的初始位置 (50,50)
        var x = ball.offsetLeft;
        var y = ball.offsetTop;
        //获取球桌的高和款
        var box_height = box.offsetHeight;
        var box_width = box.offsetWidth;
        //获取球的高和宽
        var ball_height = ball.height;
        var ball_width = ball.width;
        //最大宽和高
        var max_width = box_width - ball_width - step;
        var max_height = box_height - ball_height - step;

        //left
        if (e.keyCode == 37 && (x - 10) > 10) {
            ball.style.left = x - step + "px"
        }

        //up
        if (e.keyCode == 38 && (y - 10) > 10) {
            ball.style.top = y - step + "px"
        }

        //right
        if (e.keyCode == 39 && (x + 20) <= max_width) {
            ball.style.left = x + step + "px"
        }

        //down
        if (e.keyCode == 40 && (y + 20) <= max_height) {
            ball.style.top = y + step + "px"
>>>>>>> cfe01bc12d2c43a7119454bc1c2ec0f9af847235
        }
    }
}