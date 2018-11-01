window.onload = function() {
    var container = document.getElementById('container');
    var list = document.getElementById('list');
    var buttons = document.getElementById('buttons').getElementsByTagName('span');
    var prev = document.getElementById('prev');
    var next = document.getElementById('next');
    var index = 1;
    var tim

    function animate(offset) {
        //获取的是style.left，是相对左边获取距离，所以第一张图后style.left都为负值，
        //且style.left获取的是字符串，需要用parseInt()取整转化为数字。
        var newLeft = parseInt(list.style.left) + offset;
        list.style.left = newLeft + 'px';
        //无限滚动判断

        if (newLeft > -500) {
            list.style.left = -2000 + 'px';

        }

        if (newLeft < -2000) {
            list.style.left = -500 + 'px';

        }

    }


    function play() {
        //重复执行的定时器
        timer = setInterval(function() {
            next.onclick();

        }, 2000)

    }


    function stop() {
        clearInterval(timer);

    }


    function buttonsShow() {
        //将之前的小方块的样式清除

        for (var i = 0; i < buttons.length; i++) {

            if (buttons[i].className == "on") {
                buttons[i].className = "";

            }

        }
        //数组从0开始，故index需要-1
        buttons[index - 1].className = "on";

    }

    prev.onclick = function() {
        index -= 1;

        if (index < 1) {
            index = 5

        }
        buttonsShow();
        animate(500);

    };

    next.onclick = function() {
        //由于上边定时器的作用，index会一直递增下去，我们只有5个小圆点，所以需要做出判断
        index += 1;

        if (index > 5) {
            index = 1

        }
        animate(-500);
        buttonsShow();

    };


    for (var i = 0; i < buttons.length; i++) {
        (function(i) {
            buttons[i].onmouseover = function() {
                var moveIndex = parseInt(this.getAttribute('index'));
                var offset = 500 * (index - moveIndex); //这个index是当前图片停留时的index
                animate(offset);
                index = moveIndex;
                buttonsShow();

            }

        })(i)

    }

    container.onmouseover = stop;
    container.onmouseout = play;
    play();


}