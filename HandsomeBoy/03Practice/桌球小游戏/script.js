window.onload = function () {
    document.body.onkeydown = function (evt) {

        //定义小球的步长
        var step = 10;
        //获取球台和小球的元素
        var box = document.getElementById('box');
        var ball = document.getElementById('img')
        //获取小球相对于球台div左侧和顶部的距离
        var left = ball.offsetLeft;
        var top = ball.offsetTop;
        console.log("球的初始位置：" + left + ',' + top);

        // 获取球桌的高和宽
        var box_width = box.offsetWidth;
        var box_height = box.offsetTop;
        console.log('球桌的高和宽: ' + box_width + ',' + box_height);

        //小球的高和宽
        var ball_width = ball.width;
        var ball_height = ball.height;
        console.log('球的高和宽：' + ball_width + ',' + ball_height);

        // 小球距离桌球左侧和顶部的最大距离
        var x_max = box_width - ball_width - step;
        var y_max = box_height - ball_height - step;
        console.log('x,y最大的距离' + x_max + ',' + y_max);

        //创建键盘事件的对象
        var e = evt ? evt : window.event;


        switch (e.keyCode) {

            //  上
            case 87:
            case 38:
                if ((top - 20) < step)
                    break;
                ball.style.top = top - step + "px";
                break;
                //  左
            case 65:
            case 37:
                if ((left - 20) < step)
                    break;
                ball.style.left = left - step + "px";
                break;
                //  下
            case 83:
            case 40:
                if (top <= (y_max - 20))
                    break;
                ball.style.top = top + step + "px";
                break;
                //  右
            case 68:
            case 39:
                if (left > (x_max - 20))
                    break;
                ball.style.left = left + step + "px";
                break;

        }
    }
}