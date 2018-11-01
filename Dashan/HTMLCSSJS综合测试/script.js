window.onload = function () {
    var container = document.getElementById('container');
    var list = document.getElementById('list');
    var buttons = document.getElementById('buttons').getElementsByTagName('span');
    var prev = document.getElementById('prev');
    var next = document.getElementById('next');
    var index =1; //显示第几个
    var changed = false; //切换状态值无切换
    var timer;

    function showButton() { 
        for (var i = 0; i < buttons.length; i++) {
            if (buttons[i].className == 'on') {
                buttons[i].className = '';
                break;
            }
        }
        buttons[index - 1].className = 'on';
    }

    function change(offset) { //切换函数
        changed = true;
        var newleft = parseInt(list.style.left) + offset;

        var time = 50; //位移总时间（ms）
        var interval = 10; //位移间隔时间
        var speed = offset / (time / interval); //每次的位移量   总偏移/次数

        function go() {
            if ((speed < 0 && parseInt(list.style.left) > newleft) || (speed > 0 && parseInt(list.style.left) <
                    newleft)) {
                list.style.left = parseInt(list.style.left) + speed + 'px';
                setTimeout(go, interval); //每隔interval执行一次go
            } else {
                changed = false;
                list.style.left = newleft + 'px';

                if (newleft > -480) { //归位
                    list.style.left = -2400 + 'px';
                }
                if (newleft < -2400) {
                    list.style.left = -480 + 'px';
                }
            }
        }
        go();
    }

    function play() { //自动切换函数
        timer = setInterval(function () {
            next.onclick();
        }, 2400);
    }

    function stop() { //自动切换停止函数
        clearInterval(timer);
    }

    next.onclick = function () { //右箭头点击事件
        if (index == 5) {
            index = 1;
        } else {
            index += 1;
        }
        showButton();
        if (!changed) {
            change(-480);
        }
    }

    prev.onclick = function () { //左箭头点击事件
        if (index == 1) {
            index = 5;
        } else {
            index -= 1;
        }
        showButton();
        if (!changed) {
            change(480);
        }
    }

    //添加点击事件
    for (var i = 0; i < buttons.length; i++) {
        buttons[i].onclick = function () {
            //判断如果点击对应以打开图片，退出函数
            if (this.classname == 'on') {
                return;
            }
            //获取自定义或动态属性
            var myindex = parseInt(this.getAttribute('index'));
            var offset = -480 * (myindex - index);

            index = myindex;
            showButton();
            if (!changed) {
                change(offset);
            }
        }
    }
    container.onmouseover = stop; //鼠标移动到容器内停止  移开自动切换
    container.onmouseout = play; //鼠标在容器外执行自动切换
    play();
}
