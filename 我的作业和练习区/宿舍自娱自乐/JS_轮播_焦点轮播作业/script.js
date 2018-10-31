//页面加载完成时
window.onload = function () {
    var ul = document.getElementById('head_ul');
    var ul2 = document.getElementById('head_ul2');
    var ol = document.getElementById('head_ol');
    //取所有子元素
    var ollis = ol.children;
    //用来控制left
    var leader = 0;
    var leader2 = 567;
    var target = 0;
    //计算自动轮播页数
    var intr = 0;
    var intrs = 0;
    var intrr = 0;
    //计时器
    var timer = null;
    //遍历ol
    for (var i = 0; i < ollis.length; i++) {
        // 每个li的索引号
        ollis[i].index = i;
        //鼠标悬停事件
        ollis[i].onmouseover = function () {
            //清除计时器
            clearInterval(timer);
            for (var j = 0; j < ollis.length; j++) {
                ollis[j].className = '';//去掉所有的class='current'
            }
            //自动轮播页数同步
            intr = this.index;
            this.className = 'current';
            target = -this.index * 576;//目标位置=当前index索引号*图片宽度
        }
        ollis[i].onmouseout = function () {
            //重启计时器
            timer = setInterval(autoPlay, 2500);
        }
    }
    timer = setInterval(autoPlay, 2500);


    //过度动画
    var st = 0;
    var sr = 0;
    setInterval(function () {

            leader = leader + (target - leader) / 100;
            ul.style.left = leader + 'px';
    }, 2);

    function autoPlay() {
        intr++;
        intrs++;
        //目标位置=当前index索引号*图片宽度    
        target = -intr * 576; 
        if (intr == ollis.length + 1) {
            sr++;
            
        }
        for (var j = 0; j < ollis.length; j++) {
            ollis[j].className = '';//去掉所有的class='current'
        }
        //当页数到达最大时重置
        if (intrs == ollis.length) {
            intrs = 0;
            st++;
        }
        ollis[intrs].className = 'current';





    }
}