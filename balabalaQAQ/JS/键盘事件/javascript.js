//为网页加载键盘事件
/* window.onload = function () {
    img = document.getElementById('img')
    img.style.left = 0;
    img.style.top = 0;
    document.body.onkeydown = function (evt) {
        var e = evt ? evt : window.event;
        switch (e.keyCode) {
            //left 37
            case 37:
                img.style.left = (parseInt(img.style.left) - 3) + 'px';
                break;
            //top  38
            case 38:
                img.style.top = (parseInt(img.style.top) - 3) + 'px';
                break;
            case 39:
                //right 39
                img.style.left = (parseInt(img.style.left) + 3) + 'px';
                break;
            //bottom 40
            case 40:
                img.style.top = (parseInt(img.style.top) + 3) + 'px';
                break;
        }
    }
}
 */
window.onload = function () {
    document.body.onkeydown = function (evt) {
        //定义小球的步长
        var step = 10;
        //获取球台和小球的元素;
        var box = document.getElementById('box');
        var ball = document.getElementById('img');
        //获取小球相对于球台div左侧和顶部的距离
        var left = ball.offsetLeft;
        var top = ball.offsetTop;

        //获取球桌的高和宽
        var box_width = box.offsetWidth;
        var box_height = box.offsetHeight;

        //小球的高和宽
        var ball_width = ball.width;
        var ball_height = ball.height;

        //小球距离球桌左侧和顶部的最大距离
        var x_max = box_width - ball_width - step;
        var y_max = box_height - ball_height - step;

        //创建键盘事件的对象
        var e = evt ? evt : window.event;
        //左键37
        if (e.keyCode == 37 && (left-10)> step) {
            ball.style.left =left -step+'px';
        }
        //右键39
        if (e.keyCode == 39 && left <= (x_max-20)) {
            ball.style.left =left +step+'px';
        }
        //上键38
        if (e.keyCode == 38 && (top-10)> step) {
            ball.style.top =top -step+'px';
        }
        //下键40
        if (e.keyCode == 40 && top <= (y_max-20)) {
            ball.style.top =top +step+'px';
        }
    }
}