window.onload = function () {
    document.body.onkeydown = function (evt) {

        var box = document.getElementById('box');
        var ball = document.getElementById('img');

        var step = 10;

        var ball_left = ball.offsetLeft;
        var ball_top = ball.offsetTop;
        var ball_width = ball.offsetWidth;
        var ball_height = ball.offsetHeight;

        var box_width = box.offsetWidth;
        var box_height = box.offsetHeight;

        var x_max = box_width - ball_width - step;
        var y_max = box_height - ball_height - step;

        var e = evt ? evt : window.event;
        //左
        if (e.keyCode == 37 && ball_left >= step) {
            ball.style.left = ball_left - step + 'px';
        }
        //右
        if (e.keyCode == 39 && ball_left <= x_max) {
            ball.style.left = ball_left + step + 'px';
        }
        //上
        if (e.keyCode == 38 && ball_top > step) {
            ball.style.top = ball_top - step + 'px';
        }
        //下
        if (e.keyCode == 40 && ball_top < y_max) {
            ball.style.top = ball_top + step + 'px';
        }
    }
}