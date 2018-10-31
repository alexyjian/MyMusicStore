window.onload = function () {
    var ul = document.getElementById('sv_ul');
    var ol = document.getElementById('sv_ol');

    var ollis = ol.children;

    var leader = 0;
    var target = 0;


    
    for (var i = 0; i < ollis.length; i++) {
        //li索引号
        ollis[i].index = i;
        ollis[i].onmouseover = function () {
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = ''; //去掉所有的class=‘current’
            }
            this.className = 'current'; //目标位置current = 当前index * 图片宽度
            target = -this.index * 500;
        }
    }

    
    //计时器 
    timer = setInterval(autoPlay, 10);

    function autoPlay() {
        target--;

        target <= -1500 ? target = 0 : target;
        leader = leader + (target - leader) / 10;

        ul.style.left = leader + "px";
    }
    //鼠标悬停事件
    scri.onmouseover = function () {
        clearInterval(timer);

    }
    scri.onmouseout = function () {
        timer = setInterval(autoPlay, 10);
    }
}