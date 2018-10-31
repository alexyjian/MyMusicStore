window.onload = function() {
    var wrap = document.getElementById('wrap'),
        pic = document.getElementById('pic'),
        list = document.getElementById('list').getElementsByTagName('li'),
        index = 0,
        timer = null;
    // 定义并调用自动播放函数  
    if (timer) {
        clearInterval(timer);
        timer = null;
    }
    timer = setInterval(autoplay, 2000);
    // 定义图片切换函数  
    function autoplay() {
        index++;
        if (index >= list.length) {
            index = 0
        }
        changeoptions(index);
    }
    // 鼠标划过整个容器时停止自动播放  
    wrap.onmouseover = function() {
            clearInterval(timer);
        }
        // 鼠标离开整个容器时继续播放至下一张  
    wrap.onmouseout = function() {
            timer = setInterval(autoplay, 2000);
        }
        // 遍历所有数字导航实现划过切换至对应的图片  
    for (var i = 0; i < list.length; i++) {
        list[i].id = i;
        list[i].onmouseover = function() {
            clearInterval(timer);
            changeoptions(this.id);
        }
    }

    function changeoptions(curindex) {
        for (var j = 0; j < list.length; j++) {
            list[j].className = '';
            pic.style.top = 0;
        }
        list[curindex].className = 'active';
        pic.style.top = -curindex * 170 + 'px';
        index = curindex;
    }
}